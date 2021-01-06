using GameLibCommon.GameSrc.Input;
using GameLibCommon.GameSrc.Screen;
using GameLibCommon.GameSrc.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.StateHandling
{
    internal class GameScreenContext
    {
        public GraphicsDevice GraphicsDevice { get; }
        public ContentManager ContentManager { get; }
        public ScreenSizeInformation ScreenSizeInformation { get; }

        public GameScreenContext(
            GraphicsDevice graphicsDevice, 
            ContentManager contentManager,
            ScreenSizeInformation screenSizeInformation)
        {
            GraphicsDevice = graphicsDevice;
            ContentManager = contentManager;
            ScreenSizeInformation = screenSizeInformation;

            ActivateState(new StateMainMenuGame(this));
        }

        IGameState _currentState;
        internal void ActivateState(IGameState state)
        {
            _currentState = state;
            _currentState.Start();
        }

        internal void Update(GameTime gameTime, InputInformation currentInputInfo)
        {
            _currentState.Update(gameTime, currentInputInfo);
        }

        internal void Draw(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            _currentState.Draw(gameTime, graphicsDevice);
        }
    }
}
