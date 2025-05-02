CREATE TABLE [GXA0007] ([ProductoID] int NOT NULL IDENTITY(1,1), [ProductoNombre] nvarchar(80) NOT NULL , [ProductoDescripcion] nvarchar(80) NOT NULL , [ProductoPrecio] smallmoney NOT NULL , [ProductoImagen] VARBINARY(MAX) NOT NULL , [ProductoImagen_GXI] varchar(2048) NOT NULL , [VendedorID] int NOT NULL , [CategoriaID] int NOT NULL , [ProductoPaisID] int NOT NULL );
Run conversion program for table Producto;
DROP TABLE [Producto];
sp_rename '[GXA0007]', 'Producto';
ALTER TABLE [Producto] ADD PRIMARY KEY([ProductoID]);
CREATE NONCLUSTERED INDEX [IPRODUCTO1] ON [Producto] ([CategoriaID] );
CREATE NONCLUSTERED INDEX [IPRODUCTO2] ON [Producto] ([VendedorID] );
CREATE NONCLUSTERED INDEX [IPRODUCTO3] ON [Producto] ([ProductoPaisID] );

ALTER TABLE [Producto] ADD CONSTRAINT [IPRODUCTO2] FOREIGN KEY ([VendedorID]) REFERENCES [Vendedor] ([VendedorID]);
ALTER TABLE [Producto] ADD CONSTRAINT [IPRODUCTO1] FOREIGN KEY ([CategoriaID]) REFERENCES [Categoria] ([CategoriaID]);
ALTER TABLE [Producto] ADD CONSTRAINT [IPRODUCTO3] FOREIGN KEY ([ProductoPaisID]) REFERENCES [Pais] ([PaisID]);

