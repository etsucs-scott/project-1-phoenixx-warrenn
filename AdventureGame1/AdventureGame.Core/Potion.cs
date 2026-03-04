namespace AdventureGame.Core
{
    public class Potion : Item
    {
        public int HealAmount { get; } = 20;

        public Potion(string name)
            : base(name, $"You used {name} and healed yourself!")
        {

        }
    }
}
