// See https://aka.ms/new-console-template for more information

using CleanCodeLabb;
using CleanCodeLabb.Interfaces;



IIO io = new FileIO();
//IIO io = new MongoIO("mongodb+srv://magnusfiske:supersecretPassWord@clusterfiske.8tkqxzs.mongodb.net/?retryWrites=true&w=majority", "GameResults");
IGame game = new GuessingGame();
IUI ui = new ConsoleUI();
GameController controller = new GameController(ui, game, io);

 controller.Run();