TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].[IMSS_RepPosicionValuadaHistEquity]
INSERT INTO [SAM_IMSS_WEB].[dbo].[IMSS_RepPosicionValuadaHistEquity]
SELECT [FechaReporte] ,[Tipo Valor] ,[Emisora] ,[Serie] ,[Titulos] ,[Precio] ,[Monto Invertido] ,[Valor Mercado], 'MX40041626'
FROM [SAM_IMSS].[dbo].[IMSS_RepPosicionValuadaHistEquity]
UNION ALL
SELECT [FechaReporte] ,[Tipo Valor] ,[Emisora] ,[Serie] ,[Titulos] ,[Precio] ,[Monto Invertido] ,[Valor Mercado], 'MX40041627'
FROM [SAM_IMSS_1627].[dbo].[IMSS_RepPosicionValuadaHistEquity]
 

 TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].[IMSS_RepPosicionValuadaHist]
INSERT INTO [SAM_IMSS_WEB].[dbo].[IMSS_RepPosicionValuadaHist]
SELECT [FechaReporte] ,[Tipo Valor],[Emisora] ,[Serie] ,[Titulos] ,[Precio] ,[Monto Invertido] ,[Valor Mercado],  'MX40041626'
FROM [SAM_IMSS].[dbo].[IMSS_RepPosicionValuadaHist]
UNION ALL
SELECT [FechaReporte] ,[Tipo Valor],[Emisora] ,[Serie] ,[Titulos] ,[Precio] ,[Monto Invertido] ,[Valor Mercado],  'MX40041627'
FROM [SAM_IMSS_1627].[dbo].[IMSS_RepPosicionValuadaHist]

  
  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].[IMSS_Positions]
INSERT INTO [SAM_IMSS_WEB].[dbo].[IMSS_Positions]
SELECT [Buy_Sell] ,[Portfolio] ,[InvNum] ,[TipoValor] ,[Td_Num] ,[TradeDate] ,[CollateralQuantity] ,[Orig_Face] ,[PurchasePrice] ,[Coupon]
,[Settle_Date] ,[Maturity] ,[Currency] ,[Collateral_Price] ,[Collateral_ISIN] ,[CUSIP] ,[ISIN] ,[Settled]
FROM [SAM_IMSS].[dbo].[IMSS_Positions]
UNION ALL
SELECT [Buy_Sell] ,[Portfolio] ,[InvNum] ,[TipoValor] ,[Td_Num] ,[TradeDate] ,[CollateralQuantity] ,[Orig_Face] ,[PurchasePrice] ,[Coupon]
,[Settle_Date] ,[Maturity] ,[Currency] ,[Collateral_Price] ,[Collateral_ISIN] ,[CUSIP] ,[ISIN] ,[Settled]
FROM [SAM_IMSS_1627].[dbo].[IMSS_Positions]

  
TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].[IMSS_Trades]
INSERT INTO [SAM_IMSS_WEB].[dbo].[IMSS_Trades]
SELECT [Fund] ,[InvNum] ,[TipoValor] ,[Td_Num] ,[CounterParty] ,[Buy_Sell] ,[TranType] ,[TradeFace] ,[OrigFace] ,[TradePrice] ,[TradeDate]
,[SettleDate] ,[Principal] ,[NetMoney] ,[Collateral_ISIN] ,[Collateral_Quantity] ,[Cupon] ,[Maturity] ,[IssueDate] 
FROM [SAM_IMSS].[dbo].[IMSS_Trades]
UNION ALL
SELECT [Fund] ,[InvNum] ,[TipoValor] ,[Td_Num] ,[CounterParty] ,[Buy_Sell] ,[TranType] ,[TradeFace] ,[OrigFace] ,[TradePrice] ,[TradeDate]
,[SettleDate] ,[Principal] ,[NetMoney] ,[Collateral_ISIN] ,[Collateral_Quantity] ,[Cupon] ,[Maturity] ,[IssueDate] 
FROM [SAM_IMSS_1627].[dbo].[IMSS_Trades]

  
TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].[IMSS_RepTradesHist]
INSERT INTO [SAM_IMSS_WEB].[dbo].[IMSS_RepTradesHist]
SELECT [FechaReporte] ,[Mandatario] ,[FechaArchivo] ,[FechaOperacion] ,[Portafolio] ,[ClaseActivo] ,[TipoValor] ,[Emisora] ,[Serie] ,[PrecioSucio]
,[Titulos] ,[FechaLiquidacion] ,[Intermediario] ,[MontoLiquidado] ,[NumeroMandato] ,[ClaveFechaLiquidacion] ,[ClaveOperacion]
,[PrecioPactado] , 'MX40041626'
FROM [SAM_IMSS].[dbo].[IMSS_RepTradesHist]
UNION ALL
SELECT [FechaReporte] ,[Mandatario] ,[FechaArchivo] ,[FechaOperacion] ,[Portafolio] ,[ClaseActivo] ,[TipoValor] ,[Emisora] ,[Serie] ,[PrecioSucio]
,[Titulos] ,[FechaLiquidacion] ,[Intermediario] ,[MontoLiquidado] ,[NumeroMandato] ,[ClaveFechaLiquidacion] ,[ClaveOperacion]
,[PrecioPactado] , 'MX40041627' 
FROM [SAM_IMSS_1627].[dbo].[IMSS_RepTradesHist]
 

  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].[IMSS_RepPosLayoutHist]
