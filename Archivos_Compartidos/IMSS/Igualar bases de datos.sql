--TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].[IMSS_RepPosicionValuadaHistEquity]
--INSERT INTO [SAM_IMSS_WEB].[dbo].[IMSS_RepPosicionValuadaHistEquity]
--SELECT * FROM [SAM_IMSS].[dbo].[IMSS_RepPosicionValuadaHistEquity]

SELECT  [FechaReporte] ,[Tipo Valor] ,[Emisora] ,[Serie] ,[Titulos] ,[Precio] ,[Monto Invertido] ,[Valor Mercado]
  FROM [SAM_IMSS].[dbo].[IMSS_RepPosicionValuadaHistEquity]
  ORDER BY [FechaReporte]

  SELECT  [FechaReporte] ,[Tipo Valor] ,[Emisora] ,[Serie] ,[Titulos] ,[Precio] ,[Monto Invertido] ,[Valor Mercado]
  FROM [SAM_IMSS_WEB].[dbo].[IMSS_RepPosicionValuadaHistEquity]
  ORDER BY [FechaReporte]

  SELECT * FROM [SAM_IMSS].[dbo].[IMSS_RepPosicionValuadaHistEquity] EXCEPT
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[IMSS_RepPosicionValuadaHistEquity] 
    
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[IMSS_RepPosicionValuadaHistEquity] EXCEPT
  SELECT * FROM [SAM_IMSS].[dbo].[IMSS_RepPosicionValuadaHistEquity] 

--  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].[IMSS_RepPosicionValuadaHist]
--INSERT INTO [SAM_IMSS_WEB].[dbo].[IMSS_RepPosicionValuadaHist]
--SELECT * FROM [SAM_IMSS].[dbo].[IMSS_RepPosicionValuadaHist]

  SELECT [FechaReporte] ,[Tipo Valor],[Emisora] ,[Serie] ,[Titulos] ,[Precio] ,[Monto Invertido] ,[Valor Mercado]
  FROM [SAM_IMSS].[dbo].[IMSS_RepPosicionValuadaHist] 
  ORDER BY [FechaReporte]

  SELECT [FechaReporte] ,[Tipo Valor],[Emisora] ,[Serie] ,[Titulos] ,[Precio] ,[Monto Invertido] ,[Valor Mercado]
  FROM [SAM_IMSS_WEB].[dbo].[IMSS_RepPosicionValuadaHist] 
  ORDER BY [FechaReporte]

  SELECT * FROM [SAM_IMSS].[dbo].[IMSS_RepPosicionValuadaHist] EXCEPT
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[IMSS_RepPosicionValuadaHist] 
    
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[IMSS_RepPosicionValuadaHist] EXCEPT
  SELECT * FROM [SAM_IMSS].[dbo].[IMSS_RepPosicionValuadaHist] 
  
--  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].[IMSS_Positions]
--INSERT INTO [SAM_IMSS_WEB].[dbo].[IMSS_Positions]
--SELECT * FROM [SAM_IMSS].[dbo].[IMSS_Positions]

  SELECT  [Buy_Sell] ,[Portfolio] ,[InvNum] ,[TipoValor] ,[Td_Num] ,[TradeDate] ,[CollateralQuantity] ,[Orig_Face] ,[PurchasePrice]
      ,ROUND([Coupon],2) ,[Settle_Date] ,[Maturity] ,[Currency] ,[Collateral_Price] ,[Collateral_ISIN] ,[CUSIP] ,[ISIN] ,[Settled]
  FROM [SAM_IMSS].[dbo].[IMSS_Positions] 


  SELECT  [Buy_Sell] ,[Portfolio] ,[InvNum] ,[TipoValor] ,[Td_Num] ,[TradeDate] ,[CollateralQuantity] ,[Orig_Face] ,[PurchasePrice]
      ,ROUND([Coupon],2) ,[Settle_Date] ,[Maturity] ,[Currency] ,[Collateral_Price] ,[Collateral_ISIN] ,[CUSIP] ,[ISIN] ,[Settled]
  FROM [SAM_IMSS_WEB].[dbo].[IMSS_Positions]  

  
  SELECT * FROM [SAM_IMSS].[dbo].[IMSS_Positions] EXCEPT
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[IMSS_Positions] 
      
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[IMSS_Positions] EXCEPT
  SELECT * FROM [SAM_IMSS].[dbo].[IMSS_Positions] 
  
  
