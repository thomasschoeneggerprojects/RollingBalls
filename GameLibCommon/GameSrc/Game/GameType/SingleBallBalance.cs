
using GameLibCommon.GameSrc.ConcreteGameObjects;
using GameLibCommon.GameSrc.Input;
using GameLibCommon.GameSrc.Screen;
using GameLibCommon.GameSrc.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibCommon.GameSrc.Game.Type
{
    internal class SingleBallBalanceGame : IGameScreenExecution
    {
        private SpriteBatch _spriteBatch;

        private GameMediator _gameMediator;

        private const int WALL_THICKNESS = 20;

        public ExecutionState ExecutionState { get; set; }

        void IGameScreenExecution.LoadContent(GraphicsDevice graphicsDevice, ContentManager contentManager, 
            ScreenDescription screenDescription)
        {
            ExecutionState = ExecutionState.INIT;

            var width = (int)screenDescription.ScreenSizeInformation.WidhtInnerScreen;
            var height = (int)screenDescription.ScreenSizeInformation.HeightInnerScreen;

            //graphicsDevice.Viewport = new Viewport((int)screenDescription.ScreenSizeInformation.OffsetFromOutherScreen.X, (int)screenDescription.ScreenSizeInformation.OffsetFromOutherScreen.Y, width, height);

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

            _gameMediator = new GameMediator(screenDescription.ScreenSizeInformation);
            _gameMediator.Set(gameObjects.ToArray());

            // TODO remove after test
            _gameMediator.Set(contentManager.Load<SpriteFont>("Labels/LabelLarge"));
        }

        void IGameScreenExecution.Update(GameTime gameTime, InputInformation inputInformation)
        {
            ExecutionState = ExecutionState.RUN;
            _gameMediator.Refresh(_spriteBatch, inputInformation);

            HandleGameState(gameTime, inputInformation);
        }

        private void HandleGameState(GameTime gameTime, InputInformation inputInformation)
        {
            
        }

        void IGameScreenExecution.Draw(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            graphicsDevice.Clear(Color.Wheat);

            _gameMediator.DrawScreen(_spriteBatch);

        }

    }
}
