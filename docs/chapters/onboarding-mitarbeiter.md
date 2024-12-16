# Onboarding eines neuen Mitarbeiters

## Aufsetzen der lokalen Entwicklungsumgebung

### Docker-Umgebungsvariablen konfigurieren

Im Ordner `devops` befindet sich eine `docker-compose.yml`-Datei, die zum Starten einer lokalen PostgreSQL-Datenbank verwendet werden kann. Der Connection String wird in den .NET User Secrets definiert. Umgebungsvariablen für `docker-compose` können in einer `.env`-Datei im selben Verzeichnis definiert werden.

**Beispiel:**

```
POSTGRES_USER=postgres
POSTGRES_PASSWORD=yourpassword
POSTGRES_DB=book-manager
PGADMIN_DEFAULT_EMAIL=admin@admin.com
PGADMIN_DEFAULT_PASSWORD=admin
DATABASE_CONNECTION_STRING=Host=postgres;Database=book-manager;Username=postgres;Password=yourpassword
```

### .NET User Secrets einrichten

Die Einrichtung der .NET User Secrets in Rider erfolgt wie folgt:

1. **Solution öffnen**

   Öffne die Solution in Rider.

2. **User Secrets aufrufen**

   Rechtsklick auf `BookManager.Graph` -> **Tools** -> **.NET User Secrets**.

3. **Connection String eintragen**

   Füge den Connection String als JSON ein:

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=book-manager;Username=;Password="
  }
}
```

Die Werte für `Username` und `Password` entsprechen den Angaben in der `.env`-Datei.