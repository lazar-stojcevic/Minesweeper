using System.Reflection;

namespace Minesweeper.Tests;

[TestFixture]
internal class PlayerTests
{
    private Player player;
    private Board board;

    [SetUp]
    public void Setup()
    {
        player = new Player(3);
        board = new Board(10);
    }

    [Test]
    public void CurrentPositionTest()
    {
        var result = player.CurrentPosition();
        Assert.That(result, Is.EqualTo("A1"));
    }

    [TestCase("up", 0, 8)]
    [TestCase("down", 8, 0)]
    [TestCase("down", 0, 0)]
    [TestCase("left", 0, 0)]
    [TestCase("left", 1, 0)]
    [TestCase("right", 0, 1)]
    [TestCase("right", 7, 7)]
    public void MoveTest(string command, int currentPosition, int exprectedPosition)
    {
        SetPlayerPosition(currentPosition);
        player.Move(command, board);
        Assert.That(player.Position, Is.EqualTo(exprectedPosition));
    }

    [Test]
    public void MoveOnMineTest()
    {
        board = new Board(63);
        player.Move("up", board);
        Assert.That(player.RemainingLives, Is.EqualTo(2));
    }

    [Test]
    public void MoveOnEmptyFieldTest()
    {
        board = new Board(0);
        player.Move("up", board);
        Assert.That(player.RemainingLives, Is.EqualTo(3));
    }

    private void SetPlayerPosition(int position)
    {
        var propertyInfo = player.GetType().GetTypeInfo().GetDeclaredProperty("Position");
        propertyInfo!.SetValue(player, Convert.ChangeType(position, propertyInfo.PropertyType));
    }

}