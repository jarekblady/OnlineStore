# OnlineStore

#### This app allows you to create your own reading list. 
#### The user can add, edit and remove the book.
#### The user has the option to mark the book as read.
#### The user can reorder the books.

## Configuration
#### 1. In the first step, change "ConnectionStrings" in [appsettings.json](https://github.com/jarekblady/OnlineStore/blob/master/OnlineStore.API/appsettings.json)
#### 2. in Solution Explorer, right click on OnlineStore.API and select `Set as Startup Project`.
![Startup Project](https://github.com/jarekblady/OnlineStore/blob/master/StartupProject.PNG)
#### 3. In Package Manager Console change Default project as `OnlineStore.API`.
![Package Manager Console](https://github.com/jarekblady/OnlineStore/blob/master/PackageManagerConsole.PNG)
#### 4. In Package Manager Console run `update-database` command
#### 5. Now you can start `OnlineStore.API`.
#### 6. In Visual Studio Code you open `client-app`.
#### 7. In Terminal run `npm install` command.
#### 8. In Terminal run `npm start` command.

## Architecture

#### Layers od Solution: API, Service, Repository, client-app. 
#### EF Core is used for connection with database.
#### Repository-Service pattern divides the business layer into two layers: Repository and Service.
#### Repository handles getting data into and out of database.
#### Mapping a DTO to an Entity with Automapper.
#### Database (MS SQL Server)

## Database (MS SQL Server)
### Database Diagram
![Database Diagram](https://github.com/jarekblady/OnlineStore/blob/master/DatabaseDiagram.PNG)