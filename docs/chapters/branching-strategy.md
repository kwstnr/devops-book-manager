# Branching-Strategie: Trunk-Based Development

## Überblick

Für unser Projekt haben wir uns für **Trunk-Based Development** als Branching-Strategie entschieden. Dieser Ansatz sorgt für einen schlanken Workflow, minimiert Integrationsprobleme und ermöglicht eine schnelle Bereitstellung von Features. Im Folgenden beschreiben wir die zentralen Prinzipien, Arbeitsabläufe und Praktiken, die unsere Strategie ausmachen.

---

## Zentrale Prinzipien

1. **Ein einziger Trunk-Branch:**
   - Alle Arbeiten werden direkt in den `trunk`-Branch (Hauptbranch) eingecheckt.

2. **Kurzlebige Feature-Branches:**
   - Entwickler können kurzlebige Feature-Branches für komplexe Änderungen verwenden, sollten aber so schnell wie möglich in den `trunk` zurück mergen.

3. **Häufige Commits:**
   - Entwickler committen kleine, inkrementelle Änderungen als PR in den Trunk, um kontinuierliche Integration zu gewährleisten.

4. **Kontinuierliche Integration:**
   - Automatisierte Tests und Builds werden bei jedem Commit ausgelöst, um Codequalität und Funktionalität sicherzustellen.

---

## Workflow

### 1. Tägliche Entwicklung
- Entwickler committen ihren Code in den `trunk`-Branch via Pull-Requests (PR).
- Code-Reviews werden im Rahmen von Pull-Requests durchgeführt.
- Automatisierte Tests validieren jeden Commit, um die Qualität sicherzustellen.

### 2. Kurzlebige Feature-Branches
- Ein Feature-Branch wird vom `trunk` erstellt, wenn Änderungen mehrere Commits erfordern oder nicht sofort gemerged werden können.
- Entwickler rebasen den Feature-Branch kontinuierlich auf den `trunk`, um Abweichungen zu minimieren.
- Nach Fertigstellung wird der Feature-Branch in den `trunk` gemerged und gelöscht.

### 3. Release-Workflow
- Ein Release-Branch wird vom `trunk` erstellt, um eine Produktionseinsetzung vorzubereiten.
- Kritische Bugfixes werden bei Bedarf vom `trunk` in den Release-Branch übernommen (Cherry-Picking).
- Nach der Bereitstellung wird der Release-Branch geschlossen.

### 4. Hotfix-Workflow
- Kritische Produktionsprobleme werden direkt im `trunk` behoben.
- Falls das Problem in einem Live-Release besteht, wird ein temporärer Hotfix-Branch vom Release-Branch erstellt, behoben und zurück in den Release-Branch sowie in den `trunk` gemerged.

---

## Vorteile von Trunk-Based Development

- **Schnellere Integration:**
  Häufige Commits zu einem einzigen Branch reduzieren die Integrationskomplexität.
- **Bessere Zusammenarbeit:**
  Entwickler arbeiten an einer einzigen Quelle der Wahrheit, wodurch Branch-Konflikte minimiert werden.
- **Vereinfachte Releases:**
  Kurzlebige Release-Branches reduzieren den Überkopfaufwand und vereinfachen den Release-Prozess.
- **Hohe Codequalität:**
  Kontinuierliche Integration und Tests stellen sicher, dass der `trunk` immer in einem deploybaren Zustand ist.

---

## Diagramm

Unten sehen Sie ein Beispiel, wie die Trunk-Based Development-Strategie visualisiert wird:

![Trunk-Based Development Diagram](../images/what_is_trunk.jpg)

---