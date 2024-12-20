# Notfall-Bugfix auf Prod

Dieser Leitfaden beschreibt den Ablauf für einen Notfall-Bugfix auf Prod basierend auf unserer Trunk-Based Development-Strategie.

## Ablauf

1. **Ermitteln des aktuellen Release-Branches auf Prod**
   - Finde heraus, welcher Release-Branch aktuell auf Prod deployed ist. (Beispiel: `release/1.0.0`)

2. **Release-Branch lokal auschecken**
   - Wechsle lokal in den Release-Branch:
     ```bash
     git checkout release/1.0.0
     ```

3. **Neuen Hotfix-Branch erstellen**
   - Erstelle einen neuen Branch für den Bugfix:
     ```bash
     git checkout -b bug/xxxxx
     ```
     (Ersetze `xxxxx` durch eine aussagekräftige Bug-ID oder Beschreibung.)

4. **Problem lösen**
   - Implementiere die notwendigen Änderungen, um das Problem zu beheben.

5. **Änderungen committen**
   - Committe die Änderungen mit einer aussagekräftigen Nachricht:
     ```bash
     git add .
     git commit -m "bug: xxxxx"
     ```

6. **Merge-Requests erstellen**
   - Erstelle zwei Merge-Requests:
     1. **Von `bug/xxxxx` in `release/1.0.0`:**
        - Dieser Merge-Request sorgt dafür, dass der Bugfix in den aktuellen Release-Branch aufgenommen wird.
     2. **Von `bug/xxxxx` in `trunk`:**
        - Dieser Merge-Request stellt sicher, dass der Bugfix langfristig auch im Hauptbranch (`trunk`) vorhanden ist.

7. **Prod-Release-Pipeline ausführen**
   - Führe die Produktionspipeline erneut mit dem aktualisierten `release/1.0.0` Branch aus, um den Bugfix auf Prod zu deployen.

## Hinweise
- Informiere relevante Stakeholder, dass ein Notfall-Bugfix auf Prod erfolgt.
- Dokumentiere die durchgeführten Änderungen und den Grund für den Bugfix im entsprechenden Ticket oder Dokumentationssystem.

Mit diesem Ablauf stellen wir sicher, dass ein Problem auf Prod schnell und effizient behoben wird.
