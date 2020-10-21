using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TestCDCI
{
    public class Class
    {
        public string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["sqlConnectionString"].ConnectionString;

        public void Method()
        {  }
    }
}