--  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].[IMSS_Trades]
--INSERT INTO [SAM_IMSS_WEB].[dbo].[IMSS_Trades]
--SELECT * FROM [SAM_IMSS].[dbo].[IMSS_Trades]

  SELECT [Fund] ,[InvNum] ,[TipoValor] ,[Td_Num] ,[CounterParty] ,[Buy_Sell] ,[TranType] ,[TradeFace] ,[OrigFace] ,[TradePrice] ,[TradeDate] ,[SettleDate]
      ,[Principal] ,[NetMoney] ,[Collateral_ISIN] ,[Collateral_Quantity] ,[Cupon] ,[Maturity] ,[IssueDate] FROM [SAM_IMSS].[dbo].[IMSS_Trades]
  ORDER BY [TradeDate]

  SELECT [Fund] ,[InvNum] ,[TipoValor] ,[Td_Num] ,[CounterParty] ,[Buy_Sell] ,[TranType] ,[TradeFace] ,[OrigFace] ,[TradePrice] ,[TradeDate] ,[SettleDate]
      ,[Principal] ,[NetMoney] ,[Collateral_ISIN] ,[Collateral_Quantity] ,[Cupon] ,[Maturity] ,[IssueDate] FROM [SAM_IMSS_WEB].[dbo].[IMSS_Trades]
  ORDER BY [TradeDate]

  
  SELECT [Fund] ,[InvNum] ,[TipoValor] ,[Td_Num] ,[CounterParty] ,[Buy_Sell] ,[TranType]  FROM [SAM_IMSS].[dbo].[IMSS_Trades] EXCEPT
  SELECT [Fund] ,[InvNum] ,[TipoValor] ,[Td_Num] ,[CounterParty] ,[Buy_Sell] ,[TranType]  FROM [SAM_IMSS_WEB].[dbo].[IMSS_Trades] 
      
  SELECT [Fund] ,[InvNum] ,[TipoValor] ,[Td_Num] ,[CounterParty] ,[Buy_Sell] ,[TranType]  FROM [SAM_IMSS_WEB].[dbo].[IMSS_Trades] EXCEPT
  SELECT [Fund] ,[InvNum] ,[TipoValor] ,[Td_Num] ,[CounterParty] ,[Buy_Sell] ,[TranType]  FROM [SAM_IMSS].[dbo].[IMSS_Trades] 

  
--  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].[IMSS_RepTradesHist]
--INSERT INTO [SAM_IMSS_WEB].[dbo].[IMSS_RepTradesHist]
--SELECT * FROM [SAM_IMSS].[dbo].[IMSS_RepTradesHist]
 

  SELECT [FechaReporte],[Mandatario] ,[FechaArchivo] ,[FechaOperacion] ,[Portafolio] ,[ClaseActivo] ,[TipoValor] ,[Emisora] ,[Serie] ,[PrecioSucio] ,[Titulos] ,[FechaLiquidacion]
      ,[Intermediario] ,[MontoLiquidado] ,[NumeroMandato] ,[ClaveFechaLiquidacion] ,[ClaveOperacion] ,[PrecioPactado]
  FROM [SAM_IMSS].[dbo].[IMSS_RepTradesHist]
  ORDER BY [FechaReporte]

  SELECT [FechaReporte],[Mandatario] ,[FechaArchivo] ,[FechaOperacion] ,[Portafolio] ,[ClaseActivo] ,[TipoValor] ,[Emisora] ,[Serie] ,[PrecioSucio] ,[Titulos] ,[FechaLiquidacion]
      ,[Intermediario] ,[MontoLiquidado] ,[NumeroMandato] ,[ClaveFechaLiquidacion] ,[ClaveOperacion] ,[PrecioPactado]
  FROM [SAM_IMSS_WEB].[dbo].[IMSS_RepTradesHist]
  ORDER BY [FechaReporte]

  
  SELECT * FROM [SAM_IMSS].[dbo].[IMSS_RepTradesHist] EXCEPT
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[IMSS_RepTradesHist] 
      
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[IMSS_RepTradesHist] EXCEPT
  SELECT * FROM [SAM_IMSS].[dbo].[IMSS_RepTradesHist] 
  

