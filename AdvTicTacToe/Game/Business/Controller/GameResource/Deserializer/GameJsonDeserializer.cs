using AdvTicTacToe.Game.Business.Model;
using Newtonsoft.Json;

namespace AdvTicTacToe.Game.Business.Controller.GameResource.Deserializer;

public class GameJsonDeserializer : IGameDeserializer
{
    public GameState FromFile(string filepath)
    {
        var jsonString = File.ReadAllText(filepath);
        
        return JsonConvert.DeserializeObject<GameState>(
            jsonString,
            new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            })!;
    }
}