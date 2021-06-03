namespace Asteroids.Test
{
    internal sealed class Example2
    {
        internal void StartGame(IPlayerFactory playerFactory)
        {
            new Example3().StartGame(playerFactory.CreatePlayer(177)); 
        }
    }
}