INSERT INTO [SAM_IMSS_WEB].[dbo].[IMSS_RepPosLayoutHist]
SELECT [FechaReporte] ,[ClaveOperacion] ,[ClaveMandato] ,[FechaPosicion] ,[Portafolio] ,[SubPortafolio] ,[ClaseActivo] ,[TipoValor] ,[Emisora] ,[Serie] ,[SumaTitulosAcciones]
      ,[DiasCupon] ,[TasaCupon] ,[DxVCupon] ,[FechaInicialCupon] ,[FechaFinalCupon] ,[FechaEmisionInstrumento] ,[FechaVencimientoOperacion] ,[DiasPorVencerInstrumento]
      ,[YTM] ,[TasaPactada] ,[Moneda] ,[Subyacente] ,[SumaMontoInvertido_1] ,[TipoCambio] ,[Sector] ,[S&P] ,[Fitch] ,[Moody's] ,[HRR] ,[Intermediario] ,[DescripcionIntermediario]
      ,[ClasificadorIntermediario] ,[TipoOperacion] ,[Operacion] ,[Emisor] ,[OrigenEmisor] ,[Sobretasa] ,[VolatilidadImplicita] ,[StatusIntrumento] ,[IdentificadorIMSS]
      ,[Mandatario] ,[MontoEmitido] ,[TitulosCirculacion] ,[TitulosEmitidos] ,[ValorNominal] ,[SumaMontoInvertido_2], 'MX40041626' 
FROM [SAM_IMSS].[dbo].[IMSS_RepPosLayoutHist]
UNION ALL
SELECT [FechaReporte] ,[ClaveOperacion] ,[ClaveMandato] ,[FechaPosicion] ,[Portafolio] ,[SubPortafolio] ,[ClaseActivo] ,[TipoValor] ,[Emisora] ,[Serie] ,[SumaTitulosAcciones]
      ,[DiasCupon] ,[TasaCupon] ,[DxVCupon] ,[FechaInicialCupon] ,[FechaFinalCupon] ,[FechaEmisionInstrumento] ,[FechaVencimientoOperacion] ,[DiasPorVencerInstrumento]
      ,[YTM] ,[TasaPactada] ,[Moneda] ,[Subyacente] ,[SumaMontoInvertido_1] ,[TipoCambio] ,[Sector] ,[S&P] ,[Fitch] ,[Moody's] ,[HRR] ,[Intermediario] ,[DescripcionIntermediario]
      ,[ClasificadorIntermediario] ,[TipoOperacion] ,[Operacion] ,[Emisor] ,[OrigenEmisor] ,[Sobretasa] ,[VolatilidadImplicita] ,[StatusIntrumento] ,[IdentificadorIMSS]
      ,[Mandatario] ,[MontoEmitido] ,[TitulosCirculacion] ,[TitulosEmitidos] ,[ValorNominal] ,[SumaMontoInvertido_2], 'MX40041627'
FROM [SAM_IMSS_1627].[dbo].[IMSS_RepPosLayoutHist]
 

  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].[IMSS_CustodioTrades]
INSERT INTO [SAM_IMSS_WEB].[dbo].[IMSS_CustodioTrades]
SELECT [InvNum] ,[Td_Num] ,[Fund] ,[Tran_Type] ,[Trader] ,[Tipo_Valor] ,[Trade_Date] ,[Settle_Date] ,[Counterparty] ,[Counterparty_Desk] ,[Currency] ,[Orig_Face]
      ,[Trade_Price] ,[Effective_Rate] ,[Principal] ,[Commission] ,[Ex_Commission] ,[Net_Money] ,[CUSIP] ,[ISIN] 
FROM [SAM_IMSS].[dbo].[IMSS_CustodioTrades]
UNION ALL
SELECT [InvNum] ,[Td_Num] ,[Fund] ,[Tran_Type] ,[Trader] ,[Tipo_Valor] ,[Trade_Date] ,[Settle_Date] ,[Counterparty] ,[Counterparty_Desk] ,[Currency] ,[Orig_Face]
      ,[Trade_Price] ,[Effective_Rate] ,[Principal] ,[Commission] ,[Ex_Commission] ,[Net_Money] ,[CUSIP] ,[ISIN] 
FROM [SAM_IMSS_1627].[dbo].[IMSS_CustodioTrades]
 

  
TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].IMSS_CustodiaBBVA
INSERT INTO [SAM_IMSS_WEB].[dbo].IMSS_CustodiaBBVA
SELECT [InvNum] ,[Texto] FROM [SAM_IMSS].[dbo].IMSS_CustodiaBBVA
UNION ALL
SELECT [InvNum] ,[Texto] FROM [SAM_IMSS_1627].[dbo].IMSS_CustodiaBBVA



TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].IMSS_CustodiaS3
INSERT INTO [SAM_IMSS_WEB].[dbo].IMSS_CustodiaS3
SELECT [InvNum] ,[Texto] FROM [SAM_IMSS].[dbo].IMSS_CustodiaS3
UNION ALL
SELECT [InvNum] ,[Texto] FROM [SAM_IMSS_1627].[dbo].IMSS_CustodiaS3



  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].IMSS_PosIncorrectos
INSERT INTO [SAM_IMSS_WEB].[dbo].IMSS_PosIncorrectos
SELECT [TipoValor] ,[Monto Invertido] FROM [SAM_IMSS].[dbo].IMSS_PosIncorrectos
UNION ALL
SELECT [TipoValor] ,[Monto Invertido] FROM [SAM_IMSS_1627].[dbo].IMSS_PosIncorrectos



  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].IMSS_RepPosLayout
INSERT INTO [SAM_IMSS_WEB].[dbo].IMSS_RepPosLayout
SELECT [ClaveOperacion] ,[ClaveMandato] ,[FechaPosicion] ,[Portafolio] ,[SubPortafolio] ,[ClaseActivo] ,[TipoValor] ,[Emisora] ,[Serie] ,[Títulos_Acciones]
      ,[DiasCupon] ,[TasaCupon] ,[DxVCupon] ,[FechaInicialCupon] ,[FechaFinalCupon] ,[FechaEmisionInstrumento] ,[FechaVencimientoOperacion]
      ,[DiasPorVencerInstrumento] ,[YTM] ,[TasaPactada] ,[Moneda] ,[Subyacente] ,[MontoInvertido] ,[TipoCambio] ,[Sector] ,[S&P] ,[Fitch]
      ,[Moody's] ,[HRR] ,[Intermediario] ,[DescripcionIntermediario] ,[ClasificadorIntermediario] ,[TipoOperacion] ,[Operacion] ,[Emisor]
      ,[OrigenEmisor] ,[Sobretasa] ,[VolatilidadImplicita] ,[StatusIntrumento] ,[IdentificadorIMSS] ,[Mandatario] ,[MontoEmitido] ,[TitulosCirculacion]
      ,[TitulosEmitidos] ,[ValorNominal] ,[MontoInvertidoFinal] 
FROM [SAM_IMSS].[dbo].IMSS_RepPosLayout
UNION ALL
SELECT [ClaveOperacion] ,[ClaveMandato] ,[FechaPosicion] ,[Portafolio] ,[SubPortafolio] ,[ClaseActivo] ,[TipoValor] ,[Emisora] ,[Serie] ,[Títulos_Acciones]
      ,[DiasCupon] ,[TasaCupon] ,[DxVCupon] ,[FechaInicialCupon] ,[FechaFinalCupon] ,[FechaEmisionInstrumento] ,[FechaVencimientoOperacion]
      ,[DiasPorVencerInstrumento] ,[YTM] ,[TasaPactada] ,[Moneda] ,[Subyacente] ,[MontoInvertido] ,[TipoCambio] ,[Sector] ,[S&P] ,[Fitch]
      ,[Moody's] ,[HRR] ,[Intermediario] ,[DescripcionIntermediario] ,[ClasificadorIntermediario] ,[TipoOperacion] ,[Operacion] ,[Emisor]
      ,[OrigenEmisor] ,[Sobretasa] ,[VolatilidadImplicita] ,[StatusIntrumento] ,[IdentificadorIMSS] ,[Mandatario] ,[MontoEmitido] ,[TitulosCirculacion]
      ,[TitulosEmitidos] ,[ValorNominal] ,[MontoInvertidoFinal] 
FROM [SAM_IMSS_1627].[dbo].[IMSS_RepPosLayout]



  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].IMSS_RepTrades
INSERT INTO [SAM_IMSS_WEB].[dbo].IMSS_RepTrades
SELECT [Mandatario] ,[FechaArchivo] ,[FechaOperacion] ,[Portafolio] ,[ClaseActivo] ,[TipoValor] ,[Emisora] ,[Serie] ,[PrecioSucio] ,[Titulos] 
	,[FechaLiquidacion] ,[Intermediario] ,[MontoLiquidado] ,[NumeroMandato] ,[ClaveFechaLiquidacion] ,[ClaveOperacion] ,[PrecioPactado] 
FROM [SAM_IMSS].[dbo].IMSS_RepTrades
UNION ALL
SELECT [Mandatario] ,[FechaArchivo] ,[FechaOperacion] ,[Portafolio] ,[ClaseActivo] ,[TipoValor] ,[Emisora] ,[Serie] ,[PrecioSucio] ,[Titulos] 
	,[FechaLiquidacion] ,[Intermediario] ,[MontoLiquidado] ,[NumeroMandato] ,[ClaveFechaLiquidacion] ,[ClaveOperacion] ,[PrecioPactado] 
FROM [SAM_IMSS_1627].[dbo].IMSS_RepTrades


TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].IMSS_SumasIncorrecto
INSERT INTO [SAM_IMSS_WEB].[dbo].IMSS_SumasIncorrecto
SELECT [TipoValor] ,[MontoFin] FROM [SAM_IMSS].[dbo].IMSS_SumasIncorrecto
UNION ALL
SELECT [TipoValor] ,[MontoFin] FROM [SAM_IMSS_1627].[dbo].IMSS_SumasIncorrecto



  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].IMSS_TMPTrades
