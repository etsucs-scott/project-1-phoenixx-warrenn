namespace AdventureGame.Core
{
    public class GameEngine
    {
        private const int BaseDamage = 10;

        public string StartBattle(Player player, Monster monster)
        {
            string log = "";

            log += "The Battle Begins!\n";
            while (player.Health > 0 && monster.Health > 0)
            {
                //for player turn
                int playerDamage = BaseDamage + GetBestWeaponModifier(player); monster.TakeDamage(playerDamage);

                log += $"Player dealth {playerDamage} damage! Monster HP: {monster.Health}\n";
                if (monster.Health <= 0)
                {
                    log += "Monster defeated!\n";
                    break;
                }

                //for monster turn
                int monsterDamage = BaseDamage; player.TakeDamage(monsterDamage);

                log += $"Monster dealt {monsterDamage} damage. Player HP: {player.Health}\n";
            }

            if (player.Health <= 0)
            
                log += "Player has been defeated. Game Over...\n";

                return log;
            }
            
            private int GetBestWeaponModifier(Player player)
        {
            if (player.Inventory.Count == 0)
                return 0;

            return player.Inventory.Max(w => w.AttackModifier);
        }
    }
}
