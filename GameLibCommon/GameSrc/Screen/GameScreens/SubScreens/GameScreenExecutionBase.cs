using GameLibCommon.GameSrc.ConcreteGameObjects;
using GameLibCommon.GameSrc.Game;
using GameLibCommon.GameSrc.Input;
using GameLibCommon.GameSrc.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.Screen.GameScreens.SubScreens
{
    internal abstract class GameScreenExecutionBase : IGameScreenExecution
    {
        public InnerExecutionState ExecutionState { get; set; }

        private SpriteBatch _spriteBatch;

        private GameMediator _gameMediator;

        public virtual void LoadContent(GraphicsDevice graphicsDevice, 
            ContentManager contentManager, ScreenDescription screenDescription)
        {
            ExecutionState = InnerExecutionState.INIT;
            var width = (int)screenDescription.ScreenSizeInformation.WidhtInnerScreen;
            var height = (int)screenDescription.ScreenSizeInformation.HeightInnerScreen;

            _spriteBatch = new SpriteBatch(graphicsDevice);

            List<GameObject> gameObjects = new List<GameObject>();
            foreach (GameObjectDescription description in screenDescription.Items)
            {
                var texture = contentManager.Load<Texture2D>(description.AssetName);
                var obj = GameObjectBuilder.Create()
                    .SetPosition(description.CurrentPosition.X, description.CurrentPosition.Y)
                    .SetOrientation(description.ObjectOrientation)
                    .SetAssetName(description.AssetName)
                    .SetSize((int)description.Width, (int)description.Height)
                    .SetObjectType(description.GameObjectType)
                    .Build(contentManager);
                gameObjects.Add(obj);
            }

            var background = contentManager.Load<Texture2D>(screenDescription.AssetNameBackground);
            
            _gameMediator = new GameMediator(screenDescription.ScreenSizeInformation);
            _gameMediator.Set(gameObjects.ToArray());

            _gameMediator.SetBackground(background);

            // TODO remove after test
            _gameMediator.Set(contentManager.Load<SpriteFont>("Labels/LabelLarge"));
        }

        public virtual void Update(GameTime gameTime, InputInformation inputInformation)
        {
            ExecutionState = InnerExecutionState.RUN;
            _gameMediator.Refresh(_spriteBatch, inputInformation);
        }

        public virtual void Draw(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            _gameMediator.DrawScreen(_spriteBatch);
        }

    }
}
