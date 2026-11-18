# Övning 1 - EF

## 1. Vilka metoder har skapats i scaffoldingen 
Scaffoldingen genererade våra CRUD-metoder:  
  
GetProducts() - returnerar alla produkter.  
  
GetProduct(int id) - returnerar en produkt med ett specifikt id. returnerar not found om id:t inte finns i databasen.  
  
PutProduct(int id, Product product) - försöker uppdatera en produkt. returnerar badrequest om angivet id inte matchar produktens id och notfound om id:t inte finns i databasen  
  
PostProduct(Product product) - Försöker lägga till en ny produkt. returnerar CreatedAtAction statuskod baserat på utfall.  
  
DeleteProduct(int id) - Försöker radera produkt i databasen. returnerar notfound om id:t inte finns i databasen.  
  
## 2. Hur används StorageContext?  
  
StorageContext är appens koppling till databasen (jag hade massor av strul med linux och SQL Server så jag har använt sqllite nu, hoppas det var ok!	). För oss innebär det att EF kan översätta requests till C# och till databasen utan att vi behöver specificera massor av SQL queries själva.

## 3. Hur fungerar CreatedAtAction, Ok, NotFound osv?  
  
Det är inbyggda metoder som kan returnera begärd data. Men kanske allra viktigast så tolkar de framgången av den action som försökts genomföras för att generera statuskoder som webläsaren kan förstå och förmedla till användaren på ett standardiserat sätt.
