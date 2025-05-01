CREATE DATABASE GDC;
GO
USE GDC;

GO
CREATE TABLE [Users]
(
	id nvarchar(64) PRIMARY KEY,
	username nvarchar(128),
	avatar nvarchar(128),
	accounttype nvarchar(64)
);

GO
CREATE TABLE [Profiles]
(
	id nvarchar(64) PRIMARY KEY,
	user_id nvarchar(64) FOREIGN KEY REFERENCES Users(id),
	discord_url nvarchar(64),
	x_url nvarchar(64),
	website_url nvarchar(64),
	email nvarchar(64),
	show_discord tinyint,
	show_x tinyint,
	show_website tinyint,
	show_email tinyint
);

GO
CREATE TABLE [Projects]
(
	id nvarchar(64) PRIMARY KEY,
	title nvarchar(128),
	description nvarchar(max),
	owner_id nvarchar(64) FOREIGN KEY REFERENCES Users(id)
);

GO
CREATE TABLE [Project_Team]
(
	project_id nvarchar(64) FOREIGN KEY REFERENCES Projects(id),
	team_member_id nvarchar(64) FOREIGN KEY REFERENCES Users(id)
);

GO
CREATE TABLE [Tags]
(
	id Integer PRIMARY KEY Identity(1,1),
	tag nvarchar(128)
);

GO
CREATE TABLE [Files]
(
	id nvarchar(64) PRIMARY KEY,
	[description] nvarchar(max),
	size integer,
	created nvarchar(128),
	owner_id nvarchar(64) FOREIGN KEY REFERENCES Users(id)
);

GO
CREATE TABLE [Requests]
(
	id nvarchar(64) PRIMARY KEY,
	title nvarchar(128),
	description nvarchar(max),
	created nvarchar(128),
	project_id nvarchar(64) FOREIGN KEY REFERENCES Projects(id),
	owner_id nvarchar(64) FOREIGN KEY REFERENCES Users(id),
	file_id nvarchar(64) FOREIGN KEY REFERENCES Files(id)
);

GO
CREATE TABLE [Request_Tag]
(
	request_id nvarchar(64) FOREIGN KEY REFERENCES Requests(id), 
	tag_id integer FOREIGN KEY REFERENCES Tags(id)
);

GO
CREATE TABLE [Request_Like]
(
	request_id nvarchar(64) FOREIGN KEY REFERENCES Requests(id), 
	owner_id nvarchar(64) FOREIGN KEY REFERENCES Users(id)
);

GO
CREATE TABLE [Notifications]
(
	id integer PRIMARY KEY Identity(1,1),
	request_id nvarchar(64) FOREIGN KEY REFERENCES Requests(id), 
	[type] integer,
	owner_id nvarchar(64) FOREIGN KEY REFERENCES Users(id),
	user_id nvarchar(64) FOREIGN KEY REFERENCES Users(id),
	seen tinyint,
	created nvarchar(128)
);

GO
CREATE TABLE [Comments]
(
	id nvarchar(64) PRIMARY KEY,
	message nvarchar(max),
	request_id nvarchar(64) FOREIGN KEY REFERENCES Requests(id),
	file_id nvarchar(64) FOREIGN KEY REFERENCES Files(id),
	owner_id nvarchar(64) FOREIGN KEY REFERENCES Users(id),
	created nvarchar(128),
	deleted tinyint
);

GO
INSERT INTO [dbo].Tags (tag) values
('2D'),
('3D'),
('Animation'),
('Model'),
('Low Poly'),
('High Poly');