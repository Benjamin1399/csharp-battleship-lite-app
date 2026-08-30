using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLibrary.Models
{
    public enum GridStatus
    {
        EMPTY,
        POPULATED,
        MISSED,
        HIT,
        SUNK
    }

    public class GridSpotModel
    {
        public string GridLetter { get; set; }

        public int GridNumber { get; set; }

        public GridStatus Status { get; set; }
    }
}
