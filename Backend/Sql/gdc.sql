drop table if exists user;
drop table if exists project;
drop table if exists project_team;
drop table if exists tag;
drop table if exists request;
drop table if exists comment;
drop table if exists request_tag;
drop table if exists file;
drop table if exists request_like;
drop table if exists request_likes;
drop table if exists notification;

-- User
CREATE TABLE IF NOT EXISTS user
(
    id text PRIMARY KEY,
    username text,
    avatar text,
    accountType text
);

-- Profile
CREATE TABLE IF NOT EXISTS profile
(
    userid text PRIMARY KEY,
    banner text,

    discordUrl text,
    xurl text,
    websiteurl text,
    email text,

    showdiscord integer,
    showx integer,
    showwebsite integer,
    showemail integer
);

-- Project
CREATE TABLE IF NOT EXISTS project
(
    id text PRIMARY KEY,
    name text,
    ownerid text
);

-- Project Team
CREATE TABLE IF NOT EXISTS project_team
(
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    projectid text,
    teammemberid text
);

-- Tag
CREATE TABLE IF NOT EXISTS tag
(
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name text
);

-- Request
CREATE TABLE IF NOT EXISTS request
(
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    title text,
    description text,
    fileid INTEGER,
    created text,
    projectId text,
    ownerId text
);

CREATE TABLE IF NOT EXISTS comment
(
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    message text,
    fileid INTEGER,
    parentid INTEGER,
    ownerId text,
    created text,
    deleted INTEGER
);

CREATE TABLE IF NOT EXISTS file
(
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name text,
    size INTEGER,
    created text,
    ownerId text
);

CREATE TABLE IF NOT EXISTS request_tag
(
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    requestId INTEGRER,
    tagid integer
);

CREATE TABLE IF NOT EXISTS request_like
(
    id text PRIMARY KEY,
    requestId INTEGER,
    userId text
);

CREATE TABLE IF NOT EXISTS notification
(
    id text PRIMARY KEY,
    requestId INTEGER,
    type INTEGER,
    ownerId text,
    userId text,
    seen text,
    created text
);

insert into tag (name) VALUES
('2D'),
('3D'),
('Animation'),
('Model'),
('Low Poly'),
('High Poly');

select * from notification;

delete from notification;

select * from project;

select * from comment;

delete from comment;

select * from file;

delete from file;

select * from request;