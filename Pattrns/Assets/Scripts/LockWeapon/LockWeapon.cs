namespace Asteroids.LockWeapon
{
    public class LockWeapon
    {
        public bool IsLocked { get; set; }

        public LockWeapon(bool isLocked)
        {
            IsLocked = isLocked;
        }
    }
}