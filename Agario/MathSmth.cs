using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System;

namespace Agario
{
    public class MathSmth
    {
        Random rnd = new Random();
        
        private static uint scWidth = Game.width;
        private static uint scHeight = Game.height;
        
        int width = checked((int)scWidth);
        int height = checked((int)scHeight);

        public Vector2f Center(CircleShape circle, float radius)
        {
            return new Vector2f(circle.Position.X + radius, circle.Position.Y + radius);
        }

        public double Distance(CircleShape One, CircleShape Two)
        {
            return Math.Sqrt(Math.Pow((One.Position.X + One.Radius) - (Two.Position.X + 5), 2) + Math.Pow(
                (One.Position.Y + One.Radius) - (Two.Position.Y + 5), 2));
        }

        public void CreatePos(int radius, out Vector2f position)
        {
            position = new Vector2f(rnd.Next(radius, width - radius), rnd.Next(radius, height - radius));
        }
    }
}