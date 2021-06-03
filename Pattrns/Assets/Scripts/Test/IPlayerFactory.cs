namespace Asteroids.Test
{
    internal interface IPlayerFactory
    {
        IPlayer CreatePlayer(int hp);
        IPlayer CreatePlayerNotWeapon(int hp);
    }
}
