using System;
using System.Collections.Generic;
using System.Text;
using GameLibCommon.GameSrc.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameLibCommon.GameSrc.Menue.Screens
{
    public class MainMenue : BaseGameScreen
    {
        private SpriteBatch _spriteBatch;

        private Texture2D _backgroundMain;
        private SpriteFont _font;

        private int _screenWidth;
        private int _screenHeight;

        private const int WALL_THICKNESS = 20;
        internal override void LoadContent(GraphicsDevice graphicsDevice, ContentManager contentManager)
        {
            _screenWidth = graphicsDevice.Viewport.Width;
            _screenHeight = graphicsDevice.Viewport.Height;

            graphicsDevice.Viewport = new Viewport(0, 0, _screenWidth, _screenHeight);

            _spriteBatch = new SpriteBatch(graphicsDevice);

            _backgroundMain = contentManager.Load<Texture2D>("RollingBallsMainScreen");

            _font = contentManager.Load<SpriteFont>("Labels/LabelLarge");

        }

        private InputInformation _inputInformation;
        internal override void Update(GameTime gameTime, InputInformation inputInformation)
        {
            _inputInformation = inputInformation;
        }

        internal override void Draw(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            graphicsDevice.Clear(Color.Wheat);

            _spriteBatch.Begin(SpriteSortMode.Immediate);

            _spriteBatch.Draw(_backgroundMain, new Rectangle(1, 1, _screenWidth, _screenHeight), Color.White);

            DrawCentered(_spriteBatch, _screenWidth, _screenHeight, _inputInformation.Acceleration.X, _inputInformation.Acceleration.Y);

            _spriteBatch.End();
        }

        private void DrawCentered(SpriteBatch spriteBatch, int screenWidth, int screenHeight, float x, float y)
        {
            spriteBatch.DrawString(_font, $"Touch Screen to start {x}/{y}", new Vector2(100, screenHeight/3*2), Color.Black);
        }
    }
}
