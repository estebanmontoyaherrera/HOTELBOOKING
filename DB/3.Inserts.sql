USE HOTELBOOKINGDB;
GO

-- Insertar roles
INSERT INTO ROLES (NAME) VALUES ('Agente de Viajes');
INSERT INTO ROLES (NAME) VALUES ('Viajero');

-- Insertar permisos
INSERT INTO PERMISSIONS (NAME) VALUES 
('Listar Usuarios'),
('Crear Usuarios'),
('Actualizar Usuario'),
('Cambiar Estado de Usuario'),
('Eliminar Usuario'),
('Listar Hoteles'),
('Crear Hotel'),
('Actualizar Hotel'),
('Cambiar Estado de Hotel'),
('Eliminar Hotel'),
('Listar Ciudades'),
('Listar Roles'),
('Obtener Rol por ID'),
('Listar Habitaciones'),
('Crear Habitación'),
('Actualizar Habitación'),
('Cambiar Estado de Habitación'),
('Eliminar Habitación'),
('Listar Tipos de Habitación');

-- Asignar permisos a roles
INSERT INTO ROLEPERMISSIONS (ROLEID, PERMISSIONID) VALUES (1, 6); -- Agente de Viajes puede listar hoteles
INSERT INTO ROLEPERMISSIONS (ROLEID, PERMISSIONID) VALUES (1, 7); -- Agente de Viajes puede crear hoteles
INSERT INTO ROLEPERMISSIONS (ROLEID, PERMISSIONID) VALUES (1, 8); -- Agente de Viajes puede actualizar hoteles
INSERT INTO ROLEPERMISSIONS (ROLEID, PERMISSIONID) VALUES (1, 9); -- Agente de Viajes puede cambiar estado de hoteles
INSERT INTO ROLEPERMISSIONS (ROLEID, PERMISSIONID) VALUES (1, 10); -- Agente de Viajes puede eliminar hoteles
INSERT INTO ROLEPERMISSIONS (ROLEID, PERMISSIONID) VALUES (1, 14); -- Agente de Viajes puede listar habitaciones
INSERT INTO ROLEPERMISSIONS (ROLEID, PERMISSIONID) VALUES (1, 15); -- Agente de Viajes puede crear habitaciones
INSERT INTO ROLEPERMISSIONS (ROLEID, PERMISSIONID) VALUES (1, 16); -- Agente de Viajes puede actualizar habitaciones
INSERT INTO ROLEPERMISSIONS (ROLEID, PERMISSIONID) VALUES (1, 17); -- Agente de Viajes puede cambiar estado de habitaciones
INSERT INTO ROLEPERMISSIONS (ROLEID, PERMISSIONID) VALUES (1, 18); -- Agente de Viajes puede eliminar habitaciones
INSERT INTO ROLEPERMISSIONS (ROLEID, PERMISSIONID) VALUES (2, 6); -- Viajero puede listar hoteles

-- Insertar usuarios
INSERT INTO USERS (FIRSTNAME, LASTNAME, EMAIL, PASSWORD, ROLEID) 
VALUES ('Carlos', 'Pérez', 'agente@gmail.com', '$2a$11$OSiP6TZdNHEJN.cq38lA8OhF0JYC4/ghMOq7Zsg9iXFx1M2B5bti.', 1);--contraseña:12345
INSERT INTO USERS (FIRSTNAME, LASTNAME, EMAIL, PASSWORD, ROLEID) 
VALUES ('María', 'Gómez', 'viajero@gmail.com', '$2a$11$OSiP6TZdNHEJN.cq38lA8OhF0JYC4/ghMOq7Zsg9iXFx1M2B5bti.', 2);--contraseña:12345

-- Insertar ciudades en Colombia
INSERT INTO CITIES (NAME) VALUES ('Bogotá'), ('Medellín'), ('Cartagena');

-- Insertar hoteles
INSERT INTO HOTELS (NAME, ADDRESS, CITYID, COMMISSIONRATE) 
VALUES 
('Hotel El Dorado', 'Calle 26 # 69D-91', 1, 10.00),
('Hotel Poblado Plaza', 'Carrera 43A # 4 Sur-75', 2, 12.50);

-- Asignar hotel al agente de viajes
INSERT INTO USERHOTELS (USERID, HOTELID) VALUES (1, 1);

-- Insertar tipos de habitación
INSERT INTO ROOMTYPES (NAME) VALUES ('Individual'), ('Doble');

-- Insertar habitaciones
INSERT INTO ROOMS (HOTELID, ROOMTYPEID, BASECOST, TAXES, LOCATION) 
VALUES 
(1, 1, 200000.00, 30000.00, 'Piso 1'),
(1, 2, 350000.00, 50000.00, 'Piso 2');

-- Insertar tipos de documento y géneros
INSERT INTO DOCUMENTTYPES (NAME) VALUES ('Cédula de Ciudadanía'), ('Pasaporte');
INSERT INTO GENDERS (NAME) VALUES ('Masculino'), ('Femenino');

-- Insertar reserva
INSERT INTO RESERVATIONS (ROOMID, USERID, CHECKINDATE, CHECKOUTDATE, GUESTCOUNT, CITYID, TOTALCOST)
VALUES (1, 2, '2025-02-10', '2025-02-15', 1, 1, 230000.00);

-- Insertar huésped
INSERT INTO GUESTS (RESERVATIONID, FIRSTNAME, LASTNAME, BIRTHDATE, GENDERID, DOCUMENTTYPEID, DOCUMENTNUMBER, EMAIL, PHONE)
VALUES (1, 'María', 'Gómez', '1990-05-05', 2, 1, '1234567890', 'viajero@ejemplo.com', '320-456-7890');

-- Insertar contacto de emergencia
INSERT INTO EMERGENCYCONTACTS (RESERVATIONID, FULLNAME, PHONE)
VALUES (1, 'Carlos Pérez', '301-654-3210');


SELECT 
    P.NAME
FROM USERS U
INNER JOIN ROLES R ON U.ROLEID = R.ROLEID
INNER JOIN ROLEPERMISSIONS RP ON R.ROLEID = RP.ROLEID
INNER JOIN PERMISSIONS P ON RP.PERMISSIONID = P.PERMISSIONID
WHERE U.USERID = @USERID