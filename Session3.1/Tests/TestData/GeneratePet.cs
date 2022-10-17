using Session3._1.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Session3._1.Tests.TestData
{
    public class GeneratePet 
    {
        public static PetModel demoPet()
        {
            //Create Pet
            var categoryName = "Cat";
            var petName = "Maven";
            var tagName = "Cute";
            var newStatus = "available";

            Category newCategory = new Category()
            {
                Id = 6969,
                Name = categoryName
            };

            Category tempTag = new Category()
            {
                Id = 7070,
                Name = tagName
            };

            Category[] newTag = { tempTag };
            return new PetModel
            {
                Id = 4444,
                Category = newCategory,
                Name = petName,
                PhotoUrls = new string[] { "https://cutepets.com/" },
                Tags = newTag,
                Status = newStatus
            };
        }
    }
}
