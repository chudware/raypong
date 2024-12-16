using System.Numerics;
using Raylib_cs;
using RL = Raylib_cs.Raylib;
namespace raypong.src;
class Program
{
    public static void Main()
    {
        RL.InitAudioDevice();
        int ScreenWidth = 1280;
        int ScreenHeight = 960;
        RL.InitWindow(ScreenWidth, ScreenHeight, "Raypong");
        RL.SetTargetFPS(60);
        Ball ball = new();
        ball.x = ScreenWidth / 2;
        ball.y = ScreenHeight / 2;
        ball.speed_x = 8;
        ball.speed_y = 8;
        ball.radius = 2; // messed up collision

        Paddle player = new();
        player.width = 64;
        player.height = 256;
        player.x = 0 + player.width / 2;
        player.y = ScreenHeight / 2 - player.height / 2;
        player.original_speed = 8;
        player.speed = 8;

        Paddle cpu = new CPUPaddle();
        cpu.width = 64;
        cpu.height = 256;
        cpu.x = ScreenWidth - cpu.width / 2 - cpu.width;
        cpu.y = ScreenHeight / 2 - cpu.height / 2;
        cpu.original_speed = 8;
        cpu.speed = 8;

        Sound pad_hit = RL.LoadSound("assets/click.wav");
        Background bg = new();

        void checkCollision()
        {
            if (RL.CheckCollisionCircleRec(new Vector2(ball.x, ball.y), ball.radius, new Rectangle(player.x, player.y, player.width, player.height)))
            {
                ball.speed_x *= -1;
                RL.PlaySound(pad_hit);
            }
            if (RL.CheckCollisionCircleRec(new Vector2(ball.x, ball.y), ball.radius, new Rectangle(cpu.x, cpu.y, cpu.width, cpu.height)))
            {
                ball.speed_x *= -1;
                RL.PlaySound(pad_hit);
            }
        }

        while (!RL.WindowShouldClose())
        {
            RL.BeginDrawing();
            ball.Update();
            player.Update();
            cpu.Update();
            checkCollision();
            RL.ClearBackground(Color.SkyBlue);
            bg.Draw();
            ball.Draw();
            player.Draw();
            cpu.Draw();
            ball.Score();
            RL.EndDrawing();
        }
        RL.CloseAudioDevice();
        RL.CloseWindow();
    }
}