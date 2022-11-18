namespace StrategyPattern
{
    public class AttackContext
    {
        private IAttackStrategy strategy;

        public void SeStrategy(IAttackStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void Attack()
        {
            if (strategy == null) Console.WriteLine("No strategy selected");
            else strategy.Attack();
        }
    }
}
