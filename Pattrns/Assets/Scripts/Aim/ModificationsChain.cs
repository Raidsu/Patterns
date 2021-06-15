using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Aim
{
    public class ModificationsChain

    {
        [SerializeField] private List<ModificationHandler> _gameHandlers;
        public ShipWeapon Weapon { get;}

        internal ModificationsChain(IPlayerInventory bullet, Transform barrelPosition, float force)
        {
            Weapon = new ShipWeapon(bullet, barrelPosition, force);
        }

        private void InitChain()
        {
            _gameHandlers[0].Handle(Weapon);
            for (var i = 1; i < _gameHandlers.Count; i++) 
            {
                _gameHandlers[i - 1].SetNext(_gameHandlers[i]);
            }
        }
    }
}