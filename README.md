# TodoRestService - C#

TodoRestService deals with storing, updating, deleting, and retrieving items from the database in Azure using WEB-API with an optional image attachment.



### How to Run Project  

Run the following command in your desired folder: 
* Clone this repository:
```
git clone
```

The solution holds three following projects: 

### 1- WebAPI 
* **ProjectName: TodoRestService**

* **Models** [Database]

  1. **Item** 
 ```TodoRestService/Models/Item.cs```: Db Classes 

  2. **TodoContext** ```TodoRestService/Models/TodoContext.cs``` : Database Context
   


* **ViewModels**

  1. **ToDoItemBaseViewModel** ```TodoRestService/ViewModels/ToDoItemBaseViewModel.cs```: For User Inputs

* **Controllers**
  
  1. **TodoItemsController** ```TodoRestService/Controllers/TodoItemsController.cs``` : Define Endpoints
* **Services**

  1. **DocumentService** ```TodoRestService/Services/DocumentService.cs```

      Uploads an image file in the Folder: ```wwwroot/uploads``` sent via Post API Call

   1. **TodoItemService** ```TodoRestService/Services/TodoItemService.cs```

      Include Methods for Get, Post, Update and Delete Items


### API Calls
* **GET api/todoitems**

  Returns all items from the database.
* **GET api/todoitems/{id}**

  Returns the item from the database for a specified ID.
* **POST api/todoitems**

  Creates a new item record in the database.
* **PUT api/todoitems/{id}**

  Updates the item record in the database for a specified ID with sent updated data.
* **DELETE api/todoitems/{id}**

  Removes the item record from the database for a specified ID.



### 2- Integration Tests 
* **Project: TodoRestService.Independent.IntegrationTests**
 
    Perform controller integration tests with HttpClient


* **Project: TodoRestService.Dependent.IntegrationTests**

   Perform controller integration tests with WebApplicationFactory


### 3- Service Unit Tests 
* **Project: TodoRestService.UnitTests**
 
    * *TestBase.cs*: Contain methods for creating database connections to perform tests. 
    * *TodoItemServiceTests.cs*: Tests TodoItemService methods to Get, Add, Delete and Update Items as desired.

### 4- Docker
* Start Docker Desktop and run the project in VS with Docker instead of IIS Express. 
* The Dockerfile will generate an image for SDK and API. 

### 5- Azure MySql Database
* The credentials are set empty appsettings.json file. 
   

## Note 
In order to test the API with your local MySql, Code First approach has been used. Please do the following steps: 
* Set your local database configuration in *appsettings.json*
* Run ```Add-Migration IntialDb``` then ```Update-Database``` command in Package Manager Console