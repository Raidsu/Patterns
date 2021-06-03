using Asteroids.Object_Pool;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        private Camera _camera;
        private Ship _ship;
        private GetDamage _damage;
        private BulletPool _bulletPool;
        
        private void Start()
        {
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(transform, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            _ship = new Ship(moveTransform, rotation);
            _damage = new GetDamage();
            _bulletPool = new BulletPool(_bullet.gameObject);
            _bulletPool.CreateBullets(20);
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

            if (Input.GetButtonDown("Fire1"))
            {
                var temAmmunition = _bulletPool.GetBullet();
                temAmmunition.transform.position = _barrel.position;
                temAmmunition.transform.rotation = _barrel.rotation;
                temAmmunition.GetComponent<Rigidbody2D>().AddForce(_barrel.up * _force);
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
