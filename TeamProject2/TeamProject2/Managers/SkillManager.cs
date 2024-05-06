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

        Dictionary<string, List<Skill>> skillDict = null;

        private SkillManager()
        {
            skillDict = new Dictionary<string, List<Skill>>();

            skillDict.Add("전사", new List<Skill>());
            skillDict.Add("마법사", new List<Skill>());
            skillDict.Add("궁수", new List<Skill>());
            skillDict.Add("도적", new List<Skill>());
            skillDict.Add("?????", new List<Skill>());
            
            skillDict["전사"].Add(new Skill("알파 스트라이크", 10, "강력한 일격입니다.", 1, SkillType.Single, 2f, 2f, 1, 1));
            skillDict["전사"].Add(new Skill("더블 스트라이크", 15, "빠르게 두 명의 적을 공격합니다.", 2, SkillType.Random, 1.3f, 1.5f, 2, 1));
            skillDict["전사"].Add(new Skill("팔척뛰기", 40, "눈에 보이지 않는 속도로 8번 공격합니다.", 5, SkillType.Multi, 1f, 1.3f, 1, 8));

            skillDict["마법사"].Add(new Skill("파이어 볼", 10, "기본적인 화염구입니다.", 1, SkillType.Single, 3f, 3f, 1, 1));
            skillDict["마법사"].Add(new Skill("썬더 볼트", 20, "하늘에서 번개를 내려쳐 적을 공격합니다.", 3, SkillType.Random, 1f, 2f, 3, 1));
            skillDict["마법사"].Add(new Skill("메테오", 50, "운석을 떨어뜨리는 최상급 화염 마법입니다.", 5, SkillType.All, 5f, 5f, 0, 1));

            skillDict["궁수"].Add(new Skill("더블 샷", 10, "빠르게 두 발의 화살을 발사합니다.", 1, SkillType.Random, 1f, 1f, 1, 1));
            skillDict["궁수"].Add(new Skill("애로우 봄", 15, "폭탄이 달린 화살을 발사합니다.", 2, SkillType.Single, 2.5f, 2.5f, 1, 1));
            skillDict["궁수"].Add(new Skill("래피드 샷", 20, "한 번에 세 발의 화살을 발사합니다.", 3, SkillType.Multi, 1.1f, 1.3f, 1, 3));

            //skillDict["도적"].Add(new Skill("더블 샷", 10, "빠르게 두 발의 화살을 발사합니다.", 1, SkillType.Random, 1f, 1f, 1, 1));
            //skillDict["도적"].Add(new Skill("애로우 봄", 15, "폭탄이 달린 화살을 발사합니다.", 2, SkillType.Single, 2.5f, 2.5f, 1, 1));
            //skillDict["도적"].Add(new Skill("래피드 샷", 20, "한 번에 세 발의 화살을 발사합니다.", 3, SkillType.Multi, 1.1f, 1.3f, 1, 3));

            //skillDict["?????"].Add(new Skill("알파 스트라이크", 10, "강력한 일격입니다.", 1, SkillType.Single, 2f, 2f, 1, 1));
            //skillDict["?????"].Add(new Skill("더블 스트라이크", 15, "빠르게 두 명의 적을 공격합니다.", 2, SkillType.Random, 1.3f, 1.5f, 2, 1));
            //skillDict["?????"].Add(new Skill("팔척뛰기", 40, "눈에 보이지 않는 속도로 8번 공격합니다.", 5, SkillType.Multi, 1f, 1.3f, 1, 8));

            //skillDict["?????"].Add(new Skill("썬더 볼트", 20, "하늘에서 번개를 내려쳐 적을 공격합니다.", 3, SkillType.Random, 1f, 2f, 3, 1));
            //skillDict["?????"].Add(new Skill("메테오", 50, "운석을 떨어뜨리는 최상급 화염 마법입니다.", 5, SkillType.All, 5f, 5f, 1, 1));
            //skillDict["?????"].Add(new Skill("파이어 볼", 10, "기본적인 화염구입니다.", 1, SkillType.Single, 3f, 3f, 1, 1));

            //skillDict["?????"].Add(new Skill("더블 샷", 10, "빠르게 두 발의 화살을 발사합니다.", 1, SkillType.Random, 1f, 1f, 1, 1));
            //skillDict["?????"].Add(new Skill("애로우 봄", 15, "폭탄이 달린 화살을 발사합니다.", 2, SkillType.Single, 2.5f, 2.5f, 1, 1));
            //skillDict["?????"].Add(new Skill("래피드 샷", 20, "한 번에 세 발의 화살을 발사합니다.", 3, SkillType.Multi, 1.1f, 1.3f, 1, 3));
        }

        public static SkillManager GetInstance()
        {
            if (null == Instance)
                Instance = new SkillManager();

            return Instance;
        }

        public void GetSkills(string job, List<Skill> skills)
        {
            foreach (Skill skill in skillDict[job])
            {
                Skill addSkill = new Skill(skill);

                skills.Add(addSkill);
            }
        }
    }
}
