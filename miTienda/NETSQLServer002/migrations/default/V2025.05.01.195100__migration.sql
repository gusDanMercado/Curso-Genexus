CREATE TABLE [Producto] ([ProductoID] int NOT NULL IDENTITY(1,1), [ProductoNombre] nvarchar(80) NOT NULL , [ProductoDescripcion] nvarchar(80) NOT NULL , [ProductoPrecio] smallmoney NOT NULL , [ProductoImagen] VARBINARY(MAX) NOT NULL , [ProductoImagen_GXI] varchar(2048) NOT NULL , [VendedorID] int NOT NULL , [CategoriaID] int NOT NULL , PRIMARY KEY([ProductoID]));
CREATE NONCLUSTERED INDEX [IPRODUCTO1] ON [Producto] ([CategoriaID] );
CREATE NONCLUSTERED INDEX [IPRODUCTO2] ON [Producto] ([VendedorID] );

ALTER TABLE [Producto] ADD CONSTRAINT [IPRODUCTO2] FOREIGN KEY ([VendedorID]) REFERENCES [Vendedor] ([VendedorID]);
ALTER TABLE [Producto] ADD CONSTRAINT [IPRODUCTO1] FOREIGN KEY ([CategoriaID]) REFERENCES [Categoria] ([CategoriaID]);

