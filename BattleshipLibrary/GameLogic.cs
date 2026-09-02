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
            int shipIndex = 0;

            foreach (GridSpotModel spot in opponent.ShipLocations)
            {
                if (spot.GridLetter == row && spot.GridNumber == column)
                {
                    if (spot.Status == GridStatus.Populated)
                    {
                        opponent.ShipLocations[shipIndex].Status = GridStatus.Sunk;
                        return true;
                    }
                }

                shipIndex++;
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
            int spotIndex = 0;

            foreach (GridSpotModel spot in activePlayer.LocationsShot)
            {
                if (spot.GridLetter == row && spot.GridNumber == column)
                {
                    if (isAHit == true)
                    {
                        activePlayer.LocationsShot[spotIndex].Status = GridStatus.Hit;
                    }
                    else
                    {
                        activePlayer.LocationsShot[spotIndex].Status = GridStatus.Miss;
                    }
                }
                spotIndex++;
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


            
            throw new NotImplementedException();
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

        public static bool PlayerStillActive(UserModel opponent)
        {
            foreach (GridSpotModel spot in opponent.ShipLocations)
            {
                if (spot.Status == GridStatus.Populated)
                {
                    return true;
                }
            }

            return false;
        }

        public static (string row, int column) SplitShotIntoRowAndColumn(string shot)
        {

            string row = shot.Substring(0, 1);
            int.TryParse(shot.Substring(1, 1), out int column);

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
