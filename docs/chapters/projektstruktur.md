# Projektstruktur, Techniken & Tools
Dieses Kapitel beschreibt die gewählte Projektstruktur und die verwendeten Techniken & Tools.

## Ordnerstruktur
### .github
Dieser Ordner beinhaltet alle Github relevanten Dateien. Konkret sind im `workflows` Ordner die Github Actions angesiedelt.

### devops
In diesem Ordner sind alle Docker relevanten Dateien angesiedelt.
Das base `docker-compose`, welches für die lokale Entwicklung verwendet werden kann und die overrides welche für die jeweiligen Deployment-Stages verwendet werden.
Im base `docker-compose` wird eine Postgres Datenbank gestartet, ein PgAdmin Container für die Datenbankverwaltung und die API wird basierend auf dem lokalen Projektstand gebaut und gestartet.
Die `docker-compose` overrides, welche für die Deployment-Stages verwendet werden, passen lediglich den API-Container an und ziehen anstelle des lokalen Builds die Images von der Docker-Registry mit den entsprechenden Image Tags.

### docs
In diesem Ordner befindet sich die Dokumentation, welche auf die Github Pages gepushed wird.

### src
Dieser Ordner beinhaltet den effektiven Sourcecode der in späteren Kapiteln behandelten GraphQL API.

## Domäne
Wie bereits angetönt, handelt es sich bei dem `devops-book-manager` um eine GraphQL API, mit welcher eine klassische Übungs-Domäne verwaltet werden kann.
Wie es der Name des Projekts schon so sprechend definiert, handelt es sich dabei um einen Buch-Manager. Hier können Bücher, deren Authoren und Genres verwaltet werden.
Ein paar Bücher und Authoren wurden Beispielshalber bereits in die Datenbank geseedet um den Graphen darzustellen und navigierbar zu machen.

