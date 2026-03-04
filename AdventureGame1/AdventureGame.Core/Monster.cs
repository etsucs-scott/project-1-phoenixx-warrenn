namespace AdventureGame.Core
{
    public  class Monster : ICharacter
    {
        public int Health { get; private set; }

        private static Random rng = new();

        public Monster()
        {
            Health = rng.Next(30, 51);
        }

        public void Attack(ICharacter target)
        {
            target.TakeDamage(10);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }
    }
}