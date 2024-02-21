FarmApplication

! notice that this app is using razor pages instead of MVC, both versions of .net core but work slightly differently

the hot reload button will refresh the website is its open when making changes.

helpful links: https://www.youtube.com/watch?v=68towqYcQlY https://www.youtube.com/watch?v=eru2emiqow0 https://www.youtube.com/watch?v=BfEjDD8mWYg

Information about the project:

The Migrations folder is used for connecting to databases.
The Model folder is used to store classes which can be saved to the databases (the database is made of the class fields).
The Data folder shoudn't be too important, but is used to estabilsh the links between classes to databases.
Layout pages appear on every page of the application.
Pages should be self explanitory.
If adding new file to Pages, reference it in the imports file
Migrating data to the database:

Tools -> NuGet Packet manager -> package manager console. then add-migration "migration name".
type update-databse in Packet manger console, the DB will now be viewable in View -> SQL Server objecct explorer in the Databases folder.