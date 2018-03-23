CREATE TRIGGER [insert_autobus_trigger]
ON [dbo].[autobus]
INSTEAD OF INSERT
AS

DECLARE @brTablica VARCHAR(10);
DECLARE @brMesta INT;
DECLARE @ispravan VARCHAR(10);
DECLARE @marka VARCHAR(30);
DECLARE @kilometri INT;

SELECT @brTablica = i.brtablica FROM inserted i;
SELECT @brMesta = i.brojmesta FROM inserted i;
select @ispravan = i.ispravan from inserted i;
select @marka = i.marka from inserted i;
select @kilometri = i.kilometri from inserted i;

IF(@kilometri > 9999)
	BEGIN
	SET @ispravan = 'ne';
	END
ELSE
	BEGIN
	SET @ispravan = 'da';
	END

INSERT INTO [dbo].[autobus] 
(brtablica, brojmesta, ispravan, marka, kilometri)
VALUES(@brTablica, @brMesta, @ispravan, @marka, @kilometri);