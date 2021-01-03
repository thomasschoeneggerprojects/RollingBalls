
using GameLibCommon.GameSrc.ConcreteGameObjects;
using GameLibCommon.GameSrc.Input;
using GameLibCommon.GameSrc.Screen;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibCommon.GameSrc.Game.Type
{
    internal class SingleBallBalanceGame : IGameScreen
    {
        private SpriteBatch _spriteBatch;

        private GameMediator _gameMediator;

        private const int WALL_THICKNESS = 20;
        void IGameScreen.LoadContent(GraphicsDevice graphicsDevice, ContentManager contentManager, 
            ScreenDescription screenDescription)
        {
            var width = (int)screenDescription.ScreenSizeInformation.Widht;
            var height = (int)screenDescription.ScreenSizeInformation.Height;

            graphicsDevice.Viewport = new Viewport(0, 0, width, height);

            _spriteBatch = new SpriteBatch(graphicsDevice);
            
            List<GameObject> gameObjects = new List<GameObject>();
            foreach (GameObjectDescription description in screenDescription.Items)
            {
                var texture = contentManager.Load<Texture2D>(description.AssetName);
                var obj =GameObjectBuilder.Create()
                    .SetPosition(description.CurrentPosition.X, description.CurrentPosition.Y)
                    .SetOrientation(description.ObjectOrientation)
                    .SetAssetName(description.AssetName)
                    .SetSize((int)description.Width, (int)description.Height)
                    .SetObjectType(description.GameObjectType)
                    .Build(contentManager);
                gameObjects.Add(obj);
            }

            _gameMediator = new GameMediator(width, height);
            _gameMediator.Set(gameObjects.ToArray());


            // TODO remove after test
            _gameMediator.Set(contentManager.Load<SpriteFont>("Labels/LabelLarge"));
        }

        void IGameScreen.Update(GameTime gameTime, InputInformation inputInformation)
        {
            _gameMediator.Refresh(_spriteBatch, inputInformation);
        }

        void IGameScreen.Draw(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            graphicsDevice.Clear(Color.Wheat);

            _gameMediator.DrawScreen(_spriteBatch);

        }

    }
}
