# DAT602-A2 Milestone 3

## Repository for DAT602 Assessment 2 Milestone 3

This repository contains the design documentation for the mousegame application
as well as the MySQL database creation script. The script creates the tables and inserts test data as well as
creating the procedures that allow the game to run.

In order to do the test calls properly the line ```SET GLOBAL event_scheduler = ON;``` needs to be commented
out at the bottom of the script and then ran. To test the game application uncomment the line again and re run the script.

MySQL workbenches maximum number of result sets needs to be changed to 100 instead of 50 because of the amount of test procedure calls and test result sets.


The password in the DatabaseAccessObject class's connection string needs to be changed to the password of the user.

For the admin account use:
Username: dddddd
Password: dddddd

This will be required to test all of the procedures.

The report document and full SQL script are located in the project root.
