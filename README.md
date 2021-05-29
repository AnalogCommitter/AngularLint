# AngularLint
Linting of an Angular Project and displaying in Jenkins Dashboard

# Unit Testing with Jenkins

## Live Demo

Zunächst legen wir ein neues Projekt an. Klicken Sie dazu auf "Element anlegen".

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step1.png)

Geben Sie einen Namen ein und wählen Sie "Free Style Softwareprojekt bauen"
Clicken Sie OK.

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step2.png)

Bei Source-Code-Management:
Wählen Sie "Git" und geben Sie ihre Repository URL und den Branch an.

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step3.png)

Bei Buildverfahren:
Wählen Sie "Windows Batch-Datei ausführen"

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step4.png)

Geben Sie den Command "dotnet test <Project-root>" ein.

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step5.png)

Speichern Sie die Konfigurationen.

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step6.png)

Clicken Sie auf "Jetzt bauen".

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step7.png)

Sobald es abgeschlossen ist, clicken Sie auf das Build.

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step8.png)

Hier sehen Sie, ob das Build erfolgreich war, oder nicht.

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step9.png)

Bei der Konsolenausgabe sehen Sie nun, welche Tests erfolgreich waren, und welche nicht.

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step10.png)
