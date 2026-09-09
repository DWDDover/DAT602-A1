DROP DATABASE if exists mousegame ;
CREATE DATABASE mousegame;
USE mousegame;

DROP PROCEDURE IF EXISTS CreateTables;

DELIMITER $$

CREATE PROCEDURE CreateTables()

BEGIN

	SET FOREIGN_KEY_CHECKS=0;

	DROP TABLE IF EXISTS `user`;
    DROP TABLE IF EXISTS mouse;
    DROP TABLE IF EXISTS game;
    DROP TABLE IF EXISTS tile;
    DROP TABLE IF EXISTS message;
    DROP TABLE IF EXISTS cat;
    DROP TABLE IF EXISTS cheese;
    DROP TABLE IF EXISTS mousetrap;
    DROP TABLE IF EXISTS `inventory`;
    
	CREATE TABLE `user`(
	   user_id INT PRIMARY KEY,
	   username VARCHAR(50) NOT NULL,
	   `Password` varchar(50) NOT NULL,
	   `locked` INT NOT NULL,
       logged_in BOOL DEFAULT FALSE,
	   high_score INT,
	   `admin` INT NOT NULL,
	   login_attempts INT NOT NULL DEFAULT 0
	);
    
    CREATE TABLE mouse(
		user_id INT NOT NULL,
        game_id INT NOT NULL,
        tile_id INT NOT NULL,
        score INT NOT NULL,
        next_tile INT,
        PRIMARY KEY (user_id, game_id)
	);
    
	CREATE TABLE game(
		game_id INT PRIMARY KEY,
        user_id INT NOT NULL,
        `name` VARCHAR(50)
	);
    
    CREATE TABLE tile(
		tile_id INT PRIMARY KEY AUTO_INCREMENT,
        game_id INT NOT NULL,
        `row` INT NOT NULL,
        `col` INT NOT NULL
    );
    
    CREATE TABLE message(
		message_id INT PRIMARY KEY,
        game_id INT NOT NULL,
        user_id INT NOT NULL,
		`timestamp` DATETIME NOT NULL,
        content VARCHAR(255) NOT NULL
    );
    
    CREATE TABLE cat(
		cat_id INT PRIMARY KEY,
        tile_id INT NOT NULL,
        game_id INT NOT NULL
    );
    
    CREATE TABLE cheese(
		cheese_id INT PRIMARY KEY,
        tile_id INT NOT NULL,
        `value` INT NOT NULL
    );
     
	CREATE TABLE mousetrap(
		mousetrap_id INT PRIMARY KEY,
        activated INT NOT NULL,
        tile_id INT
    );
    
    CREATE TABLE inventory(
		user_id INT NOT NULL,
        game_id INT NOT NULL,
        mousetrap_id INT NOT NULL,
        PRIMARY KEY (user_id, game_id, mousetrap_id)
    );
     
	ALTER TABLE mouse
		ADD CONSTRAINT fk_user_mouse 
        FOREIGN KEY (user_id) REFERENCES `user`(user_id) ON DELETE CASCADE,
        ADD CONSTRAINT fk_game_mouse 
        FOREIGN KEY (game_id) REFERENCES game(game_id) ON DELETE CASCADE,
        ADD CONSTRAINT fk_tile_mouse 
        FOREIGN KEY (tile_id) REFERENCES tile(tile_id) ON DELETE CASCADE,
        ADD CONSTRAINT fk_next_tile_mouse 
        FOREIGN KEY (next_tile) REFERENCES tile(tile_id) ON DELETE CASCADE;
        
	ALTER TABLE game
		ADD CONSTRAINT fk_user_game 
        FOREIGN KEY (user_id) REFERENCES `user`(user_id) ON DELETE CASCADE;

	ALTER TABLE message
		ADD CONSTRAINT fk_user_message 
        FOREIGN KEY (user_id) REFERENCES `user`(user_id) ON DELETE CASCADE,
        ADD CONSTRAINT fk_game_message 
        FOREIGN KEY (game_id) REFERENCES game(game_id) ON DELETE CASCADE;
        
	ALTER TABLE tile
		ADD CONSTRAINT fk_tile_game 
        FOREIGN KEY (game_id) REFERENCES game(game_id) ON DELETE CASCADE;
        
	ALTER TABLE inventory
		ADD CONSTRAINT fk_inventory_mouse 
        FOREIGN KEY (user_id, game_id) REFERENCES mouse(user_id, game_id) ON DELETE CASCADE,
        ADD CONSTRAINT fk_inventory_mousetrap 
        FOREIGN KEY (mousetrap_id) REFERENCES mousetrap(mousetrap_id) ON DELETE CASCADE;
        
	ALTER TABLE cheese
		ADD CONSTRAINT fk_tile_cheese 
        FOREIGN KEY (tile_id) REFERENCES tile(tile_id) ON DELETE CASCADE;
        
	ALTER TABLE cat
		ADD CONSTRAINT fk_tile_cat 
        FOREIGN KEY (tile_id) REFERENCES tile(tile_id) ON DELETE CASCADE,
        ADD CONSTRAINT fk_game_cat 
        FOREIGN KEY (game_id) REFERENCES game(game_id) ON DELETE CASCADE;
        
	ALTER TABLE mousetrap
		ADD CONSTRAINT fk_tile_mousetrap 
        FOREIGN KEY (tile_id) REFERENCES tile(tile_id) ON DELETE CASCADE;
        
	INSERT INTO `user`(user_id, username, `password`, `locked`, high_score, `admin`, login_attempts)
		VALUES
			(1, 'michael', 'password123', 0, 400, 0, 2),
            (2, 'admin', 'apple66', 0, 200, 1, 0),
            (3, 'dave55', 'giraffe99', 0, 800, 0, 0),
            (4, 'mouseman', 'ocean1010', 0, 100, 0, 3),
            (5, 'rachel433', 'mypassword2', 1, 100, 0, 0);
            
	INSERT INTO mouse(user_id, game_id, tile_id, score, next_tile)
		VALUES
			(1, 1, 7, 200, 8),
            (2, 1, 25, 100, 26),
            (3, 1, 17, 0, NULL),
            (4, 1, 34, 600, 56);
            
	INSERT INTO game(game_id, user_id, `name`)
		VALUES
			(1, 3, 'Daves game');
	
    -- loop to generate the tile rows, tile_id auto increments
	SET @r = 1;
	WHILE @r <= 12 DO
		SET @c = 1;
		WHILE @c <= 12 DO
			INSERT INTO tile (game_id, `row`, `col`)
			VALUES (1, @r, @c);
			SET @c = @c + 1;
		END WHILE;
		SET @r = @r + 1;
	END WHILE;       
	
	INSERT INTO message(message_id, game_id, user_id, `timestamp`, content)
		VALUES
			(1, 1, 3, '2026-08-21 10:30:45', 'hello everyone');
            
	INSERT INTO inventory(user_id, game_id, mousetrap_id)
		VALUES
			(1, 1, 1),
            (3, 1, 4);
            
	INSERT INTO mousetrap(mousetrap_id, activated, tile_id)
            VALUES
				(1, 0, NULL),
                (2, 1, 76),
                (3, 0, 31),
                (4, 0, NULL);
                
	INSERT INTO cat(cat_id, tile_id, game_id)
		VALUES
			(1, 20, 1);
            
	INSERT INTO cheese(cheese_id, tile_id, `value`)
		VALUES
			(1, 51, 100),
            (2, 73, 100);

	SET FOREIGN_KEY_CHECKS=1;
     
