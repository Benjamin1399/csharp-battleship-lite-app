using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLibrary.Models
{
    public enum Status
    {
        EMPTY,
        POPULATED,
        MISSED,
        HIT
    }

    public class GridSpotModel
    {
        public string GridLetter { get; set; }

        public int GridNumber { get; set; }

        public Status GridStatus { get; set; }
    }
}
