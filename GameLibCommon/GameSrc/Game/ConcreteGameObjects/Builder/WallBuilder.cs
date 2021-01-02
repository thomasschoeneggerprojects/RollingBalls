using GameLibCommon.GameSrc.ConcreteGameObjects.Builder;
using GameLibCommon.GameSrc.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.ConcreteGameObjects
{
    internal class WallBuilder
    {
        private float _width = 1;
        private float _height = 1;

        internal WallBuilder SetSize(float width, float height)
        {
            _width = width;
            _height = height;
            return this;
        }

        private float _x = 0;
        private float _y = 0;

        internal WallBuilder SetPosition(float x, float y)
        {
            _x = x;
            _y = y;

            return this;
        }
        private ObjectOrientation _orientation = ObjectOrientation.Horizontal;

        internal WallBuilder SetOrientation(ObjectOrientation orientation)
        {
            _orientation = orientation;
            return this;
        }

        internal Wall Build(ContentManager contentManager)
        {
            Texture2D textureWallHorz2 = contentManager.Load<Texture2D>("wallhorizontal");
            double directionDegree = 360;

            switch (_orientation)
            {
                case ObjectOrientation.Horizontal:
                    textureWallHorz2 = contentManager.Load<Texture2D>("wallhorizontal");
                    directionDegree = 360;
                    break;
                case ObjectOrientation.Vertical:
                    textureWallHorz2 = contentManager.Load<Texture2D>("wallvertical");
                    directionDegree = 90;
                    break;
            }

            Wall wall = new Wall();
            wall.DirectionDegree = directionDegree;

            wall.Width = _width;
            wall.Height = _height;
            wall.Initialize(new Vector2(_x, _y), 
                new GameObjectItem(textureWallHorz2, new Vector2(0, 0)));

            return wall;
        }

        internal static WallBuilder Create()
        {
            return new WallBuilder();
        }

        private WallBuilder()
        {

        }

    }
}
