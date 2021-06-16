using SFML.Window;
using SFML.Graphics;
using System;
using SFML.System;

namespace Agario
{
    public class Game
    {
        public static uint width = 3200;
        public static uint height = 1800;

        private MovingCircles _movingCircles = new MovingCircles();
        private KYSHAHbKA _eda = new KYSHAHbKA();
        private Interactions _interactions = new Interactions();
        private CirclesController _circlesController = new CirclesController();

        Random rnd = new Random();

        public static RenderWindow window = new RenderWindow(new VideoMode(width, height), "Game");

        private int _curPlayerId;

        private CircleShape _player;

        private static CircleShape[] AllMovingCircles;

        private CircleShape[] botsArray;

        private Vector2f[] speeds = new Vector2f[7];

        public void Main()
        {
            window.SetActive();
            _eda.SpawnEda();
            _movingCircles.FillCircles();
            //DivideCircles();
            GetCircles();
            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear(Color.Cyan);
                _eda.DrawEda();
                _movingCircles.SpawnCircles();
                window.Draw(_player);
                _circlesController.PlayerMove(_player);
                MoveAllBots();
                HandleChange();
                _interactions.TrySkyshatb(_player, _eda.cookies, botsArray);
                window.Display();
            }
        }

        void MoveAllBots()
        {
            for (int i = 0; i < botsArray.Length; i++)
            {
                _circlesController.MoveBot(_eda.cookies, botsArray[i], out speeds[i]);
                botsArray[i].Position += speeds[i];
            }
        }

        /*void DivideCircles()
        {
            _curPlayerId = 0;
            _player = AllMovingCircles[_curPlayerId];
            botsArray = new CircleShape[AllMovingCircles.Length - 1];
            for (int i = 1; i <= AllMovingCircles.Length; i++)
            {
                botsArray[i - 1] = AllMovingCircles[i];
            }
        }*/

        void GetCircles()
        {
            _movingCircles.CreateCircle(out _player);
            _player.FillColor = Color.Magenta;
            botsArray = MovingCircles.AllMovingCircles;
        }

        void ChangePlayerId()
        {
            _curPlayerId = rnd.Next(0, botsArray.Length);
        }

        void ChangeCircles()
        {
            CircleShape helpingCircle = _player;
            helpingCircle.FillColor = Color.Red;
            botsArray[_curPlayerId].FillColor = Color.Magenta;
            _player = botsArray[_curPlayerId];
            botsArray[_curPlayerId] = helpingCircle;
        }

        void HandleChange()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.F))
            {
                Change();
            }
        }

        void Change()
        {
            ChangePlayerId();
            ChangeCircles();
        }
    }
}