--  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].[IMSS_RepPosLayoutHist]
--INSERT INTO [SAM_IMSS_WEB].[dbo].[IMSS_RepPosLayoutHist]
--SELECT * FROM [SAM_IMSS].[dbo].[IMSS_RepPosLayoutHist]
 

  SELECT [FechaReporte] ,[ClaveOperacion] ,[ClaveMandato] ,[FechaPosicion] ,[Portafolio] ,[SubPortafolio] ,[ClaseActivo] ,[TipoValor] ,[Emisora] ,[Serie] ,[SumaTitulosAcciones]
      ,[DiasCupon] ,[TasaCupon] ,[DxVCupon] ,[FechaInicialCupon] ,[FechaFinalCupon] ,[FechaEmisionInstrumento] ,[FechaVencimientoOperacion] ,[DiasPorVencerInstrumento]
      ,[YTM] ,[TasaPactada] ,[Moneda] ,[Subyacente] ,[SumaMontoInvertido_1] ,[TipoCambio] ,[Sector] ,[S&P] ,[Fitch] ,[Moody's] ,[HRR] ,[Intermediario] ,[DescripcionIntermediario]
      ,[ClasificadorIntermediario] ,[TipoOperacion] ,[Operacion] ,[Emisor] ,[OrigenEmisor] ,[Sobretasa] ,[VolatilidadImplicita] ,[StatusIntrumento] ,[IdentificadorIMSS]
      ,[Mandatario] ,[MontoEmitido] ,[TitulosCirculacion] ,[TitulosEmitidos] ,[ValorNominal] ,[SumaMontoInvertido_2]
  FROM [SAM_IMSS].[dbo].[IMSS_RepPosLayoutHist] ORDER BY [FechaReporte]

  SELECT [FechaReporte] ,[ClaveOperacion] ,[ClaveMandato] ,[FechaPosicion] ,[Portafolio] ,[SubPortafolio] ,[ClaseActivo] ,[TipoValor] ,[Emisora] ,[Serie] ,[SumaTitulosAcciones]
      ,[DiasCupon] ,[TasaCupon] ,[DxVCupon] ,[FechaInicialCupon] ,[FechaFinalCupon] ,[FechaEmisionInstrumento] ,[FechaVencimientoOperacion] ,[DiasPorVencerInstrumento]
      ,[YTM] ,[TasaPactada] ,[Moneda] ,[Subyacente] ,[SumaMontoInvertido_1] ,[TipoCambio] ,[Sector] ,[S&P] ,[Fitch] ,[Moody's] ,[HRR] ,[Intermediario] ,[DescripcionIntermediario]
      ,[ClasificadorIntermediario] ,[TipoOperacion] ,[Operacion] ,[Emisor] ,[OrigenEmisor] ,[Sobretasa] ,[VolatilidadImplicita] ,[StatusIntrumento] ,[IdentificadorIMSS]
      ,[Mandatario] ,[MontoEmitido] ,[TitulosCirculacion] ,[TitulosEmitidos] ,[ValorNominal] ,[SumaMontoInvertido_2]
  FROM [SAM_IMSS_WEB].[dbo].[IMSS_RepPosLayoutHist]

  
  SELECT [FechaReporte] ,[ClaveOperacion] ,[ClaveMandato] ,[FechaPosicion] ,[Portafolio] ,[SubPortafolio] ,[ClaseActivo] ,[TipoValor] ,[Emisora] ,[Serie], [SumaMontoInvertido_1] FROM [SAM_IMSS].[dbo].[IMSS_RepPosLayoutHist] EXCEPT
  SELECT [FechaReporte] ,[ClaveOperacion] ,[ClaveMandato] ,[FechaPosicion] ,[Portafolio] ,[SubPortafolio] ,[ClaseActivo] ,[TipoValor] ,[Emisora] ,[Serie], [SumaMontoInvertido_1]  FROM [SAM_IMSS_WEB].[dbo].[IMSS_RepPosLayoutHist] 
      
  SELECT [FechaReporte] ,[ClaveOperacion] ,[ClaveMandato] ,[FechaPosicion] ,[Portafolio] ,[SubPortafolio] ,[ClaseActivo] ,[TipoValor] ,[Emisora] ,[Serie], [SumaMontoInvertido_1]  FROM [SAM_IMSS_WEB].[dbo].[IMSS_RepPosLayoutHist] EXCEPT
  SELECT [FechaReporte] ,[ClaveOperacion] ,[ClaveMandato] ,[FechaPosicion] ,[Portafolio] ,[SubPortafolio] ,[ClaseActivo] ,[TipoValor] ,[Emisora] ,[Serie], [SumaMontoInvertido_1]  FROM [SAM_IMSS].[dbo].[IMSS_RepPosLayoutHist] 
  

  
--  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].[IMSS_CustodioTrades]
--INSERT INTO [SAM_IMSS_WEB].[dbo].[IMSS_CustodioTrades]
--SELECT * FROM [SAM_IMSS].[dbo].[IMSS_CustodioTrades]
 

  SELECT [InvNum] ,[Td_Num] ,[Fund] ,[Tran_Type] ,[Trader] ,[Tipo_Valor] ,[Trade_Date] ,[Settle_Date] ,[Counterparty] ,[Counterparty_Desk] ,[Currency] ,[Orig_Face]
      ,[Trade_Price] ,[Effective_Rate] ,[Principal] ,[Commission] ,[Ex_Commission] ,[Net_Money] ,[CUSIP] ,[ISIN]
  FROM [SAM_IMSS].[dbo].[IMSS_CustodioTrades]

  SELECT [InvNum] ,[Td_Num] ,[Fund] ,[Tran_Type] ,[Trader] ,[Tipo_Valor] ,[Trade_Date] ,[Settle_Date] ,[Counterparty] ,[Counterparty_Desk] ,[Currency] ,[Orig_Face]
      ,[Trade_Price] ,[Effective_Rate] ,[Principal] ,[Commission] ,[Ex_Commission] ,[Net_Money] ,[CUSIP] ,[ISIN]
  FROM [SAM_IMSS_WEB].[dbo].[IMSS_CustodioTrades]
  
  
  SELECT * FROM [SAM_IMSS].[dbo].[IMSS_CustodioTrades] EXCEPT
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[IMSS_CustodioTrades] 
      
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[IMSS_CustodioTrades] EXCEPT
  SELECT * FROM [SAM_IMSS].[dbo].[IMSS_CustodioTrades] 
  
  
--  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].IMSS_CustodiaBBVA
--INSERT INTO [SAM_IMSS_WEB].[dbo].IMSS_CustodiaBBVA
--SELECT * FROM [SAM_IMSS].[dbo].IMSS_CustodiaBBVA

