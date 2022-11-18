
using StrategyPattern;

Console.WriteLine("Select attack preference! 1 -> Sword; 2 -> Judo; 3 -> Knife; 4 -> Karate;");
var selection = int.Parse(Console.ReadLine());

var context = new AttackContext();

if (selection == 1)
{
    context.SeStrategy(new SwordAttack());
    context.Attack();
}

if (selection == 2)
{
    context.SeStrategy(new JudoAttack());
    context.Attack();
}

if (selection == 3)
{
    context.SeStrategy(new KnifeAttack());
    context.Attack();
}

if (selection == 4)
{
    context.SeStrategy(new KarateAttack());
    context.Attack();
}

if (selection > 4 || selection < 1)
{
    context.SeStrategy(new SwordAttack());
    context.Attack();
}