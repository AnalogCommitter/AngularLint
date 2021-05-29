# AngularLint
Linting of an Angular Project and displaying in Jenkins Dashboard

# Unit Testing with Jenkins

## Live Demo

Zunächst legen wir ein neues Projekt an. Klicken Sie dazu auf "Element anlegen".

![add-element](images/step1.png)

Geben Sie einen Namen ein und wählen Sie "Free Style Softwareprojekt bauen"
Clicken Sie OK.

![project-type](images/step2.png)

Bei Source-Code-Management:
Wählen Sie "Git" und geben Sie ihre Repository URL und den Branch an.

![scm](images/step3.png)

Bei Buildverfahren:
Wählen Sie "Windows Batch-Datei ausführen"

![buildverfahren](images/step4.png)

Geben Sie den Command "dotnet test <Project-root>" ein.

![test-command](images/step5.png)

Speichern Sie die Konfigurationen.

![save](images/step6.png)

Clicken Sie auf "Jetzt bauen".

![build](images/step7.png)

Sobald es abgeschlossen ist, clicken Sie auf das Build.

![watch-report](images/step8.png)

Hier sehen Sie, ob das Build erfolgreich war, oder nicht.

![status](images/step9.png)

Bei der Konsolenausgabe sehen Sie nun, welche Tests erfolgreich waren, und welche nicht.

![console-output](images/step10.png)
