namespace StrategyPattern
{
    public class JudoAttack : IAttackStrategy
    {
        public void Attack()
        {
            Console.WriteLine("Judo attack!");
        }
    }
}
