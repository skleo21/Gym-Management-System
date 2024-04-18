--CREATE TABLE clientes (
--	idcli INT IDENTITY PRIMARY KEY,
--	ncliente NVARCHAR (50) NOT NULL,
--	datanasC	DATE,
--	idade AS datediff(YEAR,datanasc, GETDATE()),
--	foto NVARCHAR(50)
--);

GO
--INSERT INTO clientes(ncliente,datanasc)
--VALUES( 'Mário','1999-02-05'),
--( 'José','1992-01-06'),
--( 'Dinis','1995-05-21'),
--( 'Fernando','1997-12-30'),
--( 'Miguel','1999-08-13'),
--( 'RIcardo','1993-06-24');

--GO
--SELECT * FROM clientes;

--CREATE TABLE ptrainer(
--  idpt int IDENTITY PRIMARY key,
--  ptrainer NVARCHAR (50) NOT NULL,
--  especialidade NVARCHAR(50)NOT NULL,
--  xp INT CHECK(xp BETWEEN 1950 AND YEAR(GETDATE())) DEFAULT YEAR(GETDATE()),
--  idade DATE,
--  ptrainerfoto varbinary(max),
--  phora decimal(10,2)
--);

--GO
--CREATE TABLE especialidades(
--  especialidade NCHAR(20)PRIMARY key
--);
--INSERT INTO especialidades (especialidade)VALUES('Cardio'),('Musculação'),('Flexibilidade'), ('Resistencia'), ('Combate') ;

--SELECT * FROM especialidades

GO
--ALTER TABLE ptrainer ALTER COLUMN especialidade NCHAR(20)
--ALTER TABLE ptrainer ADD CONSTRAINT fkptraineresp FOREIGN KEY (especialidade)
--     REFERENCES especialidades(especialidade) ON UPDATE CASCADE ON DELETE cascade;

GO
--INSERT INTO ptrainer(ptrainer)
--VALUES( 'Mário'),
--( 'Ana'),
--( 'Leonardo'),
--( 'Maria'),
--( 'Nuno'),
--( 'Bernardo');

--UPDATE ptrainer 
--SET 
--    especialidade = 'Flexibilidade',
--    idade = '1982-05-21',
--    phora = '12'
--WHERE
--    idpt = 1;

--SELECT * FROM ptrainer

--ALTER TABLE ptrainer ALTER COLUMN xp INT

--SELECT * FROM ptrainer

--UPDATE ptrainer 
--SET 
--    especialidade = 'Musculação',
--    idade = '1988-07-01',
--    phora = '25'
--WHERE
--    idpt = 2;

--UPDATE ptrainer 
--SET 
--    especialidade = 'Cardio',
--    idade = '1990-10-15',
--    phora = 20
--WHERE
--    idpt = 3;

--UPDATE ptrainer 
--SET 
--    especialidade = 'Resistencia',
--    idade = '1990-11-09',
--    phora = '5'
--WHERE
--    idpt = 4;


--UPDATE ptrainer 
--SET 
--    especialidade = 'Combate',
--    idade = '1984-04-20',
--    phora = 30.50
--WHERE
--    idpt = 5;

--UPDATE ptrainer 
--SET 
--    especialidade = 'Musculação',
--    idade = '1991-03-31',
--    phora = 22.70
--WHERE
--    idpt = 6;

GO

--CREATE TABLE reservas (
--  idreserva INT IDENTITY PRIMARY KEY,
--  idpt INT FOREIGN KEY REFERENCES ptrainer(idpt),
--  idcli INT FOREIGN KEY REFERENCES clientes(idcli),
--  datainicio DATETIME default CURRENT_TIMESTAMP,
--  datafinal DATETIME,
--  tempo AS DATEDIFF(minute ,datainicio,datafinal) ,
--  custo DECIMAL(10,2)
--);


--INSERT INTO reservas(idpt,idcli)SELECT idpt,idcli FROM ptrainer,clientes;
--SELECT * FROM reservas;

--GO
--CREATE TRIGGER trg_one
--ON reservas
--FOR INSERT,UPDATE
--AS
--BEGIN
--	DECLARE @idreserva INT, @idpt INT ,@idcli INT ,@tempo INT,@phora DECIMAL(10,2);
--	SELECT @idreserva=idreserva, @idpt=idpt, @idcli=idcli , @tempo=tempo FROM inserted
--    SELECT @phora =phora FROM ptrainer WHERE idpt =@idpt;
--	UPDATE reservas SET custo = (@phora *@tempo)/60 WHERE idreserva=@idreserva;
--END

--GO
--ALTER TRIGGER trg_one
--ON reservas
--FOR INSERT,UPDATE
--AS
--BEGIN
--	DECLARE @idreserva INT, @idpt INT ,@idcli INT ,@tempo INT,@phora DECIMAL(10,2);
--	SELECT @idreserva=idreserva, @idpt=idpt, @idcli=idcli , @tempo=tempo FROM inserted
--    SELECT @phora =phora FROM trainers WHERE idpt =@idpt;
--	UPDATE reservas SET custo = (@phora *@tempo)/60 WHERE idreserva=@idreserva;
--END

GO
ALTER TABLE trainers ALTER COLUMN ptrainerfoto NVARCHAR;