using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace томогочи
{
    class Scale
    {
        public int max_value;
        public int currect_value;

        public Scale()
        {
            currect_value = 100;
            max_value = 100;
        } 
        public Scale(int current_value)
        {
            this.currect_value = currect_value;
            max_value = 100;
        }
        public Scale(int currect_value, int max_value)
        {
            this.currect_value = currect_value;
            this.max_value = max_value;
        }
        public Scale add_value(int add_value)
        {
            currect_value += add_value;
            if (currect_value > max_value)
            {
                currect_value = max_value;
            }
            return this;
        }
        public Scale sub_value(int sub_value)
        {
            currect_value -= sub_value;
            if (currect_value < 0)
            {
                currect_value = 0;
            }
            return this;
        }
    }
}
