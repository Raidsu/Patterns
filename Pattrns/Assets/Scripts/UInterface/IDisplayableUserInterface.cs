using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.UInterface
{
    public interface IDisplayableUserInterface
    {
        bool Successful { get; }
        bool ExecutePoints(long points);
    }
}