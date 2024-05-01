using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{
    internal class Monster
    {
        public void ShowMosterStatus()
        {
            string minion = "미니언";
            string gongbug = "공허충";
            string superminion = "대포미니언";

            Console.WriteLine($"Lv.2 {minion} HP 15");
            Console.WriteLine($"Lv.3 {gongbug} HP 10");
            Console.WriteLine($"Lv.5 {superminion} HP 25");

            Random random = new Random();
        }
    }
}
