using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamProject2;

namespace TeamProject2
{
    enum PlayerJob          // 플레이어 직업 종류
    {
        Warrior = 1,
        Magician,
        Archer
    }

    internal class Player : BaseCharacter
    {
        public PlayerJob Job { get; private set; }
        public int Defense { get; private set; }
        public int MaxHP { get; private set; }
        public int MaxMP { get; private set; }
        public int CurrentDungeon { get; private set; } = 1;
        public int CurrentSkillCount { get; private set; } = 0;
        public int MaxExp { get; private set; }
        public int IncreaseExp { get; private set; }

        Inventory inventory = null;

        // Player 필드 초기화 함수
        public bool Initialize(int level, string name, PlayerJob job, int attack, int defense, int hp, int gold, int mp, int exp = 0)        // 레벨, 이름, 직업, 공격력, 방어력, hp, 소지금을 차례로 받아 초기화에 사용
        {
            base.Initialize(level, name, attack, hp, gold, mp, exp);

            Job = job;                                              // 자식 클래스(Player)만 갖고 있는 필드 초기화
            Defense = defense;                                      // 자식 클래스(Player)만 갖고 있는 필드 초기화
            MaxHP = hp;
            MaxMP = mp;
            MaxExp = 10;
            IncreaseExp = 25;

            Skills = new List<Skill>();

            SkillManager skillManager = SkillManager.GetInstance();

            if (null == skillManager)
                return false;

            skillManager.GetSkills(Job, Skills);

            foreach (Skill skill in Skills)
            {
                if (skill.Level <= level)
                    ++CurrentSkillCount;
            }

            inventory = new Inventory();

            return true;
        }

        public void IncreaseDungeon()
        {
            ++CurrentDungeon;
        }

        public bool CanUseSkill(int skillIndex)
        {
            return MP > Skills[skillIndex].Cost;
        }

        public void BuyItem(BaseItem item)
        {
            inventory.AddItem(item);
            Gold -= item.Gold;
        }

        public BaseItem SellItem(int index)
        {
            int cost = 0;

            BaseItem item = inventory.SellItem(index, out cost);

            Gold += cost;

            return item;
        }

        public int GetEquipSize()
        {
            return inventory.EquipableItems.Count;
        }

        public void Equip(int index)
        {
            inventory.Equip(index);
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
                    HP += usePotion.Increase;

                    if (MaxHP < HP)
                        HP = MaxHP;

                    if (CharacterState.Dead == CurrentState)
                        CurrentState = CharacterState.Alive;
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
                    Defense += usePotion.Increase;
                    break;
                case ItemType.Potion_Exp:
                    LevelUp(usePotion.Increase);
                    break;
            }
        }

        public void LevelUp(int exp)
        {
            Exp += exp;

            if (MaxExp <= Exp)
            {
                ++Level;
                Exp = 0;
                MaxExp += IncreaseExp;
                IncreaseExp += 5;
                Attack += 0.5f;
                Defense += 1;
            }
        }

        public override void PrintStatus()
        {
            Console.WriteLine($"Lv. {Level}");
            Console.Write($"{Name} ( ");

            switch (Job)
            {
                case PlayerJob.Warrior:
                    Console.WriteLine("전사 )");
                    break;
                case PlayerJob.Magician:
                    Console.WriteLine("마법사 )");
                    break;
                case PlayerJob.Archer:
                    Console.WriteLine("궁수 )");
                    break;
            }

            Console.WriteLine($"공격력 : {Attack}");
            Console.WriteLine($"방어력 : {Defense}");
            Console.WriteLine($"H   P  : {HP}");
            Console.WriteLine($"M   P  : {MP}");
            Console.WriteLine($"Gold   : {Gold}\n");

            Console.WriteLine("[스킬]");

            PrintSkills();
        }

        public void PrintDungeonStatus()
        {
            Console.Write($"Lv.{Level} {Name} ( ");

            switch (Job)
            {
                case PlayerJob.Warrior:
                    Console.WriteLine("전사 )");
                    break;
                case PlayerJob.Magician:
                    Console.WriteLine("마법사 )");
                    break;
                case PlayerJob.Archer:
                    Console.WriteLine("궁수 )");
                    break;
            }

            Console.WriteLine($"HP {HP} / {MaxHP}");
            Console.WriteLine($"MP {MP} / {MaxMP}");
        }

        public void PrintSkills()
        {
            for (int i = 0; i < CurrentSkillCount; ++i)
            {
                Console.Write($"{i + 1}. ");
                Skills[i].PrintSkill();
            }
        }

        public int PrintInventory(bool isIndex = false)
        {
            return inventory.PrintInven(isIndex);
        }

        public void PrintEquipable()
        {
            inventory.PrintEquip();
        }

        public void PrintPotions()
        {
            inventory.PrintPotions();
        }
    }
}
