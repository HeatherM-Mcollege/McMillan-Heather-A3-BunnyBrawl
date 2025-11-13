using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace McMillan_Heather_A3_BunnyBrawl
{
    public class Character2
    {
        public Vector2 C2Pos;
        public Vector2 playerInput;
        public Vector2 delay = new Vector2(40, 25);
        public Vector2 size = new Vector2(100, 200);

        public float player1Health;


        //  Make Asset variables;

        public Texture2D TurtleStanding;
        public Texture2D TurtleRunning;
        public Texture2D TurtleJumping;
        public Texture2D TurtleGuarding;
        public Texture2D TurtleFighting;




        public Character2(Vector2 C2Pos)
        {
            this.C2Pos = C2Pos;
        }

        public void Setup()
        {
            //running out of this location
            //C:\Users\hmcmi\source\repos\Game prep\bin\Debug\net9.0
            //back by three?
            // set asset variables to call location
            TurtleStanding = Graphics.LoadTexture("../../../Assets/Graphics/TurtleStanding-2DAsset.png");
            TurtleRunning = Graphics.LoadTexture("../../../Assets/Graphics/TurtleRunning-2DAsset.png");
            TurtleJumping = Graphics.LoadTexture("../../../Assets/Graphics/TurtleJumping-2DAsset.png");
            TurtleGuarding = Graphics.LoadTexture("../../../Assets/Graphics/TurtleGuarding-2DAsset.png");
            TurtleFighting = Graphics.LoadTexture("../../../Assets/Graphics/TurtleFighting-2DAsset.png");


        }


        public void Update()
        {
            GetPlayerInput();
            C2Pos += playerInput * 100 * Time.DeltaTime;
            DrawCharacter2(C2Pos);
            ConstrainToSide();
        }

        public void GetPlayerInput()
        {
            //local input
            Vector2 input = Vector2.Zero;
            //posisition variables

            // Backwards motion
            if (Input.IsKeyboardKeyDown(KeyboardInput.Left))
            {
                input.X -= 2;
            }

            //forwards motion
            if (Input.IsKeyboardKeyDown(KeyboardInput.Right))
            {
                input.X += 1;
            }

            // Assign variable
            playerInput = input;

        }

        public void DrawCharacter2(Vector2 C2Pos)
        {


            if (Input.IsKeyboardKeyDown(KeyboardInput.Left))
            {
                C2HitBox(C2Pos, size);
                Graphics.Draw(TurtleRunning, C2Pos);

            }
            else if (Input.IsKeyboardKeyDown(KeyboardInput.Right))

            {
                C2HitBox(C2Pos, size);
                Graphics.Draw(TurtleRunning, C2Pos);
            }
            else if (Input.IsKeyboardKeyDown(KeyboardInput.Down))
            {
                Graphics.Draw(TurtleGuarding, C2Pos);
            }

            else if (Input.IsKeyboardKeyDown(KeyboardInput.KpEnter))
            {
                Graphics.Draw(TurtleFighting, C2Pos);

            }
            else
            {
                C2HitBox(C2Pos, size);
                Graphics.Draw(TurtleStanding, C2Pos);
            }

        }

        public void C2HitBox(Vector2 C2Pos, Vector2 Size)
        {
            Draw.LineSize = 0;
            Draw.FillColor = Color.Clear;
            Draw.Rectangle(C2Pos + delay, Size);

        }

        public void ConstrainToSide()
        {
            //screen constrain
            if (C2Pos.X < -50)
            {
                C2Pos.X = -50;
            }
            if (C2Pos.X > 640)
            {
                C2Pos.X = 640;
            }

        }
    }
}

