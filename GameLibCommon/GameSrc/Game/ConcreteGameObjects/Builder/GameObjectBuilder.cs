using GameLibCommon.GameSrc.ConcreteGameObjects.Builder;
using GameLibCommon.GameSrc.Game;
using GameLibCommon.GameSrc.Game.ConcreteGameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.ConcreteGameObjects
{
    internal class GameObjectBuilder
    {
        private float _width = 1;
        private float _height = 1;

        internal GameObjectBuilder SetSize(float width, float height)
        {
            _width = width;
            _height = height;
            return this;
        }

        private float _x = 0;
        private float _y = 0;

        internal GameObjectBuilder SetPosition(float x, float y)
        {
            _x = x;
            _y = y;

            return this;
        }

        private ObjectOrientation _orientation = ObjectOrientation.Horizontal;

        internal GameObjectBuilder SetOrientation(ObjectOrientation orientation)
        {
            _orientation = orientation;
            return this;
        }

        string _assetName = "wallhorizontal";

        internal GameObjectBuilder SetAssetName(string assetName)
        {
            _assetName = assetName;
            return this;
        }

        GameObjectType _gameObjectType = GameObjectType.WALL;

        internal GameObjectBuilder SetObjectType(GameObjectType type)
        {
            _gameObjectType = type;
            return this;
        }

        internal GameObject Build(ContentManager contentManager)
        {
            Texture2D textureWallHorz2 = contentManager.Load<Texture2D>(_assetName);
            double directionDegree = 360;

            switch (_orientation)
            {
                case ObjectOrientation.Horizontal:
                    textureWallHorz2 = contentManager.Load<Texture2D>(_assetName);
                    directionDegree = 360;
                    break;
                case ObjectOrientation.Vertical:
                    textureWallHorz2 = contentManager.Load<Texture2D>(_assetName);
                    directionDegree = 90;
                    break;
            }

            GameObject obj = GetObject(_gameObjectType);

            obj.DirectionDegree = directionDegree;
            obj.Width = _width;
            obj.Height = _height;
            obj.Initialize(new Vector2(_x, _y), 
                new GameObjectItem(textureWallHorz2, new Vector2(0, 0)));

            return obj;
        }

        internal GameObject GetObject(GameObjectType objectType)
        {
            GameObject obj = new Wall();

            switch (objectType)
            {
                case GameObjectType.BALL:
                    obj = new Ball();
                    break;
                case GameObjectType.WALL:
                    obj = new Wall();
                    break;
                case GameObjectType.BLOCK:
                    obj = new Block();
                    break;
                case GameObjectType.HOLE:
                    obj = new Wall();
                    break;
               
                default:
                    break;
            }

            return obj;
        }

        internal static GameObjectBuilder Create()
        {
            return new GameObjectBuilder();
        }

        private GameObjectBuilder()
        { }

    }
}
