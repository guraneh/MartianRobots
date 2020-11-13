# MartianRobots

Assignment: [Docs/Programming_Problem_ROBOTS.docx](https://github.com/guraneh/MartianRobots/blob/main/Docs/Programming_Problem_ROBOTS.docx)

### List of assumptions
* Program is made as component library
* Robot “scent” prohibits future robots from dropping off the world at the same grid point and the same direction
* User doesn’t get extra information if input data has wrong format. Program returns boolean result and data object only
* All commands listed in the “CommandAlias” enum have to be implemented

### An estimate of how long this would take
It has taken about 4 hours. But for the entire solution probably I need to make UI (console or graphical), remake input data parsing (to see reason of falling), more detailed unit tests may be, possibility to add new commands from the external library, and user documentation. I think it takes 6-12 hours.

### Architecture & design
Main component of the solution is “RobotManager” class. Its method “Run” runs commands execution for  robots. All needed data “RobotManager” takes from the instance of “InputData” class. Input data can be parsed from the string format. The result of commands executing returns in “OutputData” object.

All commands are implemented as derived from abstract class “Command”. To specify alias of a command I used attribute “AliasAttribute”. If you need to add new command you should add new alias in the “CommandAlias” enum, create class inherited from “Command”, implement method “Execute”, and mars this class by “AliasAttribute” to bind alias.
