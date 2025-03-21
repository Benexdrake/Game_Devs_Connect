drop table if EXISTS auth;

create table if NOT EXISTS auth
(
    userId text PRIMARY KEY,
    token text,
    expires INTEGER
);

select * from auth;