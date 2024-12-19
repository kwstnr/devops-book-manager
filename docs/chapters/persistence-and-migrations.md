# Peristenz und Migrationen
Die Persistenz wurde wie bereits erläutert mittels einer Postgres Datenbank umgesetzt.
Das Datenbankschema wird automatisiert aufgrund des Domänenmodells in Kombination mit EF-Core Configurations erzeugt.
Schema-Migrationen werden in Folge detaillierter erläutert.

## Migrationen
Migrationen können wie folgt erzeugt werden.
Das Domänenmodell oder die EF-Core Konfigurationen werden angepasst.
Mittels der dotnet ef CLI wird eine Migration generiert.
```dotnet ef migrations add "Name" -s src/BookManager.Graph/BookManager.Graph.csproj -p BookManager.Data.Postgres/BookManager.Data.Postgres.csproj -c BookManagerDbContext```
Die erzeuget Migration wird im `Migration`-Ordner des Data-Projekt abgelegt. Diese umfasst aber lediglich die Schemaänderungen. Datenmigrationen müssen jeweils in der `Up` und `Down` Methode manuell implementiert werden.
Diese müssen explizit getestet werden. Eine Infrastruktur für solche Tests existiert noch nicht. Die Verantwortung liegt dementsprechend bei jedem einzelnen Contributer und den Reviewern.

### Baby Steps und Backwards Compatibility
Migrationen sollten stets in Baby Steps ausgeführt werden. Diese sollen vor dem finalen Umstieg stets Rückwärts Kompatibel sein.
Dementsprechend benötigt eine risikobehaftete Migration stets mehrere Versionen, bis final ein Breaking Change ausgelöst wird.
Dies verlangt einen erhöhten Managementaufwand, ermöglicht jedoch sichere Breaking Schema Changes.

### Fehlgeschlagene Mutationen
Mutationen die Technisch nicht umsetzbar sind, sollten es nie auf die DEV Umgebung durch Integrationstests schaffen. Die Integrationstests in Question müssen aber noch umgesetzt werden...
Falls eine Mutation fachlich nicht wie erwartet funktioner hat, muss diese über eine weitere Mutation in einem HotFix rückwärts gemacht werden. Auf den produktiven Deployment Stages werden keine Migrationen zurückgerollt.
Dies bedeutet aber nicht, dass fehlgeschlagene Version-Upgrades ohne Migrationen nicht gerollbacked werden dürfen!
