CREATE TABLE [Vendedor] ([VendedorID] int NOT NULL IDENTITY(1,1), [VendedorNombre] nvarchar(80) NOT NULL , [PaisID] int NOT NULL , PRIMARY KEY([VendedorID]));
CREATE NONCLUSTERED INDEX [IVENDEDOR1] ON [Vendedor] ([PaisID] );

ALTER TABLE [Vendedor] ADD CONSTRAINT [IVENDEDOR1] FOREIGN KEY ([PaisID]) REFERENCES [Pais] ([PaisID]);

