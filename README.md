# Book Manager
This is a simple GraphQL Api for managing books, authors and genres. It is written specifically for learning purposes and used for DevOps focussing projects for the DevOps lectures at the university of applied sciences lucerne.

## Local Development
within the devops folder, there is a docker-compose file which can be used to start a local postgres database. The connection string is set in the .NET user secrets.
Environment variables for the docker-compose can be defined by creating a .env file in the same directory as the docker-compose file and setting the variables as seen in the example below.
```
POSTGRES_USER=postgres
POSTGRES_PASSWORD=yourpassword
POSTGRES_DB=book-manager
PGADMIN_DEFAULT_EMAIL=admin@admin.com
PGADMIN_DEFAULT_PASSWORD=admin
```