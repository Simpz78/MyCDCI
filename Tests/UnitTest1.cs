using System;
using System.Data.SqlClient;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test()
        {
            string testString = "test";

            Assert.AreEqual("test", testString);
        }

        [TestMethod]
        public void TestGetConnectionString()
        {
            TestCDCI.Class c = new TestCDCI.Class();
            string testString = c.ConnectionString;

            Assert.AreEqual("Server=localhost;Database=sdi;User ID=studioboost;Password=studioboost", testString);
        }

        [TestMethod]
        public void TestConnection()
        {
            TestCDCI.Class c = new TestCDCI.Class();
            string testString = c.ConnectionString;

            using (SqlConnection conn = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=master;Trusted_Connection=True"))
            {
                conn.Open();
                Assert.AreEqual(System.Data.ConnectionState.Open, conn.State);
            }
        }

        public void BuildDb()
        {
            using (SqlConnection conn = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=master;Trusted_Connection=True"))
            {
                conn.Open();
                string script = File.ReadAllText(@"TestCDCI\Tests\CreateDB.sql");

                using (SqlCommand command = new SqlCommand(script, conn))
                {
                    int a = command.ExecuteNonQuery();
                    Assert.IsTrue(a > -1);
                    Assert.IsTrue(a > 0);
                }
            }
        }
    }
}
