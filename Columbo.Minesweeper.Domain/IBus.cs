using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Columbo.Minesweeper.Domain
{
    public interface IBus
    {
        void send(ICommand command);
    }
}
