
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _24._06
{
  class Program
  {
    static private Url url = new Url("https://NasaAPIdimasV1.p.rapidapi.com/getAsteroids");
    static private List<Asteroid> asteroids = new List<Asteroid>();

    static void Main(string[] args)
    {
      var result = Asteroid();
      result.Start();
    }
    static Task Asteroid()
    {
      string aster = "";
      using (var client = new WebClient())
      {
        using (Stream stream = client.OpenRead(url.Value))
        {
          using (StreamReader reader = new StreamReader(stream))
          {
            string line = "";
            while ((line = reader.ReadLine()) != null)
            {
              aster += line;
            }
          }
        }
      }
      asteroids = JsonConvert.DeserializeObject<List<Asteroid>>(aster);

      foreach (var asteroid in asteroids)
      {
        Console.WriteLine($"Инфо об астироиде");
        Console.WriteLine($"Имя {asteroid.Name}");
        Console.WriteLine($"Местоположение {asteroid.Location}");
      }
      return Task.CompletedTask;
    }
  }
}
