# Övning 9 - Garage 3.0  

-Samma uppgift som Övning 5 - Garage 1.0 fast med generics.  
-I övrigt fokus på att bryta ut duplicerad kod i handlers.  
-Designen lämnar mycket att önska, SoC skulle behöva förbättras genom bl.a. förflyttning av all out till menyerna (våra views) och flytta logiken till modellerna. Det har redan gjorts en hel del men det är fortf lite spaghetti över det hela.  
-Tveksam practice med att kasta exceptions för navigation, åtminstone för bakåt-navigationen.  

### Fixes från Garage 1.0  
-Implementerade unika egenskaper för alla underklasser av fordon.  
-Tydliggjorde UX för processen att lista fordon enligt särskilda kombinationer av sökkriterier.  
-Fixade validering av första tre tecknen och sista tecknet av registreringsnumret.    

### Fixes från Garage 2.0  
-Tog bort ÅÄÖ från koden  
-Ändrade variabeln "registreringsnummer" till "licenseplate"  
-Lade till mer dokumentation  
-Simplifierade ListVehicleAttributes() genom att använda basen från Vehicle-klassen  
-Ändrade "Services" till "Handlers"  
-Förenklade/deduplicerade kod gällande user input av properties  
## Filstruktur  
**TODO**  
 
