namespace Asteroids.Aim
{
    public abstract class WeaponModifications : IAttack
    {
        private ShipWeapon _weapon;
        
        protected abstract ShipWeapon AddModification(ShipWeapon weapon);
        protected abstract ShipWeapon RemoveModification(ShipWeapon weapon);
        
        public void ApplyModification(ShipWeapon weapon)
        {
            _weapon = AddModification(weapon);
        }

        public void DeleteModification(ShipWeapon weapon)
        {
            _weapon = RemoveModification(weapon);
        }

        public void Attack()
        {
            _weapon.Attack();
        }
    }
}