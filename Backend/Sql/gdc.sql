drop table if exists user;
drop table if exists project;
drop table if exists project_team;
drop table if exists tag;
drop table if exists request;
drop table if exists comment;
drop table if exists request_tag;
drop table if exists element;


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
    fileurl text,
    created text,
    projectId text,
    userId text
);

CREATE TABLE IF NOT EXISTS comment
(
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    message text,
    filename text,
    parentid INTEGER,
    deleted INTEGER
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