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
        private double _newDistance;

        private int _curTargetId;

        private float _xDiff, _yDiff;
        private Vector2f _diff;
        private Vector2f _speed;
        
        public void PlayerMove(CircleShape player)
        {
            GetPosDiff(player);
            CalcSpeed(player);
            player.Position += _speed;
        }

        void CalcSpeed(CircleShape circle)
        {
            //if(!IsOutOfHeight(gameBall) && !IsOutOfWidth(gameBall))
            //{
            _speed = (_diff / 100);
            //}
        }

        void GetPosDiff(CircleShape player)
        {
            math.GetCenter(player, player.Radius, out _center);
            _mousePos = Mouse.GetPosition(window);
            _xDiff = _mousePos.X - _center.X;
            _yDiff = _mousePos.Y - _center.Y;
            _diff = new Vector2f(_xDiff, _yDiff);
        }
        
        public void MoveBot(CircleShape[] edaArray, CircleShape botCircle)
        {
            CheckForDistance(edaArray, botCircle);
            _xDiff = edaArray[_curTargetId].Position.X - botCircle.Position.X;
            _yDiff = edaArray[_curTargetId].Position.Y - botCircle.Position.Y;
            _diff = new Vector2f(_xDiff, _yDiff);
            CalcSpeed(botCircle);
            botCircle.Position += _speed;
        }

        void CheckForDistance(CircleShape[] edaArray, CircleShape botCircle)
        {
            for (int i = 0; i < edaArray.Length; i++)
            { 
                math.GetDistance(botCircle, edaArray[i], out _newDistance); 
                if (_newDistance < curDistance)
                {
                    curDistance = _newDistance;
                    _curTargetId = i;
                }
            }
        }
        
        bool IsOutOfHeight(CircleShape circle) => circle.Position.Y + circle.Radius > height || circle.Position.Y + circle.Radius < 0;

        bool IsOutOfWidth(CircleShape circle) => circle.Position.X + circle.Radius > width || circle.Position.X + circle.Radius < 0;

    }
}