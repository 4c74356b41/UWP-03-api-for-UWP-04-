﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WeatherApi.Models
{
    public class OWM_City_Forecast_Facade
    {
        public async static Task<RootObjectForecastCity> GetWeatherCityForecast(string city)
        {
            var http = new HttpClient();
            http.Timeout = TimeSpan.FromMilliseconds(15000);
            var url = String.Format("http://api.openweathermap.org/data/2.5/weather?id={0}&appid=5cac47538f90d19879ecaa7c8c7fab67&units=metric", city);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObjectForecastCity));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObjectForecastCity)serializer.ReadObject(ms);

            return data;
        }
        [DataContract]
        public class Coord
        {
            [DataMember]
            public double lon { get; set; }
            [DataMember]
            public double lat { get; set; }
        }
        [DataContract]
        public class Weather
        {
            [DataMember]
            public int id { get; set; }
            [DataMember]
            public string main { get; set; }
            [DataMember]
            public string description { get; set; }
            [DataMember]
            public string icon { get; set; }
        }
        [DataContract]
        public class Main
        {
            [DataMember]
            public double temp { get; set; }
            [DataMember]
            public double pressure { get; set; }
            [DataMember]
            public int humidity { get; set; }
            [DataMember]
            public double temp_min { get; set; }
            [DataMember]
            public double temp_max { get; set; }
            [DataMember]
            public double sea_level { get; set; }
            [DataMember]
            public double grnd_level { get; set; }
        }
        [DataContract]
        public class Wind
        {
            [DataMember]
            public double speed { get; set; }
            [DataMember]
            public double deg { get; set; }
        }
        [DataContract]
        public class Clouds
        {
            [DataMember]
            public int all { get; set; }
        }
        [DataContract]
        public class Sys
        {
            [DataMember]
            public double message { get; set; }
            [DataMember]
            public string country { get; set; }
            [DataMember]
            public int sunrise { get; set; }
            [DataMember]
            public int sunset { get; set; }
        }
        [DataContract]
        public class RootObjectForecastCity
        {
            [DataMember]
            public Coord coord { get; set; }
            [DataMember]
            public List<Weather> weather { get; set; }
            [DataMember]
            public string @base { get; set; }
            [DataMember]
            public Main main { get; set; }
            [DataMember]
            public Wind wind { get; set; }
            [DataMember]
            public Clouds clouds { get; set; }
            [DataMember]
            public int dt { get; set; }
            [DataMember]
            public Sys sys { get; set; }
            [DataMember]
            public int id { get; set; }
            [DataMember]
            public string name { get; set; }
            [DataMember]
            public int cod { get; set; }
        }

    }
}