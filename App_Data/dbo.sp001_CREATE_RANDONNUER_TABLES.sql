CREATE PROCEDURE sp001_CREATE_RANDONNUER_TABLES

AS

-- Create tables for Randonneur database


CREATE TABLE Brevet
(
  brevetID INTEGER NOT NULL, 
  distance INTEGER NOT NULL,
  brevetDate DATE NOT NULL,
  location VARCHAR(50) NOT NULL,
  climbing INTEGER


  CONSTRAINT PK_Brevet PRIMARY KEY (brevetID),
  CONSTRAINT CHK_brevetID CHECK(brevetID BETWEEN 1 AND 9999),
  constraint chk_distance check (distance = 200 OR distance = 300 OR distance = 400 OR distance = 600 OR distance = 1000 OR distance = 1200),
  CONSTRAINT CHK_climbing CHECK(climbing BETWEEN 0 AND 99999)
);


CREATE TABLE Club
(
  clubId INTEGER NOT NULL, 
  clubName VARCHAR (50) Not null, 
  city varchar (50) not null, 
  email varchar(50) not null

  CONSTRAINT PK_Culb PRIMARY KEY (clubId),
  constraint AK_clubName UNIQUE (clubName),
  constraint CHK_clubId CHECK (clubId BETWEEN 50 AND 4999)
);

CREATE TABLE Rider
(
  riderId integer not null,
  familyName varchar(50) not null, 
  givenName varchar (50) not null,
  gender char (1) not null,
  phone varchar(50)  not null,
  email varchar(50)  not null,
  clubId integer not null,
  username  varchar(20)  not null,
  password varchar(20)  not null,
  role varchar(20)  not null,

  constraint PK_Rider primary key (riderId),
  constraint FK_Rider_Club foreign key (clubId) REFERENCES Club (clubId),
  constraint AK_Rider Unique (username), 
  constraint CHK_riderId check (riderId BETWEEN 10 AND 99999),
  constraint CHK_gender check (gender = 'M' OR gender = 'F'),
  constraint CHK_role check (role = 'user' OR role = 'admin')
);

CREATE TABLE Brevet_Rider
(
  riderID INTEGER  NOT NULL,
  brevetID INTEGER	NOT NULL,
  isCompleted CHAR(1) NOT NULL, 
  finishingTime CHAR(5) 
  
  CONSTRAINT PK_Brevet_Rider PRIMARY KEY (riderID, brevetID)
  CONSTRAINT FK_Brevet_Rider_Brevet Foreign key (brevetID) REFERENCES Brevet(brevetID),
  constraint FK_Brevet_Rider_Rider Foreign key (riderID) references Rider (riderId),
  CONSTRAINT CHK_isCompleted CHECK(isCompleted = 'Y' OR isCompleted = 'N' )

);

-- Finally, display a message
IF (@@Error = 0) 
  BEGIN
    PRINT '======================================'
    PRINT ' TAKKULA TABLES CREATED SUCCESSFULLY.'
    PRINT '======================================'
    PRINT ' '
  END

-- End --