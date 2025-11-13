using MohawkGame2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace McMillan_Heather_A3_BunnyBrawl
{
    public class Character1
    {
        public Vector2 playerInput;
        public Vector2 C1Pos;
        public Vector2 delay = new Vector2(50, 25);
        public Vector2 size = new Vector2(100, 200);
        public float turtlePos;



        public Texture2D RightRabbitStanding;
        public Texture2D RightRabbitRunning;
        public Texture2D RightRabbitJumping;
        public Texture2D RightRabbitGuarding;
        public Texture2D RightRabbitFighting;


        public Character1(Vector2 C1Pos)
        {
            this.C1Pos = C1Pos;
        }

        public void Setup()
        {
            //running out of this location
            //C:\Users\hmcmi\source\repos\Game prep\bin\Debug\net9.0
            //back by three?
            // set asset variables to call location
            RightRabbitStanding = Graphics.LoadTexture("../../../Assets/Graphics/RabbitStanding-2DAsset.png");
            RightRabbitRunning = Graphics.LoadTexture("../../../Assets/Graphics/RabbitRunning-2DAsset.png");
            RightRabbitJumping = Graphics.LoadTexture("../../../Assets/Graphics/RabbitJumping-2DAsset.png");
            RightRabbitGuarding = Graphics.LoadTexture("../../../Assets/Graphics/RabbitGuarding-2DAsset.png");
            RightRabbitFighting = Graphics.LoadTexture("../../../Assets/Graphics/RabbitFighting-2DAsset.png");

            //set frames per second
        }

        public void Update()
        {

            GetPlayerInput();
            C1Pos += playerInput * 100 * Time.DeltaTime;
            DrawCharacter1(C1Pos);
            ConstrainToSide();

        }

        //Getinputs
        public void GetPlayerInput()
        {

            //local input
            Vector2 input = Vector2.Zero;
            //posisition variables

            // Backwards motion
            if (Input.IsKeyboardKeyDown(KeyboardInput.A))
            {
                input.X -= 1;
            }

            //forwards motion
            if (Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                input.X += 2;
            }

            // Assign variable
            playerInput = input;

        }
        //set animations
        public void DrawCharacter1(Vector2 C1Pos)
        {


            if (Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                C1HitBox(C1Pos, size);
                Graphics.Draw(RightRabbitRunning, C1Pos);

            }
            else if (Input.IsKeyboardKeyDown(KeyboardInput.A))

            {
                C1HitBox(C1Pos, size);
                Graphics.Draw(RightRabbitRunning, C1Pos);
            }
            else if (Input.IsKeyboardKeyDown(KeyboardInput.S))
            {

                Graphics.Draw(RightRabbitGuarding, C1Pos);
            }

            else if (Input.IsKeyboardKeyDown(KeyboardInput.Space))
            {

                Graphics.Draw(RightRabbitFighting, C1Pos);

            }
            else
            {
                C1HitBox(C1Pos, size);
                Graphics.Draw(RightRabbitStanding, C1Pos);
            }

        }
        public void C1HitBox(Vector2 C1Pos, Vector2 size)
        {
            Draw.LineSize = 0;
            Draw.FillColor = Color.Clear;
            Draw.Rectangle(C1Pos + delay, size);

        }

        public void ConstrainToSide()
        {

            if (C1Pos.X < -40)
            {
                C1Pos.X = -40;
            }
            if (C1Pos.X > 640)
            {
                C1Pos.X = 640;
            }

        }

    }

}
