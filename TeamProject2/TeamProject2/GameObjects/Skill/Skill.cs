using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    enum SkillType
    {
        Single,
        Multi,
        Random,
        All
    }

    internal class Skill
    {
        public string Name { get; private set; }
        public int Cost { get; private set; }
        public string Desc { get; private set; }
        public int Level { get; private set; }
        public SkillType Type { get; private set; }
        public float MinScale { get; private set; }
        public float MaxScale { get; private set; }

        public int TargetCount { get; set; }
        public int AttackCount { get; private set; }

        List<int> skillDamages = null;

        Random rand = null;

        public Skill(string name, int cost, string desc, int level, SkillType type, float minScale, float maxScale, int targetCount, int attackCount)
        {
            Name = name;
            Cost = cost;
            Desc = desc;
            Level = level;
            Type = type;
            MinScale = minScale;
            MaxScale = maxScale;
            TargetCount = targetCount;
            AttackCount = attackCount;

            skillDamages = new List<int>();

            rand = new Random();
        }

        public Skill(Skill skill)
        {
            Name = skill.Name;
            Cost = skill.Cost;    
            Desc = skill.Desc;
            Level = skill.Level;
            Type = skill.Type;
            MinScale = skill.MinScale;
            MaxScale = skill.MaxScale;
            TargetCount = skill.TargetCount;
            AttackCount = skill.AttackCount;

            skillDamages = new List<int>();

            rand = new Random();
        }

        public List<int> GetSkillDamages(float attack)
        {
            skillDamages.Clear();

            int skillDamage = 0;

            for (int i = 0; i < AttackCount; ++i)
            {
                if (MinScale == MaxScale)
                    skillDamage = (int)(attack * MinScale);
                else
                    skillDamage = rand.Next((int)Math.Ceiling(attack * MinScale), (int)Math.Ceiling(attack * MaxScale) + 1);

                skillDamages.Add(skillDamage);
            }

            return skillDamages;
        }

        public void PrintSkill()
        {
            Console.WriteLine($"{Name} - MP {Cost}");
            Console.WriteLine($"   설명 : {Desc}");
            Console.Write($"   효과 : 공격력 * ");

            if (MaxScale == MinScale)
                Console.Write($"{MinScale} 로 ");
            else
                Console.Write($"{MinScale} ~ {MaxScale} 로 ");

            if (1 < TargetCount)
                Console.Write($"{TargetCount}명의 적을 ");
            else
                Console.Write("하나의 적을 ");

            switch (Type)
            {
                case SkillType.Single:
                    Console.WriteLine("공격합니다.");
                    break;
                case SkillType.Multi:
                    Console.WriteLine($"{AttackCount} 회 공격합니다.");
                    break;
                case SkillType.Random:
                    Console.WriteLine("랜덤으로 공격합니다.");
                    break;
            }
        }
    }
}
