// See https://aka.ms/new-console-template for more information

using CleanCodeLabb;
using CleanCodeLabb.Interfaces;
using System.Security.Cryptography.X509Certificates;



IDAO myDAO = new FileDAO();
IGame myGame = new MooGame();
IUI myUI = new ConsoleUI();
GameController myController = new GameController(myUI, myGame, myDAO);

myController.Run();