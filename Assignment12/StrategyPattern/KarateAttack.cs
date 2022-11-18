namespace StrategyPattern
{
    public class KarateAttack : IAttackStrategy
    {
        public void Attack()
        {
            Console.WriteLine("Karate attack!");
        }
    }
}
