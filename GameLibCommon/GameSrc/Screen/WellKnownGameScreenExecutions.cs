using GameLibCommon.GameSrc.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.Screen
{
    internal static class WellKnownGameScreenExecutions
    {
        public static readonly GameScreenExecutionId MENUE_MAIN_SCREEN = new GameScreenExecutionId(Guid.Parse("038f6110-27dc-4ab3-8a1d-a1da7ec27118"));

        public static readonly GameScreenExecutionId MENUE_CONFIGURATION_SCREEN = new GameScreenExecutionId(Guid.Parse("c8781bf8-5f27-49ef-957f-c1635c7bdf50"));

        public static readonly GameScreenExecutionId STARTING_GAME_SCREEN = new GameScreenExecutionId(Guid.Parse("d4ed3114-78d1-4e4e-989e-00671e1298de"));

        public static readonly GameScreenExecutionId RUNNING_GAME_BALANCE_SCREEN = new GameScreenExecutionId(Guid.Parse("d9dc65c7-e036-46a7-bf25-f493f1b84f31"));

        public static readonly GameScreenExecutionId RUNNING_GAME_LABYRINTH_SCREEN = new GameScreenExecutionId(Guid.Parse("5fc4afcf-5fe9-4aa7-a939-681e8af9656a"));
        
        public static readonly GameScreenExecutionId SHOW_GAME_STATISTIC_SCREEN = new GameScreenExecutionId(Guid.Parse("ec10619f-8a9c-4e9a-97a5-c375b1dbf5e4"));
        
        public static readonly GameScreenExecutionId SHOW_GAME_STATISTIC_HISTORY_SCREEN = new GameScreenExecutionId(Guid.Parse("69b55b6a-f3e9-4b77-b4c0-e01f27a8cbab"));

    }
}
