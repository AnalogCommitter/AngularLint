# Jenkins Unit Testing und Linting

## Einführung

Jenkins ermöglicht es, bestimmte Befehle mithilfe von Jobs auszuführen. In diesem Referat möchten wir dies anhand von 
einem Lint-Job und einem UnitTest-Job (Asp-Net Rest-Api) erklären.

## Live Demo

### Genereller Aufbau

Um den Test Report der **Unit Tests** im Dashboard zu sehen, brauchen Sie das XUnit plugin.

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/plugins.png)

Für die Angular Lint Ergebnisse wird das **Warnings Next Generations** Plugin installiert.

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/plugin.PNG)

Zunächst legen wir ein neues Projekt an. Klicken Sie dazu auf "Element anlegen".

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step1.png)

Geben Sie einen Namen ein und wählen Sie "Free Style Softwareprojekt bauen"
Klicken Sie OK.

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step2.png)

Bei Source-Code-Management:
Wählen Sie "Git" und geben Sie ihre Repository URL und den Branch an.

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step3.png)

> Wir benutzen den HTTPS Link, weil wir Jenkins auf dem LocalHost laufen lassen

Bei Buildverfahren:
Wählen Sie "Windows Batch-Datei ausführen"

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step4.png)

**Unit Testing** Führen Sie hier das oben angegebene shellscript-file aus, welches die Unittests in einem Docker-Container ausführt. 

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step5.png)

#### DockerFile

````
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Formula1.Core/Formula1.Core.csproj", "Formula1.Core/"]
COPY ["Formula1.CoreTest/Formula1.CoreTest.csproj", "Formula1.CoreTest/"]
COPY ["Utils/Utils.csproj", "Utils/"]
RUN dotnet restore "Formula1.Core/Formula1.Core.csproj"
COPY . .
RUN dotnet build
RUN dotnet test --logger "trx;LogFileName=unittestResults.xml";exit 0
````

Beachten Sie die letzte Zeile im Dockerfile:

"RUN dotnet test --logger "trx;LogFileName=unittestResults.xml";exit 0"

mit `dotnet test` werden die Tests ausgeführt

mit `--logger "trx;LogFileName=unittestResults.xml"` werden die Testergebnisse im File "unittestResults.xml" gespeichert

mit `exit 0` wird sicher gestellt, dass das Build erfolgreich ist, auch wenn nicht alle Tests erfolgreich sind.

#### run-tests-docker.sh

````shell
cd Formula1
docker build -t formula1 . 
docker rm formula1-tests 
docker run --name formula1-tests formula1 
docker cp formula1-tests:/src/Formula1.CoreTest/TestResults/unittestResults.xml . 
````

Bei Post-Build-Aktionen:
Wählen Sie "Publish xUnit test result report", dann bei Report Type "MSTest-Version N/A (default)", und geben Sie bei Includes Pattern "\*\*\unittestResults.xml" ein

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step6.png)
  
### oder
    
**Linting** Geben Sie den Command 
````npm i
npm run lint --format pmd > result.xml
tr -d '\n' < result.xml > results.xml
sed -i -r -n -e "/<pmd version=\"tslint\">/,${p}" results.xml
```` 
ein.

Bei Postbuild Actions wählen Sie TSLint aus und geben Ihr Output-File an.

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/postbuild.PNG)

Speichern Sie die Konfigurationen.

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step7.png)

Clicken Sie auf "Jetzt bauen".

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step8.png)

Sobald es abgeschlossen ist, klicken Sie auf den Build.

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step9.png)

Hier sehen Sie, ob der Build erfolgreich war oder nicht:

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step10.png)

So sieht dann das Dashboard des Plugins (klicken auf "TSLint Warnings") aus: 

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/warnings-dashboard.PNG)

Wenn Sie auf "Testergebnis" klicken, sehen Sie, welche Tests erfolgreich waren und welche nicht. (Wenn der "Testergebnis" Tab nicht da ist, aktualisieren Sie die Seite.)

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step11.png)

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step12.png)

![](https://github.com/NathalieHerzog/AngularLint/blob/main/Images/step13.png)
