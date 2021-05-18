# BoardExcercise

This is sample code for the Battleship game. Current state of the code. 

Battleship state tracking API for a single player that supports the following logic:
• Create a board
• Add a battleship to the board
• Take an “attack” at a given position, and report back whether the attack resulted in a hit or a miss.

# How to run the code?
You should be just able to clone/download the code and open it in your favourite C# IDE and run it. 

By default the swagger endpoint is cofigured in the local settings to run, so you should see the Swagger UI with 2 endpoints. 
- One end point is to setup the game 
- Second endpoint is to attack and it reports if it is a hit or miss


To maintain the state the service is implemented as Singleton instance. 

# Feddback
Feel free to report any improvements to the code. 

Thank you.

