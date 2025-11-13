using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace McMillan_Heather_A3_BunnyBrawl
{
    public class TextWinner
    {
        public Vector2 tPosition;
        public Vector2 tSize;
        public Color color;

        public TextWinner(Vector2 tPosition, Vector2 tSize)
        {
            this.tPosition = tPosition;
            this.tSize = tSize;
            this.color = Color.White;
        }

        public void Update()
        {

            //bird placeholder
            Draw.LineSize = 1;
            Draw.LineColor = Color.White;
            Draw.FillColor = color;
            Draw.Rectangle(tPosition, tSize);

        }


    }
}
