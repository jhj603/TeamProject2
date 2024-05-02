using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class AlphaStrike : Skill
    {
        public AlphaStrike(string name, int cost, string desc, int level)
            : base(name, cost, desc, level)
        {

        }

        public override List<int> GetSkillDamages(int attack)
        {
            skillDamages.Clear();

            skillDamages.Add(attack * 2);

            return skillDamages;
        }
    }
}
