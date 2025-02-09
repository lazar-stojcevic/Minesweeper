namespace Minesweeper;

public class Player
{
    public int RemainingLives { get; private set; }
    public int Position { get; private set; }
    public int Score { get; private set; }

    public Player(int initialLifes)
    {
        RemainingLives = initialLifes;
        Score = 0;
        Position = 0;
    }

    public string CurrentPosition()
    {
        return $"{ConvertToLetter()}{Position / 8 + 1}";
    }

    private char ConvertToLetter()
    {
        return (char)('A' + Position % 8);
    }

    public void Move(string command, Board board)
    {
        switch (command)
        {
            case "up":
                Position += 8;
                break;
            case "down":
                if (Position < 8)
                {
                    return;
                }
                Position -= 8;
                break;
            case "left":
                if (Position % 8 == 0)
                {
                    return;
                }
                Position--;
                break;
            case "right":
                if (Position % 8 == 7)
                {
                    return;
                }
                Position++;
                break;
            default:
                return;
        }
        CheckMine(board);
    }

    public bool AbleToPlay() => RemainingLives > 0 && Position < 55;

    private void CheckMine(Board board)
    {
        var field = board.Fields[Position];
        if (field.HasMine)
        {
            RemainingLives--;
        }
        if (!board.Fields[Position].Sweeped)
        {
            Score++;
            board.Fields[Position].Sweep();
        }
    }
}
