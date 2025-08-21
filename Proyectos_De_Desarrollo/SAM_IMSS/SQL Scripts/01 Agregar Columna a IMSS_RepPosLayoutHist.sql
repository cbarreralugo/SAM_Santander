
  -- Agregar columna Contrato al histórico (si no existe)
IF COL_LENGTH('dbo.IMSS_RepPosLayoutHist', 'Contrato') IS NULL
BEGIN
    ALTER TABLE dbo.IMSS_RepPosLayoutHist
    ADD Contrato VARCHAR(50) NULL;
END
GO