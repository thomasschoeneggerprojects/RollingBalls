using GameLibCommon.GameSrc.State;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibCommon.GameSrc.StateHandling
{
    internal class GameScreenContext
    {
        public GameScreenContext(IGameState state)
        {
            ActivateState(state);
        }

        IGameState _currentState;
        internal void ActivateState(IGameState state)
        {
            _currentState = state;
        }
    }
}
