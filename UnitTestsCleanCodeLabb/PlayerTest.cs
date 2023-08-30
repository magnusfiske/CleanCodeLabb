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

        Assert.AreEqual(2.5, _player.CalculateAverage());
    }

    [TestMethod]
    public void TestPlayerName()
    {
        Assert.AreEqual("testPlayer", _player.PlayerName);
    }
}