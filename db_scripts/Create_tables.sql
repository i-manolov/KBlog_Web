Create table Users (
	user_id bigint Primary Key Identity(1,1),
	First_Name varchar(80) NOT NULL,
	Last_Name varchar(80) NOT NULL,
	Email varchar(80) Unique NOT NULL,
	user_name varchar(80) Unique NOT NULL, 
	password varchar(80) NOT NULL,
	is_private bit NOT NULL, 
	user_guid varchar(80) not NULL
); 

Create Table Friends(
	friend_id bigint Primary Key Identity (1,1),
	user_id_owner bigint NOT NULL,
	user_id_viewer bigint NOT NULL, 
	FOREIGN KEY (user_id_owner) REFERENCES Users(user_id),
	Foreign KEY (user_id_viewer) REFERENCES Users(user_id)
);

Create table Media_Type(
	media_type_id int PRIMARY KEY Identity(1,1),
	description varchar(100)
);

CREATE TABLE Media(
	media_id bigint PRIMARY KEY Identity(1,1),
	user_id bigint NOT NULL, 
	date datetime NOT NULL,
	media_type_id int NOT NULL, 
	FOREIGN KEY (user_id) REFERENCES Users(user_id),
	FOREIGN KEY (media_type_id) REFERENCES Media_Type(media_type_id)
);

Create table Tags (
	tag_id bigint PRIMARY KEY Identity(1,1),
	blog_post_id bigint NOT NULL,
	tag_content varchar(80) NOT NULL
);

Create Table Comments(
	comment_id bigint PRIMARY KEY Identity (1,1),
	comment_autor_id bigint NOT NULL, 
	comment_content varchar(max)NOT NULL
);

Create Table Blog_Posts(
	blog_post_id bigint Primary Key Identity (1,1),
	title varchar(max) NOT NULL,
	description varchar(max) NOT NULL, 
	media_id bigint NOT NULL, 
	tag_id bigint NOT NULL,
	comment_id bigint NOT NULL, 
	FOREIGN KEY (media_id) REFERENCES MEDIA(media_id),
	FOREIGN KEY (tag_id) REFERENCES Tags(tag_id),
	FOREIGN KEY (comment_id) REFERENCES Comments(comment_id)	
);