END $$
DELIMITER ;

CALL CreateTables();

-- Procedure for testing the LoginDAO in the prototype

DELIMITER $$
CREATE PROCEDURE GetAllUsers()

BEGIN

    SELECT * FROM `user`;
    
END $$

DELIMITER ;

-- Procedure for testing the GameDAO in the prototype

DELIMITER $$
CREATE PROCEDURE GetTilesForGame(IN p_game INT)

BEGIN

    SELECT * 
    FROM tile
    WHERE game_id = p_game;
    
END $$

DELIMITER ;

-- Procedure for testing the AdminDAO in the prototype

DELIMITER $$
CREATE PROCEDURE GetAllGames()

BEGIN

    SELECT g.game_id, g.`name`, COUNT(m.user_id) AS player_count
    FROM game g
    LEFT JOIN mouse m
	ON m.game_id = g.game_id
    GROUP BY g.game_id, g.`name`;
    
END $$

DELIMITER ;

-- Milestone 2 Procedures

-- Player Login including Lockout

DELIMITER $$
CREATE PROCEDURE sp_login(IN p_username VARCHAR(50), `p_password` VARCHAR(50))

BEGIN
	
	DECLARE attempts INT;
    DECLARE acc_locked INT;
    SELECT `locked` AS acc_locked
    INTO acc_locked
    FROM `user`
    WHERE username = p_username;
    
	IF acc_locked = 1 THEN
		SELECT 'locked' AS status;
	ELSEIF EXISTS ( 
					SELECT * 
					FROM `user`
					WHERE p_username = username AND `password` = p_password
				) THEN
		SELECT 'success' AS status;
        UPDATE `user`
        SET login_attempts = 0,
			logged_in = TRUE
        WHERE username = p_username;
	ELSEIF EXISTS ( 
					SELECT * 
					FROM `user`
					WHERE p_username = username AND `password` <> p_password
				) THEN
		UPDATE `user`
        SET login_attempts = login_attempts + 1, 
			`locked` = IF((login_attempts + 1) > 4, 1, 0)
        WHERE p_username = username;
		SELECT 'failed' AS status;
	ELSE
		SELECT 'failed' AS status;
	END IF;

END $$

DELIMITER ;

 -- Test procedure calls

-- CALL sp_login('michael', 'password123');
-- CALL sp_login('michael', 'wrongpassword');
-- CALL sp_login('wrongusername', 'wrongpassword');
-- CALL sp_login('rachel433', 'mypassword2');

 -- Player registration
 DELIMITER $$
 CREATE PROCEDURE sp_registration(IN p_username VARCHAR(50), p_password VARCHAR(50))
 
 BEGIN
 
	
 
 END $$

DELIMITER ;