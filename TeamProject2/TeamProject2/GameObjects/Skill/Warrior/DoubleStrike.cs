using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class DoubleStrike : Skill
    {
        public DoubleStrike(string name, int cost, string desc, int level)
            : base(name, cost, desc, level)
        {

        }

        public override List<int> GetSkillDamages(int attack)
        {
            skillDamages.Clear();

            for (int i = 0; i < 2; ++i)
                skillDamages.Add((int)(attack * (rand.Next(13, 16) / 100f)));

            return skillDamages;
        }
    }
}
