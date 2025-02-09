namespace Minesweeper;

public class Field
{
    public bool HasMine { get; private set; }
    public bool Sweeped { get; private set; }

    public Field(bool hasMine)
    {
        HasMine = hasMine;
    }

    public void Sweep()
    {
        Sweeped = true;
        HasMine = false;
    }
}
