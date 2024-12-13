# Onboarding eines neuen Mitarbeiters

## Aufsetzen der lokalen Entwicklungsumgebung

### Docker environment variablen aufsetzen

Im devops-Ordner befindet sich eine docker-compose-Datei, die zum Starten einer lokalen Postgres-Datenbank verwendet werden kann. Der ConnectionString wird in den .NET User Secrets festgelegt. Umgebungsvariablen für docker-compose können definiert werden, indem eine .env-Datei im selben Verzeichnis wie die docker-compose-Datei erstellt und die Variablen wie im folgenden Beispiel gesetzt werden.

````
POSTGRES_USER=postgres
POSTGRES_PASSWORD=yourpassword
POSTGRES_DB=book-manager
PGADMIN_DEFAULT_EMAIL=admin@admin.com
PGADMIN_DEFAULT_PASSWORD=admin
DATABASE_CONNECTION_STRING=Host=postgres;Database=book-manager;Username=postgres;Password=yourpassword
````


### .NET User Secrets aufsetzen

Um in Rider die environment variablen einzurichten, z. B. den ConnectionString, benutzen wir das .NET User Secrets Tool

1. Solution in Rider öffnen
2. rechts klick auf BookManager.Graph -> Tools -> .NET user secrets
3. Connection String als JSON einfügen

````
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=book-manager;Username=;Password="
  }
}
````

Username und password sind das Selbe wie in der .env Datei