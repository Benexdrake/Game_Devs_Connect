CREATE DATABASE Auth;
GO
USE Auth;
GO
CREATE TABLE [Auth]
(
	userid nvarchar(64) PRIMARY KEY,
	token nvarchar(128),
	expires BIGINT
);