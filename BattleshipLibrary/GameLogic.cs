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
        public static int GetShotCount(UserModel winner)
        {
            int shotsTaken = 0;

            foreach (GridSpotModel spot in winner.LocationsShot)
            {
                if (spot.Status == GridStatus.Miss || spot.Status == GridStatus.Hit)
                {
                    shotsTaken++;
                }
            }

            return shotsTaken;
        }

        public static bool IdentifyShotResult(UserModel opponent, string row, int column)
        {
            foreach (GridSpotModel spot in opponent.ShipLocations)
            {
                if (spot.GridLetter == row && spot.GridNumber == column)
                {
                    if (spot.Status == GridStatus.Populated)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

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

        public static void MarkShotResult(UserModel activePlayer, string row, int column, bool isAHit)
        {
            throw new NotImplementedException();
        }

        public static bool PlaceShip(UserModel userModel, string location)
        {
            throw new NotImplementedException();
        }

        public static bool PlayerStillActive(UserModel opponent)
        {
            throw new NotImplementedException();
        }

        public static (string row, int column) SplitShotIntoRowAndColumn(string shot)
        {
            throw new NotImplementedException();
        }

        public static bool ValidateShot(UserModel activePlayer, string row, int column)
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
