using System;
using UnityEngine;

namespace Asteroids.Parsing
{
    public class MagFactory : IUnitFactory
    {
        private const string CFactoryMainType = "mag";
        public void ParseUnits(string[] input)
        {
            for (var index = 0; index < input.Length; index++)
            {
                if (input[index] == "unit")
                {
                    index++;
                    if (input[index] == "type")
                    {
                        index++;
                        if (input[index] == CFactoryMainType)
                        {
                            index++;
                            try
                            {
                                new Mag(Convert.ToSingle(input[index]));
                            }
                            catch (Exception e)
                            {
                                Debug.Log($"{e}\n, Ошибка ввода HP! Проверьте корректность файла.");
                            }
                        }
                    }
                    else Debug.Log("Ошибка чтения файла! Проверьте корректность файла.");
                }
                else break;
            }
        }

    }
}