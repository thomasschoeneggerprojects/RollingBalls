using System;
using System.Collections.Generic;
using System.Text;
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

        private int _screenWidth;
        private int _screenHeight;

        public InnerExecutionState ExecutionState { get; set; }

        public void LoadContent(GraphicsDevice graphicsDevice, ContentManager contentManager, 
            ScreenDescription screenDescription)
        {
            ExecutionState = InnerExecutionState.INIT;

            _screenWidth = (int)screenDescription.ScreenSizeInformation.WidhtInnerScreen;
            _screenHeight = (int)screenDescription.ScreenSizeInformation.HeightInnerScreen;

            _spriteBatch = new SpriteBatch(graphicsDevice);

            _background = contentManager.Load<Texture2D>(screenDescription.AssetNameBackground);

            _font = contentManager.Load<SpriteFont>("Labels/LabelLarge");
        }

        private InputInformation _inputInformation;

        public void Update(GameTime gameTime, InputInformation inputInformation)
        {
            ExecutionState = InnerExecutionState.RUN;
            _inputInformation = inputInformation;
        }

        public void  Draw(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            graphicsDevice.Clear(Color.Wheat);

            _spriteBatch.Begin(SpriteSortMode.Immediate);

            _spriteBatch.Draw(_background, new Rectangle(1, 1, _screenWidth, _screenHeight), Color.White);

            DrawCentered(_spriteBatch, _screenWidth, _screenHeight, _inputInformation.Acceleration.X, _inputInformation.Acceleration.Y);

            _spriteBatch.End();
        }

        private void DrawCentered(SpriteBatch spriteBatch, int screenWidth, int screenHeight, float x, float y)
        {
            spriteBatch.DrawString(_font, $"Touch to start {x}/{y}", new Vector2(0, screenHeight/3*2), Color.Black);
        }

    }
}
