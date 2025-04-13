ALTER TABLE [Empleado] ADD [parqueAtraccionId] smallint NOT NULL CONSTRAINT parqueAtraccionIdEmpleado_DEFAULT DEFAULT 1;
ALTER TABLE [Empleado] DROP CONSTRAINT parqueAtraccionIdEmpleado_DEFAULT;
SET IDENTITY_INSERT [Show] ON;
INSERT INTO [Show] ([ShowId], [ShowNombre], [ShowImagen]) SELECT TOP 1 1, ' ', CONVERT(varbinary(1), '') FROM [Empleado] WHERE NOT EXISTS (SELECT 1 FROM [Show] WHERE ShowId=1);
SET IDENTITY_INSERT [Show] OFF;
SET IDENTITY_INSERT [Pais] ON;
INSERT INTO [Pais] ([PaisId], [PaisNombre]) SELECT TOP 1 1, ' ' FROM [Empleado] WHERE NOT EXISTS (SELECT 1 FROM [Pais] WHERE PaisId=1);
SET IDENTITY_INSERT [Pais] OFF;
SET IDENTITY_INSERT [parqueAtraccion] ON;
INSERT INTO [parqueAtraccion] ([parqueAtraccionId], [parqueAtraccionNombre], [parqueAtraccionSitioWeb], [parqueAtraccionDireccion], [parqueAtraccionFoto], [parqueAtraccionFoto_GXI], [PaisId], [ShowId], [parqueAtraccionShowFechaHora]) SELECT TOP 1 1, ' ', ' ', ' ', CONVERT(varbinary(1), ''), ' ', 1, 1, convert( DATETIME, '1753-1-1 0:0:0', 120) FROM [Empleado] WHERE NOT EXISTS (SELECT 1 FROM [parqueAtraccion] WHERE parqueAtraccionId=1);
SET IDENTITY_INSERT [parqueAtraccion] OFF;
CREATE NONCLUSTERED INDEX [IEMPLEADO1] ON [Empleado] ([parqueAtraccionId] );

ALTER TABLE [Empleado] ADD CONSTRAINT [IEMPLEADO1] FOREIGN KEY ([parqueAtraccionId]) REFERENCES [parqueAtraccion] ([parqueAtraccionId]);

