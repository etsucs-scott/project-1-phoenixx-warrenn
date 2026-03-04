namespace AdventureGame.Core
{
    public class Player : ICharacter
    {
        public int Health { get; private set; } = 100;
        public int MaxHealth { get; } = 150;

        public List<Weapon> Inventory { get; } = new();
        public void Attack(ICharacter target)
        {
            int damage = 10 + GetBestWeaponModifier();
            target.TakeDamage(damage);
        }
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }
        public void Heal(int amount)
        {
            Health += amount;
            if (Health > MaxHealth) Health = MaxHealth;
        }
        private int GetBestWeaponModifier()
        {
            if (Inventory.Count == 0) return 0;
            return Inventory.Max(w => w.AttackModifier);
        }
    }
}