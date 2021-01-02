using GameLibCommon.GameSrc.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.Game.Handler
{
    internal class InputHandler
    {
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
            return inputInformation.Acceleration.X;
        }

        private double calcNewAccelaration(InputInformation inputInformation)
        {
            return inputInformation.Acceleration.Y;
        }

        private void UpdateSpeed(GameObject gameObject, double direction, double acceleration)
        {
            gameObject.Speed = acceleration;
        }

        private void UpdateDicection(GameObject gameObject, double direction, double acceleration)
        {
            gameObject.DirectionDegree = (gameObject.DirectionDegree + direction) % 360;
        }
    }
}
