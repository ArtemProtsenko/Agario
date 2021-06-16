using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace Agario
{
    public class CirclesController
    {
        private MathSmth math = new MathSmth();

        private RenderWindow window = Game.window;
        
        private static uint screenWidth = Game.width;
        private static uint screenHeight = Game.height;
        
        int width = checked((int)screenWidth);
        int height = checked((int)screenHeight);

        private Vector2f _position;

        private Vector2i _mousePos;

        private Vector2f _center;

        private double curDistance = 10000;

        public void PlayerMove(CircleShape player)
        {
            Vector2f speed;
            GetPosDiff(player, out speed);
            player.Position += speed;
        }

        /*void CalcSpeed(Vector2f _diff)
        {
            if(!IsOutOfHeight(gameBall) && !IsOutOfWidth(gameBall))
            {
                
            }
        }*/

        void GetPosDiff(CircleShape player, out Vector2f speed)
        {
            _center = math.Center(player, player.Radius);
            _mousePos = Mouse.GetPosition(window);
            float xDiff = _mousePos.X - _center.X;
            float yDiff = _mousePos.Y - _center.Y;
            Vector2f diff = new Vector2f(xDiff, yDiff);
            speed = (diff / 100);
        }
        
        public void MoveBot(CircleShape[] edaArray, CircleShape botCircle, out Vector2f botSpeed)
        {
            int curTargetId;
            CheckForDistance(edaArray, botCircle, out curTargetId);
            float xDiff = edaArray[curTargetId].Position.X - botCircle.Position.X;
            float yDiff = edaArray[curTargetId].Position.Y - botCircle.Position.Y;
            Vector2f diff = new Vector2f(xDiff, yDiff);
            botSpeed = (diff / 100);
        }

        void CheckForDistance(CircleShape[] edaArray, CircleShape botCircle, out int curTargetId)
        {
            curTargetId = 1;
            
            for (int i = 0; i < edaArray.Length; i++)
            {
                double newDistance = math.Distance(botCircle, edaArray[i]);
                
                if (newDistance < curDistance)
                {
                    curDistance = newDistance;
                    curTargetId = i;
                }
            }
        }
        
        bool IsOutOfHeight(CircleShape circle) => circle.Position.Y + circle.Radius > height || circle.Position.Y + circle.Radius < 0;

        bool IsOutOfWidth(CircleShape circle) => circle.Position.X + circle.Radius > width || circle.Position.X + circle.Radius < 0;

    }
}