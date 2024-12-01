using Raylib_cs;
using RL = Raylib_cs.Raylib;
namespace raypong.src
{
    public class Ball
    {
        public int x, y;
        public int speed_x, speed_y;
        public int radius;
        public int player_hp = 20;
        public int cpu_hp = 20;
        public Sound pad_miss = RL.LoadSound("assets/explosion.mp3");
        public Texture2D ball = RL.LoadTexture("assets/ball.png");
        public Texture2D heart_full = RL.LoadTexture("assets/heart_full.png");
        public Texture2D heart_empty = RL.LoadTexture("assets/heart_empty.png");
        public Texture2D heart_half = RL.LoadTexture("assets/heart_half.png");
        public int player_hp_location = 18;
        public int heart_offset = 40;
        public void Draw()
        {
            RL.DrawRectangle(x - 1, y - 1, ball.Width + 2, ball.Height + 2, Color.Black);
            RL.DrawTexture(ball, x, y, Color.White);
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
                player_hp = 20;
                cpu_hp = 20;
            }
            if (player_hp >= 0)
            {
                RL.DrawTexture(heart_empty, player_hp_location, player_hp_location, Color.White);
                RL.DrawTexture(heart_empty, player_hp_location + heart_offset, player_hp_location, Color.White);
                RL.DrawTexture(heart_empty, player_hp_location + heart_offset * 2, player_hp_location, Color.White);
                RL.DrawTexture(heart_empty, player_hp_location + heart_offset * 3, player_hp_location, Color.White);
                RL.DrawTexture(heart_empty, player_hp_location + heart_offset * 4, player_hp_location, Color.White);
                RL.DrawTexture(heart_empty, player_hp_location + heart_offset * 5, player_hp_location, Color.White);
                RL.DrawTexture(heart_empty, player_hp_location + heart_offset * 6, player_hp_location, Color.White);
                RL.DrawTexture(heart_empty, player_hp_location + heart_offset * 7, player_hp_location, Color.White);
                RL.DrawTexture(heart_empty, player_hp_location + heart_offset * 8, player_hp_location, Color.White);
                RL.DrawTexture(heart_empty, player_hp_location + heart_offset * 9, player_hp_location, Color.White);
            }
            if (player_hp >= 1)
            {
                RL.DrawTexture(heart_half, player_hp_location, player_hp_location, Color.White);
            }
            if (player_hp >= 2)
            {
                RL.DrawTexture(heart_full, player_hp_location, player_hp_location, Color.White);
            }
            if (player_hp >= 3)
            {
                RL.DrawTexture(heart_half, player_hp_location + heart_offset, player_hp_location, Color.White);
            }
            if (player_hp >= 4)
            {
                RL.DrawTexture(heart_full, player_hp_location + heart_offset, player_hp_location, Color.White);
            }
            if (player_hp >= 5)
            {
                RL.DrawTexture(heart_half, player_hp_location + heart_offset * 2, player_hp_location, Color.White);
            }
            if (player_hp >= 6)
            {
                RL.DrawTexture(heart_full, player_hp_location + heart_offset * 2, player_hp_location, Color.White);
            }
            if (player_hp >= 7)
            {
                RL.DrawTexture(heart_half, player_hp_location + heart_offset * 3, 18, Color.White);
            }
            if (player_hp >= 8)
            {
                RL.DrawTexture(heart_full, player_hp_location + heart_offset * 3, 18, Color.White);
            }
            if (player_hp >= 9)
            {
                RL.DrawTexture(heart_half, player_hp_location + heart_offset * 4, 18, Color.White);
            }
            if (player_hp >= 10)
            {
                RL.DrawTexture(heart_full, player_hp_location + heart_offset * 4, 18, Color.White);
            }
            if (player_hp >= 11)
            {
                RL.DrawTexture(heart_half, player_hp_location + heart_offset * 5, 18, Color.White);
            }
            if (player_hp >= 12)
            {
                RL.DrawTexture(heart_full, player_hp_location + heart_offset * 5, 18, Color.White);
            }
            if (player_hp >= 13)
            {
                RL.DrawTexture(heart_half, player_hp_location + heart_offset * 6, 18, Color.White);
            }
            if (player_hp >= 14)
            {
                RL.DrawTexture(heart_full, player_hp_location + heart_offset * 6, 18, Color.White);
            }
            if (player_hp >= 15)
            {
                RL.DrawTexture(heart_half, player_hp_location + heart_offset * 7, 18, Color.White);
            }
            if (player_hp >= 16)
            {
                RL.DrawTexture(heart_full, player_hp_location + heart_offset * 7, 18, Color.White);
            }
            if (player_hp >= 17)
            {
                RL.DrawTexture(heart_half, player_hp_location + heart_offset * 8, 18, Color.White);
            }
            if (player_hp >= 18)
            {
                RL.DrawTexture(heart_full, player_hp_location + heart_offset * 8, 18, Color.White);
            }
            if (player_hp >= 19)
            {
                RL.DrawTexture(heart_half, player_hp_location + heart_offset * 9, 18, Color.White);
            }
            if (player_hp >= 20)
            {
                RL.DrawTexture(heart_full, player_hp_location + heart_offset * 9, 18, Color.White);
            }
            if (cpu_hp == 0)
            {
                cpu_hp = 20;
                player_hp = 20;
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
