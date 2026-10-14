use toddles;


-- SELECT round(RAND() * 6) + 1 AS Team_To_Start;


DROP PROCEDURE IF EXISTS ListTeams;
DROP FUNCTION IF EXISTS GetRand;

DELIMITER //

CREATE FUNCTION GetRand( pRange INT) RETURNS INT
DETERMINISTIC 
BEGIN
  DECLARE lcResult int;
  
  SET lcResult =  round(RAND() * (pRange -1)) + 1;
  
  RETURN lcResult;
END//

CREATE PROCEDURE ListTeams(IN pNumberOfTeams INT)
BEGIN
       DECLARE Count INT DEFAULT 1;
       
       DROP TABLE IF EXISTS tblTeamsOrder;
       CREATE TABLE tblTeamsOrder ( 
           TeamNumber int NOT NULL PRIMARY KEY, 
           TeamOrder int );
           
       SET @TStart = GetRand(pNumberOfTeams)  ;  
	   
       WHILE Count < (pNumberOfTeams + 1) DO
          -- Get a number that is not in the list
          WHILE @TStart IN ( SELECT TeamOrder FROM tblTeamsOrder) DO
                SET  @TStart = GetRand(pNumberOfTeams)  ;   
		  END WHILE;
          
          -- Insert that number into the table
          INSERT INTO tblTeamsOrder(TeamNumber, TeamOrder)
          VALUES (Count, @TStart);
          
          SET Count = Count + 1;
       END WHILE;
       
	   SELECT * FROM tblTeamsOrder;
END//
-- END OF PROCEDURE

DELIMITER ;
SELECT GetRand(8);
CALL ListTeams(8);
