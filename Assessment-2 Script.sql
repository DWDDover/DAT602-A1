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
	   user_id INT PRIMARY KEY AUTO_INCREMENT,
	   username VARCHAR(50) UNIQUE NOT NULL CHECK (CHAR_LENGTH(username) >= 6),
	   `password` varchar(50) NOT NULL CHECK (CHAR_LENGTH(`password`) >= 6),
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
        PRIMARY KEY (user_id, game_id)
	);
    
	CREATE TABLE game(
		game_id INT PRIMARY KEY AUTO_INCREMENT,
        user_id INT NOT NULL,
        `name` VARCHAR(50) UNIQUE
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
		cat_id INT AUTO_INCREMENT PRIMARY KEY,
        tile_id INT NOT NULL,
        game_id INT NOT NULL
    );
    
    CREATE TABLE cheese(
		cheese_id INT PRIMARY KEY AUTO_INCREMENT,
        tile_id INT NOT NULL,
        `value` INT NOT NULL
    );
     
	CREATE TABLE mousetrap(
		mousetrap_id INT PRIMARY KEY AUTO_INCREMENT,
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
        FOREIGN KEY (tile_id) REFERENCES tile(tile_id) ON DELETE CASCADE;
        
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
            (2, 'badmin', 'apple66', 0, 200, 1, 0),
            (3, 'dave55', 'giraffe99', 0, 800, 0, 0),
            (4, 'mouseman', 'ocean1010', 0, 100, 0, 3),
            (5, 'rachel433', 'mypassword2', 1, 100, 0, 0),
            (6, 'admins', 'Admin123', 0, 0, 1, 0);
--             (7, 'dd', 'dd', 0, 0, 1, 0);
            
	INSERT INTO mouse(user_id, game_id, tile_id, score)
		VALUES
			(1, 1, 7, 200),
            (2, 1, 25, 100),
            (3, 1, 17, 0),
            (4, 1, 34, 600);
            
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
            
	INSERT INTO inventory(user_id, game_id, mousetrap_id)
		VALUES
			(7, 1, 1),
            (7, 1, 4);

	SET FOREIGN_KEY_CHECKS=1;
     
END $$
DELIMITER ;

CALL CreateTables();

-- Procedure for testing the LoginDAO in the prototype

DELIMITER $$
CREATE PROCEDURE sp_GetAllUsers()

BEGIN

    SELECT user_id, username, `locked`
    FROM `user`;
    
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

-- Milestone 3 Procedures

-- Player Login including Lockout (1)
-- for error handling the trnasaction commits even on failed statuses to 
-- ensure the users failed login attempts increase
-- rolblbacks are on failed logins that dont change anything
-- in order to close the open transaction
-- Exit handles for generic database errors and 

DELIMITER $$
CREATE PROCEDURE sp_login(IN p_username VARCHAR(50), p_password VARCHAR(50))

BEGIN
	
	DECLARE attempts INT;
    DECLARE acc_locked INT;
    
    -- These are handlers for deadlock or lock timeout and will be in all procedures that 
    -- use concurrency, as well as the generic handler
	DECLARE EXIT HANDLER FOR 1213, 1205
		BEGIN
			ROLLBACK;
			SELECT 'retry' AS status, 'Busy, please try again' AS message;
		END;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
		BEGIN
			ROLLBACK;
			SELECT 'error' AS status, 'Unexpected database error' AS message;
		END;
    
    START TRANSACTION;
    
	SELECT `locked` AS acc_locked
    INTO acc_locked
    FROM `user`
    WHERE username = p_username FOR UPDATE;
    
	IF acc_locked = 1 THEN
		SELECT 'locked' AS status, NULL AS user_id, NULL AS `admin`;
        ROLLBACK;
	ELSEIF EXISTS ( 
					SELECT * 
					FROM `user`
					WHERE p_username = username AND `password` = p_password
				) THEN
		SELECT 'success' AS status, user_id, `admin` FROM `user` WHERE username = p_username;
        UPDATE `user`
        SET login_attempts = 0,
			logged_in = TRUE
        WHERE username = p_username;
        COMMIT;
	ELSEIF EXISTS ( 
					SELECT * 
					FROM `user`
					WHERE p_username = username AND `password` <> p_password
				) THEN
		UPDATE `user`
        SET login_attempts = login_attempts + 1, 
			`locked` = IF((login_attempts + 1) > 4, 1, 0)
        WHERE p_username = username;
		SELECT 'failed' AS status, NULL AS user_id, NULL AS `admin`;
        COMMIT;
	ELSE
		SELECT 'failed' AS status, NULL AS user_id, NULL AS `admin`;
        ROLLBACK;
	END IF;

END $$

DELIMITER ;

 -- Player registration (2)
 -- 23000 exit handler catches duplicate username as the column has a unique contraint
 -- generic lockout handlers are present again, as well as handlers for the two new constraints
 -- I added to the create table statement that ensure both username and password
 -- are >6 characters
 
 DELIMITER $$
 CREATE PROCEDURE sp_registration(IN p_username VARCHAR(50), p_password VARCHAR(50))
 
 BEGIN
	
    DECLARE v_msg TEXT;
    
	DECLARE EXIT HANDLER FOR SQLSTATE '23000'
		BEGIN
			SELECT 'Validation Failed: Duplicate username. Please choose a different username.' AS Message;
			ROLLBACK;
		END;
        
	DECLARE EXIT HANDLER FOR 1213, 1205
		BEGIN
			ROLLBACK;
			SELECT 'retry' AS status, 'Busy, please try again' AS message;
		END;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
		BEGIN
			ROLLBACK;
			SELECT 'error' AS status, 'Unexpected database error' AS message;
		END;
    
    DECLARE EXIT HANDLER FOR 3819
		BEGIN

			GET DIAGNOSTICS CONDITION 1 v_msg = MESSAGE_TEXT;
			
			IF v_msg LIKE '%user_chk_1%' THEN
				SELECT 'Validation Failed: Username must be 6 or more characters.' AS Message;
                ROLLBACK;
				
			ELSEIF v_msg LIKE '%user_chk_2%' THEN
				SELECT 'Validation Failed: Password must be 6 or more characters.' AS Message;
                ROLLBACK;
				
			ELSE
				-- Fallback for unexpected or unnamed check constraint failures
				SELECT CONCAT('Validation Failed: ', v_msg) AS Message;
                ROLLBACK;
			END IF;
		END;
    
    START TRANSACTION;
    
		INSERT INTO `user`(username, `password`, `locked`, high_score, `admin`, login_attempts)
		VALUES
			(p_username, p_password, 0, 0, 0, 0);
		SELECT 'success' AS Message;
 
 COMMIT;
 
 END $$

DELIMITER ;

-- Laying out tiles on a game board (3)

-- includes 3 steps, making a new game, creating the tiles, and creating a mouse on
-- the starting tile for the games host
-- Generic handlers for lockout and database issues are present again
-- added a unique constraint to the games name column and a handler for duplicate name
-- The initial place cheese call for a new game was removed as this call started a new 
-- transaction within the transaction. The games firsdt cheese will instead be placed by the 
-- event to be added later
-- Procedure changed again to return -1 as the new game id on a failed transaction
-- this is so the GameDAO call still works when there is an error

DELIMITER $$
CREATE PROCEDURE sp_newgame(IN p_gamehost_id INT, IN p_gamename VARCHAR(50))

	BEGIN
        
		DECLARE new_game_id INT;
        DECLARE start_tile_id INT;
        DECLARE cat_tile_id INT;
        
        DECLARE EXIT HANDLER FOR 1213, 1205
		BEGIN
			ROLLBACK;
			SELECT -1 AS new_game_id, 'retry' AS status, 'Busy, please try again' AS message;
		END;
		DECLARE EXIT HANDLER FOR SQLEXCEPTION
		BEGIN
			ROLLBACK;
			SELECT -1 AS new_game_id, 'error' AS status, 'Unexpected database error' AS message;
		END;
        
        DECLARE EXIT HANDLER FOR SQLSTATE '23000'
		BEGIN
			SELECT -1 AS new_game_id, 'error' AS status, 'Game name already in use. Please use a different name.' AS message;
			ROLLBACK;
		END;
        
        START TRANSACTION;
        
        INSERT INTO game(user_id, `name`)
        VALUES
			(p_gamehost_id, p_gamename);
            
		SET new_game_id = LAST_INSERT_ID();

		SET @r = 1;
		WHILE @r <= 12 DO
			SET @c = 1;
			WHILE @c <= 12 DO
				INSERT INTO tile (game_id, `row`, `col`)
				VALUES (new_game_id, @r, @c);
				SET @c = @c + 1;
			END WHILE;
			SET @r = @r + 1;
		END WHILE;
        
        SET start_tile_id = (
								SELECT tile_id
                                FROM tile
                                WHERE `row` = 1 AND `col` = 1 AND game_id = new_game_id);
                                
		SET cat_tile_id = (
								SELECT tile_id
                                FROM tile
                                WHERE `row` = 6 AND `col` = 6 AND game_id = new_game_id);
        
        INSERT INTO mouse(user_id, game_id, tile_id, score)
        VALUES
			(p_gamehost_id, new_game_id, start_tile_id, 0);
            
		INSERT INTO cat(tile_id, game_id)
        VALUES
			(cat_tile_id, new_game_id);
        
		COMMIT;
    
    SELECT new_game_id, 'success' AS status, 'Game created successfully' AS message;
		
	END $$

DELIMITER ;

 -- Placing an item on a tile (4)
 -- Needs to either create a new item or place an existing item(mousetrap)

-- Function to return a random free tile in a game

DROP FUNCTION IF EXISTS f_free_tile;

DELIMITER $$
CREATE FUNCTION f_free_tile(p_game_id INT) RETURNS INT
	DETERMINISTIC

BEGIN
	DECLARE free_tile INT;
	SELECT tile_id INTO free_tile
			FROM tile
			WHERE game_id = p_game_id
				AND tile_id NOT IN (    
										SELECT tile_id
										FROM mouse
										UNION SELECT tile_id
										FROM cheese   
										UNION SELECT tile_id
										FROM cat
										UNION SELECT tile_id
										FROM mousetrap
										WHERE tile_id IS NOT NULL
									)
			ORDER BY RAND()
            LIMIT 1;
            
	RETURN free_tile;
		
END $$

DELIMITER ;

-- place cheese
-- Generic handlers for lock and database errors added
-- Checks added for completely full board and rollback for that case
-- lock select for update added

DROP PROCEDURE IF EXISTS sp_place_cheese;

DELIMITER $$
CREATE PROCEDURE sp_place_cheese(IN p_game_id INT)

BEGIN

	DECLARE random_tile INT;
    DECLARE v_game_id INT;
    
    DECLARE EXIT HANDLER FOR 1213, 1205
		BEGIN
			ROLLBACK;
			SELECT 'retry' AS status, 'Busy, please try again' AS message;
		END;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
		BEGIN
			ROLLBACK;
			SELECT 'error' AS status, 'Unexpected database error' AS message;
		END;

	START TRANSACTION;
    -- locking game row to return an actually free tile
    SELECT game_id INTO v_game_id
    FROM game 
    WHERE game_id = p_game_id FOR UPDATE;

    SET random_tile = f_free_tile(p_game_id);
    
    -- Checking that the free tile is not null meaning the entire board is full
    IF random_tile IS NULL
		THEN ROLLBACK;
        SELECT 'failed' AS status;
    ELSE
		INSERT INTO cheese(tile_id, `value`)
		VALUES
			(random_tile, 100);
		COMMIT;
        SELECT 'success' AS status;
    END IF;
        
END $$

DELIMITER ;

-- place trap pickup
-- Same changes as the place cheese procedure

DROP PROCEDURE IF EXISTS sp_place_trap;

DELIMITER $$
CREATE PROCEDURE sp_place_trap(IN p_game_id INT)

BEGIN
	DECLARE random_tile INT;
	DECLARE v_game_id INT;
    
    DECLARE EXIT HANDLER FOR 1213, 1205
		BEGIN
			ROLLBACK;
			SELECT 'retry' AS status, 'Busy, please try again' AS message;
		END;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
		BEGIN
			ROLLBACK;
			SELECT 'error' AS status, 'Unexpected database error' AS message;
		END;

	START TRANSACTION;
    -- locking game row to return an actually free tile
    SELECT game_id INTO v_game_id
    FROM game 
    WHERE game_id = p_game_id FOR UPDATE;

    SET random_tile = f_free_tile(p_game_id);
    
    IF random_tile IS NULL
		THEN ROLLBACK;
        SELECT 'failed' AS status;
    ELSE
		INSERT INTO mousetrap(activated, tile_id)
		VALUES
			(0, random_tile);
        COMMIT;
        SELECT 'success' AS status;
	END IF;
        
END $$

DELIMITER ;

-- activate trap

-- need a function here to check if a tile is adjacent to a mouse
-- will be used when moving also

DELIMITER $$
CREATE FUNCTION f_tile_available(p_user_id INT, p_game_id INT, p_tile_id INT) RETURNS BOOL
	DETERMINISTIC

BEGIN
	DECLARE mouse_tile INT;
    
	SELECT tile_id INTO mouse_tile
			FROM mouse
			WHERE user_id = p_user_id AND game_id = p_game_id;
            
            
	IF p_tile_id IN ( 
					SELECT t.tile_id
                    FROM tile t
                    join tile t2
                    ON t2.tile_id = mouse_tile
                    WHERE 
						((t2.row = t.row + 1 ) OR (t2.row = t.row -1 ) OR (t2.row = t.row )) AND
						((t2.col = t.col + 1 ) OR (t2.col = t.col -1 )  OR (t2.col = t.col ) ) AND
                        (t.game_id = p_game_id)
					)
		THEN RETURN TRUE;
        
        ELSE
        RETURN FALSE;
        
        END IF;
		
END $$

DELIMITER ;

-- Second function, thjis checks occupancy of a tile for movement and placing a trap
-- as of milestone 3 a cat tile counts as occupied

DROP FUNCTION IF EXISTS f_tile_occupied;

DELIMITER $$

CREATE FUNCTION f_tile_occupied(p_tile_id INT) RETURNS BOOL
    DETERMINISTIC
BEGIN
    RETURN EXISTS (
        SELECT * FROM mouse
        WHERE tile_id = p_tile_id
    ) OR
    EXISTS (
        SELECT * FROM cat
        WHERE tile_id = p_tile_id
    );
END $$

DELIMITER ;

-- activate trap
-- error handling added for locked or generic database errors
-- error handling and rollback for illegal placement in the case of a changed board state
-- since procedure was called

DELIMITER $$
CREATE PROCEDURE sp_activate_trap(IN p_user_id INT, p_game_id INT, IN p_tile_id INT, IN p_mousetrap_id INT)

	BEGIN
        
	DECLARE available BOOL;
    DECLARE adjacent BOOL;
    
    DECLARE EXIT HANDLER FOR 1213, 1205
		BEGIN
			ROLLBACK;
			SELECT 'retry' AS status, 'Busy, please try again' AS message;
		END;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
		BEGIN
			ROLLBACK;
			SELECT 'error' AS status, 'Unexpected database error' AS message;
		END;
    
    START TRANSACTION;
    
    SET adjacent = f_tile_available(p_user_id, p_game_id, p_tile_id);
    SET available = f_tile_occupied(p_tile_id);
    
    
    IF adjacent = TRUE AND available = FALSE
    THEN 
		UPDATE mousetrap
        SET tile_id = p_tile_id, activated = 1
        WHERE mousetrap_id = p_mousetrap_id;

        DELETE FROM inventory
        WHERE mousetrap_id = p_mousetrap_id;
	ELSE
		ROLLBACK;
        SELECT 'failed' AS status, 'illegal placement' AS message;
	END IF;
    
    COMMIT;
    SELECT 'success' AS status, 'trap activated' AS message;
		
	END $$

DELIMITER ;

-- player game play movement (includes game play scoring and aquiring an item) (5, 6, 7)
-- also includes update data of a player (11) when adding score and moving location
-- generic checks for lockouts added, as well as locking with for updates.
-- check that game still exists added in the case of games being killed while moves are happening

DELIMITER $$
CREATE PROCEDURE sp_move_player(IN p_user_id INT, p_game_id INT, IN p_tile_id INT)

	BEGIN

	DECLARE available BOOL;
    DECLARE adjacent BOOL;
    DECLARE v_game_id INT;
    
    DECLARE EXIT HANDLER FOR 1213, 1205
		BEGIN
			ROLLBACK;
			SELECT 'retry' AS status, 'Busy, please try again' AS message;
		END;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
		BEGIN
			ROLLBACK;
			SELECT 'error' AS status, 'Unexpected database error' AS message;
		END;
    
    START TRANSACTION;
    
	SELECT game_id INTO v_game_id
    FROM game 
    WHERE game_id = p_game_id FOR UPDATE;
    
    IF v_game_id IS NULL THEN
		ROLLBACK;
		SELECT 'failed' AS status, 'game no longer exists' AS message;
        
	ELSE
    
    SET adjacent = f_tile_available(p_user_id, v_game_id, p_tile_id);
    SET available = f_tile_occupied(p_tile_id);
    
    
    IF adjacent = TRUE AND available = FALSE
    THEN 
    
		UPDATE mouse
		SET tile_id = p_tile_id
		WHERE user_id = p_user_id AND game_id = p_game_id;
		
        IF EXISTS (
				SELECT *
				FROM cheese
				WHERE tile_id = p_tile_id
            )
            THEN
				UPDATE mouse
                SET score = score + ( 
										SELECT `value`
                                        FROM cheese
                                        WHERE tile_id = p_tile_id
									)
				WHERE user_id = p_user_id AND
                game_id = p_game_id;
				DELETE FROM cheese
                WHERE tile_id = p_tile_id;
		
        END IF;
        
        IF EXISTS (
				SELECT *
				FROM mousetrap
				WHERE tile_id = p_tile_id AND activated = 0
            )
            THEN
				INSERT INTO inventory(user_id, game_id, mousetrap_id)
                VALUES (p_user_id, p_game_id, (
												SELECT mousetrap_id
												FROM mousetrap
                                                WHERE tile_id = p_tile_id
                                                ));
				UPDATE mousetrap
                SET tile_id = NULL
                WHERE tile_id = p_tile_id;
                
		END IF;
        
        IF EXISTS (
				SELECT *
				FROM mousetrap
				WHERE tile_id = p_tile_id AND activated = 1
            )
            THEN
				UPDATE mouse
                SET tile_id = (
								SELECT tile_id
                                FROM tile
                                WHERE game_id = p_game_id AND
                                col = 1 AND `row` = 1
                                )
				WHERE user_id = p_user_id AND game_id = p_game_id;
				DELETE FROM mousetrap
                WHERE tile_id = p_tile_id;
			
			END IF;
            COMMIT;
            SELECT 'success' AS status, 'player moved successfully' AS message;
	ELSE
		ROLLBACK;
		SELECT 'failed' AS status, 'illegal move' AS message;
	END IF;
    
    END IF;

	END $$

DELIMITER ;

 -- Move an item (NPC effect) (8)
 -- error handling added as well as new logic to remove points from players score upon collision
 
DELIMITER $$
CREATE PROCEDURE sp_move_cat(IN p_game_id INT)

	BEGIN
        
	DECLARE current_tile INT;
    DECLARE new_tile INT;
    DECLARE v_game_id INT;
    DECLARE v_victim INT;
    
    DECLARE EXIT HANDLER FOR 1213, 1205
		BEGIN
			ROLLBACK;
			SELECT 'retry' AS status, 'Busy, please try again' AS message;
		END;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
		BEGIN
			ROLLBACK;
			SELECT 'error' AS status, 'Unexpected database error' AS message;
		END;
    
    START TRANSACTION;
    
	SELECT game_id INTO v_game_id
    FROM game 
    WHERE game_id = p_game_id FOR UPDATE;
    
    IF v_game_id IS NULL THEN
		ROLLBACK;
        SELECT 'failed' AS status, 'game no longer exists' AS message;
        
	ELSE
    
    SET current_tile = (
						SELECT tile_id
                        FROM cat
                        WHERE game_id = p_game_id
                        );
                        
	SELECT t.tile_id INTO new_tile
    FROM tile t
    JOIN tile t2 ON current_tile = t2.tile_id
    WHERE t.game_id = t2.game_id AND
		ABS(t.`row` - t2.`row`) <= 1 AND
        ABS(t.col - t2.col) <= 1 AND
        t.tile_id <> t2.tile_id AND
        t.tile_id <> (
						SELECT tile_id
                        FROM tile
                        WHERE col = 1 AND `row` = 1 AND game_id = p_game_id
                        )
	ORDER BY RAND()
    LIMIT 1;
    
    UPDATE cat
    SET tile_id = new_tile
    WHERE game_id = p_game_id;
    
    -- New step to store victim ID for updates, check will now check if v_victim is NULL
    SELECT user_id INTO v_victim 
    FROM mouse WHERE game_id = p_game_id 
    AND tile_id = new_tile;
    
	IF v_victim IS NOT NULL
	THEN
		UPDATE mouse
		SET tile_id = (
						SELECT tile_id
						FROM tile
						WHERE game_id = p_game_id AND
						col = 1 AND `row` = 1
						),
			score = score - 100
		WHERE user_id = v_victim
        AND game_id = v_game_id;
			
	END IF;
    
    COMMIT;
    SELECT 'success' AS status, 'cat moved successfully' AS message;
    
    END IF;
		
	END $$

DELIMITER ;

 -- Kill Running games (9)
 
 DELIMITER $$
CREATE PROCEDURE sp_kill_game(IN p_game_id INT)

	BEGIN
		
        -- Handles not found errors for deletion
		DECLARE EXIT HANDLER FOR SQLEXCEPTION
			BEGIN
				SELECT 'Game not found' AS Message;
				ROLLBACK;
			END;
            
		 DECLARE EXIT HANDLER FOR 1213, 1205
		BEGIN
			ROLLBACK;
			SELECT 'retry' AS status, 'Busy, please try again' AS message;
		END;
        
        START TRANSACTION;
        
        DELETE FROM game
        WHERE game_id = p_game_id;
        
        DELETE FROM mousetrap
		WHERE mousetrap_id IN (SELECT mousetrap_id FROM inventory WHERE game_id = p_game_id);
        
        COMMIT;
        SELECT 'success' AS status, 'game killed' AS message;
		
	END $$

DELIMITER ;

 -- Add new players, this is adding players to a game (10)
  -- for the admin adding users the same registration procedure
 -- is used
 
DELIMITER $$
CREATE PROCEDURE sp_add_player(IN p_user_id INT, IN p_game_id INT)

BEGIN
        
	DECLARE start_tile INT;
        
	DECLARE EXIT HANDLER FOR 1062
		BEGIN
			ROLLBACK; 
			SELECT 'failed' AS status, 'Error: You are already in this game' AS message;
		END;
        
	 DECLARE EXIT HANDLER FOR 1213, 1205
		BEGIN
			ROLLBACK;
			SELECT 'retry' AS status, 'Busy, please try again' AS message;
		END;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
		BEGIN
			ROLLBACK;
			SELECT 'error' AS status, 'Unexpected database error' AS message;
		END;
		
	START TRANSACTION;
	
	SELECT tile_id INTO start_tile
	FROM tile
	WHERE game_id = p_game_id AND
		col = 1 AND `row` = 1;
	
	INSERT INTO mouse(user_id, game_id, tile_id, score)
	VALUES
		(p_user_id, p_game_id, start_tile, 0);
		
	COMMIT;
    SELECT 'success' AS status, 'player added to game' AS message;
		
END $$

DELIMITER ;

 -- update data of a player (11)
 -- one procedure to update the username of a user
-- and one to remove the locked status from a user
 
DELIMITER $$
CREATE PROCEDURE sp_update_user(IN p_user_id INT, IN p_username VARCHAR(50))

	BEGIN
    
		DECLARE EXIT HANDLER FOR 1062
			BEGIN
				SELECT 'failed' AS status, 'Error: That username already exists.' AS message;
                ROLLBACK;
			END;
            
		 DECLARE EXIT HANDLER FOR 1213, 1205
			BEGIN
				ROLLBACK;
				SELECT 'retry' AS status, 'Busy, please try again' AS message;
			END;
		DECLARE EXIT HANDLER FOR SQLEXCEPTION
			BEGIN
				ROLLBACK;
				SELECT 'error' AS status, 'Unexpected database error' AS message;
			END;
    
		START TRANSACTION;
        
        UPDATE `user`
        SET username = p_username
        WHERE user_id = p_user_id;
        
        COMMIT;
        SELECT 'success' AS status, 'player updated' AS message;
		
	END $$

DELIMITER ;

DELIMITER $$
CREATE PROCEDURE sp_unlock_user(IN p_user_id INT)

	BEGIN
    
		DECLARE EXIT HANDLER FOR 1213, 1205
			BEGIN
				ROLLBACK;
				SELECT 'retry' AS status, 'Busy, please try again' AS message;
			END;
		DECLARE EXIT HANDLER FOR SQLEXCEPTION
			BEGIN
				ROLLBACK;
				SELECT 'error' AS status, 'Unexpected database error' AS message;
			END;
    
		START TRANSACTION;
        
        UPDATE `user`
        SET `locked` = 0
        WHERE user_id = p_user_id;
        
        COMMIT;
        SELECT 'success' AS status, 'player unlocked' AS message;
		
	END $$

DELIMITER ;

 -- delete a player (12)
 -- 2 procedures to remove a player from a game and delete users
 
 -- remove player from game
 
DELIMITER $$
CREATE PROCEDURE sp_remove_player(IN p_user_id INT, IN p_game_id INT)

	BEGIN
    
		DECLARE EXIT HANDLER FOR 1213, 1205
			BEGIN
				ROLLBACK;
				SELECT 'retry' AS status, 'Busy, please try again' AS message;
			END;
		DECLARE EXIT HANDLER FOR SQLEXCEPTION
			BEGIN
				ROLLBACK;
				SELECT 'error' AS status, 'Unexpected database error' AS message;
			END;
    
		START TRANSACTION;
        
        DELETE FROM mouse
        WHERE user_id = p_user_id AND game_id = p_game_id;
        
        IF NOT EXISTS (
						SELECT game_id
                        FROM mouse
                        WHERE game_id = p_game_id
                        )
		THEN
			DELETE FROM game
            WHERE game_id = p_game_id;
		END IF;
        
        COMMIT;
        SELECT 'success' AS status, 'player removed from game' AS message;
		
	END $$

DELIMITER ;

 -- delete a user (12)

DELIMITER $$
CREATE PROCEDURE sp_delete_user(IN p_user_id INT)

	BEGIN
    
		DECLARE EXIT HANDLER FOR 1213, 1205
			BEGIN
				ROLLBACK;
				SELECT 'retry' AS status, 'Busy, please try again' AS message;
			END;
		DECLARE EXIT HANDLER FOR SQLEXCEPTION
			BEGIN
				ROLLBACK;
				SELECT 'error' AS status, 'Unexpected database error' AS message;
			END;
    
		START TRANSACTION;
        
        DELETE FROM `user`
        WHERE user_id = p_user_id;
        COMMIT;
        SELECT 'success' AS status, 'player deleted' AS message;
		
	END $$

DELIMITER ;

 -- Test procedure calls
 
 -- call create tables before each testing run to reset testing data
 
 CALL CreateTables();

-- a call for the result of the different failure and success types

-- LOGIN

-- commit on attempts reset
CALL sp_login('michael', 'password123');
-- commit on increased attempt count
CALL sp_login('michael', 'wrongpassword');
-- rollback on incorrect username
CALL sp_login('wrongusername', 'wrongpassword');
-- commit on successful login
CALL sp_login('rachel433', 'mypassword2');

-- REGISTER

-- user list
SELECT * FROM `user`;
-- registration call, commits
CALL sp_registration('testplayer', 'testpassword');
-- duplicate username, rollbacks
CALL sp_registration('testplayer', 'testpassword');
-- password and username too short, rollbacks
CALL sp_registration('te', 'testpassword');
CALL sp_registration('testplayer5', 'te');
 -- updated user list
SELECT * FROM `user`;

-- NEW GAME

-- game list
SELECT * FROM game;
-- new game call
CALL sp_newgame(3, "testgame");
-- updated game list
SELECT * FROM game;
-- Tile count prior to failed new game transaction
SELECT COUNT(*) FROM tile;
-- Failed on duplciate game name and rollback
CALL sp_newgame(3, "testgame");
-- Tile count not increased on rollback
SELECT COUNT(*) FROM tile;

-- PLACE CHEESE

-- cheese list
SELECT * FROM cheese;
-- place new cheese
CALL sp_place_cheese(1);
-- updated list
SELECT * FROM cheese;

-- PLACE TRAP

-- list of traps
SELECT * FROM mousetrap;
-- new trap on board
CALL sp_place_trap(1);
-- updated trap list
SELECT * FROM mousetrap;

-- ACTIVATE TRAP

-- list of traps
SELECT * FROM mousetrap;
-- trap activated on board
CALL sp_activate_trap(1, 1, 8, 1);
-- updated trap list
SELECT * FROM mousetrap;

-- MOVE PLAYER

-- users location
SELECT * FROM mouse 
WHERE user_id = 1;
-- call of move procedure
CALL sp_move_player(1, 1, 8);
-- users new loaction
SELECT * FROM mouse 
WHERE user_id = 1;
-- procedure called on illegal tile
CALL sp_move_player(1, 1, 34);
-- location not updated
SELECT * FROM mouse 
WHERE user_id = 1;

-- MOVE CAT

-- cat location
SELECT * FROM cat
WHERE game_id = 1;
-- move cat call
CALL sp_move_cat(1);
-- new loaction
SELECT * FROM cat
WHERE game_id = 1;
-- testing cat player collision, placing cat in corner surrounded by mice
UPDATE cat SET tile_id = 144 WHERE game_id = 1;
UPDATE mouse SET tile_id = 131 WHERE user_id = 1;
UPDATE mouse SET tile_id = 132 WHERE user_id = 4;
UPDATE mouse SET tile_id = 143 WHERE user_id = 5;
-- checking players scores and location
SELECT * FROM mouse WHERE game_id = 1;
-- moving mouse onto a player
CALL sp_move_cat(1);
-- checking a players new locations and scores, one of the players scores
-- will be 100 less and new location will be tile_id 1
SELECT * FROM mouse WHERE game_id = 1;

-- KILL GAME

-- new game to be killed
CALL sp_newgame(2, 'TEST');
-- game list
SELECT * FROM game;
-- kill game
CALL sp_kill_game(2);
-- updated list
SELECT * FROM game;

-- ADD PLAYER TO GAME

-- make new game
CALL sp_newgame(1, "test_add");
-- see players
SELECT * FROM mouse;
-- add player to the game
CALL sp_add_player(5, 1);
-- updated list
SELECT * FROM mouse;
-- adding player already in game
CALL sp_add_player(5, 1);
-- player not added
SELECT * FROM mouse;

-- UPDATED USERNAME

-- see player 1
SELECT * FROM `user`
WHERE user_id = 1;
-- update username
CALL sp_update_user(1, 'newname');
-- see updated name
SELECT * FROM `user`
WHERE user_id = 1;

-- UNLOCKED PLAYER

-- see locked player
SELECT * FROM `user`
WHERE user_id = 5;
-- unlock the user
CALL sp_unlock_user(5);
-- confirm unlocked
SELECT * FROM `user`
WHERE user_id = 5;

-- RMEOVE PLAYER FROM GAME

-- see players(mice) in game
SELECT * FROM mouse
WHERE game_id = 1;
-- remove the player
CALL sp_remove_player(3, 1);
-- see updated list
SELECT * FROM mouse
WHERE game_id = 1;

-- DELETE USER

-- user list
SELECT * FROM user;
-- delete user 2
CALL sp_delete_user(2);
-- updated list
SELECT * FROM user;

 -- Other procedures required that are not part of the assessment set are below
 
-- find the game name

DELIMITER $$
CREATE PROCEDURE sp_gamename(IN p_game_id INT)

	BEGIN
        
        SELECT `name` AS game_name
        FROM game
        WHERE game_id = p_game_id;
		
	END $$

DELIMITER ;

-- game state for a given game, used to update the GUI board

DELIMITER $$
CREATE PROCEDURE sp_gamestate(IN p_game_id INT)

	BEGIN
        
	SELECT tile_id, 'mouse' AS kind, user_id AS ref_id
	FROM mouse WHERE game_id = p_game_id
	UNION ALL
	SELECT tile_id, 'cheese', cheese_id
	FROM cheese JOIN tile USING (tile_id) WHERE game_id = p_game_id
    UNION ALL
	SELECT tile_id, 'cat', cat_id
	FROM cat WHERE game_id = p_game_id
    UNION ALL
	SELECT tile_id, 'mousetrap', mousetrap_id
	FROM mousetrap JOIN tile USING (tile_id) WHERE game_id = p_game_id AND tile_id IS NOT NULL;
		
	END $$

DELIMITER ;

-- player list for display

DELIMITER $$
CREATE PROCEDURE sp_players(IN p_game_id INT)

	BEGIN
        
		SELECT u.user_id, u.username, m.score
        FROM `user` u
        INNER JOIN mouse m
        ON u.user_id = m.user_id
        WHERE m.game_id = p_game_id
        ORDER BY m.score DESC;
		
	END $$

DELIMITER ;

-- players inventory for display

DELIMITER $$
CREATE PROCEDURE sp_inventory(IN p_game_id INT, IN p_user_id INT)

	BEGIN
        
		SELECT mousetrap_id, 'Mouse trap' AS item
        FROM inventory
        WHERE game_id = p_game_id
        AND user_id = p_user_id;
		
	END $$

DELIMITER ;