namespace Asteroids
{
    public class AttackLock
    {
        public bool IsUnlock { get; set; }

        public AttackLock(bool isUnlock)
        {
            IsUnlock = isUnlock;
        }
    }
}
