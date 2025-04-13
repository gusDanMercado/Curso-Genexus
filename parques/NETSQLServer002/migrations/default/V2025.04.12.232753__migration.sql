CREATE TABLE [GXA0004] ([ShowId] smallint NOT NULL IDENTITY(1,1), [ShowNombre] nvarchar(40) NOT NULL , [ShowImagen] VARBINARY(MAX) NOT NULL , [ShowImagen_GXI] varchar(2048) NULL );
Run conversion program for table Show;
DROP TABLE [Show];
sp_rename '[GXA0004]', 'Show';
ALTER TABLE [Show] ADD PRIMARY KEY([ShowId]);

ALTER TABLE [parqueAtraccion] ADD CONSTRAINT [IPARQUEATRACCION1] FOREIGN KEY ([PaisId]) REFERENCES [Pais] ([PaisId]);
ALTER TABLE [parqueAtraccion] ADD CONSTRAINT [IPARQUEATRACCION2] FOREIGN KEY ([ShowId]) REFERENCES [Show] ([ShowId]);

