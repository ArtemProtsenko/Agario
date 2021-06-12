using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System;

namespace Agario
{
    public class KYSHAHbKA
    {
        private static int count = 150;

        private int radius = 5;
        
        Random rnd = new Random();
        
        private RenderWindow window = Game.window;
        
        private static uint scWidth = Game.width;
        private static uint scHeight = Game.height;
        
        int width = checked((int)scWidth);
        int height = checked((int)scHeight);

        public CircleShape[] cookies = new CircleShape[count];

        public void DrawEda()
        {
            for (int i = 0; i < count; i++)
            {
                window.Draw(cookies[i]);
            }
        }

        public void SpawnEda()
        {
            for (int i = 0; i < count; i++)
            {
                CreateCookie(out cookies[i]);
            }
        }

        void CreateCookie(out CircleShape cookie)
        {
            cookie = new CircleShape();
            cookie.FillColor = Color.Black;
            cookie.Radius = radius;
            cookie.Position = new Vector2f(rnd.Next(radius, width - radius), rnd.Next(radius, height - radius));
        }
    }
}