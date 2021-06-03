namespace Asteroids.Test
{
    internal class PlayerFactory : IPlayerFactory
    {
        private readonly IInventory _inventory;
        private readonly IWeapon _weapon;

        public PlayerFactory(IInventory inventory, IWeapon weapon)
        {
            _inventory = inventory;
            _weapon = weapon;
        }
        
        public IPlayer CreatePlayer(int hp)
        {
            return new Player(hp, _inventory, _weapon);
        }

        public IPlayer CreatePlayerNotWeapon(int hp)
        {
            return new Mob(hp);
        }
    }
}
