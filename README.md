FarmApplication

! notice that this app is using razor pages instead of MVC, both versions of .net core but work slightly differently
using .net 8.0, if downloading nuget files try to download version 8 of them.

the hot reload button will refresh the website is its open when making changes.

helpful links: https://www.youtube.com/watch?v=68towqYcQlY https://www.youtube.com/watch?v=eru2emiqow0 https://www.youtube.com/watch?v=BfEjDD8mWYg

Information about the project:

The Migrations folder is used for connecting to databases.
The Model folder is used to store classes which can be saved to the databases (the database is made of the class fields).
The Data folder shoudn't be too important, but is used to estabilsh the links between classes to databases, stores the DBcontexts for the different dbs.
Layout pages appear on every page of the application.
Pages should be self explanitory.
The Areas Folder is used for the login system, contains the log in pages and db files, should be able to ignore it for the most part
If adding new file to Pages, reference it in the imports file

Migrating data to the database:
(i think you can safely delete the migration file after running the update command)

Tools -> NuGet Packet manager -> package manager console. then add-migration "migration name" -dbcontext (change that for the name of the context to migrate)
type update-database -dbcontext in Packet manger console, the DB will now be viewable in View -> SQL Server objecct explorer in the Databases folder.

tutorial I used to set up the login system - https://www.youtube.com/watch?v=wzaoQiS_9dI

What I think we need to do:
- create 3 tables for the different types of resources (equipments, workers, crop). Make sure to link it to the users account.
- have a page where the user can create tasks on thier farm which will allow them to select a field and some other options
- create a calender to view the tasks they have created
- not sure what to do after that (maybe improve the add field feature, like draw a box over a google map image).

- todo today: 
- merge with other branch, need to change in program.cs the connection string so that all tables are in same db.
- make sure I can get the fk feature working 
- add the new tables to record data and make sure they work, this will go on the manage resources page
- try to add a create task button - will put this on the 
- 