using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class Monster
    {
        // private으로 접근 제한해놨으므로
        // Monster 클래스 외부에서 사용하려면 프로퍼티를 적용해야 함

        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }

        private int attack = 0;

        private int hp = 0;

        private int level = 0;

        private string name = null;

        public Monster(int level, string name, int hp, int attack)
        {
            this.attack = attack;
            this.hp = hp;
            this.level = level;
            this.name = name;
        }

        void MonsterAttack(Player player)
        {
            // player hp에서 monster의 attack을 뺌

            // player의 hp가 0 이하라면
                // player의 hp = 0      
        }

        void ShowMonsterStatus()
        {
            // 레벨, 이름, hp로 문자열 출력
        }
    }
}
