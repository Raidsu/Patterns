namespace Asteroids.Test
{
    internal class Player : IPlayer
    {
        public int Hp { get; }
        public IInventory Inventory { get; }
        public IWeapon Weapon { get; }
        
        public Player(int hp, IInventory inventory, IWeapon weapon)
        {
            Hp = hp;
            Inventory = inventory;
            Weapon = weapon;
        }


        private void NameMethod(IPlayerFactory factory)
        {
            factory.CreatePlayer(90);
        }
    }
}
