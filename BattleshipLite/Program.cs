using BattleshipLibrary;
using BattleshipLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLite
{
    class Program
    {
        static void Main(string[] args)
        {
            WelcomeMessage();

            UserModel activePlayer = CreatePlayer("Player 1");
            UserModel opponent = CreatePlayer("Player 2");
            UserModel winner = null;

            do
            {
                DisplayShotGrid(activePlayer);

                RecordPlayerShot(activePlayer, opponent);

                bool doesGameContinue = GameLogic.PlayerStillActive(opponent);

                if (doesGameContinue == true)
                {
                    // Swap using a temp variable
                    /*UserModel tempHolder = opponent;
                    opponent = activePlayer;
                    activePlayer = tempHolder;*/

                    // Use tuple to swap
                    (activePlayer, opponent) = (opponent, activePlayer);
                }
                else
                {
                    winner = activePlayer;
                }
                
            } while (winner == null);

            IdentifyWinner(winner);

            Console.ReadLine();
        }

        private static void IdentifyWinner(UserModel winner)
        {
            Console.WriteLine($"Congratulations to {winner.UserName} for winning!");
            Console.WriteLine($"{winner.UserName} took {GameLogic.GetShotCount(winner)} shots.");
        }

        private static void RecordPlayerShot(UserModel activePlayer, UserModel opponent)
        {
            bool isValidShot = false;
            string row = "";
            int column = 0;

            do
            {
                string shot = AskForShot(activePlayer);
                (row, column) = GameLogic.SplitShotIntoRowAndColumn(shot);
                isValidShot = GameLogic.ValidateShot(activePlayer, row, column);

                if (isValidShot == false)
                {
                    Console.WriteLine("Invalid shot location. Please try again.");
                }

            } while (isValidShot == false);

            // Is spot chosen a hit or a miss
            bool isAHit = GameLogic.IdentifyShotResult(opponent, row, column);

            // Record results
            GameLogic.MarkShotResult(activePlayer, row, column, isAHit);
        }

        private static string AskForShot(UserModel activePlayer)
        {
            Console.Write($"{activePlayer.UserName}, please enter your shot: ");
            string output = Console.ReadLine();
            Console.Clear();

            return output;
        }

        private static void DisplayShotGrid(UserModel activePlayer)
        {
            string currentRow = activePlayer.LocationsShot[0].GridLetter;

            foreach (var gridSpot in activePlayer.LocationsShot)
            {
                if (gridSpot.GridLetter != currentRow)
                {
                    Console.WriteLine();
                    currentRow = gridSpot.GridLetter;
                }

                if (gridSpot.Status == GridStatus.Empty)
                {
                    Console.Write($" {gridSpot.GridLetter}{gridSpot.GridNumber} ");
                }
                else if (gridSpot.Status == GridStatus.Hit)
                {
                    Console.Write(" X ");
                }
                else if (gridSpot.Status == GridStatus.Miss)
                {
                    Console.Write(" O ");
                }
                else
                {
                    Console.Write(" ? ");
                }
            }
            Console.WriteLine();
        }

        private static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Battleship Lite");
            Console.WriteLine("Created by Tim Corey");
            Console.WriteLine();
        }

        private static UserModel CreatePlayer(string playerTitle)
        {
            UserModel output = new UserModel();

            Console.WriteLine($"Player information for {playerTitle}");

            // Ask user for name
            output.UserName = AskForUsersName();

            // Load up shot grid
            GameLogic.InitialiseGrid(output);

            // Ask the user for their 5 ship placements
            PlaceShips(output);

            // Clear
            Console.Clear();

            return output;
        }

        private static string AskForUsersName()
        {
            Console.Write("What is your name: ");
            string output = Console.ReadLine();

            return output;
        }

        private static void PlaceShips(UserModel userModel)
        {
            GridSpotModel spot = new GridSpotModel();

            do
            {
                Console.Write($"Where do you want to place ship number {userModel.ShipLocations.Count + 1 }: ");
                string location = Console.ReadLine();

                bool isValidLocation = GameLogic.PlaceShip(userModel, location);

                if (isValidLocation == false)
                {
                    Console.WriteLine("Invalid location, try again");
                }

            } while (userModel.ShipLocations.Count < 5);
        }
    }
}
