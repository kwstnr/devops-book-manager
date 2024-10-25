# Book Manager
This is a simple GraphQL Api for managing books, authors and genres. It is written specifically for learning purposes and used for DevOps focussing projects for the DevOps lectures at the university of applied sciences lucerne.

## Local Development
### setup docker environment variables
within the devops folder, there is a docker-compose file which can be used to start a local postgres database. The connection string is set in the .NET user secrets.
Environment variables for the docker-compose can be defined by creating a .env file in the same directory as the docker-compose file and setting the variables as seen in the example below.
```
POSTGRES_USER=postgres
POSTGRES_PASSWORD=yourpassword
POSTGRES_DB=book-manager
PGADMIN_DEFAULT_EMAIL=admin@admin.com
PGADMIN_DEFAULT_PASSWORD=admin

DATABASE_CONNECTION_STRING=Host=postgres;Database=${POSTGRES_DB};Username=${POSTGRES_USER};Password=${POSTGRES_PASSWORD}

```

### setup .NET user secrets
to set up environment variables e.g. connection string in Rider the .Net user secrets tool is used.
1. open Solution in Rider
2. right click on ```BookManager.Graph``` -> ```Tools``` -> ```.NET user secrets```
3. paste connection string as JSON

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=book-manager;Username=;Password="
  }
}
```
the username and password are the same as in .env file