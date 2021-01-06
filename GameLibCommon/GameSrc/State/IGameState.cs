using GameLibCommon.GameSrc.Input;
using GameLibCommon.GameSrc.StateHandling;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.State
{
    interface IGameState
    {
        public GameScreenContext Context { get;  }

        void GoBack();

        void Finish();

        void Start();

        void Update(GameTime gameTime, InputInformation inputInformation);

        void Draw(GameTime gameTime, GraphicsDevice graphicsDevice);

    }
}
