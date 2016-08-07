DROP TABLE [CyberHelpUser]
DROP TABLE [CyberAlert]
DROP TABLE School
DROP TABLE ClassRoom


CREATE TABLE [School](
	SchoolID [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	SchoolName VARCHAR(250) NOT NULL
)

CREATE TABLE [ClassRoom](
	ClassRoomID [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	ClassRoomName VARCHAR(250) NOT NULL,
	SchoolID [bigint] NOT NULL,
	CONSTRAINT FK_ClassRoom_SchoolID_School FOREIGN KEY (SchoolID) REFERENCES School(SchoolID)
)


CREATE TABLE [CyberHelpUser](
	[CyberHelpUserID] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[FirstName] [varchar](120) NOT NULL,
	[LastName] [varchar](120) NOT NULL,
	[Login] VARCHAR(20) NOT NULL,
	[CyberHelpUserType] CHAR(1) NOT NULL DEFAULT 'S',
	ClassRoomID [bigint] NOT NULL,
	CyberHelpYear int NOT NULL,
	CONSTRAINT FK_CyberHelpUser_SchoolID_School FOREIGN KEY (ClassRoomID) REFERENCES ClassRoom(ClassRoomID)
)


CREATE TABLE [CyberAlert] (
	[CyberAlertID] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	RecordedDate DATETIME DEFAULT GETDATE(), 
	Coordinates VARCHAR(250),
	CyberAlertType CHAR(1) DEFAULT 'U',
	Comment VARCHAR(500),
	[CyberHelpUserID] [bigint] NOT NULL,
	StatusCode VARCHAR(3) NOT NULL DEFAULT 'N',
	CONSTRAINT FK_CyberAlert_CyberHelpUserID_CyberHelpUser FOREIGN KEY (CyberHelpUserID) REFERENCES CyberHelpUser(CyberHelpUserID)
)


ALTER TABLE CyberHelpUser ADD email VARCHAR(50)


----------------------

INSERT INTO [School] (SchoolName) VALUES ('Ecole à toto')
INSERT INTO [School] (SchoolName) VALUES ('Académie Provinciale des métiers ' )
INSERT INTO [School] (SchoolName) VALUES ('Athénée Royale Marguerite Bervoets') 
INSERT INTO [School] (SchoolName) VALUES ('Athénée Provincial Jean d’Avesnes' )
INSERT INTO [School] (SchoolName) VALUES ('Athénée Royal Mons 1'              )
INSERT INTO [School] (SchoolName) VALUES ('Ecole du futur ICES Quaregnon'     )
INSERT INTO [School] (SchoolName) VALUES ('Ecoles des religieuses Ursulines'  )
INSERT INTO [School] (SchoolName) VALUES ('Sacré Coeur de Mons'               )
INSERT INTO [School] (SchoolName) VALUES ('Institut Saint Ferdinand'          )
INSERT INTO [School] (SchoolName) VALUES ('Instituts Saint-Luc'               )
INSERT INTO [School] (SchoolName) VALUES ('Collège Saint Stanislas'           )

INSERT INTO [ClassRoom] ([ClassRoomName] ,[SchoolID]) VALUES ('A1',1)
INSERT INTO [ClassRoom] ([ClassRoomName] ,[SchoolID]) VALUES ('A2',1)
INSERT INTO [ClassRoom] ([ClassRoomName] ,[SchoolID]) VALUES ('A3',1)
INSERT INTO [ClassRoom] ([ClassRoomName] ,[SchoolID]) VALUES ('A4',1)


INSERT INTO [ClassRoom] ([ClassRoomName] ,[SchoolID]) VALUES ('BC1',2)
INSERT INTO [ClassRoom] ([ClassRoomName] ,[SchoolID]) VALUES ('BC2',2)
INSERT INTO [ClassRoom] ([ClassRoomName] ,[SchoolID]) VALUES ('BC3',2)
INSERT INTO [ClassRoom] ([ClassRoomName] ,[SchoolID]) VALUES ('BC4',2)


INSERT INTO [ClassRoom] ([ClassRoomName] ,[SchoolID]) VALUES ('CL1',3)
INSERT INTO [ClassRoom] ([ClassRoomName] ,[SchoolID]) VALUES ('CL2',3)
INSERT INTO [ClassRoom] ([ClassRoomName] ,[SchoolID]) VALUES ('CL3',3)
INSERT INTO [ClassRoom] ([ClassRoomName] ,[SchoolID]) VALUES ('CL4',3)
INSERT INTO [ClassRoom] ([ClassRoomName] ,[SchoolID]) VALUES ('CL5',3)
INSERT INTO [ClassRoom] ([ClassRoomName] ,[SchoolID]) VALUES ('CL6',3)

INSERT INTO [CyberHelpUser] ([Login] ,[FirstName] ,[LastName] ,[CyberHelpUserType]
           ,[ClassRoomID] ,[CyberHelpYear])
     VALUES ('mfiorito','Michael', 'Fiorito' ,'S' ,1, 5)

	 
INSERT INTO [CyberHelpUser] ([Login] ,[FirstName] ,[LastName] ,[CyberHelpUserType]
           ,[ClassRoomID] ,[CyberHelpYear])
     VALUES ('aclerbois','Adrien', 'Clerbois' ,'T' ,1, 0)


INSERT INTO [CyberHelpUser] ([Login] ,[FirstName] ,[LastName] ,[CyberHelpUserType]
           ,[ClassRoomID] ,[CyberHelpYear])
     VALUES ('shoutteman','Stephane', 'Houtteman' ,'T' ,2, 0)

	 	 
INSERT INTO [CyberHelpUser] ([Login] ,[FirstName] ,[LastName] ,[CyberHelpUserType]
           ,[ClassRoomID] ,[CyberHelpYear])
     VALUES ('dvoituron','Denis', 'Voituron' ,'S' ,1, 0)

INSERT INTO [CyberAlert] ([Coordinates]
           ,[CyberAlertType] ,[Comment] ,[CyberHelpUserID],[StatusCode])
     VALUES ('xxxx,xxxx' ,'U' ,'Racket récurrent' ,1 ,'N')

INSERT INTO [CyberAlert] ([Coordinates]
           ,[CyberAlertType] ,[Comment] ,[CyberHelpUserID],[StatusCode])
     VALUES ('xxxx,xxxx' ,'S' ,'Alerte niveau ecole' ,1 ,'N')
	 
	 INSERT INTO [CyberAlert] ([Coordinates]
           ,[CyberAlertType] ,[Comment] ,[CyberHelpUserID],[StatusCode])
     VALUES ('xxxx,xxxx' ,'M' ,'Alerte multi écoles' ,1 ,'N')
	 
	 INSERT INTO [CyberAlert] ([Coordinates]
           ,[CyberAlertType] ,[Comment] ,[CyberHelpUserID],[StatusCode])
     VALUES ('xxxx,xxxx' ,'U' ,'Vol de livre' ,1 ,'N')		   

	 select * from cyberalert

	 




