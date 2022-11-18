namespace StrategyPattern
{
    public class SwordAttack : WeaponAttackTemplate
    {
        protected override void LearnUsingWeapon()
        {
            Console.WriteLine("Learn using sword!");
        }

        protected override void TakeTheWeapon()
        {
            Console.WriteLine("Take sword!");
        }
    }
}
