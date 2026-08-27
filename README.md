# DAT602-A1
Repository for DAT602 Assessment 1. This repository contains the design documentation for the mousegame application
as well as the MySQL database creation script. The script creates the tables and inserts test data as well as
creating the three procedures that test the DAOs. The prototype exists as a windows forms app with three forms

-Login
-Main
-Game

## Prototype test instructions
Execute the full DDL MySQL script
Run the mousegame application

### Login form
The click the 'login' button to test the LoginDAO, a popup will display the list of all registered users
click OK to proceed to the main form

### Main form
On the main form click the 'Manage Games' button to test the AdminDAO. A popup will display a list
of all active games and the amount of players in the games. Click OK. Click the 'Join Game' button
to proceed to the game form

### Game form
On load the game form uses the GameDAO to retrieve all the tiles in the tile table, their postions,
and their tile_id. Clicking a tile on the board creates a popup displaying the tile_id of the tile in
that grid location
