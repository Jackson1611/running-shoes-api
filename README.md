
## Running Shoes API

### Project Description
This ASP.NET Core Web API project is designed for members of a running club to manage a collection of running shoes. It provides a convenient way for users to browse, add, update, and remove shoes from the database.

With this API, users can:

View a list of available running shoes
Add new shoes to the collection
Update existing shoe information
Remove shoes that are no longer needed

### Project Structure
- **Controllers:** This folder contains the controller class (`ShoesController.cs`) that handles HTTP requests and interacts with the database.
- **Data:** This folder houses the `RunningShoesDbContext` class for database access and the `RunningShoesSeeder` class for populating the database with sample data.
- **Models:** This folder contains the `Shoe` model class that represents the data structure for a shoe.
- **Program.cs:** This file serves as the entry point for the application and configures the services and dependencies.
- **appsettings.json:** This file stores configuration settings for the application, including the connection string to the database.

### Getting Started
#### Instructions:
1. Clone or download the project repository.
2. Open the project in Visual Studio or your preferred IDE.
3. Ensure you have the connection string for your SQL Server database configured in `appsettings.json`.
4. Run the project (`Ctrl+F5`).

### API Endpoints
- `GET /api/shoes`: Retrieves a list of all shoes.
- `GET /api/shoes/{id}`: Retrieves a specific shoe by its ID.
- `POST /api/shoes`: Creates a new shoe.
- `PUT /api/shoes/{id}`: Updates an existing shoe.
- `DELETE /api/shoes/{id}`: Deletes a specific shoe.

### Swagger
This API utilizes Swagger for documentation and API exploration. You can access the Swagger UI by navigating to `https://localhost:<port>/swagger/index.html` in your web browser, where `<port>` is the port your application is running on.

### Additional Notes
- This project implements basic CRUD (Create, Read, Update, Delete) functionality for shoes.
- Error handling and validation are included in the controller actions.

![Screenshot](https://github.com/Jackson1611/running-shoes-api/blob/main/media/swagger.png)
