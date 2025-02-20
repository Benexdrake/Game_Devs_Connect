drop table if exists user;
drop table if exists project;
drop table if exists project_team;
drop table if exists tag;
drop table if exists request;
drop table if exists comment;
drop table if exists request_tag;
drop table if exists element;
drop table if exists file;


-- User
CREATE TABLE IF NOT EXISTS user
(
    id text PRIMARY KEY,
    username text,
    avatar text,
    accountType text,
    banner text,
    discordUrl text,
    xurl text,
    websiteurl text,
    email text    
);

-- Project
CREATE TABLE IF NOT EXISTS project
(
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    headerimage text,
    name text,
    description text,
    ownerid text
);

CREATE TABLE IF NOT EXISTS project_team
(
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    projectid INTEGER,
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
    tagid INTEGER
);

-- Element
CREATE TABLE IF NOT EXISTS element
(
    id text PRIMARY KEY,
    elementtype INTEGER,
    content text,
    config text,
    nr INTEGER,
    projectid text
);

insert into tag (name) VALUES
('2D'),
('3D'),
('Animation'),
('Model'),
('Low Poly'),
('High Poly');

select * from tag;

select * from files;