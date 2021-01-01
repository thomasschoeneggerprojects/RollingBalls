using GameLibCommon.GameSrc;
using GameLibCommon.GameSrc.ConcreteGameObjects;
using GameLibCommon.GameSrc.ConcreteGameObjects.Builder;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GameLibCommon
{
    public class GameCommon : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private GameMediator _gameMediator;

        public GameCommon()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        private const int WALL_THICKNESS = 20;
        protected override void LoadContent()
        {
            var width = 1060;
            var height = 1700;

            GraphicsDevice.Viewport = new Viewport(0, 0, width, height);

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //_testtexture = this.Content.Load<Texture2D>("ellipse");
            
            var textureBall = this.Content.Load<Texture2D>("ballblue");
            
            Ball ball = new Ball();
            ball.Initialize(new Vector2(180, 150), new GameObjectItem(textureBall, new Vector2(0, 0)));

            var wallLeft = WallBuilder.Create()
                .SetSize(WALL_THICKNESS, height)
                .SetPosition(0, 0)
                .SetOrientation(ObjectOrientation.Vertical)
                .Build(this.Content);

            var wallRight = WallBuilder.Create()
                .SetSize(WALL_THICKNESS, height)
                .SetPosition(width - WALL_THICKNESS, 0)
                .SetOrientation(ObjectOrientation.Vertical)
                .Build(this.Content);

            var wallTop = WallBuilder.Create()
                .SetSize(height - WALL_THICKNESS - WALL_THICKNESS, WALL_THICKNESS)
                .SetPosition(WALL_THICKNESS, 0)
                .SetOrientation(ObjectOrientation.Horizontal)
                .Build(this.Content);

            var wallBottom = WallBuilder.Create()
                .SetSize(height - WALL_THICKNESS - WALL_THICKNESS, WALL_THICKNESS)
                .SetPosition(WALL_THICKNESS, height - WALL_THICKNESS)
                .SetOrientation(ObjectOrientation.Horizontal)
                .Build(this.Content);

            var wallvert1 = WallBuilder.Create()
                .SetSize(WALL_THICKNESS * 2, 500)
                .SetPosition(150, 200)
                .SetOrientation(ObjectOrientation.Vertical)
                .Build(this.Content);


            var wallvert2 = WallBuilder.Create()
                .SetSize(WALL_THICKNESS * 3, 500)
                .SetPosition(700, 400)
                .SetOrientation(ObjectOrientation.Vertical)
                .Build(this.Content);

            var wallhorizontal1 = WallBuilder.Create()
               .SetSize(300, WALL_THICKNESS * 1.5f)
               .SetPosition(300, 800)
               .SetOrientation(ObjectOrientation.Horizontal)
               .Build(this.Content);

            var wallhorizontal2 = WallBuilder.Create()
              .SetSize(300, WALL_THICKNESS * 1.5f)
              .SetPosition(400, 1200)
              .SetOrientation(ObjectOrientation.Horizontal)
              .Build(this.Content);

            Texture2D textureblck1 = this.Content.Load<Texture2D>("blockredgray"); ;
            Block block1 = new Block();
            block1.DirectionDegree = 90;
            block1.Width = 50;
            block1.Height = 50;
            block1.Initialize(new Vector2(600, 700), new GameObjectItem(textureblck1, new Vector2(0, 0)));

            _gameMediator = new GameMediator(width, height);
            _gameMediator.Set(ball, wallLeft, wallRight, wallTop, wallBottom, wallvert1, wallvert2, wallhorizontal1, wallhorizontal2, block1);

            //_gameMediator.Set(ball);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Wheat);

            // TODO: Add your drawing code here

            _gameMediator.Refresh(_spriteBatch);


            
            base.Draw(gameTime);
        }
    }
}
