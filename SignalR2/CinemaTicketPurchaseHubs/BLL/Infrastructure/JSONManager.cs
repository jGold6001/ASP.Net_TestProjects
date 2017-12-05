using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTicketPurchaseHubs.BLL.Infrastructure
{
    public class JSONManager
    {
        public string Path { get; private set; }
        public JSONManager(string path)
        {
            Path = path;
        }

        public Dictionary<int, int> CoinvertToDictionary()
        {
            return JsonConvert.DeserializeObject<Dictionary<int, int>>(Path);
        }
    }
}