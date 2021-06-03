using System;
using UnityEngine;

namespace Asteroids
{
    public class EnemyShipMove : MonoBehaviour
    {
        private Transform _player;
        private Rigidbody2D _enemyRigidBody;
        private Vector2 _enemyMove;


        public void InitEnemyMove(Enemy enemy, Transform player)
        {
            _player = player;
            _enemyRigidBody = enemy.GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _enemyMove = Vector2.MoveTowards(_enemyRigidBody.position, _player.position, 30f);
        }
    }
}