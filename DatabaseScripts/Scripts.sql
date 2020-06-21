CREATE DATABASE netchat;

CREATE TABLE chat
	(id serial PRIMARY KEY,
	user_name varchar(50)  NOT NULL,
	message varchar(500) NOT NULL, 
	created_on TIMESTAMP) ;