﻿-- Crear la base de datos
USE MASTER
GO
CREATE DATABASE HOTELBOOKINGDB;
GO
-- Usar la base de datos
USE HOTELBOOKINGDB;
GO

-- Tabla ROLES
CREATE TABLE ROLES
(
    ROLEID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    NAME VARCHAR(100) NOT NULL
);
GO

-- Tabla PERMISSIONS
CREATE TABLE PERMISSIONS
(
    PERMISSIONID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    NAME VARCHAR(150) NOT NULL
);
GO

-- Tabla ROLEPERMISSIONS
CREATE TABLE ROLEPERMISSIONS
(
    ROLEID INT NOT NULL,
    PERMISSIONID INT NOT NULL,
    PRIMARY KEY (ROLEID, PERMISSIONID),
    FOREIGN KEY (ROLEID) REFERENCES ROLES(ROLEID),
    FOREIGN KEY (PERMISSIONID) REFERENCES PERMISSIONS(PERMISSIONID)
);
GO

-- Tabla USERS
CREATE TABLE USERS
(
    USERID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    FIRSTNAME VARCHAR(50) NOT NULL,
    LASTNAME VARCHAR(50) NOT NULL,
    EMAIL VARCHAR(255) UNIQUE NOT NULL,
    PASSWORD VARCHAR(MAX) NOT NULL,
    ROLEID INT NOT NULL,
    STATE INT NOT NULL DEFAULT 1,
    AUDITCREATEDATE DATETIME2(7) DEFAULT GETDATE(),
    FOREIGN KEY (ROLEID) REFERENCES ROLES(ROLEID)
);
GO

-- Tabla CITIES
CREATE TABLE CITIES
(
    CITYID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    NAME VARCHAR(100) NOT NULL
);
GO

-- Tabla HOTELS
CREATE TABLE HOTELS
(
    HOTELID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    NAME VARCHAR(100) NOT NULL,
    ADDRESS VARCHAR(255) NOT NULL,
    CITYID INT NOT NULL,
    COMMISSIONRATE DECIMAL(18,2) DEFAULT 0.00, --  campo para comisión
    STATE INT NOT NULL DEFAULT 1,
    AUDITCREATEDATE DATETIME2(7) DEFAULT GETDATE(),    
    FOREIGN KEY (CITYID) REFERENCES CITIES(CITYID)
);
GO
--Tabla USERHOTELS
--Puede usarse para asignar cualquier tipo de usuario (agentes, administradores, auditores, etc.) a un hotel.
CREATE TABLE USERHOTELS (
    USERID INT NOT NULL,
    HOTELID INT NOT NULL,
	IS_PREFERRED BIT DEFAULT 1,
    PRIMARY KEY (USERID, HOTELID),
    FOREIGN KEY (USERID) REFERENCES USERS(USERID),
    FOREIGN KEY (HOTELID) REFERENCES HOTELS(HOTELID)
);
GO

-- Tabla ROOMTYPES
CREATE TABLE ROOMTYPES
(
    ROOMTYPEID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    NAME VARCHAR(50) NOT NULL
);
GO

-- Tabla ROOMS
CREATE TABLE ROOMS 
(
    ROOMID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    HOTELID INT NOT NULL,
    ROOMTYPEID INT NOT NULL,
	CAPACITY INT  DEFAULT 1,
    BASECOST DECIMAL(18,2) NOT NULL,
    TAXES DECIMAL(18,2) NOT NULL,
    LOCATION VARCHAR(100) NOT NULL,
    STATE INT NOT NULL DEFAULT 1,
    AUDITCREATEDATE DATETIME2(7) DEFAULT GETDATE(),   
    FOREIGN KEY (HOTELID) REFERENCES HOTELS(HOTELID),
    FOREIGN KEY (ROOMTYPEID) REFERENCES ROOMTYPES(ROOMTYPEID)
);
GO


-- Tabla DOCUMENTTYPES
CREATE TABLE DOCUMENTTYPES
(
    DOCUMENTTYPEID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    NAME VARCHAR(50) NOT NULL
);
GO

