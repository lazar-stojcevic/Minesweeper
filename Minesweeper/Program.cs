using Minesweeper;

const int INITIAL_LIFES = 3;
const int NUMBER_OF_MINES = 12;
string[] POSSIBLE_COMMANDS = ["up", "down", "left", "right"];

var board = new Board(NUMBER_OF_MINES);
var player = new Player(INITIAL_LIFES);

Console.WriteLine("Welcome to Minefield!");
Console.WriteLine("Use commands 'up', 'down', 'left', 'right' to navigate chess board");

while (player.AbleToPlay())
{
    Console.WriteLine($"Current possition: {player.CurrentPosition()}");
    Console.WriteLine($"Score: {player.Score}");
    Console.WriteLine($"Lives left: {player.RemainingLives}");
    Console.Write("Command: ");

    var command = Console.ReadLine();
    if (POSSIBLE_COMMANDS.Contains(command?.ToLowerInvariant()))
    {
        player.Move(command!.ToLower(), board);
        continue;
    }
    else
    {
        Console.WriteLine("Wrong command!");
    }
}

if (player.RemainingLives > 0)
{
    Console.WriteLine($"YOU WIN! Final score: {player.Score}");
}
else
{
    Console.WriteLine("No lives left, try again.");
}