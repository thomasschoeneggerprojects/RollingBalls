using GameLibCommon.GameSrc.Game.GameScreens;
using GameLibCommon.GameSrc.Input;
using GameLibCommon.GameSrc.Screen;
using GameLibCommon.GameSrc.StateHandling;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.State
{
    internal class StateMainMenuGame : IGameState
    {
        public StateMainMenuGame(GameScreenContext context)
        {
            Context = context;
        }

        public GameScreenContext Context { get; }

        IGameScreenSequenceExecution _gameScreenSequenceExecution;

        public void GoBack()
        {
            // Got to Exit State.
        }

        public void Finish()
        {
           
        }

        public void Start()
        {
            _gameScreenSequenceExecution = new MainMenuSequence();

            var screenDesc = GlobalScreenDescriptionCreator.CreateMainScreen(Context.ScreenSizeInformation);
            var screenSequence = ScreenSequenceDescription.Create(screenDesc);

            _gameScreenSequenceExecution.LoadContent(Context.GraphicsDevice, Context.ContentManager, screenSequence);
        }
        bool _isInGame = false;
        public void Update(GameTime gameTime, InputInformation inputInformation)
        {
            if (inputInformation.ScreenTouched && !_isInGame)
            {
                Context.ActivateState(new StateExecuteGame(Context));
            }

            _gameScreenSequenceExecution.Update(gameTime, inputInformation);
        }

        public void Draw(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            _gameScreenSequenceExecution.Draw(gameTime, graphicsDevice);
        }
    }
}
