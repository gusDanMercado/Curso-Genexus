ALTER TABLE [TarjetaDePuntos] ADD [ClienteID] int NOT NULL CONSTRAINT ClienteIDTarjetaDePuntos_DEFAULT DEFAULT 1;
ALTER TABLE [TarjetaDePuntos] DROP CONSTRAINT ClienteIDTarjetaDePuntos_DEFAULT;
SET IDENTITY_INSERT [Pais] ON;
INSERT INTO [Pais] ([PaisID], [PaisNombre], [PaisBandera]) SELECT TOP 1 1, ' ', CONVERT(varbinary(1), '') FROM [TarjetaDePuntos] WHERE NOT EXISTS (SELECT 1 FROM [Pais] WHERE PaisID=1);
SET IDENTITY_INSERT [Pais] OFF;
SET IDENTITY_INSERT [Cliente] ON;
INSERT INTO [Cliente] ([ClienteID], [ClienteNombre], [PaisID], [ClienteDireccion], [ClienteEmail], [ClienteTelefono]) SELECT TOP 1 1, ' ', 1, ' ', ' ', ' ' FROM [TarjetaDePuntos] WHERE NOT EXISTS (SELECT 1 FROM [Cliente] WHERE ClienteID=1);
SET IDENTITY_INSERT [Cliente] OFF;
CREATE NONCLUSTERED INDEX [ITARJETADEPUNTOS1] ON [TarjetaDePuntos] ([ClienteID] );

ALTER TABLE [TarjetaDePuntos] ADD CONSTRAINT [ITARJETADEPUNTOS1] FOREIGN KEY ([ClienteID]) REFERENCES [Cliente] ([ClienteID]);

