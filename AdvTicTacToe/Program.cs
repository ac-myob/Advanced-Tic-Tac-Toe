using AdvTicTacToe.Game.Business.Controller;
using AdvTicTacToe.Game.Business.Controller.GameResource.Deserializer;
using AdvTicTacToe.Game.Business.Controller.GameResource.Serializer;
using AdvTicTacToe.Game.Business.Controller.GameSetup;
using AdvTicTacToe.Game.Business.View.IO;

var reader = new ConsoleReader();
var writer = new ConsoleWriter();

var gameEngine = new GameEngine(
    reader, 
    writer, 
    new GameSetupGeneric(reader, writer),
    new GameJsonSerializer(),
    new GameJsonDeserializer());
gameEngine.Run();

