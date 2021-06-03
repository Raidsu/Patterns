namespace Asteroids.Test
{
    internal sealed class Example
    {
        internal void Test(IInventory inventory, IWeapon weapon)
        {
            IPlayerFactory factory = new PlayerFactory(inventory, weapon);
            
            new Example2().StartGame(factory);
            
            // System.Threading.Tasks.Task.Factory.StartNew()
        }
    }
}
