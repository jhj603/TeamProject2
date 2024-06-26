﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class Player
    {
        // private으로 접근 제한해놨으므로
        // Player 클래스 외부에서 사용하려면 프로퍼티를 적용해야 함
        public float Attack
        {
            get { return attack; }
            set { attack = value; }
        }
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int CurrentDamage
        {
            get { return currentDamage; }
        }
        public int Gold
        {
            get { return gold; }
            set { gold = value; }
        }

        public int CurrentDungeon { get; private set; } = 1;
        public int CurrentSkillCount { get; private set; } = 0;
        public int Exp { get; private set; } = 0;
        public int MaxExp { get; private set; } = 10;
        public int IncreaseExp { get; private set; } = 25;
        public List<Skill> Skills { get; private set; } = null;
        public bool IsCritical { get; private set; } = false;
        public int MP { get; private set; }
        public int MaxMP { get; private set; }
        public float IncreaseAtk { get; set; } = 0f;
        public int IncreaseDfs { get; set; } = 0;

        int percent = 0;
        int error = 0;
        Random rand = null;

        Inventory inventory = null;

        private float attack = 0;            // 공격력

        private int hp = 0;                // HP

        private int defense = 0;           // 방어력

        private int level = 0;             // 레벨

        private string name = null;        // 이름

        private string job = null;         // 직업

        private int gold = 0;              // 소지금

        private int maxhp = 0;             // 최대 HP

        private int currentDamage = 0;

        public Player (int attack, int hp, int defense, int level, string name, string job, int gold, int mp)
        {
            this.attack = attack;
            this.hp = hp;
            this.defense = defense;
            this.level = level;
            this.name = name;
            this.job = job;
            this.gold = gold;
            this.maxhp = hp;
            this.MP = mp;
            this.MaxMP = mp;

            rand = new Random();  // 랜덤객채를 생성

            Skills = new List<Skill>();

            SkillManager skillManager = SkillManager.GetInstance();

            skillManager.GetSkills(this.job, Skills);

            foreach (Skill skill in Skills)
            {
                if (skill.Level <= level)
                    ++CurrentSkillCount;
            }

            inventory = new Inventory(this);
        }

        public void ShowStatus()
        {
            // 플레이어 필드를 사용해 문자열 생성 후 출력
            if (10 > level)
                Console.WriteLine($"Lv. {0:D1}{level}");
            else
                Console.WriteLine($"Lv. {level}");

            Console.Write($"{"닉네임",-3} : ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{name}");
            Console.ResetColor();
            Console.WriteLine($" ( {job} )\n");

            Console.Write($"{"공격력", -3} : {Attack + IncreaseAtk} ");

            if (0f < IncreaseAtk)
                Console.WriteLine($"(+ {IncreaseAtk})");
            else
                Console.WriteLine();

            Console.Write($"{"방어력", -3} : {defense + IncreaseDfs} ");

            if (0 < IncreaseDfs)
                Console.WriteLine($"(+ {IncreaseDfs})");
            else
                Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("체  력");
            Console.ResetColor();
            Console.Write(" : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{hp}");
            Console.ResetColor();

            Console.ForegroundColor= ConsoleColor.DarkYellow;
            Console.Write("소지금");
            Console.ResetColor();
            Console.Write(" : ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{gold} G");
            Console.ResetColor();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("마  나");
            Console.ResetColor();
            Console.Write(" : ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{MP}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("경험치");
            Console.ResetColor();
            Console.Write(" : ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{Exp}");
            Console.ResetColor();
            
            Console.WriteLine();
            Console.WriteLine("[스킬]");

            PrintSkills();
        }

        public void PlayerAttack(Monster monster)
        {
            IsCritical = false;

            percent = rand.Next(0, 100);

            if (15 > percent)
            {
                IsCritical = true;

                currentDamage = (int)((Attack + IncreaseAtk) * 1.6f);
            }
            else
            {
                error = (int)Math.Ceiling((Attack + IncreaseAtk) * 0.1f);
                currentDamage = rand.Next((int)((Attack + IncreaseAtk) - error), (int)((Attack + IncreaseAtk) + error + 1));         // 공격력 오차범위 생성
            }

            // monster의 hp에서 player의 attack을 뺌
            monster.Hp -= currentDamage;
            // monster의 hp가 0 이하라면
            if (monster.Hp <= 0)
            {
                // monster의 hp = 0
                monster.Hp = 0;

                QuestManager questManager = QuestManager.GetInstance();

                if (null != questManager)
                {
                    HuntQuest huntQuest = null;

                    foreach (Quest quest in questManager.ProgressList)
                    {
                        huntQuest = (quest as HuntQuest);

                        if (null != huntQuest)
                            huntQuest.CheckFinish(monster);
                    }
                }
            }
        }

        public void ShowDungeonStatus()
        {
            // 레벨, 이름, 직업으로 문자열 생성 후 출력
            if (10 > level)
                Console.Write($"Lv. {0:D1}{level} ");
            else
                Console.Write($"Lv. {level} ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{name}");
            Console.ResetColor();
            Console.WriteLine($" ( {job} )");

            // HP로 문자열 생성 후 출력
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"HP  {hp}");
            Console.ResetColor();
            Console.Write(" / ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{maxhp}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"MP  {MP}");
            Console.ResetColor();
            Console.Write(" / ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{MaxMP}");
            Console.ResetColor();
        }

        public bool IsDodge()
        {
            percent = rand.Next(0, 100);

            if (10 > percent)
                return true;

            return false;
        }

        public List<int> SkillAttack(int skillChoice, Monster monster)
        {
            List<int> Damages = Skills[skillChoice].GetSkillDamages((Attack + IncreaseAtk));

            foreach (int damage in Damages)
            {
                monster.Hp -= damage;
                // monster의 hp가 0 이하라면
                if (monster.Hp <= 0)
                {
                    // monster의 hp = 0
                    monster.Hp = 0;

                    QuestManager questManager = QuestManager.GetInstance();

                    if (null != questManager)
                    {
                        HuntQuest huntQuest = null;

                        foreach (Quest quest in questManager.ProgressList)
                        {
                            huntQuest = (quest as HuntQuest);

                            if (null != huntQuest)
                                huntQuest.CheckFinish(monster);
                        }
                    }

                    break;
                }
            }

            return Damages;
        }

        public void IncreaseDungeon()
        {
            ++CurrentDungeon;
        }

        public bool CanUseSkill(int skillIndex)
        {
            return MP >= Skills[skillIndex].Cost;
        }

        public void PrintSkills()
        {
            for (int i = 0; i < CurrentSkillCount; ++i)
            {
                Console.Write($"{i + 1}. ");
                Skills[i].PrintSkill();
            }
        }

        public void UseMP(int cost)
        {
            MP -= cost;

            if (0 > MP)
                MP = 0;
        }

        public int ShowInventory(bool isIndex = false)
        {
            return inventory.PrintInven(isIndex);
        }

        public void BuyItem(BaseItem item)
        {
            inventory.AddItem(item);
            Gold -= item.Gold;
        }

        public void GetItem(BaseItem item)
        {
            inventory.AddItem(item);
        }

        public BaseItem SellItem(int index)
        {
            int cost = 0;

            BaseItem item = inventory.SellItem(index, out cost);

            Gold += cost;

            return item;
        }

        public void PrintEquipable()
        {
            inventory.PrintEquip();
        }

        public int GetEquipSize()
        {
            return inventory.EquipableItems.Count;
        }

        public void Equip(int index)
        {
            inventory.Equip(index);
        }

        public void PrintPotions()
        {
            inventory.PrintPotions();
        }

        public int GetPotionSize()
        {
            return inventory.Potions.Count;
        }

        public void UsePotion(int index)
        {
            BaseItem usePotion = inventory.UsePotion(index);

            switch (usePotion.Type)
            {
                case ItemType.Potion_HP:
                    Hp += usePotion.Increase;

                    if (maxhp < Hp)
                        Hp = maxhp;
                    break;
                case ItemType.Potion_MP:
                    MP += usePotion.Increase;

                    if (MaxMP < MP)
                        MP = MaxMP;
                    break;
                case ItemType.Potion_Atk:
                    Attack += usePotion.Increase;
                    break;
                case ItemType.Potion_Dfs:
                    defense += usePotion.Increase;
                    break;
                case ItemType.Potion_Exp:
                    if (LevelUp(usePotion.Increase, out int increaseLevel))
                    {
                        Console.WriteLine("\n레벨업 했습니다!");

                        Thread.Sleep(1000);
                    }
                    break;
            }
        }

        public bool LevelUp(int exp, out int increaseLevel)
        {
            bool isLevelUp = false;

            Exp += exp;

            increaseLevel = 0;

            while (MaxExp <= Exp)
            {
                isLevelUp = true;
                ++Level;
                Exp -= MaxExp;
                MaxExp += IncreaseExp;
                IncreaseExp += 5;
                Attack += 0.5f;
                defense += 1;
                ++increaseLevel;

                QuestManager questManager = QuestManager.GetInstance();

                if (null != questManager)
                {
                    LevelupQuest levelupQuest = null;

                    foreach (Quest quest in questManager.ProgressList)
                    {
                        levelupQuest = (quest as LevelupQuest);

                        if (null != levelupQuest)
                            levelupQuest.CheckFinish(Level);
                    }
                }
            }

            return isLevelUp;
        }
    }
}
