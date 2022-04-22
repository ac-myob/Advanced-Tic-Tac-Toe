using AdvTicTacToe.Game.Business.Model;
using Newtonsoft.Json;

namespace AdvTicTacToe.Game.Business.Controller.GameResource.Serializer;

public class GameJsonSerializer : IGameSerializer
{
    public void ToFile(GameState gameState, string filepath)
    {
        var jsonString = JsonConvert.SerializeObject(
            gameState, 
            Formatting.Indented,
            new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });
        
        File.WriteAllText(filepath, jsonString);
    }
}