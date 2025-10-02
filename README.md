# GroceryApp sprint4

Gitflow Workflow

Voor dit project word er gebruik gemaakt van de Gitflow methode om de ontwikkeling gestructureerd en overzichtelijk te houden.

Binnen Gitflow worden de volgende branches gebruikt:


## main
Bevat de stabiele, productierijpe code. Alles in deze branch is getest en klaar om in productie te gebruiken.


## develop
De integratiebranch waarin alle nieuwe features samengevoegd worden. Hier staat altijd de laatste werkende ontwikkelversie.


## feature/…
Voor iedere nieuwe user case of functionaliteit wordt een aparte feature branch aangemaakt.

- feature/UC8 → voor de uitwerking van Use Case 8.
- feature/UC9 → voor de uitwerking van Use Case 9.


Zodra een feature klaar is, wordt deze terug samengevoegd in de develop branch.


## release/…
Wanneer een nieuwe versie bijna klaar is, wordt er een release branch aangemaakt vanuit develop. Hierin worden enkel nog documentatie-updates gedaan, zodat de release stabiel wordt.


## hotfix/…
 Voor dringende fouten in de main branch die snel opgelost moeten worden, zonder te wachten op een nieuwe release.


    

## UC10 Productaantal in boodschappenlijst
Productaantallen kunnen gewijzigd worden in de boodschappenlijst

## UC11 Meest verkochte producten
De top 5 meest populaire producten worden weergegeven onder "Meest verkocht"

## UC13 Klanten tonen per product  
Admins kunnen per product zien welke gebruikers deze gekocht hebben

  
