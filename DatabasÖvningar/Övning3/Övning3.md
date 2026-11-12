# Övning 3 - Lastbalansering

### 1. Beskriv vad lastbalansering innebär  
	Lastbalansering är en metod för att fördela trafik eller data för att flöded ska bli jämnt och inte orsaka flaskhalsar.  
### 2. Ge ett konkret exempel på där lastbalansering kan vara bra att använda.  
	En stor tjänst med många användare har nästan alltid flera databaskopior. För att det ska gå fort kan en lastbalanserar fördela användare till den databas som förväntas kunna leverera snabbast svar av rätt typ (vissa databaskopior kanske bara kan läsas från, då ska vi ju inte skicka några skriv-anrop dit förstås)  
### 3. Ange tre fördelar med att använda lastbalansering för en hemsida.  
	-Högre tillgänglighet  
	-Mer skalbart  
	-Redundans  
### 4. Vad är SQL Server Replication?  
	Det är en tjänst som duplicerar delar av data i en databas i en annan databas, gör databaskopior som håller sig uppdaterade om förändringar i originalet helt enkelt.  
### 5. Vad är Mirroring i SQL Server?  
	Mirroring har också med databaskopior att göra. Men mirroring är främst till för redundans och backup. Vid mirroring kopieras hela databasen till en ny identisk databas som sitter på avbytarbänken tills det blir en skada på originaldatabasen.  
### 6. Vad är AlwaysOn Availability Groups?  
	AlwaysOn Availability GRoups kombinerar de två ovanstående koncepten. Varför ha databaskopior som bara sitter som backup? AlwaysOn Availability GRoups gör så att helkopiorna på originaldatabasen kan användas för lastbalansering också!
	
