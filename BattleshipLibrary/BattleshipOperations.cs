using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipLibrary.Models;

namespace BattleshipLibrary
{
    public static class BattleshipOperations
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to the Battleship Lite App");
            Console.WriteLine("**********************************");
        }

        public static string GetUserName(string message)
        {
            throw new NotImplementedException();
        }

        public static string GetGridLetter(string message)
        {
            throw new NotImplementedException();
        }

        public static int GetGridNumber(string message)
        {
            throw new NotImplementedException();
        }

        public static int GetIntFromUser(string message)
        {
            throw new NotImplementedException();
        }


        public static void StoreUserName(UserModel user, string userName)
        {
            throw new NotImplementedException();
        }

        public static void GetShipPlacements(UserModel user)
        {
            throw new NotImplementedException();
        }

        public static bool IsStoreSpotValid(UserModel user, string gridLetter, int gridNumber)
        {
            throw new NotImplementedException();
        }

        public static void StoreShip(UserModel user, string gridLetter, int gridNumber)
        {
            throw new NotImplementedException();
        }

        public static void StoreShot(UserModel user, string gridLetter, int gridNumber)
        {
            throw new NotImplementedException();
        }

        public static void CreateStoredShipGrid(UserModel user)
        {
            throw new NotImplementedException();
        }

        public static void CreateShotShipGrid(UserModel user)
        {
            throw new NotImplementedException();
        }

        public static void DisplayStoredShipGrid(UserModel user)
        {
            throw new NotImplementedException();
        }

        public static void DisplayShotShipGrid(UserModel user)
        {
            throw new NotImplementedException();
        }

        public static void FireOnSpot(UserModel user, string gridLetter, int gridNumber)
        {
            throw new NotImplementedException();
        }

        public static void ValidateShot(UserModel user, string gridLetter, int gridNumber)
        {
            throw new NotImplementedException();
        }

        public static void ResultOfShot(UserModel user, string gridLetter, int gridNumber)
        {
            throw new NotImplementedException();
        }

        public static void DisplayScore(UserModel user)
        {
            throw new NotImplementedException();
        }

        public static void DetermineWinner(UserModel user)
        {
            throw new NotImplementedException();
        }

        public static void DisplayStats(UserModel user)
        {
            throw new NotImplementedException();
        }

        public static void SetupPlayerInfo(UserModel user, string message)
        {
            string userName = GetUserName(message);
            GetShipPlacements(user);
        }
    }
}
