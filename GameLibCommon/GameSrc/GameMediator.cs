using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace GameLibCommon.GameSrc
{
    internal class GameMediator
    {
        private List<GameObject> _gameObjects;
        private PhysicsEngine _physicsEngine;
        private Area _arena;
        private Matrix globalTransformation;

        public GameMediator(int width, int height)
        {
            _arena = new Area(width, height);
            _physicsEngine = new PhysicsEngine();
            _gameObjects = new List<GameObject>();
        }

        internal void Set(params GameObject[] gameObjects)
        {
            _gameObjects.AddRange(gameObjects);
        }

        public void Refresh(SpriteBatch spriteBatch)
        {
            CalculatePhysics(_gameObjects);
            Draw(spriteBatch);
        }

        public void CalculatePhysics(List<GameObject> gameObjects) 
        {

            _physicsEngine.CalculatePhysics(gameObjects, _arena);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate);
            foreach (var gameObj in _gameObjects)
            {
                foreach (var item in gameObj.GameObjectItems)
                {

                    var position = gameObj.CurrentPosition + item.Offset;
                    spriteBatch.Draw(item.Texture, new Rectangle((int)position.X,(int) position.Y, gameObj.Bounds.Width, gameObj.Bounds.Height),  Color.White);


                    //spriteBatch.Draw(item.Texture, gameObj.CurrentPosition + item.Offset, gameObj.Bounds, Color.White, 0, item.Offset,0.7f,SpriteEffects.None, 1);
                    
                }
            }
            spriteBatch.End();

        }

        }
}
