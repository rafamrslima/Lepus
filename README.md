# LEPUS APP

The Lepus app allows you to register incomes and expenses of the month and have your balance and percentage spent displayed in charts. 

![Logo of Lepus App](/APP/src/assets/images/lepusapp.PNG)

## Prerequisites
* [Docker](https://www.docker.com/products/docker-desktop)
* [Docker Compose](https://docs.docker.com/compose/install/)

## How to run
1. In the root folder of the project, open you terminal and run the command 'docker-compose up'. After making changes in the code, just run 'docker-compose up --build'.
2. Open your browser in http://localhost:4400 (the backend API will be running on port 5005, and mongoDB on port 27020. :))
 
## Built With
* [ASP.NET Core](https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-3.1) - Used to build the backend API.
* [Angular](https://angular.io/) - Used to build the frontend of the APP.
* [Mongo](https://www.mongodb.com/) - Used as the database of the project.

## Features

* Choose the year and the month in the dropdowns on the top of the page.
* In the tab 'Incomes' add your incomes (description and value).
* In the tab 'Expenses' add your expenses (description and value).
* Than in the section balance you're going to be able to see your balance of the month, percentage of the money spent, and a chart displaying the diffenrence between the total of incomes and expenses.

### Thank's :)  