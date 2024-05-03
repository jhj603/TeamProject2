using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{ 
    internal class SkillManager
    {
        private static SkillManager Instance = null;

        Dictionary<PlayerJob, List<Skill>> skillDict = null;

        private SkillManager()
        {
            skillDict = new Dictionary<PlayerJob, List<Skill>>();


        }

        public static SkillManager GetInstance()
        {
            if (null == Instance)
                Instance = new SkillManager();

            return Instance;
        }
    }
}
