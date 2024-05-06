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
        private int attack = 0;

        private int hp = 0;

        private int level = 0;

        private int maxhp = 0;

        private string name = null;

        public Monster(int level, string name, int hp, int attack)
        {
            this.attack = attack;
            this.hp = hp;
            this.level = level;
            this.name = name;
        }
        // Monster 클래스 외부에서 사용하려면 프로퍼티를 적용해야 함
        public int Attack
        {
            get { return attack; }
            set {  attack = value; }
        }
        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public void MonsterAttack(Player player)
        {
            player.Hp -= attack;    // player hp에서 monster의 attack을 뺌

            if(player.Hp <= 0)    // player의 hp가 0 이하라면
            {
                player.Hp = 0;    // player의 hp = 0     
            }

        }

        public void ShowMonsterStatus()     
        {
            Console.Write($"Lv.{Level}    ");
            Console.Write(ConsoleUtility.PadRightForMixedText(Name, 14));

            // HP 0 이면 Dead 나옴
            if (0 == Hp)
            {
                Console.WriteLine("Dead");
            }
            else
            {
                // 레벨, 이름, hp로 문자열 출력
                Console.WriteLine($"HP {Hp}");
            }
        }
    }
}
