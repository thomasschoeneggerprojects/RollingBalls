using GameLibCommon.GameSrc.Screen;
using GameLibCommon.GameSrc.Screen.GameScreens.SubScreens;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.State
{
    internal class GameScreenExecutionProvider
    {
        internal static IGameScreenExecution CreateGameScreenExecution(GraphicsDevice graphicsDevice, 
            ContentManager contentManager, ScreenDescription screenDescription) 
        {
            IGameScreenExecution execution = null;

            if (screenDescription.Id.Equals(WellKnownGameScreenExecutions.MENUE_MAIN_SCREEN))
            {
                var item = new MainMenue();
                var screen = GlobalScreenDescriptionCreator
                    .CreateMainScreen(screenDescription.ScreenSizeInformation);
                item.LoadContent(graphicsDevice, contentManager, screen);
                return item;
            }
            else if (screenDescription.Id.Equals(WellKnownGameScreenExecutions.RUNNING_GAME_BALANCE_SCREEN))
            {
                var item = new BallBallanceLevel();
                var screen = GlobalScreenDescriptionCreator
                    .CreateTestLevelScreen(screenDescription.ScreenSizeInformation);
                item.LoadContent(graphicsDevice, contentManager, screen);
                return item;
            }

            return execution;
        }

    }
}
