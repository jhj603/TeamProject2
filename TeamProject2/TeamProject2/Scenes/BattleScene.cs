using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class BattleScene : Scene
    {
        Dictionary<MonsterType, Monster>? monsterDict;

        List<Monster>? monsters;

        Random? rand;

        int prePlayerHP = 0;

        public BattleScene()
        {
            monsterDict = new Dictionary<MonsterType, Monster>();

            monsterDict.Add(MonsterType.Minion, new Monster(1, MonsterType.Minion, "미니언", 5, 15));
            monsterDict.Add(MonsterType.VoidInsect, new Monster(1, MonsterType.VoidInsect, "공허충", 9, 10));
            monsterDict.Add(MonsterType.SiegeMinion, new Monster(1, MonsterType.SiegeMinion, "대포미니언", 8, 25));

            monsters = new List<Monster>();

            rand = new Random();
        }

        public override bool Initialize(Player playerInstance)
        {
            if (!base.Initialize(playerInstance))
                return false;

            monsters.Clear();

            int currentDifficulty = player.CurrentDungeon / 5;
            int monsterLevel = 0;

            for (int i = 0; i <= (player.CurrentDungeon % 5); ++i)
            {
                monsterLevel = player.CurrentDungeon + (player.CurrentDungeon % 3);

                MonsterType insertType = (MonsterType)rand.Next((int)MonsterType.Minion, (int)MonsterType.MonsterTypeEnd);

                switch (insertType)
                {
                    case MonsterType.Minion:
                        monsters.Add(new Monster(
                            monsterLevel,
                            MonsterType.Minion,
                            monsterDict[MonsterType.Minion].Name,
                            ((monsterLevel - 1) * 3) + monsterDict[MonsterType.Minion].Attack,
                            ((monsterLevel - 1) * 5) + monsterDict[MonsterType.Minion].HP
                            ));
                        break;
                    case MonsterType.VoidInsect:
                        monsters.Add(new Monster(
                            monsterLevel,
                            MonsterType.VoidInsect,
                            monsterDict[MonsterType.VoidInsect].Name,
                            ((monsterLevel - 1) * 3) + monsterDict[MonsterType.VoidInsect].Attack,
                            ((monsterLevel - 1) * 5) + monsterDict[MonsterType.VoidInsect].HP
                            ));
                        break;
                    case MonsterType.SiegeMinion:
                        monsters.Add(new Monster(
                            monsterLevel,
                            MonsterType.SiegeMinion,
                            monsterDict[MonsterType.SiegeMinion].Name,
                            ((monsterLevel - 1) * 3) + monsterDict[MonsterType.SiegeMinion].Attack,
                            ((monsterLevel - 1) * 5) + monsterDict[MonsterType.SiegeMinion].HP
                            ));
                        break;
                }
            }

            prePlayerHP = player.HP;

            return true;
        }

        public override SceneType Update()
        {
            PrintDialogue();

            switch (MenuChoice("원하시는 행동을 입력해주세요.", 1, 2))
            {
                case 1:
                    if (NormalAttack())
                        return SceneType.Main;
                    break;
                case 2:
                    if (SkillAttack())
                        return SceneType.Main;
                    break;
            }

            return SceneType.NoChange;
        }

        bool NormalAttack()
        {
            while (true)
            {
                ChoiceMonster();

                if (IsPlayerWin())
                {
                    PrintPlayerVictory();
                    return true;
                }

                if (EnemyPhase())
                {
                    PrintPlayerLose();
                    return true;
                }
            }

            return false;
        }

        bool SkillAttack()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Battle!");
                Console.WriteLine("");

                for (int i = 0; i < monsters.Count; ++i)
                {
                    Console.Write($"[{i + 1}] ");
                    monsters[i].PrintStatus();
                }

                Console.WriteLine();
                Console.WriteLine("[내정보]\n");

                player.PrintDungeonStatus();

                Console.WriteLine("");
                Console.WriteLine("0. 취소");
                Console.WriteLine("");
            }
        }

        private void ChoiceMonster()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Battle!");
                Console.WriteLine("");

                for (int i = 0; i < monsters.Count; ++i)
                {
                    Console.Write($"[{i + 1}] ");
                    monsters[i].PrintStatus();
                }

                Console.WriteLine();
                Console.WriteLine("[내정보]\n");

                player.PrintDungeonStatus();

                Console.WriteLine("");
                Console.WriteLine("0. 턴 넘기기");
                Console.WriteLine("");

                int playerChoice = MenuChoice("대상을 선택해주세요.", 0, monsters.Count);

                if ((1 <= playerChoice) && (monsters.Count >= playerChoice))
                {
                    if (CharacterState.Dead == monsters[playerChoice - 1].CurrentState)
                    {
                        Console.WriteLine("\n해당 몬스터는 이미 죽었습니다..!");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        if (monsters[playerChoice - 1].IsDodge())
                        {
                            PrintMonsterDodge(monsters[playerChoice - 1]);
                            return;
                        }
                        else
                        {
                            PlayerAttack(playerChoice - 1);
                            return;
                        }
                    }
                }
                else if (0 == playerChoice)
                    return;
            }
        }

        void PlayerAttack(int playerChoice)
        {
            int monsterHP = monsters[playerChoice].HP;

            player.AttackTarget(monsters[playerChoice]);

            while (true)
            {
                PrintPlayerAttack(monsters[playerChoice], monsterHP);

                if (0 == MenuChoice("", 0, 0))
                    return;
            }
        }

        bool EnemyPhase()
        {
            int playerHP = 0;

            for (int i = 0; i < monsters.Count;)
            {
                if (CharacterState.Alive == monsters[i].CurrentState)
                {
                    if (player.IsDodge())
                    {
                        PrintPlayerDodge(monsters[i]);
                        ++i;
                        continue;
                    }

                    playerHP = player.HP;

                    monsters[i].AttackTarget(player);

                    while (true)
                    {
                        PrintMonsterAttack(monsters[i], playerHP);

                        if (0 == MenuChoice("", 0, 0))
                        {
                            ++i;
                            break;
                        }
                    }

                    if (CharacterState.Dead == player.CurrentState)
                        return true;
                }
                else
                    ++i;
            }

            return false;
        }

        bool IsPlayerWin()
        {
            foreach (Monster monster in monsters)
            {
                if (CharacterState.Alive == monster.CurrentState)
                    return false;
            }

            return true;
        }

        protected override void PrintDialogue()
        {
            Console.Clear();

            Console.WriteLine("Battle!!");
            Console.WriteLine("");

            for (int i = 0; i < monsters.Count; ++i)
                monsters[i].PrintStatus();

            Console.WriteLine();
            Console.WriteLine("[내정보]\n");

            player.PrintDungeonStatus();

            Console.WriteLine("");
            Console.WriteLine("1. 공격");
            Console.WriteLine("2. 스킬");
            Console.WriteLine("");
        }

        void PrintPlayerAttack(Monster monster, int preHP)
        {
            Console.Clear();

            Console.WriteLine("Battle!!\n");

            Console.WriteLine($"{player.Name} 의 공격!");
            Console.Write($"Lv.{monster.Level} {monster.Name} 을(를) 맞췄습니다!");
            Console.Write($"[데미지 : {player.CurrentDamage}]");

            if (player.IsCritical)
                Console.WriteLine(" - 치명타 공격!!\n");
            else
                Console.WriteLine("\n");

            Console.WriteLine($"Lv.{monster.Level} {monster.Name}");
            Console.Write($"HP {preHP} -> ");

            if (CharacterState.Alive == monster.CurrentState)
                Console.WriteLine($"{monster.HP}\n");
            else if (CharacterState.Dead == monster.CurrentState)
                Console.WriteLine("Dead\n");

            Console.WriteLine("0. 다음");
        }

        void PrintMonsterAttack(Monster monster, int preHP)
        {
            Console.Clear();

            Console.WriteLine("Battle!!\n");

            Console.WriteLine($"Lv.{monster.Level} {monster.Name} 의 공격!");
            Console.Write($"{player.Name} 을(를) 맞췄습니다. [데미지 : {monster.CurrentDamage}]");

            if (monster.IsCritical)
                Console.WriteLine(" - 치명타 공격!!\n");
            else
                Console.WriteLine("\n");

            Console.WriteLine($"Lv.{player.Level} {player.Name}");
            Console.WriteLine($"HP {preHP} -> {player.HP}\n");

            Console.WriteLine("0. 다음");
        }

        void PrintPlayerVictory()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Battle!! - Result\n");

                Console.WriteLine("Victory\n");
                Console.WriteLine($"던전에서 몬스터 {monsters.Count}마리를 잡았습니다.");

                Console.WriteLine($"Lv.{player.Level} {player.Name}");
                Console.WriteLine($"HP {prePlayerHP} -> {player.HP}\n");

                Console.WriteLine("0. 다음");

                if (0 == MenuChoice("", 0, 0))
                    return;
            }
        }

        void PrintPlayerLose()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Battle!! - Result\n");

                Console.WriteLine("You Lose\n");

                Console.WriteLine($"Lv.{player.Level} {player.Name}");
                Console.WriteLine($"HP {prePlayerHP} -> {player.HP}\n");

                Console.WriteLine("0. 다음");

                if (0 == MenuChoice("", 0, 0))
                    return;
            }
        }

        void PrintMonsterDodge(Monster monster)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Battle!!\n");

                Console.WriteLine($"{player.Name} 의 공격!");
                Console.WriteLine($"Lv.{monster.Level} {monster.Name} 을(를) 공격했지만 아무일도 일어나지 않았습니다.\n");

                Console.WriteLine("0. 다음");

                if (0 == MenuChoice("", 0, 0))
                    return;
            }
        }

        void PrintPlayerDodge(Monster monster)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Battle!!\n");

                Console.WriteLine($"Lv.{monster.Level} {monster.Name} 의 공격!");
                Console.WriteLine($"{player.Name} 을(를) 공격했지만 아무일도 일어나지 않았습니다.\n");

                Console.WriteLine("0. 다음");

                if (0 == MenuChoice("", 0, 0))
                    return;
            }
        }
    }
}