-- Tabla GENDERS
CREATE TABLE GENDERS
(
    GENDERID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    NAME VARCHAR(20) NOT NULL UNIQUE
);
GO

-- Tabla RESERVATIONS
CREATE TABLE RESERVATIONS
(
    RESERVATIONID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    ROOMID INT NOT NULL,
    USERID INT NOT NULL,
    CHECKINDATE DATETIME2(7) NOT NULL,
    CHECKOUTDATE DATETIME2(7) NOT NULL,  
    STATE INT NOT NULL DEFAULT 1,
    AUDITCREATEDATE DATETIME2(7) DEFAULT GETDATE(),
    FOREIGN KEY (ROOMID) REFERENCES ROOMS(ROOMID),
    FOREIGN KEY (USERID) REFERENCES USERS(USERID)
   
);
GO


-- Tabla GUESTS
CREATE TABLE GUESTS
(
    GUESTID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    RESERVATIONID INT NOT NULL,
    FIRSTNAME VARCHAR(50) NOT NULL,
    LASTNAME VARCHAR(50) NOT NULL,
    BIRTHDATE DATE NOT NULL,
    GENDERID INT NOT NULL,
    DOCUMENTTYPEID INT NOT NULL,
    DOCUMENTNUMBER VARCHAR(50) NOT NULL,
    EMAIL VARCHAR(255),
    PHONE VARCHAR(15),
    FOREIGN KEY (RESERVATIONID) REFERENCES RESERVATIONS(RESERVATIONID),
    FOREIGN KEY (DOCUMENTTYPEID) REFERENCES DOCUMENTTYPES(DOCUMENTTYPEID),
    FOREIGN KEY (GENDERID) REFERENCES GENDERS(GENDERID)
);
GO

-- Tabla EMERGENCYCONTACTS
CREATE TABLE EMERGENCYCONTACTS
(
    EMERGENCYCONTACTID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    RESERVATIONID INT NOT NULL,
    FULLNAME VARCHAR(100) NOT NULL,
    PHONE VARCHAR(15) NOT NULL,
    FOREIGN KEY (RESERVATIONID) REFERENCES RESERVATIONS(RESERVATIONID)
);
GO

-- Tabla NOTIFICATIONS (con soporte para tracking de correos)
CREATE TABLE NOTIFICATIONS
(
    NOTIFICATIONID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    USERID INT NOT NULL,
    MESSAGE VARCHAR(MAX) NOT NULL,
    ISEMAILSENT BIT NOT NULL DEFAULT 0, -- Nuevo campo para rastrear envío
    SENTDATE DATETIME2(7) DEFAULT GETDATE(),
    FOREIGN KEY (USERID) REFERENCES USERS(USERID)
);
GO



CREATE OR ALTER TRIGGER trg_AfterInsertReservation
ON RESERVATIONS
AFTER INSERT
AS
BEGIN


    INSERT INTO NOTIFICATIONS (USERID, MESSAGE, ISEMAILSENT, SENTDATE)
    SELECT 
        i.USERID, 
        CONCAT(
            'Reserva confirmada en ', h.NAME, ' (', h.ADDRESS, '). ',
            'Fecha de entrada: ', FORMAT(i.CHECKINDATE, 'yyyy-MM-dd'), 
            ', Fecha de salida: ', FORMAT(i.CHECKOUTDATE, 'yyyy-MM-dd'), 
            '. Habitación en ', r.LOCATION, '. ',

            -- Cálculo correcto del total
            'Total a pagar: $', 
            FORMAT(ROUND((r.BASECOST + r.TAXES) * 
            (DATEDIFF(DAY, CAST(i.CHECKINDATE AS DATE), CAST(i.CHECKOUTDATE AS DATE))), 2), 'N2')
        ), 
        0,  
        GETDATE()
    FROM inserted i
    INNER JOIN ROOMS r ON i.ROOMID = r.ROOMID
    INNER JOIN HOTELS h ON r.HOTELID = h.HOTELID
    WHERE DATEDIFF(DAY, CAST(i.CHECKINDATE AS DATE), CAST(i.CHECKOUTDATE AS DATE)) > 0;
END;
GO









