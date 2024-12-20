# Rollback eines missglückten Releases

Hier ist der Prozess beschrieben, wie ein missglücktes Release mithilfe unserer Trunk-Based Development-Strategie zurückgerollt wird. Allfällige fehlerhafte Migrationen werden in diesem Ablauf nicht berücksichtigt, da diese bereits im Kapitel [Persistenz und Migrationen](./persistence-and-migrations.md) behandelt werden.

## Ablauf

1. **Fehleranalyse und Entscheidung zum Rollback**
   - Identifiziere die Probleme, die durch das Release verursacht wurden.
   - Informiere relevante Stakeholder über die Entscheidung, ein Rollback durchzuführen.

2. **Bestimmung des vorherigen stabilen Releases**
   - Identifiziere den letzten stabilen Release-Branch (z. B. `release/0.9.0`).

4. **Prod-Release-Pipeline ausführen**
   - Starte die Produktionspipeline mit dem stabilen Release-Branch (`release/0.9.0`), um den vorherigen Stand wiederherzustellen.

5. **Prüfung nach dem Rollback**
   - Führe manuelle Tests durch, um sicherzustellen, dass das System stabil ist.

6. **Kommunikation**
   - Informiere das Team und relevante Stakeholder, dass der Rollback erfolgreich war.
   - Dokumentiere die Gründe für den Rollback sowie die durchgeführten Massnahmen.

## Nachbereitung
- Analysiere die Ursache des Fehlers und erarbeite eine Lösung.
- Erstelle einen neuen stabilen Release-Branch, der die notwendigen Fixes enthält.
- Plane das neue Release und führe es nach ausreichender Prüfung erneut aus.

Mit diesem Ablauf stellen wir sicher, dass das System bei einem missglückten Release schnell und sicher in einen stabilen Zustand zurückversetzt wird.
