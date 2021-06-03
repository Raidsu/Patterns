namespace Asteroids.Test
{
    public interface IWeapon
    {
        int CountAmmunition { get; }
        IAmmunition Ammunition { get; }
    }
}
