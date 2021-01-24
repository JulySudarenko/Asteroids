namespace Asteroids
{
    internal class SpaceshipModifier
    {
        protected SpaceshipInitialization _spaceship;
        protected SpaceshipModifier Next;

        public SpaceshipModifier(SpaceshipInitialization spaceship)
        {
            _spaceship = spaceship;
        }

        public void Add(SpaceshipModifier cm)
        {
            if (Next != null)
            {
                Next.Add(cm);
            }
            else
            {
                Next = cm;
            }
        }

        public virtual void Handle() => Next?.Handle();
    }
}
