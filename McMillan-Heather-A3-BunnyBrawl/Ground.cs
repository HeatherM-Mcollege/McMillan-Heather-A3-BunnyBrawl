using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McMillan_Heather_A3_BunnyBrawl
{
    public class Ground
    {
        // grass block variables
        public Color grass;
        public Color soil;
        public Color texture;
        public float x;
        public float y;
        public float size;

        public void Render()
        {

            for (int i = 0; i < 8; i++)
            {
                //start at bottom x = 0, and y = 500 and size = 100
                Draw.LineSize = 0;
                Draw.FillColor = soil;
                Draw.Square(i * 100, y, size);

                //draw texture in block
                Draw.LineSize = 3;
                Draw.LineColor = texture;
                Draw.Line(i * 100 + 10, y + 30, i * 100 + 10, y + 40);
                Draw.Line(i * 100 + 20, y + 60, i * 100 + 20, y + 70);
                Draw.Line(i * 100 + 50, y + 80, i * 100 + 50, y + 90);
                Draw.Line(i * 100 + 60, y + 50, i * 100 + 60, y + 60);
                Draw.Line(i * 100 + 80, y + 70, i * 100 + 80, y + 80);
                Draw.Line(i * 100 + 90, y + 20, i * 100 + 90, y + 30);


                //add to x and y to create triangles in unison
                Draw.LineSize = 0;
                Draw.FillColor = grass;
                Draw.Triangle(i * 100, y, i * 100 + 50, y + 50, i * 100 + 100, y);
            }
        }
    }
}


