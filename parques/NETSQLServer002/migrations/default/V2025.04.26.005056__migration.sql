DROP INDEX [IEMPLEADO1] ON [Empleado];
ALTER TABLE [Empleado] DROP CONSTRAINT [IEMPLEADO1];
ALTER TABLE [Empleado] ALTER COLUMN [parqueAtraccionId] smallint NULL;
CREATE NONCLUSTERED INDEX [IEMPLEADO1] ON [Empleado] ([parqueAtraccionId] );

ALTER TABLE [Empleado] ADD CONSTRAINT [IEMPLEADO1] FOREIGN KEY ([parqueAtraccionId]) REFERENCES [parqueAtraccion] ([parqueAtraccionId]);

