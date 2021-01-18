using System;
using System.Collections.Generic;
using System.Text;
using GameLibCommon.GameSrc.Controls;
using GameLibCommon.GameSrc.Input;
using GameLibCommon.GameSrc.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameLibCommon.GameSrc.Screen
{
    internal class MainMenue : IGameScreenExecution
    {
        private SpriteBatch _spriteBatch;

        private Texture2D _background;
        private SpriteFont _font;
        private Texture2D _button;
        private ScreenSizeInformation _screenSizeInformation;
        private int _screenHeight;

        private Button _BtnStart;
        private Button _BtnEdit;
        private Button _BtnStatistic;
        private Button _BtnMultiplayer;

        public InnerExecutionState ExecutionState { get; set; }

        public void LoadContent(GraphicsDevice graphicsDevice, ContentManager contentManager, 
            ScreenDescription screenDescription)
        {
            ExecutionState = InnerExecutionState.INIT;

            _screenSizeInformation = screenDescription.ScreenSizeInformation;

            _spriteBatch = new SpriteBatch(graphicsDevice);

            _background = contentManager.Load<Texture2D>(screenDescription.AssetNameBackground);

            _font = contentManager.Load<SpriteFont>("Labels/LabelLarge");

            // Pos Buttons
            var buttonspace = 10;
            var buttonWidth = (_screenSizeInformation.WidhtOuterScreen - 3 * buttonspace) / 2;
            var buttonHeigth = (_screenSizeInformation.HeightOuterScreen/2 - 2 * buttonspace) / 2;

            _button = contentManager.Load<Texture2D>("RoundRectangle");

            _BtnStart = Button.Create(buttonspace, _screenSizeInformation.HeightOuterScreen/2, buttonWidth, buttonHeigth);
            _BtnMultiplayer = Button.Create(buttonspace, _screenSizeInformation.HeightOuterScreen/ 2 + buttonHeigth + buttonspace, buttonWidth, buttonHeigth);
            _BtnEdit = Button.Create(buttonspace + buttonWidth + buttonspace, _screenSizeInformation.HeightOuterScreen / 2, buttonWidth, buttonHeigth);
            _BtnStatistic= Button.Create(buttonspace + buttonWidth + buttonspace, _screenSizeInformation.HeightOuterScreen / 2 + buttonHeigth, buttonWidth, buttonHeigth);
        }

        private InputInformation _inputInformation;

        public void Update(GameTime gameTime, InputInformation inputInformation)
        {
            ExecutionState = InnerExecutionState.RUN;
            _inputInformation = inputInformation;
        }

        public void Draw(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            _spriteBatch.Begin(SpriteSortMode.Immediate);

            _spriteBatch.Draw(_background, new Rectangle(0, 0, (int)_screenSizeInformation.WidhtOuterScreen, (int)_screenSizeInformation.HeightOuterScreen), Color.White);

            DrawButtons(_spriteBatch, (int)_screenSizeInformation.WidhtOuterScreen, (int)_screenSizeInformation.HeightOuterScreen,
                _inputInformation.Acceleration.X, _inputInformation.Acceleration.Y);

            _spriteBatch.End();
        }

        private void DrawButtons(SpriteBatch spriteBatch, int screenWidth, int screenHeight, float x, float y)
        {
            _spriteBatch.Draw(_button, _BtnStart.Bounds, Color.White);
            _spriteBatch.Draw(_button, _BtnMultiplayer.Bounds, Color.White);
            _spriteBatch.Draw(_button, _BtnEdit.Bounds, Color.White);
            _spriteBatch.Draw(_button, _BtnStatistic.Bounds, Color.White);

            spriteBatch.DrawString(_font, $"Start", _BtnStart.Position, Color.Black);
        }
    }
}
