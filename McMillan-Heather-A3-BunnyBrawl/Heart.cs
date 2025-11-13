using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McMillan_Heather_A3_BunnyBrawl
{
    public class Heart
    {
        public float x;
        public float y;
        public float w;
        public float h;

        public Heart(float x, float y, float w, float h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }

        public void Render()
        {
            Draw.LineSize = 0;
            Draw.FillColor = Color.Red;
            Draw.Rectangle(x, y, w, h);
            Draw.Triangle(x, y, x + 10, y - 10, x + 25, y);
            Draw.Triangle(x + 25, y, x + 40, y - 10, x + 50, y);
            Draw.Triangle(x, y + 10, x + 25, y + 30, x + 50, y + 10);

        }


    }
}

