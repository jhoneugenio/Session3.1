using DemoLearning3.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using Session3._1.DataModels;
using Session3._1.Resources;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Session3._1.Tests
{
    [TestClass]
    public class Homework4Tests : ApiBaseTest
    {
        private static List<PetModel> petCleanUpList = new List<PetModel>();

        [TestInitialize]
        public async Task TestInitialize()
        {
            PetDetails = await PetHelper.AddNewPet(RestClient);
        }

        [TestMethod]
        public async Task DemoGetPet()
        {
            //Arrange
            var demoGetRequest = new RestRequest(Endpoints.GetPetById(PetDetails.Id));
            petCleanUpList.Add(PetDetails);

            //Act
            var demoResponse = await RestClient.ExecuteGetAsync<PetModel>(demoGetRequest);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, demoResponse.StatusCode, "Failed due to wrong status code.");
            Assert.AreEqual(PetDetails.Id, demoResponse.Data.Id, "Id did not match.");
            Assert.AreEqual(PetDetails.Category.Id, demoResponse.Data.Category.Id, "Category Id did not match.");
            Assert.AreEqual(PetDetails.Category.Name, demoResponse.Data.Category.Name, "Category Name did not match.");
            Assert.AreEqual(PetDetails.Name, demoResponse.Data.Name, "Name did not match.");
            Assert.AreEqual(PetDetails.PhotoUrls[0], demoResponse.Data.PhotoUrls[0], "PhotoUrls did not match.");
            Assert.AreEqual(PetDetails.Tags[0].Id, demoResponse.Data.Tags[0].Id, "Tags Id did not match.");
            Assert.AreEqual(PetDetails.Tags[0].Name, demoResponse.Data.Tags[0].Name, "Tags Name did not match.");
            Assert.AreEqual(PetDetails.Status, demoResponse.Data.Status, "Status did not match.");
        }

        [TestCleanup]
        public async Task TestCleanUp()
        {
            foreach (var data in petCleanUpList)
            {
                var deletePetRequest = new RestRequest(Endpoints.GetPetById(data.Id));
                var deletePetResponse = await RestClient.DeleteAsync(deletePetRequest);
            }
        }
    }
}
