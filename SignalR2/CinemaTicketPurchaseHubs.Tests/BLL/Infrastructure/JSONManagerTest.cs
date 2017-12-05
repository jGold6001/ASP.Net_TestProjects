using CinemaTicketPurchaseHubs.BLL.Infrastructure;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CinemaTicketPurchaseHubs.BLL.Infrastructure.Tests
{
    [TestClass()]
    public class JSONManagerTest
    {
        JSONManager jManager = new JSONManager(@"F:\ITstep\Subjects\Diplom\ASP.Net_TestProjects\SignalR2\CinemaTicketPurchaseHubs\Resources\Json\mpx_skymall.json");

        [TestMethod()]
        public void TestCoinvertToDictionary()
        {
            var data = jManager.CoinvertToDictionary();



        }
    }
}

