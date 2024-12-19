# Projektstruktur
Dieses Kapitel beschreibt die gewählte Projektstruktur.

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
