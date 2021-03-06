﻿using GameLibCommon.GameSrc.Input;
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
            double newDirection = CalcNewAngle(inputInformation);
            double newAccel = CalcNewAccelaration(inputInformation);

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

        private double CalcNewAngle(InputInformation inputInformation)
        {
            double result = 0;

            double cY = Math.Round(inputInformation.Acceleration.Y / conversion, 5);
            double cX = Math.Round(inputInformation.Acceleration.X / conversion, 5);

            if(cX < 0)
            {
                if (cY < 0)
                {
                    if (cX <= cY)
                    {
                        result = calcTest(cX, cY, 45, 1);
                    }
                    else
                    {
                        result = calcTest(cX, cY, 45, -1);
                    }
                }
                else
                {
                    if (Math.Abs(cX) <= Math.Abs(cY))
                    {
                        result = calcTest(cX, cY, 315, -1);
                    }
                    else
                    {
                        result = calcTest(cX, cY, 315, 1);
                    }                 

                }
            }
            else
            {
                if(cY < 0)
                {
                    if(Math.Abs(cX) <= Math.Abs(cY))
                    {
                        result = calcTest(cX, cY, 135, -1);
                    }
                    else
                    {
                        result = calcTest(cX, cY, 135, 1);
                    }                    
                }
                else
                {
                    if (Math.Abs(cX) <= Math.Abs(cY))
                    {
                        result = calcTest(cX, cY, 225, 1);
                    }
                    else
                    {
                        result = calcTest(cX, cY, 225, -1);
                    }
                    
                }
            }

            return result;
        }

        private double calcTest(double cX, double cY, double startingPoint, int directionValue)
        {
            double deflection = 45;
            if (Math.Abs((Math.Abs(cX) - Math.Abs(cY))) < 45)
            {
                deflection = Math.Abs(Math.Abs(cX) - Math.Abs(cY));
            }

            return startingPoint + (deflection * directionValue);
        }

        private double CalcNewAccelaration(InputInformation inputInformation)
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
                gameObject.Speed = ((gameObject.Speed + acceleration) / 2);
            }
            else if (distance > 180 && distance < 270)
            {
                gameObject.Speed = ((gameObject.Speed + acceleration) / 2);
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
