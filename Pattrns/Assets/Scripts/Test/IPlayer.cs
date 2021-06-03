namespace Asteroids.Test
{
    internal interface IPlayer
    {
        int Hp { get; }
        IInventory Inventory { get; }
        IWeapon Weapon { get; }
    }
}
