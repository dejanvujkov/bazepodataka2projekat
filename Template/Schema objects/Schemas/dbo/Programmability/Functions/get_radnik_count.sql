CREATE FUNCTION [dbo].[get_radnik_count]
(
	@idstanice INT
)
RETURNS INT
AS
BEGIN

DECLARE @tabela TABLE(
	idStanice INT,
	brojRadnika INT
);
	INSERT INTO @tabela
	SELECT @idStanice, COUNT(r.jmbg)
	FROM autobuska_stanica a JOIN radnik r ON @idstanice = r.autobuska_stanica_idstanice
	GROUP BY a.idstanice
	
	RETURN (SELECT TOP 1 brojRadnika
	FROM @tabela)
END
