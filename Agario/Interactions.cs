using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System;

namespace Agario
{
    public class Interactions
    {
        private double distance;

        private Vector2f newPos;

        private int radius = 5;

        private MathSmth math = new MathSmth();
        
        public void Eat(CircleShape eater, CircleShape food)
        {
            distance = math.Distance(eater, food);
            
            if (IsCollided(eater))
            {
                math.CreatePos(radius, out newPos);
                eater.Radius += 1.0f;
                food.Position = newPos;
            }
        }

        void TrySkyshatbCookie(CircleShape player, CircleShape[] cookieArray, CircleShape[] botArray)
        {
            for (int i = 0; i < cookieArray.Length; i++)
            {
                Eat(player, cookieArray[i]);
            }
            
            for(int l = 0; l < botArray.Length; l++) 
            {
                for (int j = 0; j < cookieArray.Length; j++)
                {
                    Eat(botArray[l], cookieArray[j]);
                }
            }
        }
        
        void TrySkyshatbMovingCircle(CircleShape player, CircleShape[] botArray)
        {
            for (int i = 0; i < botArray.Length; i++)
            {
                if(player.Radius > botArray[i].Radius)
                {
                    botArray[i].Radius = 10;
                    Eat(player, botArray[i]);
                }
                else if(player.Radius < botArray[i].Radius)
                {
                    
                }
            }
            
            for(int l = 0; l < botArray.Length; l++) 
            {
                for (int j = 0; j < botArray.Length; j++)
                {
                    if(botArray[l].Radius > botArray[j].Radius)
                    {
                        botArray[j].Radius = 10;
                        Eat(botArray[l], botArray[j]);
                    }
                    else if(botArray[l].Radius < botArray[j].Radius)
                    {
                        botArray[l].Radius = 10;
                        Eat(botArray[j], botArray[l]);
                    }
                }
            }
        }

        public void TrySkyshatb(CircleShape player, CircleShape[] cookieArray, CircleShape[] botArray)
        {
            TrySkyshatbCookie(player, cookieArray, botArray);
            TrySkyshatbMovingCircle(player, botArray);
        }

        bool IsCollided(CircleShape circle) => distance <= circle.Radius + radius;
    }
}