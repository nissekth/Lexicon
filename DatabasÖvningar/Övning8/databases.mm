
<map version="1.0.1">
<node TEXT="Databaser" COLOR="#17365D" STYLE="bubble">

  <node TEXT="Relationell – Tabeller med rader, kolumner och relationer mellan dem." POSITION="right" COLOR="#2878B5">

    <node TEXT="Struktur – Tabeller med rader,och kolumner, identifierade av Primary keys och Foreign keys"/>
    <node TEXT="Datahantering – SQL-queries som kan extrahera data och manipulera data och strukturen"/>
    <node TEXT="Egenskaper – Förberett schema, bra dataintegritet och ACID-transaktioner"/>
    <node TEXT="Exempel – PostgreSQL, MySQL, SQL Server"/>

  </node>

  <node TEXT="Dokument – Lagrar data i flexibla föränderliga dokument, oftast i JSON-format." POSITION="right" COLOR="#299B65">

    <node TEXT="Struktur – Dokument-träd, JSON, samlingar och nästlade objekt"/>
    <node TEXT="Datahantering – Data sparas och hämtas som individuella dokument-träd"/>
    <node TEXT="Egenskaper – Flexibelt schema och stöd för halvstrukturerad data, lättförståeligt och lätthanterat"/>
    <node TEXT="Exempel – MongoDB, CouchDB"/>

  </node>

  <node TEXT="Graf – Lagrar data som noder och fokuserar på relationer mellan dem." POSITION="right" COLOR="#9468B8">

    <node TEXT="Struktur – Noder (entiteter), kanter (relationer) och attribut"/>
    <node TEXT="Datahantering – Relationer följs mellan noder för att hitta kopplingar mellan dem"/>
    <node TEXT="Egenskaper – Relationsfokuserad och effektiv för data som är länkad och där relationerna mellan dem är intressant"/>
    <node TEXT="Exempel – Neo4j, Amazon Neptune och ArangoDB"/>

  </node>

  <node TEXT="Key-value – Lagrar data som set av nycklar och tillhörande data, som dictionaries." POSITION="right" COLOR="#C58B43">

    <node TEXT="Struktur – Unika nycklar och tillhörande data"/>
    <node TEXT="Datahantering – Värden sparas och hämtas indexerat med sina egan nycklar"/>
    <node TEXT="Egenskaper – Enkel datastruktur och ruskigt snabb indexering och datahämtning"/>
    <node TEXT="Exempel – Redis, Amazon DynamoDB"/>

  </node>

  <node TEXT="Sök – Specialiserade databassystem för snabb sökning i stora datamängder. Bygger på dokument." POSITION="right" COLOR="#68758B">

    <node TEXT="Struktur – Dokument, sökindex och inverterade index"/>
    <node TEXT="Datahantering – Indexering, fritextsökning och relevansrankning"/>
    <node TEXT="Egenskaper – Snabb sökning på text, kan filtrera och ge resultat baserade på relevans"/>
    <node TEXT="Exempel – Elasticsearch, OpenSearch"/>

  </node>

</node>
</map>

