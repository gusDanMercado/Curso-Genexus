CREATE TABLE [CarritoDetalleCompra] ([CarritoID] int NOT NULL , [CarritoDetalleCompraID] int NOT NULL , [ProductoID] int NOT NULL , [CarritoDetalleCompraCantidadUn] smallint NOT NULL , [CarritoDetalleCompraCostoTotal] smallmoney NOT NULL , PRIMARY KEY([CarritoID], [CarritoDetalleCompraID]));
CREATE NONCLUSTERED INDEX [ICARRITODETALLECOMPRA1] ON [CarritoDetalleCompra] ([ProductoID] );

CREATE TABLE [Carrito] ([CarritoID] int NOT NULL IDENTITY(1,1), [CarritoFchCompra] datetime NOT NULL , [CarritoFchEntrega] datetime NOT NULL , [ClienteID] int NOT NULL , [CarritoCostoTotalCompra] smallmoney NOT NULL , PRIMARY KEY([CarritoID]));
CREATE NONCLUSTERED INDEX [ICARRITO1] ON [Carrito] ([ClienteID] );

ALTER TABLE [Carrito] ADD CONSTRAINT [ICARRITO1] FOREIGN KEY ([ClienteID]) REFERENCES [Cliente] ([ClienteID]);

ALTER TABLE [CarritoDetalleCompra] ADD CONSTRAINT [ICARRITODETALLECOMPRA2] FOREIGN KEY ([CarritoID]) REFERENCES [Carrito] ([CarritoID]);
ALTER TABLE [CarritoDetalleCompra] ADD CONSTRAINT [ICARRITODETALLECOMPRA1] FOREIGN KEY ([ProductoID]) REFERENCES [Producto] ([ProductoID]);

