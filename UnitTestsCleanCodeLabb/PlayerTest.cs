namespace UnitTestsCleanCodeLabb;

[TestClass]
public class PlayerTest
{
    private Player? _player;

    [TestInitialize]
    public void CreatePlayer()
    {
        this._player = new Player("testPlayer", 0);
    }

    [TestMethod]
    public void TestUpdate()
    {
        _player.Update(5);

        Assert.AreEqual(5, _player.TotalNumberOfGuesses);
        Assert.AreEqual(2, _player.NumberOfGames);
    }

    [TestMethod]
    public void TestCalculateAverage()
    {
        _player.Update(5);
        _player.CalculateAverage();

        Assert.AreEqual(_player.CalculateAverage(), 2.5);
    }

    [TestMethod]
    public void TestPlayerName()
    {
        Assert.AreEqual(_player.PlayerName, "testPlayer");
    }
}