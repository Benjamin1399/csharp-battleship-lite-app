using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLibrary.Models
{
    public class Enums
    {
        public enum GridStatus
        {
            EMPTY,
            POPULATED,
            MISSED,
            HIT,
            SUNK
        }
    }
}