INSERT INTO [SAM_IMSS_WEB].[dbo].IMSS_TMPTrades
SELECT [Fund] ,[InvNum] ,[TipoValor] ,[Td_Num] ,[CounterParty] ,[Buy_Sell] ,[TranType] ,[TradeFace] ,[OrigFace] ,[TradePrice]
,[TradeDate] ,[SettleDate] ,[Principal] ,[NetMoney] ,[Collateral_ISIN] ,[Collateral_Quantity] ,[Cupon] ,[Maturity] ,[IssueDate] 
FROM [SAM_IMSS].[dbo].IMSS_TMPTrades
UNION ALL
SELECT [Fund] ,[InvNum] ,[TipoValor] ,[Td_Num] ,[CounterParty] ,[Buy_Sell] ,[TranType] ,[TradeFace] ,[OrigFace] ,[TradePrice]
,[TradeDate] ,[SettleDate] ,[Principal] ,[NetMoney] ,[Collateral_ISIN] ,[Collateral_Quantity] ,[Cupon] ,[Maturity] ,[IssueDate] 
FROM [SAM_IMSS_1627].[dbo].IMSS_TMPTrades



  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].MontosInversion
INSERT INTO [SAM_IMSS_WEB].[dbo].MontosInversion
SELECT [TipoValor] ,[Monto] FROM [SAM_IMSS].[dbo].MontosInversion
UNION ALL
SELECT [TipoValor] ,[Monto] FROM [SAM_IMSS_1627].[dbo].MontosInversion



  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].PiPAnalitico
