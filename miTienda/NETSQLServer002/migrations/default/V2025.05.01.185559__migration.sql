ALTER TABLE [Vendedor] ADD [VendedorFoto] VARBINARY(MAX) NOT NULL CONSTRAINT VendedorFotoVendedor_DEFAULT DEFAULT CONVERT(varbinary(1), ''), [VendedorFoto_GXI] varchar(2048) NOT NULL CONSTRAINT VendedorFoto_GXIVendedor_DEFAULT DEFAULT '';
ALTER TABLE [Vendedor] DROP CONSTRAINT VendedorFotoVendedor_DEFAULT;
ALTER TABLE [Vendedor] DROP CONSTRAINT VendedorFoto_GXIVendedor_DEFAULT;

