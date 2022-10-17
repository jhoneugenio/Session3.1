using RestSharp;
using Session3._1.DataModels;
using Session3._1.Resources;
using Session3._1.Tests.TestData;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DemoLearning3.Helpers
{
    /// <summary>
    /// Demo class containing all methods for pets
    /// </summary>
    public class PetHelper
    {
        /// <summary>
        /// Send POST request to add new pet
        /// </summary>
        ///

        public static async Task<PetModel> AddNewPet(RestClient client)
        {
            var newPetData = GeneratePet.demoPet();
            var postRequest = new RestRequest(Endpoints.PostPet());

            //Send Post Request to add new pet
            postRequest.AddJsonBody(newPetData);
            var postResponse = await client.ExecutePostAsync<PetModel>(postRequest);

            var createdPetData = newPetData;
            return createdPetData;
        }
    }
}
