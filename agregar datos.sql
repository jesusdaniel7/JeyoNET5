--Insertar sexo, tipo de ingreso, tipo de egreso, tipo unidad, unidad, medico.

INSERT INTO Sexo VALUES ('Masculino')
INSERT INTO Sexo VALUES ('Femenino')
go

INSERT INTO TipoIngresos VALUES ('Ingreso programado')
INSERT INTO TipoIngresos VALUES ('Ingreso por urgencias')
INSERT INTO TipoIngresos VALUES ('Ingreso intrahospitalario')
go

INSERT INTO TipoEgresos VALUES ('Egreso por mejoria')
INSERT INTO TipoEgresos VALUES ('Egreso voluntario')
INSERT INTO TipoEgresos VALUES ('Egreso por fuga')
INSERT INTO TipoEgresos VALUES ('Egreso por traslado')
INSERT INTO TipoEgresos VALUES ('Egreso por defuncion')
go


INSERT INTO TipoUnidad VALUES ('Intensivo')
INSERT INTO TipoUnidad VALUES ('Atencion basica')
INSERT INTO TipoUnidad VALUES ('Atencion compleja')
go

INSERT INTO Unidades VALUES (2, 41, 1 )
go

INSERT INTO Medicos VALUES ('Carlos', 'Perez', '1979-02-10 01:02:00', 1, 'Dominicana', '402-1688902-1', 'carlosperez@medico.com', '829-291-0291')
go
