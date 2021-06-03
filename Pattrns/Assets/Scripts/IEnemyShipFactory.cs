namespace Asteroids
{
    public interface IEnemyShipFactory
    {
        Enemy Create(Health hp, Damage damage);
    }
}