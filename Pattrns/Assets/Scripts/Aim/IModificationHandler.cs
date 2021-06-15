namespace Asteroids.Aim
{
    public interface IModificationHandler
    {
        IModificationHandler Handle(ShipWeapon weapon);
        IModificationHandler SetNext(IModificationHandler nextHandler);

    }
}