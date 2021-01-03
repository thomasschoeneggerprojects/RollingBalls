using GameLibCommon.GameSrc.StateHandling;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.State
{
    interface IGameState
    {
        public GameScreenContext Context { get;  }

        void GoBack();

        void Execute(IGameScreenExecution gameScreenExecution);

    }
}
