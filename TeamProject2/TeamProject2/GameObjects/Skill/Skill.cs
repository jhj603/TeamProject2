using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    enum SkillType
    {
        AlphaStrike,
        DoubleStrike,
        Hassoutobi,
        FireBall,
        ColdBeam,
        Meteor,
        DoubleShot,
        ArrowBomb,
        RapidShot
    }

    internal class Skill
    {
        public string Name { get; private set; }
        public int Cost { get; private set; }
        public string Desc { get; private set; }
        public int Level { get; private set; }
        public SkillType Type { get; protected set; }

        protected List<int> skillDamages = null;

        protected Random rand = null;

        public Skill(string name, int cost, string desc, int level)
        {
            Name = name;
            Cost = cost;
            Desc = desc;
            Level = level;

            skillDamages = new List<int>();

            rand = new Random();
        }

        public virtual List<int> GetSkillDamages(int attack)
        {
            return skillDamages;
        }

        public void PrintSkill()
        {
            Console.WriteLine($"{Name} - MP {Cost}");
            Console.WriteLine($"{Desc}");
        }
    }
}
