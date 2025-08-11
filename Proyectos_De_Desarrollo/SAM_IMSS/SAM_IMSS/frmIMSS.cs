using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace SAM_IMSS
{
    public partial class frmIMSS : Form
    {
        string pathlog;

        public frmIMSS()
        {
            InitializeComponent();
        }

        public static string GetFileName(string targetDirectory, string filename)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                if (fileName.Contains(filename.ToString()))
                {
                    return fileName;
                }
            }
            return "";
        }

        private void frmIMSS_Load(object sender, EventArgs e)
        {
            try
            {
                Recursos.appfecha = DateTime.Now.ToString("yyyyMMdd");
                Recursos.logfecha = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                pathlog = string.Concat(Directory.GetCurrentDirectory().ToString(), "\\Log\\Log", Recursos.appfecha.ToString(), ".txt");
                using (StreamWriter swlog = File.AppendText(pathlog.ToString()))
                {
                    swlog.WriteLine(string.Concat(Recursos.logfecha.ToString(), "--", "Se abre ventana para generar layout del IMSS"));
                }

                //obtener el ultimo archivo
                string dir_archivo = Recursos.strRutaAladdin.ToString().Trim();
                var directory = new DirectoryInfo(dir_archivo);
                var ultimo_archivo_positions = (from f in directory.GetFiles()
                                                where f.Name.Contains("positions-downloadReport")
                                                orderby f.LastWriteTime descending
                                                select f).First();

                var ultimo_archivo_trades = (from f in directory.GetFiles()
                                             where f.Name.Contains("trades-downloadReport")
                                             orderby f.LastWriteTime descending
                                             select f).First();

                txArchPosition.Text = string.Concat(Recursos.strRutaAladdin.ToString().Trim(), ultimo_archivo_positions.ToString().Trim());
                txArchTradesCustodio.Text = string.Concat(Recursos.strRutaAladdin.ToString().Trim(), ultimo_archivo_trades.ToString().Trim());
                txLayouts.Text = Recursos.strRutaLayouts.ToString();

                using (StreamWriter swlog = File.AppendText(pathlog.ToString()))
                {
                    swlog.WriteLine(string.Concat(Recursos.logfecha.ToString(), "--", "Se cargaron correctamente las rutas de los archivos de Aladdin"));
                }

            }
            catch
            {
                //txArchPosition.Text = ""; // string.Concat(GetFileName(Recursos.strRutaAladdin.ToString().Trim(), "positions-downloadReport")).Trim();
                //txArchTradesCustodio.Text = "";// string.Concat(GetFileName(Recursos.strRutaAladdin.ToString().Trim(), "trades-downloadReport")).Trim();
                //txLayouts.Text = Recursos.strRutaLayouts.ToString();

                //using (StreamWriter swlog = File.AppendText(pathlog.ToString()))
                //{
                //    swlog.WriteLine(string.Concat(Recursos.logfecha.ToString(), "--", "No se encontraron las rutas por default, se colocan las del archivo de configuración"));
                //}
            }


            try
            {
                string dir_archivo = Recursos.strRutaValmer.ToString().Trim();
                var directory = new DirectoryInfo(dir_archivo);

                var ultimo_archivo_valmer = (from f in directory.GetFiles()
                                             where f.Name.Contains(string.Concat("VectorAnaliticoMD", ".xls"))
                                             orderby f.LastWriteTime descending
                                             select f).First();

                dir_archivo = Recursos.strRutaPip.ToString().Trim();
                directory = new DirectoryInfo(dir_archivo);


                var ultimo_archivo_pip = (from f in directory.GetFiles()
                                          where f.Name.Contains(string.Concat("VectorAnalitico", Recursos.appfecha.ToString(), "MD.xls"))
                                          orderby f.LastWriteTime descending
                                          select f).First();


                txFile.Text = string.Concat(Recursos.strRutaValmer.ToString(), ultimo_archivo_valmer.ToString().Trim());

                txFilePiP.Text = string.Concat(Recursos.strRutaPip.ToString(), ultimo_archivo_pip.ToString().Trim());

                using (StreamWriter swlog = File.AppendText(pathlog.ToString()))
                {
                    swlog.WriteLine(string.Concat(Recursos.logfecha.ToString(), "--", "Se cargaron rutas de los vectores correctamente"));
                }
            }
            catch
            {
                string fechaarchivos = string.Concat(Recursos.appfecha.ToString().Substring(0, 4), "_", Recursos.appfecha.ToString().Substring(4, 2), "_", Recursos.appfecha.ToString().Substring(6, 2));
                txFile.Text = string.Concat(Recursos.strRutaValmer.ToString(), "VectorAnaliticoMD", ".xls").Trim();
                txFilePiP.Text = string.Concat(Recursos.strRutaPip.ToString(), "VectorAnalitico", Recursos.appfecha.ToString(), "MD.xls").Trim();

                using (StreamWriter swlog = File.AppendText(pathlog.ToString()))
                {
                    swlog.WriteLine(string.Concat(Recursos.logfecha.ToString(), "--", "No se encontraron las rutas por default para vectores, se colocan las del archivo de configuración"));
                }
            }
        }

        private int ValidarVectorValmerCSV()
        {
            string connectionString = string.Concat("Server=", Recursos.strServer, "; Database=", Recursos.strBD, "; User Id=", Recursos.strUsr, "; Password=", Recursos.strPassword, "; Connection Timeout=60;");
            SqlConnection con = new SqlConnection(connectionString);

            //Valido que el vector de valmer se el del día
            string strqry = @"select count(*) from VectorAnaliticoValmerCSV where datediff(dd, convert(datetime,Fecha, 103), getdate()) > 1";
            con.Open();
            SqlCommand cmd = new SqlCommand(strqry, con);
            cmd.CommandType = CommandType.Text;
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count == 0)
                return 0;
            else
                return 1;
        }

        private int ValidarVectorValmer()
        {
            string connectionString = string.Concat("Server=", Recursos.strServer, "; Database=", Recursos.strBD, "; User Id=", Recursos.strUsr, "; Password=", Recursos.strPassword, "; Connection Timeout=60;");
            SqlConnection con = new SqlConnection(connectionString);

            //Valido que el vector de valmer se el del día
            string strqry = @"select count(*) from VectorAnaliticoValmer where datediff(dd, convert(datetime,fecha, 103), convert(datetime,getdate(),103)) > 1";
            con.Open();
            SqlCommand cmd = new SqlCommand(strqry, con);
            cmd.CommandType = CommandType.Text;
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count == 0)
                return 0;
            else
                return 1;
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            Recursos.appfecha = DateTime.Now.ToString("yyyyMMdd");
            Recursos.logfecha = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            using (StreamWriter swlog = File.AppendText(pathlog.ToString()))
            {
                swlog.WriteLine(string.Concat(Recursos.logfecha.ToString(), "--", "Inicia proceso para cargar layouts y generar archivos del IMSS"));
            }

            if (txFile.Text.ToString() != "" && chMDValmer.Checked == true)
            {
                LimpiarTablaVector();
                if (chkXLS.Checked)
                {
                    SaveAsCsvVectorMD(txFile.Text.ToString(), txFile.Text.ToString().Replace(".xls", ".csv"));
                    BulkVectorValmer(txFile.Text.ToString().Replace(".xls", ".csv"));

                    int Valida = ValidarVectorValmer();

                    if (Valida == 1)
                    {
                        MessageBox.Show("El vector de valmer no es del día, continua proceso", "SAM - IMSS");
                        using (StreamWriter swlog = File.AppendText(pathlog.ToString()))
                        {
                            swlog.WriteLine(string.Concat(Recursos.logfecha.ToString(), "--", "El vector de valmer no es del día, continua proceso"));
                        }
                    }
                }

                if (chkCSV.Checked)
                {
                    BulkVectorValmerCSV(txFile.Text.ToString());
                }
                using (StreamWriter swlog = File.AppendText(pathlog.ToString()))
                {
                    swlog.WriteLine(string.Concat(Recursos.logfecha.ToString(), "--", "El vector de valmer se cargo de manera correcta -- ", txFile.Text.ToString()));
                }
                MessageBox.Show("Carga de vector de Valmer exitosa.", "SAM - IMSS");
            }

            if (txFilePiP.Text.ToString() != "" && chVectorPip.Checked == true)
            {
                LimpiarVectorPiP();
                SaveAsCsvVectorPiP(txFilePiP.Text.ToString(), txFilePiP.Text.ToString().Replace(".xls", ".csv"));
                BulkVectorPiP(txFilePiP.Text.ToString().Replace(".xls", ".csv"));

                MessageBox.Show("Carga de vector de PiP exitosa.", "SAM - IMSS");

                using (StreamWriter swlog = File.AppendText(pathlog.ToString()))
                {
                    swlog.WriteLine(string.Concat(Recursos.logfecha.ToString(), "--", "El vector de PIP se cargo de manera correcta -- ", txFilePiP.Text.ToString()));
                }
            }

            //Carga de archivos de Aladdin
            if (txArchPosition.Text.ToString() != "" && chArcPositions.Checked == true)
            {

                using (StreamWriter swlog = File.AppendText(pathlog.ToString()))
                {
                    swlog.WriteLine(string.Concat(Recursos.logfecha.ToString(), "--", "Inicia carga archivo Position -- ", txArchPosition.Text.ToString()));
                }

                LimpiarTablasAladdinPosition();
                LeerArchivoPositions(txArchPosition.Text.ToString());
            }

            if (txArchTradesCustodio.Text.ToString() != "" && chArchTrades.Checked == true)
            {

                using (StreamWriter swlog = File.AppendText(pathlog.ToString()))
                {
                    swlog.WriteLine(string.Concat(Recursos.logfecha.ToString(), "--", "Inicia carga archivo Trades Custodio -- ", txArchTradesCustodio.Text.ToString()));
                }

                //Valido que el archivo traiga todas los trades que liquidan en el dia en comparacion con lo que tenia programado un dia antes
                ValidarLiquidacionPositionsTrades(txArchTradesCustodio.Text.ToString());

                LimpiarTablasAladdinTrades();
                LeerArchivoTrades(txArchTradesCustodio.Text.ToString());
            }

            string tiempo = DateTime.Now.ToString("HHmmss");

            if ((chkPosicion.Checked == true) || (chkTrades.Checked == true) || (chkValuada.Checked == true))
            {
                int ban = ValidoInstrumentosenVector();
                if (ban == 1)
                {
                    MessageBox.Show("Hay intrumentos en la posición que no se encuentran en el vector de Pip, continua generación de archivos", "SAM - IMSS");
                }

                if (ban == 2)
                {
                    MessageBox.Show("Hay intrumentos en la posición que no se encuentran en el vector de Valmer, continua generación de archivos", "SAM - IMSS");
                }
            }

            //Genero los archivos
            if (chkPosicion.Checked == true)
            {
                if (chkXLS.Checked)
                {
                    ExpArcPosLayout(string.Concat(txLayouts.Text.ToString(), "MSANT", Recursos.appfecha, "layout.csv").Trim());
                }

                if (chkCSV.Checked)
                {
                    ExpArcPosLayoutCSV(string.Concat(txLayouts.Text.ToString(), "MSANT", Recursos.appfecha, "layout.csv").Trim());
                }

                using (StreamWriter swlog = File.AppendText(pathlog.ToString()))
                {
                    swlog.WriteLine(string.Concat(Recursos.logfecha.ToString(), "--", "Layout generado correctamente -- ", string.Concat(txLayouts.Text.ToString(), "MSANT", Recursos.appfecha, "layout.csv").Trim()));
                }
                MessageBox.Show("Layout exitoso.", "SAM - IMSS");
            }

            if (chkTrades.Checked == true)
            {
                if (chkXLS.Checked)
                {
                    ExpArcTrades(string.Concat(txLayouts.Text.ToString(), "MSANT", Recursos.appfecha, "_FV.csv").Trim());
                }

                if (chkCSV.Checked)
                {
                    ExpArcTradesCSV(string.Concat(txLayouts.Text.ToString(), "MSANT", Recursos.appfecha, "_FV.csv").Trim());
                }

                using (StreamWriter swlog = File.AppendText(pathlog.ToString()))
                {
                    swlog.WriteLine(string.Concat(Recursos.logfecha.ToString(), "--", "Layout FV generado correctamente -- ", string.Concat(string.Concat(txLayouts.Text.ToString(), "MSANT", Recursos.appfecha, "_FV.csv").Trim())));
                }
                MessageBox.Show("Trades exitoso.", "SAM - IMSS");
            }

            if (chkValuada.Checked == true)
            {
                if (chkXLS.Checked)
                {
                    ExpArcPosValuada(string.Concat(txLayouts.Text.ToString(), Recursos.appfecha, "excel_SAM.xlsx").Trim());
                }
                if (chkCSV.Checked)
                {
                    ExpArcPosValuadaCSV(string.Concat(txLayouts.Text.ToString(), Recursos.appfecha, "excel_SAM.xlsx").Trim());
                }


                using (StreamWriter swlog = File.AppendText(pathlog.ToString()))
                {
                    swlog.WriteLine(string.Concat(Recursos.logfecha.ToString(), "--", "Layout posición valuada excel generado correctamente -- ", string.Concat(txLayouts.Text.ToString(), Recursos.appfecha, "excel_SAM.xlsx").Trim()));
                }
                MessageBox.Show("Posición Valuada exitoso.", "SAM - IMSS");
            }

            if (chkBBVA.Checked == true)
            {
                ExpArcBBVA(string.Concat(txLayouts.Text.ToString(), "BBVA", Recursos.appfecha, "_", tiempo.ToString(), ".txt").Trim());

                using (StreamWriter swlog = File.AppendText(pathlog.ToString()))
                {
                    swlog.WriteLine(string.Concat(Recursos.logfecha.ToString(), "--", "Layout BBVA generado correctamente -- ", string.Concat(txLayouts.Text.ToString(), "BBVA", Recursos.appfecha, "_", tiempo.ToString(), ".txt").Trim()));
                }
                MessageBox.Show("Custodio BBVA exitoso.", "SAM - IMSS");
            }

            if (chkS3.Checked == true)
            {
                ExpArcS3(string.Concat(txLayouts.Text.ToString(), "S3", Recursos.appfecha, "_", tiempo.ToString(), ".txt").Trim());

                using (StreamWriter swlog = File.AppendText(pathlog.ToString()))
                {
                    swlog.WriteLine(string.Concat(Recursos.logfecha.ToString(), "--", "Layout S3 generado correctamente -- ", string.Concat(txLayouts.Text.ToString(), "S3", Recursos.appfecha, "_", tiempo.ToString(), ".txt").Trim()));
                }
                MessageBox.Show("Custodio S3 exitoso.", "SAM - IMSS");
            }
        }

        public void SaveAsCsvVectorMD(string excelFilePath, string destinationCsvFilePath)
        {
            Excel.Application exlApp = new Excel.Application();
            Excel.Workbook libroExcel;
            Excel.Worksheet hojaExcel;

            //exlApp.Visible = true;

            libroExcel = exlApp.Workbooks.Open(@excelFilePath);
            hojaExcel = (Excel.Worksheet)libroExcel.Worksheets[1]; //get_Item("Sheet1");

            Excel.Range miRango = hojaExcel.UsedRange;

            int rows = miRango.Rows.Count;
            int cols = miRango.Columns.Count;
            Excel.Range startCell = hojaExcel.Cells[1, 1];
            Excel.Range endCell = hojaExcel.Cells[rows, cols];

            hojaExcel.Range[startCell, endCell].Replace(@",", @"");

            hojaExcel.Columns["J"].Delete();
            hojaExcel.Rows[1].Delete();
            hojaExcel.Rows[1].Delete();

            hojaExcel.SaveAs(destinationCsvFilePath, Excel.XlFileFormat.xlCSV);

            exlApp.ActiveWorkbook.Close();

            if (exlApp != null) exlApp.Quit();
            if (hojaExcel != null) Marshal.ReleaseComObject(hojaExcel);
            if (libroExcel != null) Marshal.ReleaseComObject(libroExcel);
            if (exlApp != null) Marshal.ReleaseComObject(exlApp);
        }

        public void SaveAsCsvVectorPiP(string excelFilePath, string destinationCsvFilePath)
        {
            Excel.Application exlApp = new Excel.Application();
            Excel.Workbook libroExcel;
            Excel.Worksheet hojaExcel;

            //exlApp.Visible = true;

            libroExcel = exlApp.Workbooks.Open(@excelFilePath);
            hojaExcel = (Excel.Worksheet)libroExcel.Worksheets[1];

            //hojaExcel.Columns["E:BI"].Delete();
            //hojaExcel.Columns["A"].Delete();
            Excel.Range miRango = hojaExcel.UsedRange;

            int rows = miRango.Rows.Count;
            int cols = miRango.Columns.Count;
            Excel.Range startCell = hojaExcel.Cells[1, 1];
            Excel.Range endCell = hojaExcel.Cells[rows, cols];

            hojaExcel.Range[startCell, endCell].Replace(@",", @"");

            hojaExcel.Columns["J"].Delete();
            hojaExcel.Rows[1].Delete();
            hojaExcel.Rows[1].Delete();

            hojaExcel.SaveAs(destinationCsvFilePath, Excel.XlFileFormat.xlCSV);

            exlApp.ActiveWorkbook.Close();

            if (exlApp != null) exlApp.Quit();
            if (hojaExcel != null) Marshal.ReleaseComObject(hojaExcel);
            if (libroExcel != null) Marshal.ReleaseComObject(libroExcel);
            if (exlApp != null) Marshal.ReleaseComObject(exlApp);
        }

        public void LimpiarTablaVector()
        {

            //Limpio tabla de paso y tabla del vector
            //string strTruncate = @"Truncate table VectorAnaliticoValmer";


            string strTruncate = @"Truncate table VectorAnaliticoValmerCSV";

            SqlConnection con = new SqlConnection(string.Concat("Server=180.176.163.137; Database= SAM_IMSS; User Id=sa; Password = password; Connection Timeout=60;"));

            //SqlConnection con = new SqlConnection(string.Concat("Server=", Recursos.strServer, "; Database=", Recursos.strBD, ";  Persist Security Info=False;Integrated Security=true;"));
            con.Open();

            //Valido que la fecha del día sea igual a la del sistema
            SqlCommand cmd = new SqlCommand(strTruncate, con);
            cmd.CommandType = CommandType.Text;

            if (chkCSV.Checked)
            {
                cmd.ExecuteNonQuery();
            }

            con.Close();

            strTruncate = @"Truncate table VectorAnaliticoValmer";

            con = new SqlConnection(string.Concat("Server=180.176.163.137; Database= SAM_IMSS; User Id=sa; Password = password; Connection Timeout=60;"));

            //SqlConnection con = new SqlConnection(string.Concat("Server=", Recursos.strServer, "; Database=", Recursos.strBD, ";  Persist Security Info=False;Integrated Security=true;"));
            con.Open();

            //Valido que la fecha del día sea igual a la del sistema
            cmd = new SqlCommand(strTruncate, con);
            cmd.CommandType = CommandType.Text;

            if (chkXLS.Checked)
            {
                cmd.ExecuteNonQuery();
            }

            con.Close();

        }

        public void LimpiarVectorPiP()
        {

            string strTruncate = @"Truncate table VectorAnaliticoPiP";

            SqlConnection con = new SqlConnection(string.Concat("Server=180.176.163.137; Database= SAM_IMSS; User Id=sa; Password = password; Connection Timeout=60;"));

            //SqlConnection con = new SqlConnection(string.Concat("Server=", Recursos.strServer, "; Database=", Recursos.strBD, ";  Persist Security Info=False;Integrated Security=true;"));
            con.Open();

            //Valido que la fecha del día sea igual a la del sistema
            SqlCommand cmd = new SqlCommand(strTruncate, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            con.Close();
        }

        private int ValidoInstrumentosenVector()
        {

            int valor = 0;


            SqlConnection con = new SqlConnection(string.Concat("Server=180.176.163.137; Database= SAM_IMSS; User Id=sa; Password = password; Connection Timeout=60;"));

            //Valido que el vector de valmer se el del día
            string strqry = @"Select count(*) from IMSS_Positions where TipoValor not in (select[TIPO VALOR] + '_' + EMISORA + '_' + SERIE from VectorAnaliticoPiP)and TipoValor <> ''";
            con.Open();
            SqlCommand cmd = new SqlCommand(strqry, con);
            cmd.CommandType = CommandType.Text;
            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count == 0)
                valor = 0;
            else
                valor = 1;

            if (chkCSV.Checked)
            {
                strqry = "Select count(*) from IMSS_Positions where TipoValor not in (select TV + '_' + EMISORA + '_' + SERIE from VectorAnaliticoValmerCSV) and TipoValor <> ''";
            }
            if (chkXLS.Checked)
            {
                strqry = "Select count(*) from IMSS_Positions where TipoValor not in (select [TIPO VALOR] + '_' + EMISORA + '_' + SERIE from VectorAnaliticoValmer) and TipoValor <> ''";
            }
            cmd = new SqlCommand(strqry, con);
            cmd.CommandType = CommandType.Text;
            count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count == 0)
                valor = 0;
            else
                valor = 2;

            return valor;
        }

        private void BulkVectorValmerCSV(string rutaString)
        {

            using (StreamWriter fileWrite = new StreamWriter(@rutaString.ToString().Replace(".csv", "copia.csv")))
            {
                using (StreamReader fielRead = new StreamReader(@rutaString))
                {
                    string linea;

                    while ((linea = fielRead.ReadLine()) != null)
                    {
                        string[] datos = linea.Split(new char[] { ',' });

                        if (datos[0] != "TipoMercado")
                        {
                            fileWrite.WriteLine(linea);
                        }

                    }
                }
            }

            //aqui se renombra el archivo temporal
            File.Delete(@rutaString);
            File.Move(@rutaString.ToString().Replace(".csv", "copia.csv"), @rutaString);


            int i = 0;
            string connectionString = string.Concat("Server=", Recursos.strServer, "; Database=", Recursos.strBD, "; User Id=", Recursos.strUsr, "; Password=", Recursos.strPassword, "; Connection Timeout=60;");
            var dbConn = new SqlConnection(connectionString);
            var sr = new StreamReader(@rutaString);
            string line = sr.ReadLine();

            string[] strArray = line.Split(',');
            var dt = new DataTable();

            for (int index = 0; index < strArray.Length; index++)
                dt.Columns.Add(new DataColumn());

            do
            {
                DataRow row = dt.NewRow();

                string[] itemArray = line.Split(',');
                row.ItemArray = itemArray;
                dt.Rows.Add(row);
                i = i + 1;
                line = sr.ReadLine();
            } while (!string.IsNullOrEmpty(line));


            var bc = new SqlBulkCopy(dbConn, SqlBulkCopyOptions.TableLock, null)
            {
                DestinationTableName = "VectorAnaliticoValmerCSV",
                BatchSize = dt.Rows.Count
            };
            dbConn.Open();
            bc.WriteToServer(dt);
            dbConn.Close();
            bc.Close();


            sr.Close();
            File.Delete(@rutaString);

        }

        private void BulkVectorValmer(string rutaString)
        {

            int i = 0;
          
             string connectionString = (string.Concat("Server=180.176.163.137; Database= SAM_IMSS; User Id=sa; Password = password; Connection Timeout=60;"));
            var dbConn = new SqlConnection(connectionString);
            var sr = new StreamReader(@rutaString);
            string line = sr.ReadLine();

            string[] strArray = line.Split(',');
            var dt = new DataTable();
            var dt2 = new DataTable();
            var dt3 = new DataTable();
            var dt4 = new DataTable();
            var dt5 = new DataTable();
            var dt6 = new DataTable();

            for (int index = 0; index < strArray.Length; index++)
            {
                dt.Columns.Add(new DataColumn());
                dt2.Columns.Add(new DataColumn());
                dt3.Columns.Add(new DataColumn());
                dt4.Columns.Add(new DataColumn());
                dt5.Columns.Add(new DataColumn());
                dt6.Columns.Add(new DataColumn());
            }

            do
            {



                string[] itemArray = line.Split(',');
                if (i < 5000)
                {
                    DataRow row = dt.NewRow();
                    row.ItemArray = itemArray;
                    dt.Rows.Add(row);
                }

                if (i >= 5000 && i < 10000)
                {
                    DataRow row2 = dt2.NewRow();
                    row2.ItemArray = itemArray;
                    dt2.Rows.Add(row2);
                }

                if (i >= 10000 && i < 15000)
                {
                    DataRow row3 = dt3.NewRow();
                    row3.ItemArray = itemArray;
                    dt3.Rows.Add(row3);
                }

                if (i >= 15000 && i < 20000)
                {
                    DataRow row4 = dt4.NewRow();
                    row4.ItemArray = itemArray;
                    dt4.Rows.Add(row4);
                }

                if (i >= 20000 && i < 25000)
                {
                    DataRow row5 = dt5.NewRow();
                    row5.ItemArray = itemArray;
                    dt5.Rows.Add(row5);
                }


                if (i >= 25000)
                {
                    DataRow row6 = dt6.NewRow();
                    row6.ItemArray = itemArray;
                    dt6.Rows.Add(row6);
                }


                i = i + 1;
                line = sr.ReadLine();
            } while (!string.IsNullOrEmpty(line));


            var bc = new SqlBulkCopy(dbConn, SqlBulkCopyOptions.TableLock, null)
            {
                DestinationTableName = "VectorAnaliticoValmer",
                BatchSize = dt.Rows.Count
            };
            dbConn.Open();
            bc.WriteToServer(dt);
            dbConn.Close();
            bc.Close();

            //Segunda li
            var bc2 = new SqlBulkCopy(dbConn, SqlBulkCopyOptions.TableLock, null)
            {
                DestinationTableName = "VectorAnaliticoValmer",
                BatchSize = dt2.Rows.Count
            };
            dbConn.Open();
            bc2.WriteToServer(dt2);
            dbConn.Close();
            bc2.Close();

            //tercer li
            var bc3 = new SqlBulkCopy(dbConn, SqlBulkCopyOptions.TableLock, null)
            {
                DestinationTableName = "VectorAnaliticoValmer",
                BatchSize = dt3.Rows.Count
            };
            dbConn.Open();
            bc3.WriteToServer(dt3);
            dbConn.Close();
            bc3.Close();

            //cuarto li
            var bc4 = new SqlBulkCopy(dbConn, SqlBulkCopyOptions.TableLock, null)
            {
                DestinationTableName = "VectorAnaliticoValmer",
                BatchSize = dt4.Rows.Count
            };
            dbConn.Open();
            bc4.WriteToServer(dt4);
            dbConn.Close();
            bc4.Close();

            //cuarto li
            var bc5 = new SqlBulkCopy(dbConn, SqlBulkCopyOptions.TableLock, null)
            {
                DestinationTableName = "VectorAnaliticoValmer",
                BatchSize = dt5.Rows.Count
            };
            dbConn.Open();
            bc5.WriteToServer(dt5);
            dbConn.Close();
            bc5.Close();

            var bc6 = new SqlBulkCopy(dbConn, SqlBulkCopyOptions.TableLock, null)
            {
                DestinationTableName = "VectorAnaliticoValmer",
                BatchSize = dt6.Rows.Count
            };
            dbConn.Open();
            bc6.WriteToServer(dt6);
            dbConn.Close();
            bc6.Close();

            sr.Close();
            File.Delete(@rutaString);

        }

        public static void BulkVectorPiP(string strfile)
        {
            int i = 0;
            string connectionString = (string.Concat("Server=180.176.163.137; Database= SAM_IMSS; User Id=sa; Password = password; Connection Timeout=60;"));
            var dbConn = new SqlConnection(connectionString);
            var sr = new StreamReader(@strfile);
            string line = sr.ReadLine();

            string[] strArray = line.Split(',');
            var dt = new DataTable();
            var dt2 = new DataTable();
            var dt3 = new DataTable();
            var dt4 = new DataTable();
            var dt5 = new DataTable();
            var dt6 = new DataTable();

            for (int index = 0; index < strArray.Length; index++)
            {
                dt.Columns.Add(new DataColumn());
                dt2.Columns.Add(new DataColumn());
                dt3.Columns.Add(new DataColumn());
                dt4.Columns.Add(new DataColumn());
                dt5.Columns.Add(new DataColumn());
                dt6.Columns.Add(new DataColumn());
            }

            do
            {


                string[] itemArray = line.Split(',');
                if (i < 5000)
                {
                    DataRow row = dt.NewRow();
                    row.ItemArray = itemArray;
                    dt.Rows.Add(row);
                }

                if (i >= 5000 && i < 10000)
                {
                    DataRow row2 = dt2.NewRow();
                    row2.ItemArray = itemArray;
                    dt2.Rows.Add(row2);
                }

                if (i >= 10000 && i < 15000)
                {
                    DataRow row3 = dt3.NewRow();
                    row3.ItemArray = itemArray;
                    dt3.Rows.Add(row3);
                }

                if (i >= 15000 && i < 20000)
                {
                    DataRow row4 = dt4.NewRow();
                    row4.ItemArray = itemArray;
                    dt4.Rows.Add(row4);
                }


                if (i >= 20000 && i < 25000)
                {
                    DataRow row5 = dt5.NewRow();
                    row5.ItemArray = itemArray;
                    dt5.Rows.Add(row5);
                }

                if (i >= 25000)
                {
                    DataRow row6 = dt6.NewRow();
                    row6.ItemArray = itemArray;
                    dt6.Rows.Add(row6);
                }

                i = i + 1;
                line = sr.ReadLine();
            } while (!string.IsNullOrEmpty(line));



            var bc = new SqlBulkCopy(dbConn, SqlBulkCopyOptions.TableLock, null)
            {
                DestinationTableName = "VectorAnaliticoPiP",
                BatchSize = dt.Rows.Count
            };
            dbConn.Open();
            bc.WriteToServer(dt);
            dbConn.Close();
            bc.Close();

            //Segunda li
            var bc2 = new SqlBulkCopy(dbConn, SqlBulkCopyOptions.TableLock, null)
            {
                DestinationTableName = "VectorAnaliticoPiP",
                BatchSize = dt2.Rows.Count
            };
            dbConn.Open();
            bc2.WriteToServer(dt2);
            dbConn.Close();
            bc2.Close();

            //tercer li
            var bc3 = new SqlBulkCopy(dbConn, SqlBulkCopyOptions.TableLock, null)
            {
                DestinationTableName = "VectorAnaliticoPiP",
                BatchSize = dt3.Rows.Count
            };
            dbConn.Open();
            bc3.WriteToServer(dt3);
            dbConn.Close();
            bc3.Close();

            //cuarto li
            var bc4 = new SqlBulkCopy(dbConn, SqlBulkCopyOptions.TableLock, null)
            {
                DestinationTableName = "VectorAnaliticoPiP",
                BatchSize = dt4.Rows.Count
            };
            dbConn.Open();
            bc4.WriteToServer(dt4);
            dbConn.Close();
            bc4.Close();

            var bc5 = new SqlBulkCopy(dbConn, SqlBulkCopyOptions.TableLock, null)
            {
                DestinationTableName = "VectorAnaliticoPiP",
                BatchSize = dt5.Rows.Count
            };
            dbConn.Open();
            bc5.WriteToServer(dt5);
            dbConn.Close();
            bc5.Close();


            var bc6 = new SqlBulkCopy(dbConn, SqlBulkCopyOptions.TableLock, null)
            {
                DestinationTableName = "VectorAnaliticoPiP",
                BatchSize = dt6.Rows.Count
            };
            dbConn.Open();
            bc6.WriteToServer(dt6);
            dbConn.Close();
            bc6.Close();

            //Ya que cargue el archivo lo elimino
            sr.Close();
            File.Delete(@strfile);

        }

        public static void LimpiarTablasAladdinPosition()
        {

            //Limpio tabla de paso y tabla del vector
            string strTruncate = @"Truncate table IMSS_Positions";

      

            SqlConnection con = new SqlConnection(string.Concat("Server=180.176.163.137; Database= SAM_IMSS; User Id=sa; Password = password; Connection Timeout=60;"));

            //SqlConnection con = new SqlConnection(string.Concat("Server=", Recursos.strServer, "; Database=", Recursos.strBD, ";  Persist Security Info=False;Integrated Security=true;"));
            con.Open();

            //Valido que la fecha del día sea igual a la del sistema
            SqlCommand cmd = new SqlCommand(strTruncate, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            con.Close();


            strTruncate = @"Truncate table IMSS_trades";
            con.Open();

            cmd = new SqlCommand(strTruncate, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public static void LimpiarTablasAladdinTrades()
        {

            string strTruncate = @"Truncate table IMSS_CustodioTrades";

            
            SqlConnection con = new SqlConnection(string.Concat("Server=180.176.163.137; Database= SAM_IMSS; User Id=sa; Password = password; Connection Timeout=60;"));
            con.Open();

            SqlCommand cmd = new SqlCommand(strTruncate, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            con.Close();


        }

        void LeerArchivoPositions(string ruta)
        {

            Excel.Application exlApp = new Excel.Application();
            Excel.Workbook libroExcel;
            Excel.Worksheet hojaExcel;
            Excel.Range miRango;
            try
            {
                libroExcel = exlApp.Workbooks.Open(@ruta);

                SqlConnection con = new SqlConnection(string.Concat("Server=180.176.163.137; Database= SAM_IMSS; User Id=sa; Password = password; Connection Timeout=60;"));
                con.Open();

                //Abro la hoja de posiciones
                hojaExcel = (Excel.Worksheet)libroExcel.Worksheets[1]; //.get_Item("Positions");
                for (int fila = 13; fila < 10000; fila++)
                {

                    miRango = hojaExcel.UsedRange;

                    string Buy_Sell = Convert.ToString(miRango.Cells[fila, 1].Value);
                    string Portfolio = Convert.ToString(miRango.Cells[fila, 2].Value);
                    string InvNum = Convert.ToString(miRango.Cells[fila, 3].Value);
                    string TipoValor = Convert.ToString(miRango.Cells[fila, 4].Value);
                    string Td_Num = Convert.ToString(miRango.Cells[fila, 5].Value);
                    string TradeDate = Convert.ToString(miRango.Cells[fila, 6].Value);
                    string CollateralQuantity = Convert.ToString(miRango.Cells[fila, 7].Value);

                    string Orig_Face = Convert.ToString(miRango.Cells[fila, 8].Value);
                    string PurchasePrice = Convert.ToString(miRango.Cells[fila, 9].Value);
                    string Coupon = Convert.ToString(miRango.Cells[fila, 10].Value);

                    string Settle_Date = Convert.ToString(miRango.Cells[fila, 11].Value);
                    string Maturity = Convert.ToString(miRango.Cells[fila, 12].Value);
                    string Currency = Convert.ToString(miRango.Cells[fila, 13].Value);
                    string Collateral_Price = Convert.ToString(miRango.Cells[fila, 14].Value);
                    string Collateral_ISIN = Convert.ToString(miRango.Cells[fila, 15].Value);

                    string ISIN = Convert.ToString(miRango.Cells[fila, 16].Value);
                    string Settled = Convert.ToString(miRango.Cells[fila, 17].Value);

                    string CUSIP = Convert.ToString(miRango.Cells[fila, 18].Value);


                    if (Buy_Sell == "" || Buy_Sell == null)
                    {
                        //Finalizo el ciclo ya que ya no hay valores
                        break;
                    }

                    string strValues = string.Concat("'", Buy_Sell, "','",
                    Portfolio, "','", InvNum, "','", TipoValor, "','", Td_Num, "','", TradeDate, "','",
                    CollateralQuantity, "','", Orig_Face, "','", PurchasePrice, "','", Coupon, "','",
                    Settle_Date, "','", Maturity, "','", Currency, "','", Collateral_Price, "','", Collateral_ISIN, "','", CUSIP, "','", ISIN, "','", Settled, "'");

                    string strInsert = @"Insert Into IMSS_Positions (Buy_Sell,Portfolio,InvNum,TipoValor,Td_Num,TradeDate,
                    CollateralQuantity,Orig_Face,PurchasePrice,Coupon,
                    Settle_Date,Maturity,Currency,Collateral_Price,Collateral_ISIN,CUSIP,ISIN,Settled) values (" + strValues.ToString() + ") ";

                    //Valido que la fecha del día sea igual a la del sistema
                    SqlCommand cmd = new SqlCommand(strInsert, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }


                //Abro la hoja de las operaciones
                hojaExcel = (Excel.Worksheet)libroExcel.Worksheets[2]; //.get_Item("Trades");
                for (int fila = 14; fila < 10000; fila++)
                {

                    miRango = hojaExcel.UsedRange;

                    string Fund = Convert.ToString(miRango.Cells[fila, 1].Value);
                    string InvNum = Convert.ToString(miRango.Cells[fila, 2].Value);
                    string TipoValor = Convert.ToString(miRango.Cells[fila, 3].Value);
                    string Td_Num = Convert.ToString(miRango.Cells[fila, 4].Value);
                    string CounterParty = Convert.ToString(miRango.Cells[fila, 5].Value);
                    string Buy_Sell = Convert.ToString(miRango.Cells[fila, 6].Value);
                    string TranType = Convert.ToString(miRango.Cells[fila, 7].Value);
                    string TradeFace = Convert.ToString(miRango.Cells[fila, 8].Value);
                    string OrigFace = Convert.ToString(miRango.Cells[fila, 9].Value);
                    string TradePrice = Convert.ToString(miRango.Cells[fila, 10].Value);
                    string TradeDate = Convert.ToString(miRango.Cells[fila, 11].Value);
                    string SettleDate = Convert.ToString(miRango.Cells[fila, 12].Value);
                    string Principal = Convert.ToString(miRango.Cells[fila, 13].Value);
                    string NetMoney = Convert.ToString(miRango.Cells[fila, 14].Value);
                    string Collateral_ISIN = Convert.ToString(miRango.Cells[fila, 15].Value);
                    string Collateral_Quantity = Convert.ToString(miRango.Cells[fila, 16].Value);
                    string Cupon = Convert.ToString(miRango.Cells[fila, 17].Value);
                    string Maturity = Convert.ToString(miRango.Cells[fila, 18].Value);
                    string IssueDate = Convert.ToString(miRango.Cells[fila, 19].Value);

                    if (string.IsNullOrEmpty(Td_Num))
                    {
                        //Finalizo el ciclo ya que ya no hay valores
                        break;
                    }
                    else
                    {
                        if (Td_Num.Contains(")"))
                        {
                            //Finalizo el ciclo ya que ya no hay valores
                            break;
                        }
                    }

                    string strValues = string.Concat("'", Fund, "','", InvNum, "','", TipoValor, "','", Td_Num, "','", CounterParty, "','", Buy_Sell, "','", TranType, "','",
                    TradeFace, "','", OrigFace, "','", TradePrice, "','", TradeDate, "','", SettleDate, "','", Principal, "','", NetMoney, "','", Collateral_ISIN, "','",
                    Collateral_Quantity, "','", Cupon, "','", Maturity, "','", IssueDate, "'");

                    string strInsert = @"Insert Into IMSS_Trades (Fund,InvNum,TipoValor,Td_Num,CounterParty,Buy_Sell,TranType,
                    TradeFace,OrigFace,TradePrice,TradeDate,SettleDate,Principal,NetMoney,Collateral_ISIN,Collateral_Quantity,Cupon,
                    Maturity, IssueDate) values (" + strValues.ToString() + ") ";

                    //Valido que la fecha del día sea igual a la del sistema
                    SqlCommand cmd = new SqlCommand(strInsert, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                }
                con.Close();

                libroExcel.Close(false);
                exlApp.Quit();
            }
            catch (Exception e)
            {
                using (StreamWriter swlog = File.AppendText(pathlog.ToString()))
                {
                    swlog.WriteLine(string.Concat(Recursos.logfecha.ToString(), "--", "Error al cargar archivo Position -- ", e.Message.ToString()));
                }
                MessageBox.Show("Error " + e.Message.ToString());
            }
            finally
            {
                using (StreamWriter swlog = File.AppendText(pathlog.ToString()))
                {
                    swlog.WriteLine(string.Concat(Recursos.logfecha.ToString(), "--", "Carga archivo Position correcta -- ", txArchPosition.Text.ToString()));
                }
                MessageBox.Show("Carga de Positions correcta ", "SAM - IMSS");
            }
        }

        void LeerArchivoTrades(string ruta)
        {

            Excel.Application exlApp = new Excel.Application();
            Excel.Workbook libroExcel;
            Excel.Worksheet hojaExcel;
            Excel.Range miRango;
            try
            {
                libroExcel = exlApp.Workbooks.Open(@ruta);

                SqlConnection con = new SqlConnection(string.Concat("Server=180.176.163.137; Database= SAM_IMSS; User Id=sa; Password = password; Connection Timeout=60;"));
                con.Open();

                //Abro la hoja de posiciones
                hojaExcel = (Excel.Worksheet)libroExcel.Worksheets[1]; //.get_Item("Positions");

                int ultimaFilaConDatos = hojaExcel.get_Range("A" + hojaExcel.Rows.Count).get_End(Excel.XlDirection.xlUp).Row;

                for (int fila = 13; fila <= ultimaFilaConDatos; fila++)
                {
                    miRango = hojaExcel.UsedRange;

                    if (Convert.ToString(miRango.Cells[fila, 1].Value).Contains("InvNum"))
                    {
                        fila++;
                    }

                    string InvNum = Convert.ToString(miRango.Cells[fila, 1].Value);
                    string Td_Num = Convert.ToString(miRango.Cells[fila, 2].Value);
                    string Fund = Convert.ToString(miRango.Cells[fila, 3].Value);
                    string Tran_Type = Convert.ToString(miRango.Cells[fila, 4].Value);
                    string Trader = Convert.ToString(miRango.Cells[fila, 5].Value);
                    string Tipo_Valor = Convert.ToString(miRango.Cells[fila, 6].Value);
                    string Trade_Date = Convert.ToString(miRango.Cells[fila, 7].Value);
                    string Settle_Date = Convert.ToString(miRango.Cells[fila, 8].Value);
                    string Counterparty = Convert.ToString(miRango.Cells[fila, 9].Value);
                    string Counterparty_Desk = Convert.ToString(miRango.Cells[fila, 10].Value);
                    string Currency = Convert.ToString(miRango.Cells[fila, 11].Value);
                    string Orig_Face = Convert.ToString(miRango.Cells[fila, 12].Value);
                    string Trade_Price = Convert.ToString(miRango.Cells[fila, 13].Value);
                    string Effective_Rate = Convert.ToString(miRango.Cells[fila, 14].Value);
                    string Principal = Convert.ToString(miRango.Cells[fila, 15].Value);
                    string Commission = Convert.ToString(miRango.Cells[fila, 16].Value);
                    string Ex_Commission = Convert.ToString(miRango.Cells[fila, 17].Value);
                    string Net_Money = Convert.ToString(miRango.Cells[fila, 18].Value);
                    string CUSIP = Convert.ToString(miRango.Cells[fila, 19].Value);
                    string ISIN = Convert.ToString(miRango.Cells[fila, 20].Value);



                    if (InvNum.ToString().Contains("("))
                    {
                        //Finalizo el ciclo ya que ya no hay valores
                        break;
                    }

                    //Valido si el INVNUM ya existe
                    string strValues = string.Concat("'", InvNum, "','",
                    Td_Num, "','", Fund, "','", Tran_Type, "','", Trader, "','", Tipo_Valor, "','",
                    Trade_Date, "','", Settle_Date, "','", Counterparty, "','", Counterparty_Desk, "','",
                    Currency, "','", Orig_Face, "','", Trade_Price, "','", Effective_Rate, "','", Principal, "','",
                    Commission, "','", Ex_Commission, "','", Net_Money, "','", CUSIP, "','", ISIN, "'");

                    string strInsert = @"IF NOT EXISTS (SELECT * FROM IMSS_CustodioTrades WHERE InvNum = '" + InvNum + "')" +
                    @"BEGIN

                    Insert Into IMSS_CustodioTrades (InvNum, Td_Num, Fund, Tran_Type,
                    Trader,Tipo_Valor,Trade_Date,Settle_Date,Counterparty,Counterparty_Desk,Currency,Orig_Face,
                    Trade_Price,Effective_Rate,Principal,Commission,Ex_Commission,Net_Money,CUSIP,ISIN) values (" + strValues.ToString() + ")" +

                    @" End";

                    //Valido que la fecha del día sea igual a la del sistema
                    SqlCommand cmd = new SqlCommand(strInsert, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

                con.Close();

                libroExcel.Close();
                exlApp.Quit();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error" + e.Message);
            }
            finally
            {
                MessageBox.Show("Carga de Trades correcta ", "SAM - IMSS");
            }
        }

        void ValidarLiquidacionPositionsTrades(string ruta)
        {
            Excel.Application exlApp = new Excel.Application();
            Excel.Workbook libroExcel;
            Excel.Worksheet hojaExcel;
            Excel.Range miRango;
            try
            {
                libroExcel = exlApp.Workbooks.Open(@ruta);

                SqlConnection con = new SqlConnection(string.Concat("Server=180.176.163.137; Database= SAM_IMSS; User Id=sa; Password = password; Connection Timeout=60;"));
                con.Open();

                //Borro la tabla temporal
                string strTruncate = @"Truncate table IMSS_TMPTrades";
                //Valido que la fecha del día sea igual a la del sistema
                SqlCommand cmd = new SqlCommand(strTruncate, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                //Abro la hoja de las operaciones
                hojaExcel = (Excel.Worksheet)libroExcel.Worksheets[1]; //.get_Item("Trades");
                for (int fila = 14; fila < 10000; fila++)
                {
                    miRango = hojaExcel.UsedRange;

                    string Fund = Convert.ToString(miRango.Cells[fila, 1].Value);
                    string InvNum = Convert.ToString(miRango.Cells[fila, 2].Value);
                    string TipoValor = Convert.ToString(miRango.Cells[fila, 3].Value);
                    string Td_Num = Convert.ToString(miRango.Cells[fila, 4].Value);
                    string CounterParty = Convert.ToString(miRango.Cells[fila, 5].Value);
                    string Buy_Sell = Convert.ToString(miRango.Cells[fila, 6].Value);
                    string TranType = Convert.ToString(miRango.Cells[fila, 7].Value);
                    string TradeFace = Convert.ToString(miRango.Cells[fila, 8].Value);
                    string OrigFace = Convert.ToString(miRango.Cells[fila, 9].Value);
                    string TradePrice = Convert.ToString(miRango.Cells[fila, 10].Value);
                    string TradeDate = Convert.ToString(miRango.Cells[fila, 11].Value);
                    string SettleDate = Convert.ToString(miRango.Cells[fila, 12].Value);
                    string Principal = Convert.ToString(miRango.Cells[fila, 13].Value);
                    string NetMoney = Convert.ToString(miRango.Cells[fila, 14].Value);
                    string Collateral_ISIN = Convert.ToString(miRango.Cells[fila, 15].Value);
                    string Collateral_Quantity = Convert.ToString(miRango.Cells[fila, 16].Value);
                    string Cupon = Convert.ToString(miRango.Cells[fila, 17].Value);
                    string Maturity = Convert.ToString(miRango.Cells[fila, 18].Value);
                    string IssueDate = Convert.ToString(miRango.Cells[fila, 19].Value);

                    if (Td_Num.Contains(")"))
                    {
                        //Finalizo el ciclo ya que ya no hay valores
                        break;
                    }

                    string strValues = string.Concat("'", Fund, "','", InvNum, "','", TipoValor, "','", Td_Num, "','", CounterParty, "','", Buy_Sell, "','", TranType, "','",
                    TradeFace, "','", OrigFace, "','", TradePrice, "','", TradeDate, "','", SettleDate, "','", Principal, "','", NetMoney, "','", Collateral_ISIN, "','",
                    Collateral_Quantity, "','", Cupon, "','", Maturity, "','", IssueDate, "'");

                    string strInsert = @"Insert Into IMSS_TMPTrades (Fund,InvNum,TipoValor,Td_Num,CounterParty,Buy_Sell,TranType,
                    TradeFace,OrigFace,TradePrice,TradeDate,SettleDate,Principal,NetMoney,Collateral_ISIN,Collateral_Quantity,Cupon,
                    Maturity, IssueDate) values (" + strValues.ToString() + ") ";

                    //Valido que la fecha del día sea igual a la del sistema
                    cmd = new SqlCommand(strInsert, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

                //Valido que las operaciones que liquidan el dia de hoy que se capturaron antes sigan apareciendo
                string qryvalida = @"Select count(*) from [IMSS_TMPTrades]
                where datediff(dd, getdate(), convert(datetime, substring(SettleDate, 1, 10), 103)) = 0
                and TipoValor not in (select TipoValor from[IMSS_Trades]
                where datediff(dd, getdate(), convert(datetime, substring(SettleDate, 1, 10), 103)) = 0) ";

                SqlCommand cmdvalida = new SqlCommand(qryvalida, con);
                cmdvalida.CommandType = CommandType.Text;
                SqlDataReader rdvalida = cmdvalida.ExecuteReader();

                while (rdvalida.Read())
                {
                    if (rdvalida[0].ToString().Trim() != "0")
                    {
                        using (StreamWriter swlog = File.AppendText(pathlog.ToString()))
                        {
                            swlog.WriteLine(string.Concat(Recursos.logfecha.ToString(), "--", "El archivo del día no contiene todas las operaciones por liquidar en comparación al archivo del día habil anterior -- ", txArchPosition.Text.ToString()));
                        }
                        MessageBox.Show("El archivo del día no contiene todas las operaciones por liquidar en comparación al archivo del día habil anterior");
                        break;
                    }
                }
                rdvalida.Close();

                con.Close();

                libroExcel.Close(false);
                exlApp.Quit();
            }
            catch (Exception e)
            {
                using (StreamWriter swlog = File.AppendText(pathlog.ToString()))
                {
                    swlog.WriteLine(string.Concat(Recursos.logfecha.ToString(), "--", "El archivo de Trades aun no trae la segunda pestaña -- ", e.Message));
                }

            }
            finally
            {
                using (StreamWriter swlog = File.AppendText(pathlog.ToString()))
                {
                    swlog.WriteLine(string.Concat(Recursos.logfecha.ToString(), "--", "Carga archivo Trades Custodio correcta"));
                }
                MessageBox.Show("Validación de Positions correcta ", "SAM - IMSS");
            }
        }

        public void ExpArcTrades(string rutaArchivo)
        {
            string Comillas = "\"";

            string detalle = "";
            SqlConnection con = new SqlConnection(string.Concat("Server=180.176.163.137; Database= SAM_IMSS; User Id=sa; Password = password; Connection Timeout=60;"));
            
            con.Open();

            using (StreamWriter sw = File.CreateText(rutaArchivo.ToString()))
            { }

            detalle = string.Concat("exec IMSS_ArcTrades '", Recursos.appfecha.ToString(), "'");
            SqlCommand cmd = new SqlCommand(detalle, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                using (StreamWriter sw = File.AppendText(rutaArchivo.ToString()))
                {
                    string linea = string.Concat(rdr["Mandatario"].ToString(), ",",
                        rdr["FechaArchivo"].ToString(), ",",
                        rdr["FechaOperacion"].ToString(), ",",
                        rdr["Portafolio"].ToString(), ",",
                        rdr["ClaseActivo"].ToString(), ",",
                        rdr["TipoValor"].ToString(), ",",
                        rdr["Emisora"].ToString(), ",",
                        rdr["Serie"].ToString(), ",",
                        rdr["PrecioSucio"].ToString(), ",",
                        rdr["Titulos"].ToString(), ",",
                        rdr["FechaLiquidacion"].ToString(), ",",
                        rdr["Intermediario"].ToString(), ",",
                        rdr["MontoLiquidado"].ToString(), ",",
                        rdr["NumeroMandato"].ToString(), ",",
                        rdr["ClaveFechaLiquidacion"].ToString(), ",",
                        rdr["ClaveOperacion"].ToString(), ",",
                        rdr["PrecioPactado"].ToString());

                    sw.WriteLine(linea);
                }
            }
            rdr.Close();


            con.Close();

        }

        public void ExpArcTradesCSV(string rutaArchivo)
        {
            string Comillas = "\"";

            string detalle = "";
            string connectionString =(string.Concat("Server=180.176.163.137; Database= SAM_IMSS; User Id=sa; Password = password; Connection Timeout=60;"));
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            using (StreamWriter sw = File.CreateText(rutaArchivo.ToString()))
            { }

            detalle = string.Concat("exec IMSS_ArcTrades_csv '", Recursos.appfecha.ToString(), "'");
            SqlCommand cmd = new SqlCommand(detalle, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                using (StreamWriter sw = File.AppendText(rutaArchivo.ToString()))
                {
                    string linea = string.Concat(rdr["Mandatario"].ToString(), ",",
                        rdr["FechaArchivo"].ToString(), ",",
                        rdr["FechaOperacion"].ToString(), ",",
                        rdr["Portafolio"].ToString(), ",",
                        rdr["ClaseActivo"].ToString(), ",",
                        rdr["TipoValor"].ToString(), ",",
                        rdr["Emisora"].ToString(), ",",
                        rdr["Serie"].ToString(), ",",
                        rdr["PrecioSucio"].ToString(), ",",
                        rdr["Titulos"].ToString(), ",",
                        rdr["FechaLiquidacion"].ToString(), ",",
                        rdr["Intermediario"].ToString(), ",",
                        rdr["MontoLiquidado"].ToString(), ",",
                        rdr["NumeroMandato"].ToString(), ",",
                        rdr["ClaveFechaLiquidacion"].ToString(), ",",
                        rdr["ClaveOperacion"].ToString(), ",",
                        rdr["PrecioPactado"].ToString());

                    sw.WriteLine(linea);
                }
            }
            rdr.Close();


            con.Close();

        }

        public void ExpArcPosLayout(string rutaArchivo)
        {
            string encabezado = "";
            string detalle = "";
            string connectionString = (string.Concat("Server=180.176.163.137; Database= SAM_IMSS; User Id=sa; Password = password; Connection Timeout=60;"));
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            detalle = string.Concat("exec IMSS_ArcPosLayout '", Recursos.appfecha.ToString(), "'");
            SqlCommand cmd = new SqlCommand(detalle, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();


            encabezado = "Select DISTINCT 'H'as [H], 'MSANT' as [Mandato], FechaPosicion as [Fecha], 'MSANT' as [Mandatario], count(*) as [Registros]  from  IMSS_RepPosLayoutHist where datediff(DD,FechaReporte, getdate()) = 0  GROUP BY FechaPosicion";
            cmd = new SqlCommand(encabezado, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                using (StreamWriter sw = File.CreateText(rutaArchivo.ToString()))
                {
                    string linea = string.Concat(rdr["H"].ToString(), ",", rdr["Mandato"].ToString(), ",", rdr["Fecha"].ToString(), ",", rdr["Mandatario"].ToString(), ",", rdr["Registros"].ToString());
                    sw.WriteLine(linea);
                }
            }
            rdr.Close();

            detalle = string.Concat("exec IMSS_ArcPosLayout '", Recursos.appfecha.ToString(), "'");
            cmd = new SqlCommand(detalle, con);
            cmd.CommandType = CommandType.Text;
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                using (StreamWriter sw = File.AppendText(rutaArchivo.ToString()))
                {
                    string linea = string.Concat(rdr["ClaveOperacion"].ToString(), ",",
                        rdr["ClaveMandato"].ToString(), ",",
                        rdr["FechaPosicion"].ToString(), ",",
                        rdr["Portafolio"].ToString(), ",",
                        rdr["SubPortafolio"].ToString(), ",",
                        rdr["ClaseActivo"].ToString(), ",",
                        rdr["TipoValor"].ToString(), ",",
                        rdr["Emisora"].ToString(), ",",
                        rdr["Serie"].ToString(), ",",
                        rdr["SumaTitulosAcciones"].ToString(), ",",
                        rdr["DiasCupon"].ToString(), ",",
                        rdr["TasaCupon"].ToString(), ",",
                        rdr["DxVCupon"].ToString(), ",",
                        rdr["FechaInicialCupon"].ToString(), ",",
                        rdr["FechaFinalCupon"].ToString(), ",",
                        rdr["FechaEmisionInstrumento"].ToString(), ",",
                        rdr["FechaVencimientoOperacion"].ToString(), ",",
                        rdr["DiasPorVencerInstrumento"].ToString(), ",",
                        rdr["YTM"].ToString(), ",",
                        rdr["TasaPactada"].ToString(), ",",
                        rdr["Moneda"].ToString(), ",",
                        rdr["Subyacente"].ToString(), ",",
                        rdr["SumaMontoInvertido_1"].ToString(), ",",
                        rdr["TipoCambio"].ToString(), ",",
                        rdr["Sector"].ToString(), ",",
                        rdr["S&P"].ToString(), ",",
                        rdr["Fitch"].ToString(), ",",
                        rdr["Moody's"].ToString(), ",",
                        rdr["HRR"].ToString(), ",",
                        rdr["Intermediario"].ToString(), ",",
                        rdr["DescripcionIntermediario"].ToString(), ",",
                        rdr["ClasificadorIntermediario"].ToString(), ",",
                        rdr["TipoOperacion"].ToString(), ",",
                        rdr["Operacion"].ToString(), ",",
                        rdr["Emisor"].ToString(), ",",
                        rdr["OrigenEmisor"].ToString(), ",",
                        rdr["Sobretasa"].ToString(), ",",
                        rdr["VolatilidadImplicita"].ToString(), ",",
                        rdr["StatusIntrumento"].ToString(), ",",
                        rdr["IdentificadorIMSS"].ToString(), ",",
                        rdr["Mandatario"].ToString(), ",",
                        rdr["MontoEmitido"].ToString().Trim(), ",",
                        rdr["TitulosCirculacion"].ToString(), ",",
                        rdr["TitulosEmitidos"].ToString(), ",",
                        rdr["ValorNominal"].ToString(), ",",
                        rdr["SumaMontoInvertido_2"].ToString());

                    sw.WriteLine(linea);
                }
            }
            rdr.Close();


            con.Close();
        }

        public void ExpArcPosLayoutCSV(string rutaArchivo)
        {
            string encabezado = "";
            string detalle = "";
            string connectionString = (string.Concat("Server=180.176.163.137; Database= SAM_IMSS; User Id=sa; Password = password; Connection Timeout=60;"));
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            detalle = string.Concat("exec IMSS_ArcPosLayout_csv '", Recursos.appfecha.ToString(), "'");
            SqlCommand cmd = new SqlCommand(detalle, con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();


            encabezado = "Select DISTINCT 'H'as [H], 'MSANT' as [Mandato], FechaPosicion as [Fecha], 'MSANT' as [Mandatario], count(*) as [Registros]  from  IMSS_RepPosLayoutHist where datediff(DD,FechaReporte, getdate()) = 0  GROUP BY FechaPosicion";
            cmd = new SqlCommand(encabezado, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                using (StreamWriter sw = File.CreateText(rutaArchivo.ToString()))
                {
                    string linea = string.Concat(rdr["H"].ToString(), ",", rdr["Mandato"].ToString(), ",", rdr["Fecha"].ToString(), ",", rdr["Mandatario"].ToString(), ",", rdr["Registros"].ToString());
                    sw.WriteLine(linea);
                }
            }
            rdr.Close();

            detalle = string.Concat("exec IMSS_ArcPosLayout_csv '", Recursos.appfecha.ToString(), "'");
            cmd = new SqlCommand(detalle, con);
            cmd.CommandType = CommandType.Text;
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                using (StreamWriter sw = File.AppendText(rutaArchivo.ToString()))
                {
                    string linea = string.Concat(rdr["ClaveOperacion"].ToString(), ",",
                        rdr["ClaveMandato"].ToString(), ",",
                        rdr["FechaPosicion"].ToString(), ",",
                        rdr["Portafolio"].ToString(), ",",
                        rdr["SubPortafolio"].ToString(), ",",
                        rdr["ClaseActivo"].ToString(), ",",
                        rdr["TipoValor"].ToString(), ",",
                        rdr["Emisora"].ToString(), ",",
                        rdr["Serie"].ToString(), ",",
                        rdr["SumaTitulosAcciones"].ToString(), ",",
                        rdr["DiasCupon"].ToString(), ",",
                        rdr["TasaCupon"].ToString(), ",",
                        rdr["DxVCupon"].ToString(), ",",
                        rdr["FechaInicialCupon"].ToString(), ",",
                        rdr["FechaFinalCupon"].ToString(), ",",
                        rdr["FechaEmisionInstrumento"].ToString(), ",",
                        rdr["FechaVencimientoOperacion"].ToString(), ",",
                        rdr["DiasPorVencerInstrumento"].ToString(), ",",
                        rdr["YTM"].ToString(), ",",
                        rdr["TasaPactada"].ToString(), ",",
                        rdr["Moneda"].ToString(), ",",
                        rdr["Subyacente"].ToString(), ",",
                        rdr["SumaMontoInvertido_1"].ToString(), ",",
                        rdr["TipoCambio"].ToString(), ",",
                        rdr["Sector"].ToString(), ",",
                        rdr["S&P"].ToString(), ",",
                        rdr["Fitch"].ToString(), ",",
                        rdr["Moody's"].ToString(), ",",
                        rdr["HRR"].ToString(), ",",
                        rdr["Intermediario"].ToString(), ",",
                        rdr["DescripcionIntermediario"].ToString(), ",",
                        rdr["ClasificadorIntermediario"].ToString(), ",",
                        rdr["TipoOperacion"].ToString(), ",",
                        rdr["Operacion"].ToString(), ",",
                        rdr["Emisor"].ToString(), ",",
                        rdr["OrigenEmisor"].ToString(), ",",
                        rdr["Sobretasa"].ToString(), ",",
                        rdr["VolatilidadImplicita"].ToString(), ",",
                        rdr["StatusIntrumento"].ToString(), ",",
                        rdr["IdentificadorIMSS"].ToString(), ",",
                        rdr["Mandatario"].ToString(), ",",
                        rdr["MontoEmitido"].ToString().Trim(), ",",
                        rdr["TitulosCirculacion"].ToString(), ",",
                        rdr["TitulosEmitidos"].ToString(), ",",
                        rdr["ValorNominal"].ToString(), ",",
                        rdr["SumaMontoInvertido_2"].ToString());

                    sw.WriteLine(linea);
                }
            }
            rdr.Close();


            con.Close();
        }

        public void ExpArcPosValuada(string rutaArchivo)
        {

            //Creo excel y coloco encabezado
            Excel.Application Mi_Excel = default(Excel.Application);
            Excel.Workbook LibroExcel = default(Excel.Workbook);
            Excel.Worksheet HojaExcel = default(Excel.Worksheet);

            Mi_Excel = new Excel.Application();
            Mi_Excel.Visible = true;

            LibroExcel = Mi_Excel.Workbooks.Add();
            HojaExcel = LibroExcel.Worksheets[1];
            //HojaExcel.Visible = Excel.XlSheetVisibility.xlSheetHidden;

            HojaExcel.Activate();

            //Encabezados Tipo de Valor	Emisora	Serie	Titulos	Precio	Monto Invertido	Valor Mercado
            Excel.Range objCelda = HojaExcel.Range["A1", Type.Missing];
            objCelda.Value = "Tipo de Valor";

            objCelda = HojaExcel.Range["B1", Type.Missing];
            objCelda.Value = "Emisora";

            objCelda = HojaExcel.Range["C1", Type.Missing];
            objCelda.Value = "Serie";

            objCelda = HojaExcel.Range["D1", Type.Missing];
            objCelda.Value = "Titulos";

            objCelda = HojaExcel.Range["E1", Type.Missing];
            objCelda.Value = "Precio";

            objCelda = HojaExcel.Range["F1", Type.Missing];
            objCelda.Value = "Monto Invertido";

            objCelda = HojaExcel.Range["G1", Type.Missing];
            objCelda.Value = "Valor Mercado";


            SqlConnection con = new SqlConnection(string.Concat("Server=180.176.163.137; Database= SAM_IMSS; User Id=sa; Password = password; Connection Timeout=60;"));
            

            //Valido que los fondos ya estan valuados y cerrados
            string strqry = string.Concat("Exec IMSS_ArcPosicionValuada ", "'", Recursos.appfecha.ToString(), "'"); ;
            con.Open();
            SqlCommand cmd = new SqlCommand(strqry, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rdr = cmd.ExecuteReader();

            int i = 2;
            while (rdr.Read())
            {
                objCelda = HojaExcel.Range[string.Concat("A", i.ToString()), Type.Missing];
                objCelda.Value = rdr["Tipo Valor"].ToString();

                objCelda = HojaExcel.Range[string.Concat("B", i.ToString()), Type.Missing];
                objCelda.Value = rdr["Emisora"].ToString();

                objCelda = HojaExcel.Range[string.Concat("C", i.ToString()), Type.Missing];
                objCelda.Value = rdr["Serie"].ToString();

                objCelda = HojaExcel.Range[string.Concat("D", i.ToString()), Type.Missing];
                objCelda.Value = rdr["Titulos"].ToString();

                objCelda = HojaExcel.Range[string.Concat("E", i.ToString()), Type.Missing];
                objCelda.Value = rdr["Precio"].ToString();

                objCelda = HojaExcel.Range[string.Concat("F", i.ToString()), Type.Missing];
                objCelda.Value = rdr["Monto Invertido"].ToString();

                objCelda = HojaExcel.Range[string.Concat("G", i.ToString()), Type.Missing];
                objCelda.Value = rdr["Valor Mercado"].ToString();

                i++;
            }
            rdr.Close();

            LibroExcel.SaveAs(rutaArchivo);

            //LibroExcel.Close(false);
            Mi_Excel.Quit();

        }

        public void ExpArcPosValuadaCSV(string rutaArchivo)
        {

            //Creo excel y coloco encabezado
            Excel.Application Mi_Excel = default(Excel.Application);
            Excel.Workbook LibroExcel = default(Excel.Workbook);
            Excel.Worksheet HojaExcel = default(Excel.Worksheet);

            Mi_Excel = new Excel.Application();
            Mi_Excel.Visible = true;

            LibroExcel = Mi_Excel.Workbooks.Add();
            HojaExcel = LibroExcel.Worksheets[1];
            //HojaExcel.Visible = Excel.XlSheetVisibility.xlSheetHidden;

            HojaExcel.Activate();

            //Encabezados Tipo de Valor	Emisora	Serie	Titulos	Precio	Monto Invertido	Valor Mercado
            Excel.Range objCelda = HojaExcel.Range["A1", Type.Missing];
            objCelda.Value = "Tipo de Valor";

            objCelda = HojaExcel.Range["B1", Type.Missing];
            objCelda.Value = "Emisora";

            objCelda = HojaExcel.Range["C1", Type.Missing];
            objCelda.Value = "Serie";

            objCelda = HojaExcel.Range["D1", Type.Missing];
            objCelda.Value = "Titulos";

            objCelda = HojaExcel.Range["E1", Type.Missing];
            objCelda.Value = "Precio";

            objCelda = HojaExcel.Range["F1", Type.Missing];
            objCelda.Value = "Monto Invertido";

            objCelda = HojaExcel.Range["G1", Type.Missing];
            objCelda.Value = "Valor Mercado";


            SqlConnection con = new SqlConnection(string.Concat("Server=180.176.163.137; Database= SAM_IMSS; User Id=sa; Password = password; Connection Timeout=60;"));
            

            //Valido que los fondos ya estan valuados y cerrados
            string strqry = string.Concat("Exec IMSS_ArcPosicionValuada_csv ", "'", Recursos.appfecha.ToString(), "'"); ;
            con.Open();
            SqlCommand cmd = new SqlCommand(strqry, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rdr = cmd.ExecuteReader();

            int i = 2;
            while (rdr.Read())
            {
                objCelda = HojaExcel.Range[string.Concat("A", i.ToString()), Type.Missing];
                objCelda.Value = rdr["Tipo Valor"].ToString();

                objCelda = HojaExcel.Range[string.Concat("B", i.ToString()), Type.Missing];
                objCelda.Value = rdr["Emisora"].ToString();

                objCelda = HojaExcel.Range[string.Concat("C", i.ToString()), Type.Missing];
                objCelda.Value = rdr["Serie"].ToString();

                objCelda = HojaExcel.Range[string.Concat("D", i.ToString()), Type.Missing];
                objCelda.Value = rdr["Titulos"].ToString();

                objCelda = HojaExcel.Range[string.Concat("E", i.ToString()), Type.Missing];
                objCelda.Value = rdr["Precio"].ToString();

                objCelda = HojaExcel.Range[string.Concat("F", i.ToString()), Type.Missing];
                objCelda.Value = rdr["Monto Invertido"].ToString();

                objCelda = HojaExcel.Range[string.Concat("G", i.ToString()), Type.Missing];
                objCelda.Value = rdr["Valor Mercado"].ToString();

                i++;
            }
            rdr.Close();

            LibroExcel.SaveAs(rutaArchivo);

            //LibroExcel.Close(false);
            Mi_Excel.Quit();
        }

        public void ExpArcBBVA(string rutaArchivo)
        {
            string detalle = "";
            SqlConnection con = new SqlConnection(string.Concat("Server=180.176.163.137; Database= SAM_IMSS; User Id=sa; Password = password; Connection Timeout=60;"));
            
            con.Open();

            detalle = string.Concat("exec IMSS_CustodioBBVA");
            SqlCommand cmd = new SqlCommand(detalle, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {

                using (StreamWriter sw = File.AppendText(rutaArchivo.ToString()))
                {
                    string linea = string.Concat(rdr["Texto"].ToString());

                    sw.WriteLine(linea);
                }
            }
            rdr.Close();

            con.Close();
        }

        public void ExpArcS3(string rutaArchivo)
        {

            string detalle = "";
            SqlConnection con = new SqlConnection(string.Concat("Server=180.176.163.137; Database= SAM_IMSS; User Id=sa; Password = password; Connection Timeout=60;"));
            
            con.Open();

            detalle = string.Concat("exec IMSS_CustodioS3");
            SqlCommand cmd = new SqlCommand(detalle, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {

                using (StreamWriter sw = File.AppendText(rutaArchivo.ToString()))
                {
                    string linea = string.Concat(rdr["Texto"].ToString());

                    sw.WriteLine(linea);
                }
            }
            rdr.Close();


            con.Close();

        }

        private void btnSelTrades_Click(object sender, EventArgs e)
        {
            OpenFileDialog fldArchivo = new OpenFileDialog();

            fldArchivo.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            fldArchivo.Filter = "Archivos XLSX(*.xlsx)|*.xlsx";

            // codigo para abrir el cuadro de dialogo
            if (fldArchivo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string str_RutaArchivo = fldArchivo.FileName;
                    txArchTradesCustodio.Text = str_RutaArchivo;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void btnSelArchivo_Click(object sender, EventArgs e)
        {
            if ((chkXLS.Checked) && (chkCSV.Checked))
            {

                MessageBox.Show("Favor de seleccionar solo un tipo de archivo");
                return;

            }

            OpenFileDialog fldArchivo = new OpenFileDialog();

            fldArchivo.InitialDirectory = Recursos.strRutaAladdin.ToString().Trim();
            if (chkXLS.Checked)
            {
                fldArchivo.Filter = "Archivos XLS(*.xls)|*.xls";
            }
            if (chkCSV.Checked)
            {
                fldArchivo.Filter = "Archivos CSV(*.csv)|*.csv";
            }

            // codigo para abrir el cuadro de dialogo
            if (fldArchivo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string str_RutaArchivo = fldArchivo.FileName;
                    txFile.Text = str_RutaArchivo;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void btSelArchivoPiP_Click(object sender, EventArgs e)
        {
            OpenFileDialog fldArchivo = new OpenFileDialog();

            fldArchivo.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            fldArchivo.Filter = "Archivos XLS(*.xls)|*.xls";

            // codigo para abrir el cuadro de dialogo
            if (fldArchivo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string str_RutaArchivo = fldArchivo.FileName;
                    txFilePiP.Text = str_RutaArchivo;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void btRutaPosition_Click(object sender, EventArgs e)
        {
            OpenFileDialog fldArchivo = new OpenFileDialog();

            fldArchivo.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            fldArchivo.Filter = "Archivos XLSX(*.xlsx)|*.xlsx";

            // codigo para abrir el cuadro de dialogo
            if (fldArchivo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string str_RutaArchivo = fldArchivo.FileName;
                    txArchPosition.Text = str_RutaArchivo;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void chkCSV_CheckedChanged(object sender, EventArgs e)
        {
            txFile.Text = "";
            if (chkXLS.Checked)
            {
                txFile.Text = string.Concat(Recursos.strRutaValmer.ToString(), "VectorAnaliticoMD", ".xls").Trim();
            }
            if (chkCSV.Checked)
            {
                txFile.Text = string.Concat(Recursos.strRutaValmer.ToString(), "vector_precios", ".csv").Trim();
            }
        }

        private void chkXLS_CheckedChanged(object sender, EventArgs e)
        {
            txFile.Text = "";
            if (chkCSV.Checked)
            {
                txFile.Text = string.Concat(Recursos.strRutaValmer.ToString(), "vector_precios", ".csv").Trim();
            }
            if (chkXLS.Checked)
            {
                txFile.Text = string.Concat(Recursos.strRutaValmer.ToString(), "VectorAnaliticoMD", ".xls").Trim();
            }

        }

        private void btnSelCarpetaSalida_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();

            fbd.SelectedPath = Recursos.strRutaLayouts.ToString().Trim();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                txLayouts.Text = string.Concat(fbd.SelectedPath, @"\");
            }
        }

     
    }
}
