namespace Minesweeper;

public class Board
{
    public readonly Field[] Fields;

    public Board(int numberOfMines)
    {
        var minesPositions = RandomNumberGenerator.GenerateNumbers(numberOfMines, 1, 63);
        Fields = Enumerable.Range(0, 64).Select(index =>
        {
            return new Field(minesPositions.Contains(index));
        }).ToArray();
        Fields[0].Sweep();
    }
}
