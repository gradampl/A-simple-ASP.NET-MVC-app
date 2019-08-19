# A-simple-ASP.NET-MVC-app
Introduction

A-simple-ASP.NET-MVC-app is a Visual Studio 2017 project which performs the create, read, update and delete operations in the ASP.NET Core MVC application with Entity Framework Core Code First approach.



Getting Started

The data base for this project has been created on the local SQL Server. As I have applied the EnsureCreated() function (instead of EF Migrations) and DBInitialiser class with sample data, getting started should be as simple as this:

1. download the project,
2. build and debug it.



What remains to be done

If I had more time, I would try to find the way to display the Fluent Validation ErrorMessages. For the time being, the Model is validated each time the Edit action is called, but the messages are not displayed, which does not seem to be just my issue (see: https://github.com/JeremySkinner/FluentValidation/issues/387). I have tried, first, to decorate the ProductViewModel class with the Validator attribute, but it turned out impossible, second, to implement the JS validaton scripts alongside with the FV, which caused the messages (but those defined in the Models, not the ProductVMValidator class) to appear, but as for the Price field, the validation demanded the integer type of data instead of the decimal one, so I had to give it all up.

Also, I would do my best to elaborate the way to display the product list of a given category if the user, having chosen the "Create new" option, decided not to insert a new product but to leave the form blank instead and to get back to the product list. For the time being, as I have not yet found the way to pass the CategoryId to the ProductController in this kind of situation, my awkward temporary solution is getting back to the category list.

I think that in the further development of this application I should also add paging as well as filtering and sorting products.
