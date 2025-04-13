ALTER TABLE [parqueAtraccion] ADD [parqueAtraccionShowFechaHora] datetime NOT NULL CONSTRAINT parqueAtraccionShowFechaHoraparqueAtraccion_DEFAULT DEFAULT convert( DATETIME, '17530101', 112 );
ALTER TABLE [parqueAtraccion] DROP CONSTRAINT parqueAtraccionShowFechaHoraparqueAtraccion_DEFAULT;

