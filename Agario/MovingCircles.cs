using SFML.Graphics;
using SFML.System;
using System;

namespace Agario
{
    public class MovingCircles
    {
        private static uint screenWidth = Game.width;
        private static uint screenHeight = Game.height;
        
        int width = checked((int)screenWidth);
        int height = checked((int)screenHeight);
        
        private static int radius = 10;
        
        Random rnd = new Random();

        private static int count = 7;

        private CircleShape player;

        public static CircleShape[] AllMovingCircles = new CircleShape[count];

        private RenderWindow window = Game.window;

        public void SpawnCircles()
        {
            for (int i = 0; i < AllMovingCircles.Length; i++)
            {
                window.Draw(AllMovingCircles[i]);
            }
        }

        public void FillCircles()
        {
            for (int i = 0; i < AllMovingCircles.Length; i++)
            {
                CreateCircle(out AllMovingCircles[i]);
            }
            CreateCircle(out player);
        }
        
        public void CreateCircle(out CircleShape circle)
        {
            circle = new CircleShape();
            circle.FillColor = Color.Red;
            circle.Radius = radius;
            circle.Position = new Vector2f(rnd.Next(radius, width - radius), rnd.Next(radius, height - radius));
        }
    }
}