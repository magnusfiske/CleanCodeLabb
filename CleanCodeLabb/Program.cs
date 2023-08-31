// See https://aka.ms/new-console-template for more information

using CleanCodeLabb;
using CleanCodeLabb.Interfaces;
using CleanCodeLabb.GameLogic;
using CleanCodeLabb.IO;



IIO io = new ioHandler();
IGame game = new GuessingGame();
IUI ui = new ConsoleUI();
GameController controller = new GameController(ui, game, io);

 controller.Run();