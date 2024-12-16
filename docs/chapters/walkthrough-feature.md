# Walkthrough: Ein Feature von A-Z

Dieses Kapitel beschreibt die Schritte, die erforderlich sind, um ein neues Feature im *devops-book-manager* einzubauen.

## Schritte zur Implementierung eines Features

1. **Feature-Branch erstellen**

   Beginne mit der Erstellung eines Feature-Branches aus dem `main`-Branch. Der `main`-Branch ist stets in einem validen und funktionsfähigen Zustand.

2. **Implementierung und Testen**

   Implementiere und teste das Feature im erstellten Feature-Branch.

3. **Pull Request erstellen**

   Während oder nach der Implementierung wird ein Pull Request (PR) auf den `main`-Branch erstellt. Hierbei gibt es zwei Varianten:

   - **Draft-Pull-Request:** Wenn das Feature noch nicht fertiggestellt ist.
   - **Regulärer Pull Request:** Nach Abschluss der Implementierung wird der Draft in einen regulären Pull Request geändert.

4. **Code-Qualität überprüfen**

   Der Pull Request triggert automatisierte Prozesse, um sicherzustellen, dass die Codequalität den Anforderungen entspricht. Die Überprüfung umfasst folgende Schritte:

   - **Statische Codeanalyse:** Qodana führt eine Analyse durch, meldet Fehler und gibt Verbesserungsvorschläge aus.
   - **Kommentare in PRs:** Qodana fügt Kommentare direkt in den Pull Request ein, um auf potenzielle Probleme hinzuweisen.
   - **Threshold:** Ein definierter Threshold legt fest, wie viele Fehler maximal erlaubt sind. Wird dieser überschritten, müssen die gemeldeten Fehler behoben werden, bevor der Pull Request gemerged werden kann.

5. **Pull Request mergen**

   Ein Pull Request kann in den `main`-Branch gemerged werden, wenn er die folgenden Anforderungen erfüllt:

   - Die Qualitätsprüfung wurde bestanden.
   - Die Builds waren erfolgreich.
   - Ein anderer Entwickler hat den Pull Request angeschaut und freigegeben.

6. **Delivery und Deployment**

   Das Mergen triggert die Delivery- und Deployment-Pipeline:

   - Die Applikation wird als Docker-Image gebaut und auf DockerHub gepusht.
   - Die Dev-Umgebung wird mit den neuen Docker-Images auf der VM aktualisiert und neu gestartet.

7. **Release erstellen**

   Für ein neues Release sind folgende Schritte erforderlich:

   - **Release-Branch erstellen:** Leite einen dedizierten Release-Branch vom `main`-Branch ab.
   - **Manuellen Build starten:** Um auf Int oder Prod zu deployen, muss der Build manuell gestartet werden. Beim Starten des Builds ist der gewünschte Branch anzugeben.
   - **Deployment auf Int und Prod:**
     - Der gleiche Prozess wird sowohl für die Integrationsumgebung (Int) als auch für die Produktionsumgebung (Prod) verwendet.
     - Es gibt separate Builds für Int und Prod, aber die Deployments laufen identisch ab.