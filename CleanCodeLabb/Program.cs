// See https://aka.ms/new-console-template for more information

using CleanCodeLabb;
using CleanCodeLabb.Interfaces;
using System.Security.Cryptography.X509Certificates;



IIO myIo = new FileIO();
IGame myGame = new GuessingGame();
IUI myUI = new ConsoleUI();
GameController myController = new GameController(myUI, myGame, myIo);

myController.Run();