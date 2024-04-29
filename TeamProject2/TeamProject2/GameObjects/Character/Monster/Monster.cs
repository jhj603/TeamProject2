using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class Monster : BaseCharacter
    {
        // 요구조건을 보고 필요하다고 느끼는 필드를 추가해주세요.

        // Initialize() 함수를 만들어서 내부에서 필드 값 초기화를 할 수 있게 구현해주세요.

        public int Lv { get; }
        public string Name { get; }
        public int Hp { get; set; }


        public Monster(int lv, string name, int hp)
        {
            Lv = lv;
            Name = name;
            Hp = hp;
        }
    }
}
