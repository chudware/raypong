using Raylib_cs;
using RL = Raylib_cs.Raylib;
namespace raypong.src
{
    public class Ball
    {
        public int x, y;
        public int speed_x, speed_y;
        public int radius;
        public int player_hp = 1;
        public int cpu_hp = 1;
        public Sound pad_miss = RL.LoadSound("assets/explosion.mp3");
        public Texture2D ball = RL.LoadTexture("assets/ball.png");
        public Texture2D heart_full = RL.LoadTexture("assets/heart_full.png");
        public Texture2D heart_empty = RL.LoadTexture("assets/heart_empty.png");
        public int player_hp_location = 14;
        public int heart_offset = 68;

        public void Draw()
        {
            RL.DrawRectangle(x - 33 , y - 33, 64, 64, Color.Black);
            RL.DrawTexture(ball, x - 32, y - 32, Color.White);
            if (cpu_hp == 0)
            {
                cpu_hp = 3;
                player_hp = 3;
            }
        }
        public void Update()
        {
            x += speed_x;
            y += speed_y;

            if (y + radius >= RL.GetScreenHeight() || y - radius <= 0)
            {
                speed_y *= -1;
            }
            if (x + radius >= RL.GetScreenWidth())
            {
                cpu_hp--;
                RL.PlaySound(pad_miss);
                ResetBall();
            }
            if (x - radius <= 0)
            {
                player_hp--;
                RL.PlaySound(pad_miss);
                ResetBall();
            }
        }
        public void Score()
        {
            if (player_hp == 0)
            {
                cpu_hp = 3;
                player_hp = 3;
            }
            if (player_hp >= 0)
            {
                RL.DrawTexture(heart_empty, player_hp_location, player_hp_location, Color.White);
                RL.DrawTexture(heart_empty, player_hp_location + heart_offset, player_hp_location, Color.White);
                RL.DrawTexture(heart_empty, player_hp_location + heart_offset * 2, player_hp_location, Color.White);
            }
            if (player_hp >= 1)
            {
                RL.DrawTexture(heart_full, player_hp_location, player_hp_location, Color.White);
            }
            if (player_hp >= 2)
            {
                RL.DrawTexture(heart_full, player_hp_location + heart_offset, player_hp_location, Color.White);
            }
            if (player_hp >= 3)
            {
                RL.DrawTexture(heart_full, player_hp_location + heart_offset * 2, player_hp_location, Color.White);
            }
            if (cpu_hp == 0)
            {
                cpu_hp = 3;
                player_hp = 3;
            }
            if (cpu_hp >= 0)
            {
                // missing hp bar for cpu
            }
        }
        public void ResetBall()
        {
            x = RL.GetScreenWidth() / 2;
            y = RL.GetScreenHeight() / 2;

            int[] speed_choices = { -1, 1 };

            speed_x *= speed_choices[RL.GetRandomValue(0, 1)];
            speed_y *= speed_choices[RL.GetRandomValue(0, 1)];
        }
    }
}
