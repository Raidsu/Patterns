namespace Asteroids.Aim
{
    public abstract class ModificationHandler : IModificationHandler
    {
        private IModificationHandler _nextHandler;

        
        public virtual IModificationHandler Handle(ShipWeapon weapon)
        {
            _nextHandler?.Handle(weapon);
            return _nextHandler;

        }

        public IModificationHandler SetNext(IModificationHandler nextHandler)
        {
            _nextHandler = nextHandler;
            return nextHandler;

        }
    }
}