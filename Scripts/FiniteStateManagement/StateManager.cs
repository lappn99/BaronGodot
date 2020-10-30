using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaronyGame.FSM
{
    public class StateManager
    {
        private Stack<IState> states;

        public Stack<IState> States { get => states; }

        public StateManager()
        {
            states = new Stack<IState>();
        }

        public void PushState<T>(T state) where T : IState
        {

            states.Push(state);
            states.Peek().Ready();
        }

        public void ChangeState<T>(T state) where T : IState
        {

            if (states.Count > 0)
            {
                PopState();
            }
            PushState(state);

        }


        public void NextTurn()
        {
            if (states.Count > 0)
            {
                states.Peek().NextTurn();
            }
        }

        public void PopState()
        {
            if (states.Count > 0)
            {
                states.Pop().Exit();
            }
        }





    }
}
