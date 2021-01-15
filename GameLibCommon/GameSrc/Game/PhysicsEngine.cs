using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.Game
{
    internal class PhysicsEngine
    {
        public List<GameObject> CalculatePhysics(List<GameObject> gameObjects, Area area)
        {
            CalculateCollision(gameObjects, area);

            ChangeToNewPosition(gameObjects, area);

            return gameObjects;
        }

        public void CalculateCollision(List<GameObject> gameObjects, Area area)
        {
            var gameObjectArray = gameObjects.ToArray();
            for (int i = 0; i < gameObjectArray.Length; i++)
            {
                if(i < gameObjectArray.Length - 1)
                {
                    for (int j = i + 1; j < gameObjectArray.Length; j++)
                    {
                        if (gameObjectArray[i].Bounds.Intersects(gameObjectArray[j].Bounds))
                        {
                            if (gameObjectArray[i].Stability < 10000)
                            {
                                gameObjectArray[i].DirectionDegree
                                    = CalculateReDirection(gameObjectArray[i].DirectionDegree, gameObjectArray[j].DirectionDegree);

                                gameObjectArray[i].Speed = gameObjectArray[j].Speed / 2;
                            }
                            if (gameObjectArray[j].Stability < 10000)
                            {
                                gameObjectArray[j].DirectionDegree
                                    = CalculateReDirection(gameObjectArray[j].DirectionDegree, gameObjectArray[i].DirectionDegree);
                                gameObjectArray[j].Speed = gameObjectArray[j].Speed / 2;
                            }
                        }

                    }
                }
            }

        }

        public double CalculateReDirection(double directionmovingObject, double collitionObjectDirection )
        {
            double originalDifference = GetDifferenceAngles(directionmovingObject, collitionObjectDirection);

            double inverseObjectDirection = AddAngleDirection(collitionObjectDirection, 180);

            double inverseDifference = GetDifferenceAngles(directionmovingObject, collitionObjectDirection + 180);

            // TODO Find better solution
            //if (originalDifference < 5 || inverseDifference < 5)
            //{
            //    return AddAngleDirection(directionmovingObject, 180);
            //}

            double commingDirectionMultFactor = 1;

            if (collitionObjectDirection < directionmovingObject)
            {
                commingDirectionMultFactor = -1;
            }

            
            if (inverseDifference < originalDifference )
            {
                double flowDirectionMultFactor = 1;
                if (directionmovingObject < inverseObjectDirection)
                {
                    flowDirectionMultFactor = -1;
                }
                return AddAngleDirection(inverseObjectDirection, 
                    inverseDifference * commingDirectionMultFactor * flowDirectionMultFactor);
            }

            return AddAngleDirection(collitionObjectDirection, 
                originalDifference * commingDirectionMultFactor);
        }

        public double AddAngleDirection(double currentDirection, double additionalDifference)
        {
            double sum = currentDirection + additionalDifference;

            if (sum < 0)
            {
                sum = sum + 360;
            }

            double newDirection = (sum) % 360.0f;
            return newDirection;
        }

        public double GetDifferenceAngles(double firstDirection, double secondDirection)
        {
            double newDifference = Math.Abs(firstDirection - secondDirection);
            return newDifference;
        }

        #region Position Calculation
        public void ChangeToNewPosition(List<GameObject> gameObjects, Area area)
        {
            foreach (var gameObj in gameObjects)
            {
                double newX = gameObj.CurrentPosition.X;
                double newY = gameObj.CurrentPosition.Y;

                if (gameObj.Speed <= 0.1)
                {
                    continue;
                }

                double length = 1 * gameObj.Speed;
                if(gameObj.DirectionDegree < 90)
                {
                    double rad = Math.PI * gameObj.DirectionDegree / 180.0;
                    newX = newX + Math.Cos(rad) * length;
                    newY = newY - Math.Sin(rad) * length;
                    
                }
                else if (gameObj.DirectionDegree > 90 && gameObj.DirectionDegree < 180)
                {
                    double direction = 90 - (gameObj.DirectionDegree - 90);
                    double rad = Math.PI * direction / 180.0;
                    newX = newX - Math.Cos(rad) * length;
                    newY = newY - Math.Sin(rad) * length;

                }
                else if (gameObj.DirectionDegree > 180 && gameObj.DirectionDegree < 270)
                {
                    double direction = gameObj.DirectionDegree - 180;
                    double rad = Math.PI * direction / 180.0;
                    newX = newX - Math.Cos(rad) * length;
                    newY = newY + Math.Sin(rad) * length;
                }
                else if (gameObj.DirectionDegree > 270 && gameObj.DirectionDegree < 360)
                {
                    double direction =90 - (gameObj.DirectionDegree - 270);
                    //double direction = gameObj.DirectionDegree;
                    double rad = Math.PI * direction / 180.0;
                    newX = newX + Math.Cos(rad) * length;
                    newY = newY + Math.Sin(rad) * length;
                }
                else if (gameObj.DirectionDegree == 90 )
                {
                    newY = newY +  length;
                }
                else if (gameObj.DirectionDegree == 180 )
                {
                    newX = newX -  length;
                }
                else if (gameObj.DirectionDegree == 270 )
                {
                    newY = newY -  length;
                }
                else if (gameObj.DirectionDegree == 0)
                {
                    newX = newX + length;
                }

                gameObj.CurrentPosition = new Microsoft.Xna.Framework.Vector2((float)newX, (float)newY);
                continue;
            }
        }

        #endregion

    }
}
