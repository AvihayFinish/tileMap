# tileMap project

to the game [click here](https://afinish.itch.io/tilemap-project)

the game demonstrating work with tiles in unity, in the game you play as some character and there is a enemy that you need to escape from him <br>
use the arrows to move <br>

for part one we added this scripts: <br>
> - Invisibilty: in this script we control the sprite renderer of the enemy. [click here](https://github.com/AvihayFinish/tileMap/blob/main/Assets/Scripts/3-enemies/Invisibility.cs) <br>
> - Booster: this script inherits from Chaser script [click here](https://github.com/AvihayFinish/tileMap/blob/main/Assets/Scripts/3-enemies/Booster.cs) <br>
> - EnemyControllerStateMachine: in this script we add the states Booster and Invisibillity, and the transitions to them. The transition for Booster its a radius smaller then the radius for the Chaser and to invisibillity its some probability. [click here](https://github.com/AvihayFinish/tileMap/blob/main/Assets/Scripts/3-enemies/EnemyControllerStateMachine.cs)

for part two we added this scripts: <br>
> - TileMapForDijkstra: this script is same as TileMap but we added Dictionary member class to define the weights of the various tiles and the function GetWeights() to get the weight of the tile with her position. [click here](https://github.com/AvihayFinish/tileMap/blob/main/Assets/Scripts/0-shortestPath/TilemapGraphForDijkstra.cs) <br>
> - Igraph: in this interface we added the GetWeight() function. [click here](https://github.com/AvihayFinish/tileMap/blob/main/Assets/Scripts/0-shortestPath/IGraph.cs) <br>
> - Dijkstra: in this script we realization the Dijkstra's algorithm. [click here](https://github.com/AvihayFinish/tileMap/blob/main/Assets/Scripts/0-shortestPath/Dijkstra.cs) <br>
> - TargetMover: in TargetMover we define the way to use Dijkstra in the game. [click here](https://github.com/AvihayFinish/tileMap/blob/main/Assets/Scripts/2-player/TargetMover.cs) <br>
> - PriorityQueue: this script we take from the internrt. its define a Priority queue data structure. [click here](https://github.com/AvihayFinish/tileMap/blob/main/Assets/Scripts/0-shortestPath/PriorityQueue.cs)

