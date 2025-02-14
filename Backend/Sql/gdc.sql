
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
    id text PRIMARY KEY,
    headerimage text,
    name text,
    description text,
    ownerid text
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
    id text PRIMARY KEY,
    title text,
    description text,
    fileurl text,
    created text,
    projectId text,
    userId text
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