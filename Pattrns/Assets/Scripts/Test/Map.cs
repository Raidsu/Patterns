namespace Asteroids.Test
{
    class Map : IMap
    {
        public IPlayer Player { get; }
        
        public Map(IPlayer player)
        {
            Player = player;
        }
    }
}
