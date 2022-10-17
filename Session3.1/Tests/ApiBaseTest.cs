using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Session3._1.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Session3._1.Tests
{
    public class ApiBaseTest
    {
        public RestClient RestClient { get; set; }
        public PetModel PetDetails { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            RestClient = new RestClient();
        }

        [TestCleanup]
        public void CleanUp()
        { 
        
        }
    }
}
