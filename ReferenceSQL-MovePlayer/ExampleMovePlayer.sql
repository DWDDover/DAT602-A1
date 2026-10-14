drop database if exists movingdb;
create database movingdb;
use  movingdb;

create table tblBoard(
	id int primary key,
    maxRow int,
    maxCol int
);
insert into tblBoard values
  (1,5,5);
  
create table tblTile(
	id int primary key auto_increment,
    board_id int,
    `row` int not null,
    col int not null,
    foreign key(board_id) references tblboard(id)
);
alter table tblTile auto_increment = 1;

insert into tblTile(board_id,`row`,col) values
  (1,1,1), 
  (1,1,2),
  (1,1,3),
  (1,1,4),
  (1,1,5),
  (1,2,1), 
  (1,2,2),
  (1,2,3),
  (1,2,4),
  (1,2,5),
  (1,3,1), 
  (1,3,2),
  (1,3,3),
  (1,3,4),
  (1,3,5),
  (1,4,1), 
  (1,4,2),
  (1,4,3),
  (1,4,4),
  (1,4,5),
  (1,5,1), 
  (1,5,2),
  (1,5,3),
  (1,5,4),
  (1,5,5)
  ;
  select * from tblTile;
  
create table tblPlayer(
	id int primary key,
    tile_id int,
    foreign key(tile_id) references tblTile(id)
);
insert into tblPlayer values
(1,1),(2,2);

-- insert into tblPlayer
create table tblLoot(
	id int primary key,
    tile_id int,
    foreign key(tile_id) references tblTile(id)
);
-- 1. Get player row col
SELECT `row`,col
FROM 
      tblPlayer as p join tblTile as t
	  on p.tile_id = t.id
WHERE
       p.id = 1;

-- 2 Get neighbours tile_ids
SELECT t2.id
FROM 
      tblPlayer as p 
	  join tblTile as t
	  on p.tile_id = t.id 
      join tblTile as t2
      on t.id <> t2.id
WHERE
      ((t2.row = t.row + 1 ) OR (t2.row = t.row -1 ) OR (t2.row = t.row )) AND
	  ((t2.col = t.col + 1 ) OR (t2.col = t.col -1 )  OR (t2.col = t.col ) )
	  AND
	   p.id = 1;
       
-- 3. Is our Move to a neighbour tile 

select * 
from 
    tblTile as t3 
where
    (t3.`row` = 1 and t3.col = 1) and 
    t3.id IN (
				SELECT t2.id
				FROM 
					  tblPlayer as p 
					  join tblTile as t
					  on p.tile_id = t.id 
					  join tblTile as t2
					  on t.id <> t2.id
				WHERE
					  ((t2.row = t.row + 1 ) OR (t2.row = t.row -1 ) OR (t2.row = t.row )) AND
					  ((t2.col = t.col + 1 ) OR (t2.col = t.col -1 )  OR (t2.col = t.col ) )
					  AND
					   p.id = 1   
    );

	   