using GameLibCommon.GameSrc.ConcreteGameObjects;
using GameLibCommon.GameSrc.Game;
using GameLibCommon.GameSrc.Input;
using GameLibCommon.GameSrc.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLibCommon.GameSrc.Screen.GameScreens
{
    internal abstract class GameLevelScreenSequenceExecutionBase : IGameScreenSequenceExecution
    {
        public InnerExecutionState ExecutionState { get; set; }

        protected IGameScreenExecution _currentExecutionScreen;

        int currentScreen = 0;

        public virtual void LoadContent(GraphicsDevice graphicsDevice, 
            ContentManager contentManager, 
            ScreenSequenceDescription screenSequenceDescription)
        {
            ExecutionState = InnerExecutionState.INIT;
            currentScreen = 0;
            var firstScreen = screenSequenceDescription.ScreenDescriptions.ElementAt(0);
            LoadScreen(graphicsDevice, contentManager, firstScreen);
        }

        private void LoadScreen(GraphicsDevice graphicsDevice, ContentManager contentManager, ScreenDescription desc)
        {
            LoadGameLevelScreen(graphicsDevice, contentManager, desc);
        }

        private void LoadGameLevelScreen(GraphicsDevice graphicsDevice, ContentManager contentManager, ScreenDescription desc)
        {
            _currentExecutionScreen = GameScreenExecutionProvider.CreateGameScreenExecution(graphicsDevice, contentManager, desc);
        }

        public virtual void Update(GameTime gameTime, InputInformation inputInformation)
        {
            _currentExecutionScreen.Update(gameTime, inputInformation);
        }

        private void HandleGameState(GameTime gameTime, InputInformation inputInformation)
        {

        }

        public virtual void Draw(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            _currentExecutionScreen.Draw(gameTime, graphicsDevice);
        }
    }
}
