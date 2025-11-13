// Include the namespaces (code libraries) you need below.
using McMillan_Heather_A3_BunnyBrawl;
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        //overall color array
        Color[] colors = [
            new Color("#75a743"), //grass 0
            new Color("#ad7757"), //soil 1
            new Color("#602c2c"), //texture 2
            new Color("#73bed3 "), //sky 3
            
            ];

        Heart[] c1Hearts = [
            new Heart(0, 20, 50, 10),
            new Heart(60, 20, 50, 10),
            new Heart(120, 20, 50, 10),

            ];

        Heart[] c2Hearts = [
            new Heart(750, 20, 50, 10),
            new Heart(690, 20, 50, 10),
            new Heart(630, 20, 50, 10),
           ];

        TextWinner[] winner = [
            new TextWinner(new Vector2(320,275),new Vector2(10,50)),
            new TextWinner(new Vector2(320,325),new Vector2(50,10)),
            new TextWinner(new Vector2(340,300),new Vector2(10,25)),
            new TextWinner(new Vector2(370,275),new Vector2(10,50)),
            new TextWinner(new Vector2(390,275),new Vector2(10,50)),
            new TextWinner(new Vector2(390,275),new Vector2(20,10)),
            new TextWinner(new Vector2(410,275),new Vector2(10,50)),
            new TextWinner(new Vector2(410,325),new Vector2(30,10)),
            new TextWinner(new Vector2(440,325),new Vector2(10,50)),
            new TextWinner(new Vector2(460,275),new Vector2(10,50)),
            new TextWinner(new Vector2(460,275),new Vector2(20,10)),
            new TextWinner(new Vector2(480,275),new Vector2(10,50)),
            new TextWinner(new Vector2(480,325),new Vector2(30,10)),
            new TextWinner(new Vector2(510,325),new Vector2(10,50)),
            new TextWinner(new Vector2(530,275),new Vector2(10,50)),
            new TextWinner(new Vector2(530,275),new Vector2(50,10)),
            new TextWinner(new Vector2(530,295),new Vector2(50,10)),
            new TextWinner(new Vector2(530,275),new Vector2(50,10)),
            new TextWinner(new Vector2(550,275),new Vector2(10,50)),
            new TextWinner(new Vector2(550,275),new Vector2(50,10)),
            new TextWinner(new Vector2(600,275),new Vector2(10,30)),
            new TextWinner(new Vector2(550,305),new Vector2(50,51)),
            new TextWinner(new Vector2(580,305),new Vector2(10,20)),

            ];

        //new Vector2 C2Pos = new Vector2(600, 275);

        //initialize class
        Ground ground = new Ground();
        Character2 Turtle = new Character2(new Vector2(600, 280));
        Character2 winnerTurtle = new Character2(new Vector2(300, 350));
        Character1 Bunny = new Character1(new Vector2(25, 275));
        Character1 winnerBunny = new Character1(new Vector2(300, 350));

        //possible variables
        new float player1Health;
        new float player2Health;
        public Vector2 char1Input;
        public Vector2 char2Input;
        Vector2 Text = new Vector2(400, 300);
        string fontName = ("Winner");
        int fontSize = 20;



        public void Setup()
        {
            Window.SetTitle("Game Prep");
            Window.SetSize(800, 600);


            //initialize ground colors
            ground.grass = colors[0];
            ground.soil = colors[1];
            ground.texture = colors[2];

            Bunny.Setup();
            Turtle.Setup();


        }
        public void Update()
        {
            Window.ClearBackground(colors[3]);

            //call ground with variables
            ground.Render();

            //assign ground position
            ground.x = 0;
            ground.y = 500;
            ground.size = 100;

            //call characters

            Turtle.Update();
            Bunny.Update();
            //   PlayerCollision(Bunny, Turtle);
            PlayerCollision(Bunny, Turtle);
            player1Health = 3;
            player2Health = 3;

            Hit(Bunny, Turtle);
            Health();
        }

        public void PlayerCollision(Character1 bunny, Character2 turtle)
        {
            //local variable
            Vector2 c1Input = Vector2.Zero;
            Vector2 c2Input = Vector2.Zero;

            float bunnyPos = bunny.C1Pos.X + 125;
            float turtlePos = turtle.C2Pos.X;

            if (bunnyPos >= turtlePos)
            {
                c1Input.X -= -2;
                c2Input.X += -2;
            }

            char1Input = c1Input;
            char2Input = c2Input;


            bunny.C1Pos -= char1Input * 100 * Time.DeltaTime;
            turtle.C2Pos -= char2Input * 100 * Time.DeltaTime;

        }

        public void Hit(Character1 bunny, Character2 turtle)
        {

            float bunnyPos = bunny.C1Pos.X + 200;
            float turtlePos = turtle.C2Pos.X;

            if (bunnyPos >= turtlePos && Input.IsKeyboardKeyDown(KeyboardInput.Space))
            {
                player2Health -= 1;

                if (bunnyPos >= turtlePos && Input.IsKeyboardKeyDown(KeyboardInput.Down))
                {
                    player2Health += 1;
                }

            }

            if (bunnyPos >= turtlePos && Input.IsKeyboardKeyDown(KeyboardInput.KpEnter))
            {
                player1Health -= 1;

                if (bunnyPos >= turtlePos && Input.IsKeyboardKeyDown(KeyboardInput.Down))
                {
                    player1Health += 1;
                }

            }
        }
        public void Health()
        {

            if (player2Health == 3)
            {
                c2Hearts[0].Render();
                c2Hearts[1].Render();
                c2Hearts[2].Render();
            }
            if (player2Health == 2)
            {
                c2Hearts[0].Render();
                c2Hearts[1].Render();
            }
            if (player2Health == 1)
            {
                c1Hearts[0].Render();
            }
            if (player2Health == 0)
            {
                Window.ClearBackground(Color.Black);
                winnerBunny.Update();
                for (int i = 0; i < winner.Length; i++)
                    winner[i].Update();
            }
            if (player1Health == 3)
            {
                c1Hearts[0].Render();
                c1Hearts[1].Render();
                c1Hearts[2].Render();
            }
            if (player1Health == 2)
            {
                c1Hearts[0].Render();
                c1Hearts[1].Render();
            }
            if (player1Health == 1)
            {
                c1Hearts[0].Render();
            }
            if (player1Health == 0)
            {
                Window.ClearBackground(Color.Black);
                winnerTurtle.Update();
                for (int i = 0; i < winner.Length; i++)
                    winner[i].Update();
            }

        }
    }

}
