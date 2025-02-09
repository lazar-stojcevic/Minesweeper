namespace Minesweeper;

public static class RandomNumberGenerator
{
    public static int[] GenerateNumbers(int count, int min, int max)
    {
        Random rand = new();
        HashSet<int> numbers = new();

        while (numbers.Count < count)
        {
            numbers.Add(rand.Next(min, max + 1));
        }

        return [.. numbers];
    }
}
