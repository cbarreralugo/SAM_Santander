namespace SAM_IMSS
{
    partial class frmIMSS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            btnProcesar = new Button( );
            groupBox3 = new GroupBox( );
            chkS3 = new CheckBox( );
            chkBBVA = new CheckBox( );
            btnSelCarpetaSalida = new Button( );
            txLayouts = new TextBox( );
            chkValuada = new CheckBox( );
            chkTrades = new CheckBox( );
            chkPosicion = new CheckBox( );
            groupBox2 = new GroupBox( );
            chArchTrades = new CheckBox( );
            chArcPositions = new CheckBox( );
            label4 = new Label( );
            label3 = new Label( );
            btnSelTrades = new Button( );
            txArchTradesCustodio = new TextBox( );
            btRutaPosition = new Button( );
            txArchPosition = new TextBox( );
            groupBox1 = new GroupBox( );
            chkXLS = new CheckBox( );
            chkCSV = new CheckBox( );
            chVectorPip = new CheckBox( );
            chMDValmer = new CheckBox( );
            label2 = new Label( );
            btSelArchivoPiP = new Button( );
            txFilePiP = new TextBox( );
            label1 = new Label( );
            btnSelArchivo = new Button( );
            txFile = new TextBox( );
            groupBox3.SuspendLayout( );
            groupBox2.SuspendLayout( );
            groupBox1.SuspendLayout( );
            SuspendLayout( );
            // 
            // btnProcesar
            // 
            btnProcesar.Location = new Point( 863, 1215 );
            btnProcesar.Margin = new Padding( 5, 6, 5, 6 );
            btnProcesar.Name = "btnProcesar";
            btnProcesar.Size = new Size( 233, 46 );
            btnProcesar.TabIndex = 9;
            btnProcesar.Text = "Procesar y Generar";
            btnProcesar.UseVisualStyleBackColor = true;
            btnProcesar.Click += btnProcesar_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add( chkS3 );
            groupBox3.Controls.Add( chkBBVA );
            groupBox3.Controls.Add( btnSelCarpetaSalida );
            groupBox3.Controls.Add( txLayouts );
            groupBox3.Controls.Add( chkValuada );
            groupBox3.Controls.Add( chkTrades );
            groupBox3.Controls.Add( chkPosicion );
            groupBox3.Location = new Point( 43, 900 );
            groupBox3.Margin = new Padding( 5, 6, 5, 6 );
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding( 5, 6, 5, 6 );
            groupBox3.Size = new Size( 1137, 283 );
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Text = "IMSS -- Layouts";
            // 
            // chkS3
            // 
            chkS3.AutoSize = true;
            chkS3.Checked = true;
            chkS3.CheckState = CheckState.Checked;
            chkS3.Location = new Point( 713, 71 );
            chkS3.Margin = new Padding( 5, 6, 5, 6 );
            chkS3.Name = "chkS3";
            chkS3.Size = new Size( 135, 29 );
            chkS3.TabIndex = 6;
            chkS3.Text = "Custodio S3";
            chkS3.UseVisualStyleBackColor = true;
            // 
            // chkBBVA
            // 
            chkBBVA.AutoSize = true;
            chkBBVA.Checked = true;
            chkBBVA.CheckState = CheckState.Checked;
            chkBBVA.Location = new Point( 542, 71 );
            chkBBVA.Margin = new Padding( 5, 6, 5, 6 );
            chkBBVA.Name = "chkBBVA";
            chkBBVA.Size = new Size( 157, 29 );
            chkBBVA.TabIndex = 5;
            chkBBVA.Text = "Custodio BBVA";
            chkBBVA.UseVisualStyleBackColor = true;
            // 
            // btnSelCarpetaSalida
            // 
            btnSelCarpetaSalida.Location = new Point( 985, 169 );
            btnSelCarpetaSalida.Margin = new Padding( 5, 6, 5, 6 );
            btnSelCarpetaSalida.Name = "btnSelCarpetaSalida";
            btnSelCarpetaSalida.Size = new Size( 78, 44 );
            btnSelCarpetaSalida.TabIndex = 4;
            btnSelCarpetaSalida.Text = "...";
            btnSelCarpetaSalida.UseVisualStyleBackColor = true;
            btnSelCarpetaSalida.Click += btnSelCarpetaSalida_Click;
            // 
            // txLayouts
            // 
            txLayouts.Enabled = false;
            txLayouts.Location = new Point( 18, 154 );
            txLayouts.Margin = new Padding( 5, 6, 5, 6 );
            txLayouts.Name = "txLayouts";
            txLayouts.Size = new Size( 939, 31 );
            txLayouts.TabIndex = 3;
            // 
            // chkValuada
            // 
            chkValuada.AutoSize = true;
            chkValuada.Checked = true;
            chkValuada.CheckState = CheckState.Checked;
            chkValuada.Location = new Point( 297, 71 );
            chkValuada.Margin = new Padding( 5, 6, 5, 6 );
            chkValuada.Name = "chkValuada";
            chkValuada.Size = new Size( 213, 29 );
            chkValuada.TabIndex = 2;
            chkValuada.Text = "Excel Posición Valuada";
            chkValuada.UseVisualStyleBackColor = true;
            // 
            // chkTrades
            // 
            chkTrades.AutoSize = true;
            chkTrades.Checked = true;
            chkTrades.CheckState = CheckState.Checked;
            chkTrades.Location = new Point( 172, 71 );
            chkTrades.Margin = new Padding( 5, 6, 5, 6 );
            chkTrades.Name = "chkTrades";
            chkTrades.Size = new Size( 88, 29 );
            chkTrades.TabIndex = 1;
            chkTrades.Text = "Trades";
            chkTrades.UseVisualStyleBackColor = true;
            // 
            // chkPosicion
            // 
            chkPosicion.AutoSize = true;
            chkPosicion.Checked = true;
            chkPosicion.CheckState = CheckState.Checked;
            chkPosicion.Location = new Point( 42, 71 );
            chkPosicion.Margin = new Padding( 5, 6, 5, 6 );
            chkPosicion.Name = "chkPosicion";
            chkPosicion.Size = new Size( 103, 29 );
            chkPosicion.TabIndex = 0;
            chkPosicion.Text = "Posición";
            chkPosicion.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add( chArchTrades );
            groupBox2.Controls.Add( chArcPositions );
            groupBox2.Controls.Add( label4 );
            groupBox2.Controls.Add( label3 );
            groupBox2.Controls.Add( btnSelTrades );
            groupBox2.Controls.Add( txArchTradesCustodio );
            groupBox2.Controls.Add( btRutaPosition );
            groupBox2.Controls.Add( txArchPosition );
            groupBox2.Location = new Point( 45, 462 );
            groupBox2.Margin = new Padding( 5, 6, 5, 6 );
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding( 5, 6, 5, 6 );
            groupBox2.Size = new Size( 1135, 402 );
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Aladdin -- Favor de seleccionar la ruta del archivo:";
            // 
            // chArchTrades
            // 
            chArchTrades.AutoSize = true;
            chArchTrades.Checked = true;
            chArchTrades.CheckState = CheckState.Checked;
            chArchTrades.Location = new Point( 1075, 258 );
            chArchTrades.Margin = new Padding( 5, 6, 5, 6 );
            chArchTrades.Name = "chArchTrades";
            chArchTrades.Size = new Size( 22, 21 );
            chArchTrades.TabIndex = 11;
            chArchTrades.UseVisualStyleBackColor = true;
            // 
            // chArcPositions
            // 
            chArcPositions.AutoSize = true;
            chArcPositions.Checked = true;
            chArcPositions.CheckState = CheckState.Checked;
            chArcPositions.Location = new Point( 1075, 144 );
            chArcPositions.Margin = new Padding( 5, 6, 5, 6 );
            chArcPositions.Name = "chArcPositions";
            chArcPositions.Size = new Size( 22, 21 );
            chArcPositions.TabIndex = 10;
            chArcPositions.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point( 22, 213 );
            label4.Margin = new Padding( 5, 0, 5, 0 );
            label4.Name = "label4";
            label4.Size = new Size( 214, 25 );
            label4.TabIndex = 9;
            label4.Text = "Archivo Trades (Custodio)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point( 23, 96 );
            label3.Margin = new Padding( 5, 0, 5, 0 );
            label3.Name = "label3";
            label3.Size = new Size( 224, 25 );
            label3.TabIndex = 8;
            label3.Text = "Archivo Positions (Layouts)";
            // 
            // btnSelTrades
            // 
            btnSelTrades.Location = new Point( 983, 240 );
            btnSelTrades.Margin = new Padding( 5, 6, 5, 6 );
            btnSelTrades.Name = "btnSelTrades";
            btnSelTrades.Size = new Size( 78, 44 );
            btnSelTrades.TabIndex = 7;
            btnSelTrades.Text = "...";
            btnSelTrades.UseVisualStyleBackColor = true;
            btnSelTrades.Click += btnSelTrades_Click;
            // 
            // txArchTradesCustodio
            // 
            txArchTradesCustodio.Enabled = false;
            txArchTradesCustodio.Location = new Point( 17, 246 );
            txArchTradesCustodio.Margin = new Padding( 5, 6, 5, 6 );
            txArchTradesCustodio.Name = "txArchTradesCustodio";
            txArchTradesCustodio.Size = new Size( 939, 31 );
            txArchTradesCustodio.TabIndex = 6;
            // 
            // btRutaPosition
            // 
            btRutaPosition.Location = new Point( 983, 127 );
            btRutaPosition.Margin = new Padding( 5, 6, 5, 6 );
            btRutaPosition.Name = "btRutaPosition";
            btRutaPosition.Size = new Size( 78, 44 );
            btRutaPosition.TabIndex = 3;
            btRutaPosition.Text = "...";
            btRutaPosition.UseVisualStyleBackColor = true;
            btRutaPosition.Click += btRutaPosition_Click;
            // 
            // txArchPosition
            // 
            txArchPosition.Enabled = false;
            txArchPosition.Location = new Point( 17, 127 );
            txArchPosition.Margin = new Padding( 5, 6, 5, 6 );
            txArchPosition.Name = "txArchPosition";
            txArchPosition.Size = new Size( 939, 31 );
            txArchPosition.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add( chkXLS );
            groupBox1.Controls.Add( chkCSV );
            groupBox1.Controls.Add( chVectorPip );
            groupBox1.Controls.Add( chMDValmer );
            groupBox1.Controls.Add( label2 );
            groupBox1.Controls.Add( btSelArchivoPiP );
            groupBox1.Controls.Add( txFilePiP );
            groupBox1.Controls.Add( label1 );
            groupBox1.Controls.Add( btnSelArchivo );
            groupBox1.Controls.Add( txFile );
            groupBox1.Location = new Point( 43, 48 );
            groupBox1.Margin = new Padding( 5, 6, 5, 6 );
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding( 5, 6, 5, 6 );
            groupBox1.Size = new Size( 1137, 404 );
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Vectores  -- Favor de seleccionar la ruta del archivo:";
            // 
            // chkXLS
            // 
            chkXLS.AutoSize = true;
            chkXLS.Checked = true;
            chkXLS.CheckState = CheckState.Checked;
            chkXLS.Location = new Point( 357, 104 );
            chkXLS.Margin = new Padding( 5, 6, 5, 6 );
            chkXLS.Name = "chkXLS";
            chkXLS.Size = new Size( 67, 29 );
            chkXLS.TabIndex = 11;
            chkXLS.Text = "XLS";
            chkXLS.UseVisualStyleBackColor = true;
            // 
            // chkCSV
            // 
            chkCSV.AutoSize = true;
            chkCSV.Location = new Point( 240, 102 );
            chkCSV.Margin = new Padding( 5, 6, 5, 6 );
            chkCSV.Name = "chkCSV";
            chkCSV.Size = new Size( 70, 29 );
            chkCSV.TabIndex = 10;
            chkCSV.Text = "CSV";
            chkCSV.UseVisualStyleBackColor = true;
            // 
            // chVectorPip
            // 
            chVectorPip.AutoSize = true;
            chVectorPip.Checked = true;
            chVectorPip.CheckState = CheckState.Checked;
            chVectorPip.Location = new Point( 1083, 304 );
            chVectorPip.Margin = new Padding( 5, 6, 5, 6 );
            chVectorPip.Name = "chVectorPip";
            chVectorPip.Size = new Size( 22, 21 );
            chVectorPip.TabIndex = 9;
            chVectorPip.UseVisualStyleBackColor = true;
            // 
            // chMDValmer
            // 
            chMDValmer.AutoSize = true;
            chMDValmer.Checked = true;
            chMDValmer.CheckState = CheckState.Checked;
            chMDValmer.Location = new Point( 1082, 156 );
            chMDValmer.Margin = new Padding( 5, 6, 5, 6 );
            chMDValmer.Name = "chMDValmer";
            chMDValmer.Size = new Size( 22, 21 );
            chMDValmer.TabIndex = 8;
            chMDValmer.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point( 25, 258 );
            label2.Margin = new Padding( 5, 0, 5, 0 );
            label2.Name = "label2";
            label2.Size = new Size( 272, 25 );
            label2.TabIndex = 7;
            label2.Text = "Vector Analitco PiP (Formato .xls)";
            // 
            // btSelArchivoPiP
            // 
            btSelArchivoPiP.Location = new Point( 985, 288 );
            btSelArchivoPiP.Margin = new Padding( 5, 6, 5, 6 );
            btSelArchivoPiP.Name = "btSelArchivoPiP";
            btSelArchivoPiP.Size = new Size( 78, 44 );
            btSelArchivoPiP.TabIndex = 6;
            btSelArchivoPiP.Text = "...";
            btSelArchivoPiP.UseVisualStyleBackColor = true;
            btSelArchivoPiP.Click += btSelArchivoPiP_Click;
            // 
            // txFilePiP
            // 
            txFilePiP.Enabled = false;
            txFilePiP.Location = new Point( 18, 288 );
            txFilePiP.Margin = new Padding( 5, 6, 5, 6 );
            txFilePiP.Name = "txFilePiP";
            txFilePiP.Size = new Size( 939, 31 );
            txFilePiP.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point( 25, 110 );
            label1.Margin = new Padding( 5, 0, 5, 0 );
            label1.Name = "label1";
            label1.Size = new Size( 160, 25 );
            label1.TabIndex = 4;
            label1.Text = "Vector MD Valmer ";
            // 
            // btnSelArchivo
            // 
            btnSelArchivo.Location = new Point( 985, 140 );
            btnSelArchivo.Margin = new Padding( 5, 6, 5, 6 );
            btnSelArchivo.Name = "btnSelArchivo";
            btnSelArchivo.Size = new Size( 78, 44 );
            btnSelArchivo.TabIndex = 3;
            btnSelArchivo.Text = "...";
            btnSelArchivo.UseVisualStyleBackColor = true;
            btnSelArchivo.Click += btnSelArchivo_Click;
            // 
            // txFile
            // 
            txFile.Enabled = false;
            txFile.Location = new Point( 18, 140 );
            txFile.Margin = new Padding( 5, 6, 5, 6 );
            txFile.Name = "txFile";
            txFile.Size = new Size( 939, 31 );
            txFile.TabIndex = 1;
            // 
            // frmIMSS
            // 
            AutoScaleDimensions = new SizeF( 10F, 25F );
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size( 1252, 1308 );
            Controls.Add( btnProcesar );
            Controls.Add( groupBox3 );
            Controls.Add( groupBox2 );
            Controls.Add( groupBox1 );
            Margin = new Padding( 5, 6, 5, 6 );
            Name = "frmIMSS";
            Text = "frmIMSS";
            Load += frmIMSS_Load;
            groupBox3.ResumeLayout( false );
            groupBox3.PerformLayout( );
            groupBox2.ResumeLayout( false );
            groupBox2.PerformLayout( );
            groupBox1.ResumeLayout( false );
            groupBox1.PerformLayout( );
            ResumeLayout( false );
        }

        #endregion

        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkS3;
        private System.Windows.Forms.CheckBox chkBBVA;
        private System.Windows.Forms.Button btnSelCarpetaSalida;
        private System.Windows.Forms.TextBox txLayouts;
        private System.Windows.Forms.CheckBox chkValuada;
        private System.Windows.Forms.CheckBox chkTrades;
        private System.Windows.Forms.CheckBox chkPosicion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chArchTrades;
        private System.Windows.Forms.CheckBox chArcPositions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSelTrades;
        private System.Windows.Forms.TextBox txArchTradesCustodio;
        private System.Windows.Forms.Button btRutaPosition;
        private System.Windows.Forms.TextBox txArchPosition;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkXLS;
        private System.Windows.Forms.CheckBox chkCSV;
        private System.Windows.Forms.CheckBox chVectorPip;
        private System.Windows.Forms.CheckBox chMDValmer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btSelArchivoPiP;
        private System.Windows.Forms.TextBox txFilePiP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelArchivo;
        private System.Windows.Forms.TextBox txFile;
    }
}