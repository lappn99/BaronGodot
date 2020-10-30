using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BaronyGame.FSM
{
    public interface IState
    {

        void Ready();
        void NextTurn();
        void Exit();

    }
}

