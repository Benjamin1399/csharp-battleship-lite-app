using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipLibrary.Models;

namespace BattleshipLibrary
{
    public static class GameLogic
    {

        public static void InitialiseGrid(UserModel userModel)
        {
            List<string> letters = new List<string>
            {
                "A",
                "B",
                "C",
                "D",
                "E"
            };

            List<int> numbers = new List<int>
            {
                1,
                2,
                3,
                5
            };

            foreach (string letter in letters)
            {
                foreach (int number in numbers)
                {
                    AddGridSpot(userModel, letter, number);
                }
            }
        }

        public static bool PlaceShip(UserModel userModel, string location)
        {
            throw new NotImplementedException();
        }

        private static void AddGridSpot(UserModel userModel, string letter, int number)
        {
            GridSpotModel spot = new GridSpotModel
            {
                GridLetter = letter,
                GridNumber = number,
                Status = GridStatus.Empty
            };

            userModel.LocationsShot.Add(spot);
        }


    }
}
