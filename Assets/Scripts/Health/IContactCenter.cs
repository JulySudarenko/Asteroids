using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    public interface IContactCenter
    {
        Dictionary<int, GameObject> ContactInfo { get; }
    }
}
