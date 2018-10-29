using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace OpenWeatherMap_API
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your API Key from Open Weather Map:");
            Console.WriteLine("(Please visit www.openweathermap.org to retrieve your API Key)");
            string api = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Which city would you like to see the weather for?");
            Console.WriteLine("(Please use number zip code for area)");
            string userResponse = Console.ReadLine();
            Console.Clear();
            GetWeather(int.Parse(userResponse), api);

            


            Console.ReadLine();
        }

        public static void GetWeather(int zip, string API)
        {
            WebClient webClient = new WebClient();
            string weatherJSON = webClient.DownloadString("http://api.openweathermap.org/data/2.5/weather?zip=" + zip + "&units=imperial&APPID=" + API);
            JObject jo = JObject.Parse(weatherJSON);
            double tempMath = double.Parse(jo.GetValue("main")["temp"].ToString());
            Console.WriteLine("The temperature in " + zip + " is " + tempMath);
        }
    }

}
