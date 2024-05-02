using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class Hassoutobi : Skill
    {
        public Hassoutobi(string name, int cost, string desc, int level)
            : base(name, cost, desc, level)
        {

        }

        public override List<int> GetSkillDamages(int attack)
        {
            skillDamages.Clear();

            for (int i = 0; i < 8; ++i)
                skillDamages.Add((int)(attack * (rand.Next(10, 13) / 100f)));

            return skillDamages;
        }
    }
}
