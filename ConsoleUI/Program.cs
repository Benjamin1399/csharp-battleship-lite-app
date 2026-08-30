using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleshipLibrary;
using BattleshipLibrary.Models;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            UserModel player1 = new UserModel();

            BattleshipOperations.WelcomeMessage();
            BattleshipOperations.SetupPlayerInfo(user, "Enter username for player 1: ");
            BattleshipOperations.SetupPlayerInfo(user, "Enter username for player 2: ");

        }
    }
}
