# Startdocument C#2 project - racing game

Startdocument van **Monique Sabong**, **Yannieck Blaauw** en **Chris Klunder**. 

## Applicatie Beschrijving

Voor dit project willen wij een race game maken. Het is een single player game, waarbij je één auto kan besturen van links naar rechts.
Er komen 4 of meerdere wegen naast elkaar waarbij andere auto's oprijden die je moet ontwijken. Het doel van dit spel is om zo ver mogelijk auto's te ontwijken zonder
een auto aan te rijden of een ander obstakel. Voor dit spel komt er minstens 4 schermen, namelijk de startmenu, de game zelf, een highscore board met de beste tijd en een about pagina.


### Input & Output

In deze sectie worden de input en output van de applicatie beschreven.

#### Input

In de tabellen hieronder worden alle input beschreven. (De input dat de user moet invoeren om de applicatie werkend te krijgen)

|Case|Type|Conditions|
|----|----|----------|
|Naam speler|`String`|not empty|
|Type auto|`Image`| not empty| 
|De keybinds om de auto naar links of naar rechts te laten gaan|`KeyBoardKey`|

#### Output

|Case|Type|
|----|----|
|De highscore van de speler|`TimeSpan`|
|De images van de auto's op de weg|`image`|
|De gekozen auto van de speler op de weg|`image`|
|De positie van de speler op de weg|`float`|
|De positie van de overige auto's op de weg|`float`|
|De score aan het einde van de game (tijd: HH:MM:SS)|`TimeSpan`|

#### Calculations

| Case              | Calculation                        |
| ----------------- | ---------------------------------- |
| De tijd score van de speler| TimeSpan  |
| De auto van de speler naar links of recht laten gaan| huidige postitie plus of min de hoeveelheid dat je naar links of recht gaat |
| Berekenen of de speler een auto heeft geraakt| Checken of de auto van de speler bijna of dezelfde x/y waarde heeft als de auto waar je tegenaan kan botsen |
| De auto op de weg houden. Niet dat je de auto buiten het scherm komt. | Als de auto van de speler niet kleiner dan of groter dan een bepaalde x waarde komt, dan kan je niet verder naar links of rechts| 


#### Remarks

* Input will be validated.
* Only the Main class will contain `System.out.println`
* Unit Tests will be provided.

## Lay-out of GUI
Startmenu van de game
![GUI](img/race-start.png "First Version of the GUI")

About pagina
![GUI](img/race-about.png "First Version of the GUI")

Highscore pagina
![GUI](img/race-highscore.png "First Version of the GUI")

De game zelf
![GUI](img/race-game.png "First Version of the GUI")

## Class Diagram

![Class Diagram](img/raceGame.png "First Version of the class diagram")

## Testplan

In this section the testcases will be described to test the application.

### Test Data

In de tabellen hieronder worden de data weergegeven die nodig zijn om de applicatie te testen.


#### Player

| ID        | Input                                                        | Code                                               |
| --------- | ------------------------------------------------------------ | -------------------------------------------------- |
| `Lightning McQueen`| name: Chris<br /> | `new Player("Lightning McQueen")`|

#### Car
| ID        | Input                                                        | Code                                               |
| --------- | ------------------------------------------------------------ | -------------------------------------------------- |
| `rodeAuto`| rodeAuto.png<br /> | `new Car(image[0])`|
| `blauweAuto`| blauweAuto.png<br /> | `new Car(image[1])`|
| `geleAuto`| geleAuto.png<br /> | `new Car(image[2])`|
| `oranjeAuto`| oranjeAuto.png<br /> | `new Car(image[3])`|

#### Game
| ID        | Input                                                        | Code                                               |
| --------- | ------------------------------------------------------------ | -------------------------------------------------- |
| `raceGame`| name: raceGame<br /> | `new Game(Player lightning McQueen)`|

### Test Cases

In this section the testcases will be described. Every test case should be executed with the test data as starting point.

#### #1 Checking if the member is a senior or not

Testing the method to check if a member is 18 years or older.

|Step|Input|Action|Expected output|
|----|-----|------|---------------|
|1| `Monique1` | `isSenior()` |FALSE|
|2| `Henry1` | `isSenior()`| TRUE| 




### User testplan

|input|       |                                    | |Expected output       |               |
|-----|-------|---------------------|--------------|------------------------|---------------|
|Step|Birthday|Start membership date|playing member|Contribution price      |Youngest member|
|1|22-09-2006 |05-11-2020           |FALSE         |75                      |Youngest member|
|2|22-10-2006 |05-11-2020           |TRUE          |120                     | -             |
|3|22-10-2006 |05-11-2014           |TRUE          |114                     | -             |
|4|22-09-2002 |05-11-2020           |FALSE         |150                     | -             |
|5|22-09-2002 |05-11-2020           |TRUE          |195                     | -             |
|6|22-09-2002 |05-11-2014           |FALSE         |142,50                  | -             |
|Expected output||Average membership years is: 6 years|| Total Contribution: 753,75|        |