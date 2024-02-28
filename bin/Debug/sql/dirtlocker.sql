
/** Create the database, re-creating it if needed **/
DROP DATABASE IF EXISTS DirtLocker;
CREATE DATABASE DirtLocker;
USE DirtLocker;

/** Create the user table, storing the user's id and dirt count, related to dirt **/
CREATE TABLE [DiscordUser]
(
	user_id    VARCHAR(255) NOT NULL,
	user_total INT          NOT NULL,

	primary key (user_id)
);

/** Create the dirt table, storing the individual user's dirt entries, related to user and attachment **/
CREATE TABLE [Dirt] (
	indexation_id VARCHAR(255) NOT NULL,
	user_id       VARCHAR(255) NOT NULL,
	attachment_id INT          NOT NULL,
	username      VARCHAR(255) NOT NULL,
	notes         varchar(max) NOT NULL,
    
	primary key (indexation_id),
	foreign key (user_id) references [DiscordUser](user_id)
);

/** Create the attachment table, storing the attachment's information, related to dirt **/
CREATE TABLE [Attachment]
(
	attachment_id   INT          NOT NULL IDENTITY(1,1),
	attachment_type VARCHAR(255) NOT NULL,
	attachment_url  VARCHAR(MAX) NOT NULL,
	attachment_size INT          NOT NULL,

	primary key (attachment_id)
);