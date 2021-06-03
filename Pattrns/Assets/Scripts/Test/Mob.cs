namespace Asteroids.Test
{
    class Mob : IPlayer
    {
        public int Hp { get; }
        public IInventory Inventory { get; }
        public IWeapon Weapon { get; }
        
        public Mob(int hp)
        {
            Hp = hp;
        }
    }
}
