using UnityEngine;

namespace Asteroids.Aim
{
    public class AimModification : WeaponModifications
    {
        private readonly Vector2 _aimPosition;
        private readonly IAim _aim;
        private GameObject _aimObject;

        public AimModification(Vector2 aimPosition, IAim aim)
        {
            _aimPosition = aimPosition;
            _aim = aim;
        }
        
        protected override ShipWeapon AddModification(ShipWeapon weapon)
        {
            _aimObject = Object.Instantiate(_aim.AimInstance, _aimPosition, Quaternion.identity);
            weapon.SetBarrelPosition(_aim.BarrelPositionAim);
            return weapon;

        }

        protected override ShipWeapon RemoveModification(ShipWeapon weapon)
        {
            Object.Destroy(_aimObject);
            return weapon;
        }
    }
}