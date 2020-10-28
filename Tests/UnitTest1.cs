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


            using (SqlConnection conn = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=testDB;Trusted_Connection=True"))
            {
                conn.Open();
                Assert.AreEqual(System.Data.ConnectionState.Open, conn.State);
            }
        }

        [TestMethod]
        public void BuildDb()
        {
            TestCDCI.Class c = new TestCDCI.Class();
            string testString = c.ConnectionString;

            using (SqlConnection conn = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB;Database=testDB;Trusted_Connection=True"))
            //using (SqlConnection conn = new SqlConnection(testString))
            {

                conn.Open();
                string script = File.ReadAllText(@"D:\a\MyCDCI\MyCDCI\Tests\CreateDB.sql");
                //string script = File.ReadAllText(@"C:\Progetti_VS\2017\TestCDCI_GITHUB\Tests\CreateDB.sql");
                script = script.Replace("\r\n", Environment.NewLine);

                using (SqlCommand command = new SqlCommand(script, conn))
                {
                    int a = command.ExecuteNonQuery();
                    //è -1 bisogna fare una select o una insert
                }

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = "SELECT * FROM FT";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Assert.AreEqual("1.zip", reader["NomeFile"].ToString());
                            Assert.AreEqual(1, int.Parse(reader["ID"].ToString()));
                        }

                    }
                    //è -1 bisogna fare una select o una insert
                }
            }
        }

        [TestMethod]
        public void IntToStringEnum()
        {
            string test = "1";

            FinalMoreScore f = (FinalMoreScore)Enum.Parse(typeof(FinalMoreScore), test);

            Assert.AreEqual("D", f.ToString());

            

        }


    }
}
