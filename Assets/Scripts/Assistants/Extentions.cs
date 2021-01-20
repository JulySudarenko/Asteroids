using System.IO;
using UnityEngine;

namespace Asteroids
{
    public static class Extentions
    {
        public static T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}
