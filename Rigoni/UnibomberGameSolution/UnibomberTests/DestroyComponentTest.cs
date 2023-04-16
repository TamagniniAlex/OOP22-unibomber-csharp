namespace UnibomberTests;

[TestClass]
public class DestroyComponentTest
{
    private const float WALL_COORD_X = 5.6f;
    private const float WALL_COORD_Y = 3.4f;
    private const int FIELD_ROWS = 15;
    private const int FIELD_COLS = 19;
    private readonly IGame _game = new Game(FIELD_ROWS, FIELD_COLS);
    private readonly IEntityFactory _entityFactory = new EntityFactory(_game);

    [TestMethod]
    public void TestDestructibleWall()
    {
        var desWall = _entityFactory.MakeDestructibleWall(new Pair<WALL_COORD_X, WALL_COORD_Y>);
        Assert.False(desWall.GetComponent<DestroyComponent>().IsDestroyed);
        desWall.GetComponent<DestroyComponent>().Destroy();
        Assert.True(desWall.GetComponent<DestroyComponent>().IsDestroyed);
    }
}