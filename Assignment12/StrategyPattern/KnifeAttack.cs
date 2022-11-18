namespace StrategyPattern
{
    public class KnifeAttack : WeaponAttackTemplate
    {
        protected override void LearnUsingWeapon()
        {
            Console.WriteLine("Learn using knife!");
        }

        protected override void TakeTheWeapon()
        {
            Console.WriteLine("Take knife!");
        }
    }
}
