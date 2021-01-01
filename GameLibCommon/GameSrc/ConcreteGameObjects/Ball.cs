using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.ConcreteGameObjects
{
    internal class Ball : GameObject
    {
        public Ball()
        {
            TextureDescriptions.Add("ball", typeof(Texture2D));
        }

        internal override void Initialize(Vector2 currentPosition, params GameObjectItem[] loadedGameObjectItems)
        {
            Width = 40;
            Height = 40;

            DirectionDegree = 272;
            Speed = 12;
            CurrentPosition = currentPosition;
            GameObjectItems.AddRange(loadedGameObjectItems);

            Stability = 100;
        }

        internal void AddSpeed(double speed)
        {
            Speed = speed;
        }
    }
}
