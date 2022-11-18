namespace StrategyPattern
{
    public abstract class WeaponAttackTemplate: IAttackStrategy
    {
        public void Attack()
        {
            LearnUsingWeapon();
            TakeTheWeapon();
            AttackYourOpponent();
            DefendYourself();
        }

        protected virtual void LearnUsingWeapon()
        {
            Console.WriteLine("Learn using weapon!");
        }
        protected virtual void TakeTheWeapon()
        {
            Console.WriteLine("Take the weapon!");
        }
        protected virtual void AttackYourOpponent()
        {
            Console.WriteLine("Attack oppenent!");
        }
        protected virtual void DefendYourself()
        {
            Console.WriteLine("Defent yourself!");
        }

    }
}
