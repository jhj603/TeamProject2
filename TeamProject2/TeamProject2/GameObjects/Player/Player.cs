using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class Player
    {
        // private으로 접근 제한해놨으므로
        // Player 클래스 외부에서 사용하려면 프로퍼티를 적용해야 함
        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public int Hp
        {
            get { return hp; }
            set { hp = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Random_attackErrorrange
        {
            get { return random_attackErrorrange; }
        }

        private int attack = 0;            // 공격력

        private int hp = 0;                // HP

        private int defense = 0;           // 방어력

        private int level = 0;             // 레벨

        private string name = null;        // 이름

        private string job = null;         // 직업

        private int gold = 0;              // 소지금

        private int maxhp = 0;             // 최대 HP

        private int random_attackErrorrange = 0;

        public Player(int attack, int hp, int defense, int level, string name, string job, int gold)
        {
            this.attack = attack;
            this.hp = hp;
            this.defense = defense;
            this.level = level;
            this.name = name;
            this.job = job;
            this.gold = gold;
            this.maxhp = hp;
        }

        public void ShowStatus()
        {
            // 플레이어 필드를 사용해 문자열 생성 후 출력
            Console.WriteLine($"Lv. {0:D1}{level}");

            Console.Write($"{"닉네임",-3} : ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{name}");
            Console.ResetColor();
            Console.WriteLine($" ( {job} )\n");

            Console.WriteLine($"{"공격력", -3} : {attack}");
            Console.WriteLine($"{"방어력", -3} : {defense}");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{"체  력", -3}");
            Console.ResetColor();
            Console.Write(" : ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{hp}");
            Console.ResetColor();

            Console.ForegroundColor= ConsoleColor.DarkYellow;
            Console.Write($"{"소지금", -3}");
            Console.ResetColor();
            Console.Write(" : ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{gold} G");
            Console.ResetColor();
        }

        public void PlayerAttack(Monster monster)
        {
            Random rand = new Random();  // 랜덤객채를 생성
            int error = (int)Math.Ceiling(0.1f * Attack);
            random_attackErrorrange = rand.Next((Attack - error), (Attack + error + 1));         // 공격력 오차범위 생성

            // monster의 hp에서 player의 attack을 뺌
            monster.Hp -= random_attackErrorrange;
            // monster의 hp가 0 이하라면
            if (monster.Hp <= 0)
            {
                // monster의 hp = 0
                monster.Hp = 0;
            }
        }

        public void ShowDungeonStatus()
        {
            Console.WriteLine($"Lv. {level} {name} ({job})");            // 레벨, 이름, 직업으로 문자열 생성 후 출력
            Console.WriteLine($"HP {hp}/{maxhp}");                       // HP로 문자열 생성 후 출력
        }
    }
}
