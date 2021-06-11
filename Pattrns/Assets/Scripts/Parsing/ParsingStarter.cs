using System;
using UnityEngine;

namespace Asteroids.Parsing
{
    public class ParsingStarter : MonoBehaviour
    {
        [SerializeField] private string inputData;
        private void Start()
        {
            var parsingFile = new ParseFile();
            parsingFile.SetFileToParse(inputData);
            var preparedFile = parsingFile.PrepareFile();
            
            var unitFactory = new UnitFactory();
            unitFactory.AddFactory(new InfantryFactory());
            unitFactory.AddFactory(new MagFactory());
            unitFactory.ParseUnits(preparedFile);
        }
    }
}