SELECT COUNT(*) FROM  [SAM_IMSS].[dbo].IMSS_CustodiaBBVA
SELECT COUNT(*) FROM  [SAM_IMSS_WEB].[dbo].IMSS_CustodiaBBVA


  SELECT * FROM [SAM_IMSS].[dbo].[IMSS_CustodiaBBVA] EXCEPT
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[IMSS_CustodiaBBVA] 
      
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[IMSS_CustodiaBBVA] EXCEPT
  SELECT * FROM [SAM_IMSS].[dbo].[IMSS_CustodiaBBVA] 
  

--  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].IMSS_CustodiaS3
--INSERT INTO [SAM_IMSS_WEB].[dbo].IMSS_CustodiaS3
--SELECT * FROM [SAM_IMSS].[dbo].IMSS_CustodiaS3

SELECT COUNT(*) FROM  [SAM_IMSS].[dbo].[IMSS_CustodiaS3]
SELECT COUNT(*) FROM  [SAM_IMSS_WEB].[dbo].[IMSS_CustodiaS3]


  SELECT * FROM [SAM_IMSS].[dbo].[IMSS_CustodiaS3] EXCEPT
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[IMSS_CustodiaS3] 
      
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[IMSS_CustodiaS3] EXCEPT
  SELECT * FROM [SAM_IMSS].[dbo].[IMSS_CustodiaS3] 


--  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].IMSS_PosIncorrectos
--INSERT INTO [SAM_IMSS_WEB].[dbo].IMSS_PosIncorrectos
--SELECT * FROM [SAM_IMSS].[dbo].IMSS_PosIncorrectos

