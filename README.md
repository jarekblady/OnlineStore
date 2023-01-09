# Online Electronics Store

#### The site is available to both authorized and unauthorized users.
#### An unauthorized user can view products in the store and add products to the cart.
#### The product list page includes filters by brand and category, search by name and description, and sorting by product name and cost.
#### The product list page contains pagination.
#### The cart page contains a list of items added to the cart and a "Purchase" button.
#### For unauthorized users, in case of clicking the "Purchase" button, there redirects to the authorization form.
#### The admin page is available only to users with the admin role.
#### The admin page contains orders. Here you can change the order status. 
#### The order history page is available to authorized users.

## How to run
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
#### Fluent Validation is used for validation.
#### Material UI.
#### Database (MS SQL Server)

## Database (MS SQL Server)
### Database Diagram
![Database Diagram2](https://github.com/jarekblady/OnlineStore/blob/master/DatabaseDiagram2.PNG)