ReadMe.md

Link to Azure https://rabbitbank.azurewebsites.net/

Seeded Users
Two users are seeded into the database:

User: richard.chalk@systementor.se
Password: Hejsan123#
Role: Admin

User: richard.chalk@customer.systementor.se
Password: Hejsan123#
Role: Cashier


Bank System Administration Web Application
This web application was developed as part of a .NET Web Development course assignment. It is a banking system administration tool implemented using ASP.NET Core. It enables efficient management of bank customers, their accounts, balances, and transactions.

Overview
The application is hosted on Microsoft Azure and interacts with a provided database using Entity Framework Core. It uses a "Database First" approach where the database is provided and the models are created to match the database schema.

The web interface is built with ASP.NET Core Razor Pages, although MVC can also be used if you are comfortable with it. A free Bootstrap template is used and modified to give the website a professional look and feel.

The application follows best practices, particularly in regards to the use of ViewModels, to avoid exposing database entities in views. AutoMapper is implemented to simplify the mapping between models and view models.

Functionality
The homepage displays statistical information including the total number of customers, the total number of accounts, and the sum of balances across all accounts. This information is public and does not require authentication.

Search functionality is provided to find customer profiles based on customer number, name, and city. The search results are paginated, displaying 50 results at a time. Clicking on a customer takes you to a detailed customer view.

A detailed customer view shows all the information about the customer and their accounts. It also shows the total balance for the customer by summing the balances on the customer's accounts.

Individual account views show account number, balance, and a list of transactions in descending order by date. If there are more than 20 transactions, JavaScript/AJAX is used to load additional transactions in chunks of 20.

The system handles deposits, withdrawals, and transfers between accounts. It ensures accuracy by using decimal data type to avoid rounding errors. Balances cannot be directly changed - they are always updated through a transaction.

ASP.NET Core Identity is used for user authentication and role-based authorization. Two roles, Admin and Cashier, are seeded into the database at startup if they do not exist.

User Roles
Admin: Has the ability to manage users. This is an empty view for the base requirements but can be expanded for advanced grading.

Cashier: Has the ability to manage customers and their accounts.

Please note: Customers are not users, only admins and cashiers interact with the system.


Deployment
The application and its database are deployed to Microsoft Azure for live interaction and evaluation.

This application is a comprehensive tool for managing a banking system, demonstrating a grasp of key .NET technologies and best practices.
