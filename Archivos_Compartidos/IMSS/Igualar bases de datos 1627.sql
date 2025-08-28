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
  