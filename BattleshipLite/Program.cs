using BattleshipLibrary;
using BattleshipLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLite
{
    class Program
    {
        static void Main(string[] args)
        {
            WelcomeMessage();

            UserModel model1 = CreatePlayer("Player 1");
            UserModel model2 = CreatePlayer("Player 2");
            UserModel winner = new UserModel();

            winner = PlayGame(model1, model2);

            CelebrateWinner(winner);


            Console.ReadLine();
        }

        private static void CelebrateWinner(UserModel winner)
        {
            Console.WriteLine("HOORAY!!!");
            Console.WriteLine($"Winner is {winner.UserName}");
            Console.WriteLine($"Took {winner.LocationsShot.Count} shots");
        }

        private static UserModel PlayGame(UserModel model1, UserModel model2)
        {
            bool gameWon = false;
            UserModel winner = new UserModel();

            do
            {
                TakeTurn(model1, model2);
                gameWon = CheckPlayerWon(model1, model2);

                if (gameWon == false)
                {
                    TakeTurn(model2, model1);
                    gameWon = CheckPlayerWon(model2, model1);
                    if (gameWon == true)
                    {
                        winner = model2;
                    }
                }
                else
                {
                    winner = model1;
                }

            } while (gameWon == false);

            return winner;
        }

        private static bool CheckPlayerWon(UserModel userModel, UserModel opponentModel)
        {
            throw new NotImplementedException();
        }

        private static void TakeTurn(UserModel attackerModel, UserModel defenderModel)
        {
            DisplayGrid(attackerModel);
            FireShot(attackerModel, defenderModel);
            DisplayScore(attackerModel, defenderModel);
        }

        private static void DisplayScore(UserModel attackerModel, UserModel defenderModel)
        {
            throw new NotImplementedException();
        }

        private static void FireShot(UserModel model1, UserModel model2)
        {
            bool isValidShot;

            do
            {
                Console.Write("Enter spot to fire on: ");
                string location = Console.ReadLine();

                isValidShot = GameLogic.StoreShot(model1, model2, location);

            } while (isValidShot == false);

            throw new NotImplementedException();
        }

        private static void DisplayGrid(UserModel model1)
        {
            throw new NotImplementedException();
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
