# Bahrain vACC API
Written using ASP.NET.
The Bahrain vACC is a **virtual** air traffic control centre on the VATSIM network.

## Running
### Database
Before running you need to set up a database. You can use either MySQL or MariaDB, for this project I used MariaDB. Once you have setup your database, create a user and append the details to the connection string inside `appsettings.json`.
The default one looks like this:
```json
"BahrainConnection": "server=localhost;port=3306;database=BahrainAPI;uid=YOUR_UID;pwd=YOUR_PASSWORD;"
```
Change `YOUR_UID` and `YOUR_PASSWORD` to the password of the use account you created in your database.

You will then need to run `dotnet ef migrations add MIGRATION_NAME` to create a migration and `dotnet ef database update` to build the database. 
See more here: https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli

### Running
Run the API using the dotnet CLI. Simply type `dotnet run` in terminal while inside the project file.

### Testing
For this project I used Postman to test the API.

## TODO
On my TODO list is:
* Add authorization to each HTTP request to stop unwanted users ;).
* Add the ability to send PUT, PATCH and DELETE requests using VATSIM CIDs as well as database IDs.
* Dockerise API.
