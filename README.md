# Jenkins Unit Testing und Linting

## Einführung

Jenkins ermöglicht es, bestimmte Befehle mithilfe von Jobs auszuführen. In diesem Referat möchten wir dies anhand von 
einem Lint-Job und einem UnitTest-Job (Asp-Net Rest-Api) erklären.

## Live Demo

### Genereller Aufbau

Um den Test Report der **Unit Tests** im Dashboard zu sehen, brauchen Sie das XUnit plugin.

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/plugins.png)

Zunächst legen wir ein neues Projekt an. Klicken Sie dazu auf "Element anlegen".

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step1.png)

Geben Sie einen Namen ein und wählen Sie "Free Style Softwareprojekt bauen"
Klicken Sie OK.

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step2.png)

Bei Source-Code-Management:
Wählen Sie "Git" und geben Sie ihre Repository URL und den Branch an.

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step3.png)

Bei Buildverfahren:
Wählen Sie "Windows Batch-Datei ausführen"

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step4.png)

**Unit Testing** Geben Sie den Command "dotnet test *project-root* --logger "trx;LogFileName=*project-root*\unittestResults.xml"" ein. *project-root* braucht man nur, wenn das Git-Repo-root nicht das project-root ist. 

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step5.png)

Bei Post-Build-Aktionen:
Wählen Sie "Publish xUnit test result report", dann bei Report Type "MSTest-Version N/A (default)", und geben Sie bei Includes Pattern "\*\*\unittestResults.xml" ein

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step6.png)
  
### oder
    
**Linting** Geben Sie den Command "npm run lint" ein.

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step5-lint.PNG)

Speichern Sie die Konfigurationen.

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step7.png)

Clicken Sie auf "Jetzt bauen".

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step8.png)

Sobald es abgeschlossen ist, klicken Sie auf den Build.

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step9.png)

Hier sehen Sie, ob der Build erfolgreich war oder nicht:

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step10.png)

Wenn Sie auf "Testergebnis" klicken, sehen Sie, welche Tests erfolgreich waren und welche nicht. (Wenn der "Testergebnis" Tab nicht da ist, aktualisieren Sie die Seite.)

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step11.png)

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step12.png)

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step13.png)
