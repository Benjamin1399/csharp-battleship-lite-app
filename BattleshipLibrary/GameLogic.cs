using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
                        spot.Status = GridStatus.Sunk;
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
                4,
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
            foreach (GridSpotModel spot in activePlayer.LocationsShot)
            {
                if (spot.GridLetter == row && spot.GridNumber == column)
                {
                    if (isAHit == true)
                    {
                        spot.Status = GridStatus.Hit;
                    }
                    else
                    {
                        spot.Status = GridStatus.Miss;
                    }
                }
            }
        }

        public static bool PlaceShip(UserModel userModel, string location)
        {
            GridSpotModel chosenSpot = new GridSpotModel();

            (string row, int column) = SplitShotIntoRowAndColumn(location);


            bool locationValid = ValidateLocationToPlaceShip(userModel, row, column);

            if (locationValid == true)
            {
                chosenSpot.GridLetter = row;
                chosenSpot.GridNumber = column;
                chosenSpot.Status = GridStatus.Populated;
                userModel.ShipLocations.Add(chosenSpot);
                return true;
            }
            else
            {
                return false;
            }

        }

        private static bool ValidateLocationToPlaceShip(UserModel userModel, string row, int column)
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
                4,
                5
            };

            foreach (GridSpotModel spot in userModel.ShipLocations)
            {
                if (spot.GridLetter == row && spot.GridNumber == column)
                {
                    if (spot.Status == GridStatus.Populated)
                    {
                        return false;
                    }
                }
            }

            if (letters.Contains(row) == true && numbers.Contains(column) == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool PlayerStillActive(UserModel player)
        {
            foreach (GridSpotModel ship in player.ShipLocations)
            {
                if (ship.Status == GridStatus.Populated)
                {
                    return true;
                }
            }

            return false;
        }

        public static (string row, int column) SplitShotIntoRowAndColumn(string shot)
        {
            string row = "";
            int column = 0;
         
            if (shot.Length != 2)
            {
                throw new ArgumentException("This was an invalid shot type", shot);
            }

            char[] shotArray = shot.ToArray();
            row = shotArray[0].ToString();

            bool isColumnValid = int.TryParse(shot.Substring(1, 1), out column);

            if (isColumnValid == false)
            {
                throw new ArgumentException("This was an invalid shot type", shot);
            }

            return (row, column);
        }

        public static bool ValidateShot(UserModel activePlayer, string row, int column)
        {
            foreach (GridSpotModel spot in activePlayer.LocationsShot)
            {
                if (spot.GridLetter == row && spot.GridNumber == column)
                {
                    if (spot.Status != GridStatus.Empty)
                    {
                        return false;
                    }
                }
            }

            return true;
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
