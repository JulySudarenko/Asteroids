namespace TheSixthLessonTasks.Patterns.ChainOfResponsibilitySecond
{
    internal sealed class AddAttackModifier : EnemyModifier
    {
        private readonly int _attack;

        public AddAttackModifier(Enemy enemy, int attack)
            : base(enemy)
        {
            _attack = attack;
            
        }

        public override void Handle()
        {
            _enemy.Attack += _attack;
            base.Handle();
        }
    }
}