INSERT INTO [SAM_IMSS_WEB].[dbo].PiPAnalitico
SELECT [FECHA] ,[TIPO VALOR] ,[EMISORA] ,[SERIE] ,[PRECIO LIMPIO] ,[PRECIO SUCIO] ,[INTERESES ACUMULADOS] ,[CUPON ACTUAL] ,[SOBRETASA] ,[NOMBRE COMPLETO]
      ,[SECTOR] ,[MONTO EMITIDO] ,[MONTO EN CIRCULACION] ,[FECHA EMISION] ,[PLAZO EMISION] ,[FECHA VCTO] ,[VALOR NOMINAL] ,[MONEDA EMISION] ,[SUBYACENTE]
      ,[REND# COLOCACION] ,[ST COLOCACION] ,[FREC# CPN] ,[TASA CUPON] ,[DIAS TRANSC# CPN] ,[REGLA CUPON] ,[CUPONES EMISION] ,[CUPONES X COBRAR] ,[HECHO DE MKT]
      ,[FECHA U#H#] ,[PRECIO TEORICO] ,[POST COMPRA] ,[POST VENTA] ,[YIELD COMPRA] ,[YIELD VENTA] ,[SPREAD COMPRA] ,[SPREAD VENTA] ,[MDYS] ,[S&P] ,[BURSATILIDAD]
      ,[LIQUIDEZ] ,[CAMBIO DIARIO] ,[CAMBIO SEMANAL] ,[PRECIO MAX 12M] ,[PRECIO MIN 12M] ,[SUSPENSION] ,[VOLATILIDAD] ,[VOLATILIDAD 2] ,[DURACION],[DURACION MONET#]
      ,[CONVEXIDAD] ,[VAR] ,[DESVIACION STAND] ,[VALOR NOMINAL ACTUALIZADO] ,[CALIFICACION FITCH] ,[FECHA PRECIO MAXIMO] ,[FECHA PRECIO MINIMO] ,[SENSIBILIDAD]
      ,[DURACION MACAULAY] ,[TASA DE RENDIMIENTO] ,[HR RATINGS] ,[DURACION EFECTIVA] ,[ISIN] ,[CALIFICACION VERUM] ,[CALIFICACION DBRS] 
FROM [SAM_IMSS].[dbo].PiPAnalitico



  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].VectorAnaliticoMD
INSERT INTO [SAM_IMSS_WEB].[dbo].VectorAnaliticoMD
SELECT [Column 0] ,[Column 1] ,[Column 2] ,[Column 3] ,[Column 4] ,[Column 5] ,[Column 6] ,[Column 7] ,[Column 8] ,[Column 9] ,[Column 10] ,[Column 11]
      ,[Column 12] ,[Column 13] ,[Column 14] ,[Column 15] ,[Column 16] ,[Column 17] ,[Column 18] ,[Column 19] ,[Column 20] ,[Column 21] ,[Column 22]
      ,[Column 23] ,[Column 24] ,[Column 25] ,[Column 26] ,[Column 27] ,[Column 28] ,[Column 29] ,[Column 30] ,[Column 31] ,[Column 32] ,[Column 33]
      ,[Column 34] ,[Column 35] ,[Column 36] ,[Column 37] ,[Column 38] ,[Column 39] ,[Column 40] ,[Column 41] ,[Column 42] ,[Column 43] ,[Column 44]
      ,[Column 45] ,[Column 46] ,[Column 47] ,[Column 48] ,[Column 49] ,[Column 50] ,[Column 51] ,[Column 52] ,[Column 53] ,[Column 54] ,[Column 55]
      ,[Column 56] ,[Column 57] ,[Column 58] 
FROM [SAM_IMSS].[dbo].VectorAnaliticoMD



TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].VectorAnaliticoPiP
INSERT INTO [SAM_IMSS_WEB].[dbo].VectorAnaliticoPiP
SELECT [FECHA] ,[TIPO VALOR] ,[EMISORA] ,[SERIE] ,[PRECIO LIMPIO] ,[PRECIO SUCIO] ,[INTERESES ACUMULADOS] ,[CUPON ACTUAL] ,[SOBRETASA] ,[SECTOR] 
		,[MONTO EMITIDO] ,[MONTO EN CIRCULACION] ,[FECHA EMISION] ,[PLAZO EMISION] ,[FECHA VCTO] ,[VALOR NOMINAL] ,[MONEDA EMISION] ,[SUBYACENTE]
      ,[REND# COLOCACION] ,[ST COLOCACION] ,[FREC# CPN] ,[TASA CUPON] ,[DIAS TRANSC# CPN] ,[REGLA CUPON] ,[CUPONES EMISION] ,[CUPONES X COBRAR]
      ,[HECHO DE MKT] ,[FECHA U#H#] ,[PRECIO TEORICO] ,[POST COMPRA] ,[POST VENTA] ,[YIELD COMPRA] ,[YIELD VENTA] ,[SPREAD COMPRA] ,[SPREAD VENTA]
      ,[MDYS] ,[S&P] ,[BURSATILIDAD] ,[LIQUIDEZ] ,[CAMBIO DIARIO] ,[CAMBIO SEMANAL] ,[PRECIO MAX 12M] ,[PRECIO MIN 12M] ,[SUSPENSION] ,[VOLATILIDAD]
      ,[VOLATILIDAD 2] ,[DURACION] ,[DURACION MONET#] ,[CONVEXIDAD] ,[VAR] ,[DESVIACION STAND] ,[VALOR NOMINAL ACTUALIZADO] ,[CALIFICACION FITCH]
      ,[FECHA PRECIO MAXIMO] ,[FECHA PRECIO MINIMO] ,[SENSIBILIDAD] ,[DURACION MACAULAY] ,[TASA DE RENDIMIENTO] ,[HR RATINGS] ,[DURACION EFECTIVA]
      ,[ISIN] ,[CALIFICACION VERUM] ,[CALIFICACION DBRS] 
FROM [SAM_IMSS].[dbo].VectorAnaliticoPiP




  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].VectorAnaliticoValmer
INSERT INTO [SAM_IMSS_WEB].[dbo].VectorAnaliticoValmer
SELECT [FECHA] ,[TIPO VALOR] ,[EMISORA] ,[SERIE] ,[PRECIO LIMPIO] ,[PRECIO SUCIO] ,[INTERESES ACUMULADOS] ,[CUPON ACTUAL] ,[SOBRETASA] ,[NOMBRE COMPLETO]
      ,[SECTOR] ,[MONTO EMITIDO] ,[MONTO EN CIRCULACION] ,[FECHA EMISION] ,[PLAZO EMISION] ,[FECHA VCTO] ,[VALOR NOMINAL] ,[MONEDA EMISION] ,[SUBYACENTE]
      ,[REND# COLOCACION] ,[STCOLOCACION] ,[FREC# CPN] ,[TASA CUPON] ,[DIAS TRANSC# CPN] ,[REGLA CUPON] ,[CUPONES EMISION] ,[CUPONES X COBRAR] ,[HECHO DE MKT]
      ,[FECHA U#H#] ,[PRECIO TEORICO] ,[POST COMPRA] ,[POST VENTA] ,[YIELD COMPRA] ,[YIELD VENTA] ,[SPREAD COMPRA] ,[SPREAD VENTA] ,[MDYS] ,[S&P] ,[BURSATILIDAD]
      ,[LIQUIDEZ] ,[CAMBIO DIARIO] ,[CAMBIO SEMANAL] ,[PRECIO MAX 12M] ,[PRECIO MIN 12M] ,[SUSPENSION] ,[VOLATILIDAD] ,[VOLATILIDAD 2] ,[DURACION]
      ,[DURACION MONET#] ,[CONVEXIDAD] ,[VAR] ,[DESVIACION STAND] ,[VALOR NOMINAL ACTUALIZADO] ,[CALIFICACION FITCH] ,[FECHA PRECIO MAXIMO]
      ,[FECHA PRECIO MINIMO] ,[SENSIBILIDAD] ,[DURACION MACAULAY] ,[TASA DE RENDIMIENTO] ,[HR RATINGS] 
FROM [SAM_IMSS].[dbo].VectorAnaliticoValmer



  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].VectorAnaliticoValmerCSV
INSERT INTO [SAM_IMSS_WEB].[dbo].VectorAnaliticoValmerCSV
SELECT [TipoMercado] ,[Fecha] ,[TV] ,[Emisora] ,[Serie] ,[PrecioSucio] ,[PrecioLimpio] ,[InteresesDevengados] ,[DiasporVencer] ,[TasaDescuento] ,[PrecioSucio24Hrs]
      ,[PrecioLimpio24Hrs] ,[InteresesDevengados24Hrs] ,[DiasporVencer24Hrs] ,[TasaDescuento24Hrs] ,[Plazo] ,[Sobretasa] ,[ClaveProveedor] ,[TipoEnvio]
      ,[Duracion] ,[Convexidad] ,[Rendimiento] ,[Instrumento] ,[FechaInicioCupon] ,[FechaFinCupon] ,[TasaCuponVigente] ,[TasaCuponVigente24Hrs]
      ,[Moneda] ,[Isin] 
FROM [SAM_IMSS].[dbo].VectorAnaliticoValmerCSV
