using UnityEngine;


namespace Asteroids
{
    public static class SpawnPlaces
    {
        public static Vector3 FindPoint(Vector3 center, float radius, int startAngle, int finishAngle)
        {
            return center + 
                   Quaternion.AngleAxis(1.0f * Random.Range(startAngle, finishAngle), Vector3.forward) * 
                   (Vector3.right * radius);
        }
    }
}
