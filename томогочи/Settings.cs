using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace томогочи
{
    class Settings
    {
        public static Scale eat;
        public static Scale sleep;
        public static Scale happy;
        public static Scale clear;
        public static Scale hp;
        public static int sub;
        public static int add;

        public Settings()
        {
            eat = new Scale(100, 100);
            sleep = new Scale(100, 100);
            happy = new Scale(100, 100);
            clear = new Scale(100, 100);
            hp = new Scale(100, 100);
            sub = 8;
            add = 15;
        }

    }
}