## Projektarchitektur
Bei dem `devops-book-manager` handelt es sich um eine klassische [layered architecture](https://www.oreilly.com/library/view/software-architecture-patterns/9781491971437/ch01.html).
Die Applikation wurde dreigeteilt in *Data Layer*, *Domain* oder *Business Layer* und das *Graph Layer*. Die einzelnen Layers werden in folge detaillierter erläutert.

### Domain Layer
Das Domain Layer beinhaltet das, in diesem Fall relativ fett- und vorallem blutarme ([anemic](https://martinfowler.com/bliki/AnemicDomainModel.html)) Domänenmodell.
Blutarm in diesem Fall weil es das Herz der Software auch einfach nicht viel Blut zu pumpen gibt. Der Fokus in diesem Projekt waren definitiv die DevOps Praktiken. Einen kleinen Bonus gibt es aber trotzdem, es wurde mit einer GraphQL Schnittstelle experminentiert.
Diese wird in Folge noch etwas genauer betrachtet.

### Data Layer
Das Data Layer ist das erste Layer in welchem wir den Einfluss der [ChilliCream GraphQL Platform](https://github.com/ChilliCream/graphql-platform) zu spüren bekommen.
Zuerst aber nochmal zu den Basics. In erster Linie wird auch hier simplistisch auf das ORM Entity Framework Core gesetzt, welches in der .NET Welt weit verbreitet und rege genutzt ist.
EFCore verwendet `DataBaseContext`s und `EntityTypeConfiguration`s um ein Schema basierend auf dem im *Domain Layer* entwickelten Domänenmodell zu erzeugen.

Interessant wird es aber vorallem bei den Datenbankzugriffen. Anders als in bekannten REST Schnittstellen, werden die Daten nicht einfach von der Datenbank gelesen und herausgegeben.
Wie es im `main`-Branch leider noch nicht aber in einem [Prototyping-Branch](https://github.com/kwstnr/devops-book-manager/tree/feature/data-loader-prototyping) ersichtlich ist, werden [GreenDonut](https://github.com/ChilliCream/graphql-platform/tree/main/src/GreenDonut) DataLoaders verwendet, welche den Zweck verfolgen, Daten entsprechend dem angeforderten Graphen, effizient aus der Datenbank zu laden und zu cachen, damit diese in der selben Request nicht erneut materialisiert werden müssen. 
Hierbei sind noch viele Challanges wie Projection, Nested Filtering und effizientes Paging offen, aber genau dafür kann das Projekt weiterverwendet werden, zum Prototypen!

### Graph Layer
In diesem Layer werden alle GraphQL-Spezifischen Queries, Types und Nodes definiert. Hierbei wird stark auf die HotChocolate Source-Generation gesetzt, welche viel Boilerplate-Code mittels Attributen übernimmt.
In dieser Dokumentation wird nicht zu detailliert in die Funktionsweise von GraphQL eingegangen. Diese kann auf der offiziellen [HotChocolate Dokumentation](https://chillicream.com/docs/hotchocolate/v14) betrachtet werden.

## Techniken & Tools
In Sachen "Techniken" wurden die meisten Themen bereits erwähnt. Es wird auf eine Postgres Datenbank gesetzt, da diese Multiplatform Docker Images anbietet und eine schlanke Datenbankstruktur anbietet.
Somit ist die Entwicklung und das Hosting auf den unterschiedlichen Umgebungen, welche das Enterprise Lab und die Entwicklungsumgebungen der Teammitglieder ermöglicht.

Die soeben genannten Entwicklungsumgebungen und Tools unterscheiden sich stark voneinander. Gemeinsam eingesetzte Tools umfassen Github, Github Actions und Qodanas statische Code Analyse.
Die dotnet CLI wird entweder direkt oder über die Nutzung von verschiedenen IDE's angesteuert um die App zu starten, Migrationen zu erzeugen oder Tests auszuführen.

Ebenso wird die dotnet CLI für die Verwaltung von User Secrets verwendet, welche für die Übersteuerung von Konfigurationsdateien verwendet werden, genutzt.

IDE's umfassen verschiedene ausprägungen, von NeoVim über Rider bis zu Visual Studio kann alles verwendet werden. Users Choice!

## 12-Factor App
Wie setzt der `devops-book-manager` die zwölf Faktoren der [Twelve-Factor App](12factor.net/de) um?

### I. Codebase
Die Codebase ist auf github verwaltet und jedes Push auf den `main`-Branch führ zu einem DEV-Release.
INT und PROD werden manuell gesteuert, sollen aber schnell und häufig passieren.

### II: Abhängigkeiten
Abhängigkeiten explizit deklariert und isoliert, in dem Sinne, dass das DataLayer von Postgres Abhängig ist und das Graph Layer von HotChocolate.
Die Abhängigkeiten der Bibliotheken untereinander sind klar definiert.

### III. Konfiguration
Die Konfiguration wird über Umgebungsvariabeln gesteuert und kann beispielsweise im Onboarding gelesen werden.

### IV. Unterstützdene Dienste
Unterstützende Dienste wie Postgres und PgAdmin werden als Ressourcen angehängt durch deren Präsenz in allen `docker-compose` Dateien.

### V. Build, Release, Run
Hier könnte man sich noch etwas verbessern, rein logisch. Die einzelnen Steps sind strikt verteilt, befinden sich aber immer in den selben Files.
Builds werden getriggered, Releases werden auf die Docker-Registry basierend auf den Builds getriggered und nach erfolgreichen Releases werden die Images auf die VMs gepulled und gestartet.

### VI. Prozesse
Die App selbst wird als ein einziger Prozess ausgeführt. Einzelne Requests werden jedoch Multithreaded durch die GraphQL Engine verwaltet, abgearbeitet.

### VII. Bindung and Ports
Die API ist durch `docker-compose` Port-Mapping an spezifische Ports gebunden.

### VIII. Nebenläufigkeit
Durch die HotChocolate Technologie wird Nebenläufigkeit automatisch verwaltet. Es muss lediglich nicht aktiv verhindert werden!

### IX. Einweggebrauch
Die Applikation kann schnell gestartet und problemlos gestoppt werden.

### X. Dev-Prod-Vergleichbarkeit
Dies liegt in der Verantwortung der Release-Engineers, möglichst fleissig INT- und PROD-Releases anzusteuern.

### XI. Logs
Logs werden standardmässig über den IO-Stream ausgegeben und können wie erwünscht Technologieunabhängig gesammelt werden.

### XII. Admin-Prozessse
Admin- und Management-Aufgaben gibt es im Moment keine im Rahmen des `devops-book-manager`.

