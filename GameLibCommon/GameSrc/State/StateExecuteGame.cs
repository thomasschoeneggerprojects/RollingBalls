using GameLibCommon.GameSrc.StateHandling;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.State
{
    internal class StateExecuteGame : IGameState
    {
        public StateExecuteGame(GameScreenContext context)
        {
            Context = context;
        }

        public GameScreenContext Context { get; }

        IGameScreenSequenceExecution _gameScreenSequenceExecution;

        public void Execute(IGameScreenSequenceExecution gameScreenSequenceExecution)
        {
            throw new NotImplementedException();
        }

        public void GoBack()
        {
            throw new NotImplementedException();
        }
    }
}
