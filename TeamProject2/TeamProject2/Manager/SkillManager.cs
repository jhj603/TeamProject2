using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

            skillDict.Add(PlayerJob.Warrior, new List<Skill>());
            skillDict.Add(PlayerJob.Magician, new List<Skill>());
            skillDict.Add(PlayerJob.Archer, new List<Skill>());

            skillDict[PlayerJob.Warrior].Add(new AlphaStrike("알파 스트라이크", 10, "공격력 * 2 로 하나의 적을 공격합니다.", 1));
            skillDict[PlayerJob.Warrior].Add(new DoubleStrike("더블 스트라이크", 15, "공격력 * (1.3 ~ 1.5) 로 2 명의 적을 랜덤으로 공격합니다.", 2));
            skillDict[PlayerJob.Warrior].Add(new Hassoutobi("팔척뛰기", 40, "공격력 * (1.0 ~ 1.2) 로 하나의 적을 8 번 공격합니다.", 5));

            //skillDict[PlayerJob.Magician].Add(new FireBall("파이어 볼", 10, "공격력 * 3 로 하나의 적을 공격합니다.", 1));
            //skillDict[PlayerJob.Magician].Add(new ThunderBolt("썬더 볼트", 20, "공격력 * () 로 3 명의 적을 공격합니다.", 3));
            //skillDict[PlayerJob.Magician].Add(new Meteor("메테오", 50, "공격력 * 5 로 모든 적을 공격합니다.", 5));

            //skillDict[PlayerJob.Archer].Add(new DoubleShot("더블 샷", 10, "공격력 * 1 로 하나의 적을 2 번 공격합니다.", 1));
            //skillDict[PlayerJob.Archer].Add(new ArrowBomb("애로우 봄", 15, "공격력 * 2.5 로 하나의 적을 공격합니다.", 2));
            //skillDict[PlayerJob.Archer].Add(new RapidShot("래피드 샷", 30, "공격력 * (1.1 ~ 1.3) 로 하나의 적을 3 번 공격합니다.", 3));
        }

        public static SkillManager GetInstance()
        {
            if (null == Instance)
                Instance = new SkillManager();

            return Instance;
        }
    }
}
