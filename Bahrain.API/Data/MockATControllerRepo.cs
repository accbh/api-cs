using System.Collections.Generic;
using Bahrain.API.Models;

namespace Bahrain.API.Data
{

    public class MockATControllerRepo //: IATControllerRepo
    {
        public void AddATController(ATController atc)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteController(ATController atc)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ATController> GetAllControllers()
        {
            var controllers = new List<ATController>
            {
                new ATController{Id=0, FullName="Piam Lee", Rating="I1", Email="user1@email.com"},
                new ATController{Id=1, FullName="Vavin", Rating="C3", Email="user2@email.com"},
                new ATController{Id=2, FullName="Kornie", Rating="I3", Email="user3@email.com"}
            };

            return controllers;
        }

        public ATController GetControllerById(int id)
        {
            return new ATController{Id=0, FullName="Piam Lee", Rating="I1", Email="user1@email.com"};
        }

        public ATController GetControllerByNetworkId(string networkId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ATController> GetControllerByRating(string rating)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ATController> GetControllersByPosition(string positions)
        {
            throw new System.NotImplementedException();
        }

        public ATController GetControllerStatus(int networkId)
        {
            throw new System.NotImplementedException();
        }

        public ATController GetHomeDivision(int networkId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ATController> GetSignedOffControllers()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ATController> GetSoloValidatedControllers()
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateATController(ATController atc)
        {
            throw new System.NotImplementedException();
        }
    }

}