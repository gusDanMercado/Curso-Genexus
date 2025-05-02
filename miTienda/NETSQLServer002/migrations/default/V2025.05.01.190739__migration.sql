CREATE TABLE [Cliente] ([ClienteID] int NOT NULL IDENTITY(1,1), [ClienteNombre] nvarchar(80) NOT NULL , [PaisID] int NOT NULL , [ClienteDireccion] nvarchar(1024) NOT NULL , [ClienteEmail] nvarchar(100) NOT NULL , [ClienteTelefono] nchar(20) NOT NULL , PRIMARY KEY([ClienteID]));
CREATE NONCLUSTERED INDEX [ICLIENTE1] ON [Cliente] ([PaisID] );

ALTER TABLE [Cliente] ADD CONSTRAINT [ICLIENTE1] FOREIGN KEY ([PaisID]) REFERENCES [Pais] ([PaisID]);

