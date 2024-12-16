using Raylib_cs;
using RL = Raylib_cs.Raylib;
namespace raypong.src
{
    public class Background
    {
        public Texture2D outline = RL.LoadTexture("assets/stone.png");
        public Texture2D inner = RL.LoadTexture("assets/grass.png");
        public int outlineWidth = 64;
        public int outlineHeight = 64;
        public int maxImagesX = RL.GetScreenWidth() / 64;
        public int maxImagesY = RL.GetScreenHeight() / 64;

        public void Draw()
        {
            for (int x = -1; x < maxImagesX; x++)
            {
                for (int y = -1; y < maxImagesY; y++)
                {
                    RL.DrawTexture(inner, x * outlineWidth - outlineWidth, y * outlineHeight + outlineHeight, Color.White);
                    RL.DrawTexture(outline, outlineWidth - outlineWidth, y * outlineHeight + outlineHeight, Color.White);
                    RL.DrawTexture(outline, RL.GetScreenWidth() - outlineWidth, y * outlineHeight + outlineHeight, Color.White);
                    RL.DrawTexture(outline, x * outlineWidth - outlineWidth, outlineHeight - outlineHeight, Color.White);   
                    RL.DrawTexture(outline, x * outlineWidth - outlineWidth, RL.GetScreenHeight() - outlineHeight, Color.White);
                    //RL.DrawTexture(statbg, 0, 0, Color.White);
                }
            }
        }
    }
}