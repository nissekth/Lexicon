# Övning 6 - Garage 2.0  

-Samma uppgift som Övning 5 - Garage 1.0 fast med listor.  
-I övrigt fokus på att bryta ut duplicerad kod i services.  
-Designen lämnar mycket att önska, SoC skulle behöva förbättras genom bl.a. förflyttning av all out till menyerna (våra views) och flytta logiken till modellerna. Det har redan gjorts en hel del men det är fortf lite spaghetti över det hela.  
-Tveksam practice med att kasta exceptions för navigation, åtminstone för bakåt-navigationen.  

### Fixes från Garage 1.0  
-Implementerade unika egenskaper för alla underklasser av fordon.  
-Tydliggjorde UX för processen att lista fordon enligt särskilda kombinationer av sökkriterier.  
-Fixade validering av första tre tecknen och sista tecknet av registreringsnumret.  

## Run program  
Ladda ned projektet, kör med **dotnet run**-kommandot i terminalen och sen är det bara att knappa på i menyerna.  
Eller med vscode/visual studio så gissar jag att det bara är att trycka på **run**-knappen.
  
## Filstruktur  
**Menus**  
Det finns en meny-klass för varje meny i projektet.  
Tanken är att varje meny sköter UI, hanterar första steg av validering av användarens input för att sedan skicka vidare info eller förfrågningar till service.  
**Services**  
Services används för att minimera kodduplicering och för att kunna göra ändringar i en och samma metod snarare än i flera utspridda liknande.  
Tanken är att menyerna ska kunna använda services för att slippa logik och slippa förstå/känna till vad som händer i modellerna.  
**Models**  
Models innehåller alla objekt-klasser.  
Vehicle är abstract och ärvs av alla subklasser av fordon.  
VehicleCreator ansvarar för att undvika duplicerad kod och ansvarar för att skapa fordon av alla subklasser.  
Garage ansvarar för individuella garage instanser, för att hantera förfrågningar om information eller närvaro i garaget.  
**Enums**  
Består bara av några custom typer  
**Exceptions**  
Består bara av några custom exceptions  

## Önskar feedback på...   
Allt ni känner för egentligen. Men då finns det ju en jäkla massor att kommentera på, så vill ni ha vägledning kanske något nedan?  
### Arkitektur och ansvar  
-Vad tycker ni om separation of concerns i projektet? Är det tydligt vilket område varje klass ansvarar för? Och hur mycket bryts det?  
-Jag har försökt ha så lite logik som möjligt i "meny-klasserna" och så lite output/UI som möjligt i modellerna. Jag har inte helt lyckats med det dock, är det några riktigt stora bovar där ni reagerar på?  
-Är service-lagret logiskt? Eller är det förvirrande att de klasserna mixar för mycket logik och UI?  
-Är det någon särskild validering som ni tycker har hamnat i helt fel lager?  

### OOP och klassdesign  
-Är det rimligt att varje subklass har en override för att printa en enda unik egenskap? Om inte, hur löste ni det?  
-Är inkapslingen tillräckligt bra?  

### UX  
-Jag är ingen höjdare på UI och frontend (som ni märker hehe). Men är det några ställen ni tycker att textformuleringar är otydliga? Eller något ställe där ni tycker att stegen ni går igenom kommer i en oväntad/ologisk ordning?  

### Felhantering och robusthet  
-Jag har löst så att användaren kan navigera bakåt till den tidigare menyn eller avbryta input och starta om i samma meny. Det är ordnat genom att kasta ett exception för att notifiera den kallande metoden om att dess call avbröts regelrätt. Det känns lite tokigt att använda ett exception så, vad tycker ni? Hur har ni gjort med det och/eller med när användaren avslutar programmet?  
-Säg förstås till om ni hittar några buggar.


