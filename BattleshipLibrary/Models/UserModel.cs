using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLibrary.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        
        public List<GridSpotModel> ShipLocations { get; set; }  = new List<GridSpotModel>();

        public List<GridSpotModel> LocationsShot { get; set; } = new List<GridSpotModel>();

    }
}
