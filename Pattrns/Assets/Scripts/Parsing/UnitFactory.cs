using System.Collections.Generic;

namespace Asteroids.Parsing
{
    public class UnitFactory : IUnitFactory
    {
        private readonly List<IUnitFactory> _factories;
        
        public UnitFactory()
        {
            _factories = new List<IUnitFactory>();
        }

        public void AddFactory(IUnitFactory factory)
        {
            _factories.Add(factory);
        }

        public void RemoveFactory(IUnitFactory factory)
        {
            _factories.Remove(factory);
        }
        
        public void ParseUnits(string[] input)
        {
            foreach (var factory in _factories)
            {
                factory.ParseUnits(input);
            }
        }
    }
}