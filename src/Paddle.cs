
using Raylib_cs;
using RL = Raylib_cs.Raylib;
namespace raypong.src
{
    public class Paddle
    {
        public int x, y;
        public int width, height;
        public int speed;
        public int original_speed;
        public Texture2D paddle = RL.LoadTexture("assets/paddle.png");
        public void Draw()
        {
            RL.DrawRectangle(x - 1, y - 1, paddle.Width + 2, paddle.Height + 2, Color.Black);
            RL.DrawTexture(paddle, x, y, Color.White);
        }

        public void Update()
        {
            if (RL.IsKeyDown(KeyboardKey.Up) || RL.IsKeyDown(KeyboardKey.D) || RL.IsKeyDown(KeyboardKey.W) || RL.IsKeyDown(KeyboardKey.Right))
            {
                y -= speed;
            }
            if (RL.IsKeyDown(KeyboardKey.Down) || RL.IsKeyDown(KeyboardKey.A) || RL.IsKeyDown(KeyboardKey.S) || RL.IsKeyDown(KeyboardKey.Left))
            {
                y += speed;
            }
            if (RL.IsKeyDown(KeyboardKey.Space))
            {
                speed = 16;
            }
            else
            {
                speed = original_speed;
            }
            LimitMovement();
        }

        public void LimitMovement()
        {
            if (y <= 0)
            {
                y = 0;
            }
            if (y + height >= RL.GetScreenHeight())
            {
                y = RL.GetScreenHeight() - height;
            }
        }

    }
    public class CPUPaddle : Paddle
    {
        public void Update(int ballY)
        {
            if (y + height / 2 > ballY)
            {
                y -= speed;
            }
            if (y + height / 2 <= ballY)
            {
                y += speed;
            }
            LimitMovement();
        }
    }
}