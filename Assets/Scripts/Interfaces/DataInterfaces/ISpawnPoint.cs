namespace Asteroids
{
    internal interface ISpawnPoint
    {
        float SpawnDistance { get; }

        int StartAngle { get; }

        int FinishAngle { get; }

    }
}
