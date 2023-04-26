# Startdocument C#2 project - racing game

Startdocument van **Monique Sabong**, **Yannieck Blaauw** en **Chris Klunder**. 

## Applicatie Beschrijving

Voor dit project willen wij een race game maken. Het is een single player game, waarbij je één auto kan besturen van links naar rechts.
Er komen 4 of meerdere wegen naast elkaar waarbij andere auto's oprijden die je moet ontwijken. Het doel van dit spel is om zo ver mogelijk auto's te ontwijken zonder
een auto aan te rijden of een ander obstakel. Voor dit spel komt er minstens 4 schermen, namelijk de startmenu, de game zelf, een highscore board en een about pagina.


### Input & Output

In deze sectie worden de input en output van de applicatie beschreven.

#### Input

In de tabellen hieronder worden alle input beschreven. (De input dat de user moet invoeren om de applicatie werkend te krijgen)

|Case|Type|Conditions|
|----|----|----------|
|Name of player|`String`|not empty|
|Type of car|`Image`| not empty| 

#### Output

|Case|Type|
|----|----|
|De score aan het einde van de game|`TimeSpan`|



#### Calculations

| Case              | Calculation                        |
| ----------------- | ---------------------------------- |
| Total contribution of 1 member | The sum of all the contribution prices of 1 member |

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

![Class Diagram](img/contribution.png "First Version of the class diagram")

## Testplan

In this section the testcases will be described to test the application.

### Test Data

In de tabellen hieronder worden de data weergegeven die nodig zijn om de applicatie te testen.


#### Player

| ID        | Input                                                        | Code                                               |
| --------- | ------------------------------------------------------------ | -------------------------------------------------- |
| `Chris`| name: Chris<br /> | `new Player("Chris")`|
| `Yannieck`| name: Yannieck<br /> | `new Player("Yannieck")`|
| `Monique`| name: Monique<br /> | `new Player("Monique")`|

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