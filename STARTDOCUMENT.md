# Startdocument C#2 project - racing game

Startdocument van **Monique Sabong**, **Yannieck Blaauw** en **Chris Klunder**. 

## Probleem Beschrijving



### Input & Output

In deze sectie worden de input en output van de applicatie beschreven.

#### Input

In de tabellen hieronder worden alle input beschreven. (De input dat de user moet invoeren om de applicatie werkend te krijgen)

|Case|Type|Conditions|
|----|----|----------|
|Name of Sportclub|`String`|not empty|
|Name Of Member|`String` |not empty|
|DOB of Member|`DateTime` |dd-mm-yyyy|
|Member since date|`dd:mm:yyyy`|not empty|
|PlayingMember|`boolean`|not empty|
|Member ID|`int`|not empty|

#### Output

|Case|Type|
|----|----|
|The cumulative total contribution price|`float`|
|Youngest member at the sportclub|`String`|
|The average number of membership years|`int`|
|Contribution price for a member|`float`|


#### Calculations

| Case              | Calculation                        |
| ----------------- | ---------------------------------- |
| Total contribution of 1 member | The sum of all the contribution prices of 1 member |
| Total contribution of all the members in the sportclub|The sum of all the contribution prices of all the members|
| The 5% discount if a member has a membership longer than 7 years|0.05 x the total contribution price from a member|

#### Remarks

* Input will be validated.
* Only the Main class will contain `System.out.println`
* Unit Tests will be provided.

## Lay-out of GUI

![GUI](img/GUI.png "First Version of the GUI")

## Class Diagram

![Class Diagram](img/contribution.png "First Version of the class diagram")

## Testplan

In this section the testcases will be described to test the application.

### Test Data

In de tabellen hieronder worden de data weergegeven die nodig zijn om de applicatie te testen.


#### Sportclub

| ID        | Input                                                        | Code                                               |
| --------- | ------------------------------------------------------------ | -------------------------------------------------- |
| `Ice skating club`| name: Ice skating club<br /> | `new Sportclub("Ice skating club")`|

### Test Cases

In this section the testcases will be described. Every test case should be executed with the test data as starting point.

#### #1 Checking if the member is a senior or not

Testing the method to check if a member is 18 years or older.

|Step|Input|Action|Expected output|
|----|-----|------|---------------|
|1| `Monique1` | `isSenior()` |FALSE|
|2| `Henry1` | `isSenior()`| TRUE| 

#### #2 Getting the contribution price for one member


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