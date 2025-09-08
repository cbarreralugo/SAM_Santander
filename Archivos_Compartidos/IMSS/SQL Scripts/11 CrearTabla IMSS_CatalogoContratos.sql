-- En la BD SAM_IMSS (o la que uses para IMSS_SAM_Web)
-- Esquema por defecto: dbo

IF OBJECT_ID('dbo.IMSS_CatalogoContratos') IS NULL
BEGIN
    CREATE TABLE dbo.IMSS_CatalogoContratos (
        IdCatContrato INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        NumContrato   VARCHAR(50) NOT NULL,   -- N° de contrato “interno”/referencia que recibes
        ContratoBBVA  VARCHAR(50) NOT NULL    -- N° de contrato que requiere BBVA en el layout
    );

    -- Recomendado: evitar duplicados por NumContrato y (opcional) por ContratoBBVA
    CREATE UNIQUE INDEX UX_IMSS_CatalogoContratos_NumContrato
        ON dbo.IMSS_CatalogoContratos(NumContrato);

    -- Opcional (solo si BBVA te exige unicidad también en este campo)
    -- CREATE UNIQUE INDEX UX_IMSS_CatalogoContratos_ContratoBBVA
    --     ON dbo.IMSS_CatalogoContratos(ContratoBBVA);
END
GO
