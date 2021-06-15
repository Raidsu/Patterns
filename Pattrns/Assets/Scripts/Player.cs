using Asteroids.Aim;
using Asteroids.LockWeapon;
using Asteroids.Object_Pool;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Sprite _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private Vector2 _aimPosition;
        [SerializeField] private GameObject _aimInstanse;
        [SerializeField] private float _force;
        [SerializeField] private float _aimDistance;
        
        private Camera _camera;
        private Ship _ship;
        private GetDamage _damage;
        private ShipWeapon _weapon;
        private Aim.Aim _aim;
        private IAttack _attack;
        private WeaponModifications _weaponModifications;
        private bool isAimed = false;
        private LockWeapon.LockWeapon _lockWeapon;
        private WeaponProxy _weaponProxy;
        private ModificationsChain _modificationsChain;
        
        private void Start()
        {
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(transform, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            _ship = new Ship(moveTransform, rotation);
            _damage = new GetDamage();
            ServiceLocator.Resolve<IServiceLocator>().CreateBullets(20);
            _lockWeapon = new LockWeapon.LockWeapon(false);
            _modificationsChain = new ModificationsChain(new BulletPool(_bullet), _barrel, _force);
            _weapon = _modificationsChain.Weapon;
            _weaponProxy = new WeaponProxy(_weapon, _lockWeapon);
            
            _aim = new Aim.Aim(_aimDistance, _barrel, _aimInstanse);
            _attack = _weaponModifications;
            

        }

        private void Update()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);
            
            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }
            
            if (Input.GetMouseButtonDown(1))
            {
                if (!isAimed)
                {
                    _weaponModifications = new AimModification(_aimPosition, _aim);
                    _weaponModifications.ApplyModification(_weapon);
                    isAimed = !isAimed;
                }
                else
                {
                    _weaponModifications.DeleteModification(_weapon);
                    isAimed = !isAimed;
                }    
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                var jammingProbability = Random.Range(0, 11);
                if (jammingProbability < 4)
                    _lockWeapon.IsLocked = true;
                
                _weaponProxy.Attack();
            }
            
            if (Input.GetKeyDown(KeyCode.H))
            {
                _lockWeapon.IsLocked = false;
                Debug.Log("Weapon is unlocked");
            }
        }

       

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<EnemyMarker>())
            {
                _hp-=_damage.GetDamaged(other.gameObject);
            }
            
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