SELECT COUNT(*) FROM  [SAM_IMSS].[dbo].[IMSS_PosIncorrectos]
SELECT COUNT(*) FROM  [SAM_IMSS_WEB].[dbo].[IMSS_PosIncorrectos]

  SELECT * FROM [SAM_IMSS].[dbo].[IMSS_PosIncorrectos] EXCEPT
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[IMSS_PosIncorrectos] 
      
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[IMSS_PosIncorrectos] EXCEPT
  SELECT * FROM [SAM_IMSS].[dbo].[IMSS_PosIncorrectos] 

--  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].IMSS_RepPosLayout
--INSERT INTO [SAM_IMSS_WEB].[dbo].IMSS_RepPosLayout
--SELECT * FROM [SAM_IMSS].[dbo].IMSS_RepPosLayout

SELECT COUNT(*) FROM  [SAM_IMSS].[dbo].[IMSS_RepPosLayout]
SELECT COUNT(*) FROM  [SAM_IMSS_WEB].[dbo].[IMSS_RepPosLayout]

  SELECT * FROM [SAM_IMSS].[dbo].[IMSS_RepPosLayout] EXCEPT
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[IMSS_RepPosLayout] 
      
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[IMSS_RepPosLayout] EXCEPT
  SELECT * FROM [SAM_IMSS].[dbo].[IMSS_RepPosLayout] 

--  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].IMSS_RepTrades
--INSERT INTO [SAM_IMSS_WEB].[dbo].IMSS_RepTrades
--SELECT * FROM [SAM_IMSS].[dbo].IMSS_RepTrades

SELECT COUNT(*) FROM  [SAM_IMSS].[dbo].[IMSS_RepTrades]
SELECT COUNT(*) FROM  [SAM_IMSS_WEB].[dbo].[IMSS_RepTrades]

  SELECT * FROM [SAM_IMSS].[dbo].[IMSS_RepTrades] EXCEPT
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[IMSS_RepTrades] 
      
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[IMSS_RepTrades] EXCEPT
  SELECT * FROM [SAM_IMSS].[dbo].[IMSS_RepTrades]


--  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].IMSS_SumasIncorrecto
--INSERT INTO [SAM_IMSS_WEB].[dbo].IMSS_SumasIncorrecto
--SELECT * FROM [SAM_IMSS].[dbo].IMSS_SumasIncorrecto

SELECT COUNT(*) FROM  [SAM_IMSS].[dbo].[IMSS_SumasIncorrecto]
SELECT COUNT(*) FROM  [SAM_IMSS_WEB].[dbo].[IMSS_SumasIncorrecto]

  SELECT * FROM [SAM_IMSS].[dbo].[IMSS_SumasIncorrecto] EXCEPT
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[IMSS_SumasIncorrecto] 
      
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[IMSS_SumasIncorrecto] EXCEPT
  SELECT * FROM [SAM_IMSS].[dbo].[IMSS_SumasIncorrecto]


--  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].IMSS_TMPTrades
--INSERT INTO [SAM_IMSS_WEB].[dbo].IMSS_TMPTrades
--SELECT * FROM [SAM_IMSS].[dbo].IMSS_TMPTrades

SELECT COUNT(*) FROM  [SAM_IMSS].[dbo].[IMSS_TMPTrades]
SELECT COUNT(*) FROM  [SAM_IMSS_WEB].[dbo].[IMSS_TMPTrades]

  SELECT * FROM [SAM_IMSS].[dbo].[IMSS_TMPTrades] EXCEPT
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[IMSS_TMPTrades] 
      
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[IMSS_TMPTrades] EXCEPT
  SELECT * FROM [SAM_IMSS].[dbo].[IMSS_TMPTrades]


--  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].MontosInversion
--INSERT INTO [SAM_IMSS_WEB].[dbo].MontosInversion
--SELECT * FROM [SAM_IMSS].[dbo].MontosInversion

SELECT COUNT(*) FROM  [SAM_IMSS].[dbo].[MontosInversion]
SELECT COUNT(*) FROM  [SAM_IMSS_WEB].[dbo].[MontosInversion]

  SELECT * FROM [SAM_IMSS].[dbo].[MontosInversion] EXCEPT
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[MontosInversion] 
      
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[MontosInversion] EXCEPT
  SELECT * FROM [SAM_IMSS].[dbo].[MontosInversion]


