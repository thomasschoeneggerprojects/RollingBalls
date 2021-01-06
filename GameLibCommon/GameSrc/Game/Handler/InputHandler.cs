using GameLibCommon.GameSrc.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.Game.Handler
{
    internal class InputHandler
    {
        const double conversion = 0.01745581; 
        internal void Handle(List<GameObject> gameObjects, InputInformation inputInformation)
        {
            double newDirection = calcNewAngle(inputInformation);
            double newAccel = calcNewAccelaration(inputInformation);

            foreach(GameObject gameObject in gameObjects)
            {
                if(gameObject.Stability >= 100000)
                {
                    continue;
                }

                UpdateSpeed(gameObject, newDirection, newAccel);
                UpdateDicection(gameObject, newDirection, newAccel);
            }
        }

        private double calcNewAngle(InputInformation inputInformation)
        {
            double result = 0;

            double cY = Math.Round(inputInformation.Acceleration.Y / conversion, 5);
            double cX = Math.Round(inputInformation.Acceleration.X / conversion, 5);

            if(cX < 0)
            {
                if (cY < 0)
                {
                    result = Math.Abs(cY) + 90;
                }
                else
                {
                    result = Math.Abs(cY);
                }

            }
            else
            {
                if(cY < 0)
                {
                    result = Math.Abs(cY) + 180;
                }
                else
                {
                    result = 360 - Math.Abs(cY);
                }
            }

            return result;
        }

        private double calcNewAccelaration(InputInformation inputInformation)
        {
            double cY = Math.Round(inputInformation.Acceleration.Y / conversion, 5);
            double cX = Math.Round(inputInformation.Acceleration.X / conversion, 5);

            return (Math.Abs(cY) + Math.Abs(cX)) * 10;
        }

        private void UpdateSpeed(GameObject gameObject, double direction, double acceleration)
        {
            double distance = Math.Abs((gameObject.DirectionDegree - direction) % 360);
            if (distance < 90)
            {
                gameObject.Speed = (gameObject.Speed + acceleration);
            }
            else if(distance > 90 && distance < 180)
            {
                gameObject.Speed = (gameObject.Speed + acceleration / 2);
            }
            else if (distance > 180 && distance < 270)
            {
                gameObject.Speed = (gameObject.Speed + acceleration / 2);
            }
            else if (distance > 270 && distance < 360)
            {
                gameObject.Speed = (gameObject.Speed - acceleration);
            }

            gameObject.Speed = gameObject.Speed % 10;
        }

        private void UpdateDicection(GameObject gameObject, double direction, double acceleration)
        {
            if (gameObject.DirectionDegree <= 90)
            {
                if(direction <= 180)
                {
                    gameObject.DirectionDegree += Math.Abs(gameObject.DirectionDegree - direction) / 2;
                } 
                else if(direction > 180 && direction <= 270)
                {
                    gameObject.DirectionDegree = Math.Abs(gameObject.DirectionDegree - 180);
                }
                else if (direction > 270 && direction <= 360)
                {
                    gameObject.DirectionDegree = 360 - gameObject.DirectionDegree;
                }
            }
            else if (gameObject.DirectionDegree > 90 && gameObject.DirectionDegree <= 180)
            {
                if (direction <= 180)
                {
                    gameObject.DirectionDegree += Math.Abs(gameObject.DirectionDegree - direction) / 2;
                }
                else if (direction > 180 && direction <= 270)
                {
                    gameObject.DirectionDegree = 270 + (direction - 90);
                }
                else if (direction > 270 && direction <= 360)
                {
                    gameObject.DirectionDegree = Math.Abs(gameObject.DirectionDegree - 180);
                }
            }
            else if (gameObject.DirectionDegree > 180 && gameObject.DirectionDegree <= 270)
            {
                if (direction >= 180)
                {
                    gameObject.DirectionDegree += Math.Abs(gameObject.DirectionDegree - direction) / 2;
                }
                else if (direction < 180 && direction > 90)
                {
                    gameObject.DirectionDegree = direction + (gameObject.DirectionDegree - 180);
                }
                else if (direction <= 90)
                {
                    gameObject.DirectionDegree = Math.Abs(gameObject.DirectionDegree - 180);
                }
            }
            else if (gameObject.DirectionDegree > 270 && gameObject.DirectionDegree <= 360)
            {
                if (direction >= 180)
                {
                    gameObject.DirectionDegree += Math.Abs(gameObject.DirectionDegree - direction) / 2;
                }
                else if (direction < 180 && direction > 90)
                {
                    gameObject.DirectionDegree = Math.Abs(gameObject.DirectionDegree - 180);
                }
                else if (direction <= 90)
                {
                    gameObject.DirectionDegree = direction + gameObject.DirectionDegree;
                }
            }

                gameObject.DirectionDegree = gameObject.DirectionDegree % 360;
        }
    }
}
