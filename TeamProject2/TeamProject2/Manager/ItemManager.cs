using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject2
{ 
    internal class ItemManager
    {
        private static ItemManager Instance = null;

        private ItemManager()
        {

        }

        public static ItemManager GetInstance()
        {
            if (null == Instance)
                Instance = new ItemManager();

            return Instance;
        }
    }
}