--  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].PiPAnalitico
--INSERT INTO [SAM_IMSS_WEB].[dbo].PiPAnalitico
--SELECT * FROM [SAM_IMSS].[dbo].PiPAnalitico

SELECT COUNT(*) FROM  [SAM_IMSS].[dbo].[PiPAnalitico]
SELECT COUNT(*) FROM  [SAM_IMSS_WEB].[dbo].[PiPAnalitico]

  SELECT * FROM [SAM_IMSS].[dbo].[PiPAnalitico] EXCEPT
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[PiPAnalitico] 
      
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[PiPAnalitico] EXCEPT
  SELECT * FROM [SAM_IMSS].[dbo].[PiPAnalitico]


--  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].VectorAnaliticoMD
--INSERT INTO [SAM_IMSS_WEB].[dbo].VectorAnaliticoMD
--SELECT * FROM [SAM_IMSS].[dbo].VectorAnaliticoMD

SELECT COUNT(*) FROM  [SAM_IMSS].[dbo].[VectorAnaliticoMD]
SELECT COUNT(*) FROM  [SAM_IMSS_WEB].[dbo].[VectorAnaliticoMD]

  SELECT * FROM [SAM_IMSS].[dbo].[VectorAnaliticoMD] EXCEPT
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[VectorAnaliticoMD] 
      
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[VectorAnaliticoMD] EXCEPT
  SELECT * FROM [SAM_IMSS].[dbo].[VectorAnaliticoMD]

--  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].VectorAnaliticoPiP
--INSERT INTO [SAM_IMSS_WEB].[dbo].VectorAnaliticoPiP
--SELECT * FROM [SAM_IMSS].[dbo].VectorAnaliticoPiP

SELECT COUNT(*) FROM  [SAM_IMSS].[dbo].[VectorAnaliticoPiP]
SELECT COUNT(*) FROM  [SAM_IMSS_WEB].[dbo].[VectorAnaliticoPiP]

  SELECT * FROM [SAM_IMSS].[dbo].[VectorAnaliticoPiP] EXCEPT
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[VectorAnaliticoPiP] 
      
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[VectorAnaliticoPiP] EXCEPT
  SELECT * FROM [SAM_IMSS].[dbo].[VectorAnaliticoPiP]

--  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].VectorAnaliticoValmer
--INSERT INTO [SAM_IMSS_WEB].[dbo].VectorAnaliticoValmer
--SELECT * FROM [SAM_IMSS].[dbo].VectorAnaliticoValmer

SELECT COUNT(*) FROM  [SAM_IMSS].[dbo].[VectorAnaliticoValmer]
SELECT COUNT(*) FROM  [SAM_IMSS_WEB].[dbo].[VectorAnaliticoValmer]

  SELECT * FROM [SAM_IMSS].[dbo].[VectorAnaliticoValmer] EXCEPT
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[VectorAnaliticoValmer] 
      
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[VectorAnaliticoValmer] EXCEPT
  SELECT * FROM [SAM_IMSS].[dbo].[VectorAnaliticoValmer]

--  TRUNCATE TABLE [SAM_IMSS_WEB].[dbo].VectorAnaliticoValmerCSV
--INSERT INTO [SAM_IMSS_WEB].[dbo].VectorAnaliticoValmerCSV
--SELECT * FROM [SAM_IMSS].[dbo].VectorAnaliticoValmerCSV

SELECT COUNT(*) FROM  [SAM_IMSS].[dbo].[VectorAnaliticoValmerCSV]
SELECT COUNT(*) FROM  [SAM_IMSS_WEB].[dbo].[VectorAnaliticoValmerCSV]


  SELECT * FROM [SAM_IMSS].[dbo].[VectorAnaliticoValmerCSV] EXCEPT
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[VectorAnaliticoValmerCSV] 
      
  SELECT * FROM [SAM_IMSS_WEB].[dbo].[VectorAnaliticoValmerCSV] EXCEPT
  SELECT * FROM [SAM_IMSS].[dbo].[VectorAnaliticoValmerCSV]
