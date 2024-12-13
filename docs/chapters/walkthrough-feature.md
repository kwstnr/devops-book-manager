# Walkthrough: Ein Feature von A-Z

Dieses Kapitel gibt eine Übersicht welche Schritte gemacht werden müssen um ein Feature in den devops-book-manager einzubauen.

Um ein neues Feature einzubauen muss man in erster Linie einen Feature branch vom main Branch abzweigen. Der main Branch hat dabei immer einen validen und releasebaren Stand und ist immer funktionsfähig.
Die Implementierung und das testen des Features geschieht dann auf dem eigens erstellten feature Branch.
Ebenfalls wird währent oder nach der Implementierung des Features ein PullRequest auf den Main Branch erstellt. Solange das Feature noch nicht fertig implementiert ist, soll dies ein draft PullRequest sein. Dieser wird nach vorübergehender Fertigstellung zu einem normalen PullRequest geändert.
Durch das erstellen eines PullRequests wird dann unteranderem der Quality Gate getriggert und es wird ein Qodana Build ausgeführt. Qodana ist ein Tool zur statischen Codeanalyse, welches gewisse vorschläge zum Code macht, welche man umsetzen kann oder sogar muss. Es gibt diverse Einstellungen, unteranderem ein threshold welches aussagt, mit wie vielen Fehlern maximal noch ein merge zugelassen wird. Wenn dieser threshold überstiegen wird, müssen die Vorschläge von Qodana zuerst gelöst werden, bevor der PullRequest gemerged werden kann.
Wenn Das Quality Gate und der Build erfolgreich durchlaufen sind und der PullRequest von einem anderen Entwickler approved ist, kann der PullRequest in den Main Branch gemerged werden.
Das mergen des feature Branches in den main Branch triggert dann wiederum das delivery und deployment, wobei die Applikation als Docker Image gebuildet wird und das Image dann auf DockerHub gepushed wird. Dieses wird dann von der VM verwendet um die Dev Umgebung zu aktualisieren.

## Release erstellen
Sobals ein Release erstellt werden soll, muss ein eigen dafür erstellter Release Branch gemacht werden. Dieser wird ebenfalls vom main Branch abgezweigt und wird genau gleich wie die Dev Umgebung auf die Int Umgebung deployed. Sobald alles getestet wurde, kann manuel das selbe Szenario nochmals für die Prod Umgebung ausgeführt werden.