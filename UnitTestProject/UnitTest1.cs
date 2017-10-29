using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTotalPrice()
        {
            List<String> list = new List<String>();
            Assert.AreEqual(0, ritz.Service.getTotalPrice(list));

            String drink1 = "Coca Cola";
            int drink1Price = ritz.Service.getDrinkPrice(drink1);
            list.Add(drink1);
            Assert.AreEqual(drink1Price, ritz.Service.getTotalPrice(list));

            String drink2 = "Fanta";
            int drink2Price = ritz.Service.getDrinkPrice(drink2);
            list.Add(drink2);
            Assert.AreEqual((drink1Price + drink2Price), ritz.Service.getTotalPrice(list));

        }

        [TestMethod]
        public void TestBuyRoom()
        {
            List<String> list = new List<String>();
            list.Add("Coca Cola");
            list.Add("Fanta");
            int id = ritz.Service.getRoomNumbersAsInt()[0];
            String preSql = "SELECT count(*) FROM loungeBilling";
            ritz.Dal d = new ritz.Dal();
            SqlConnection con = d.getConnection();

            ritz.Service.executeQuery("SET TRANSACTION ISOLATION LEVEL READ COMMITTED ", con);
            ritz.Service.executeQuery("BEGIN TRANSACTION", con);
            int preCount = ritz.Service.executeQueryReturnInt(preSql, con);
            ritz.Service.buyRoom(list, id);
            int postCount = ritz.Service.executeQueryReturnInt("select count(*) FROM loungeBilling ", con);
            ritz.Service.executeQuery("ROLLBACK TRANSACTION", con);
            con.Close();
            Assert.AreEqual((preCount + list.Count), postCount);
        }
    }
}
