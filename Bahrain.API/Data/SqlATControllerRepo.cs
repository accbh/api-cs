using System;
using System.Collections.Generic;
using System.Linq;
using Bahrain.API.Models;

namespace Bahrain.API.Data
{

    public class SqlATControllerRepo : IATControllerRepo
    {
        private readonly BahrainDataContext _context;

        public SqlATControllerRepo(BahrainDataContext context)
        {
            _context = context;
        }

        public void AddATController(ATController atc)
        {
            if (atc == null)
            {
                throw new ArgumentNullException(nameof(atc));
            }

            _context.ATControllers.Add(atc);

        }

        public void DeleteController(ATController atc)
        {
            if (atc == null) 
            {
                throw new ArgumentNullException(nameof(atc));
            }
            _context.ATControllers.Remove(atc);
        }

        public IEnumerable<ATController> GetAllControllers()
        {
            return _context.ATControllers.ToList();
        }

        public ATController GetControllerById(int id)
        {
            return _context.ATControllers.FirstOrDefault(atc => atc.Id == id);
        }

        public ATController GetControllerByNetworkId(string networkId)
        {
            return _context.ATControllers.FirstOrDefault(atc => atc.NetworkId == networkId);
        }

        public IEnumerable<ATController> GetControllerByRating(string rating)
        {
            return _context.ATControllers.Where(atc => atc.Rating == rating).ToList();
        }

        public string GetControllerStatus(string cid)
        {
            return GetControllerByNetworkId(cid).Visitor ? "Visitor" : "Home Controller";
        }

        public string GetHomeDivision(string cid)
        {
            return GetControllerByNetworkId(cid).HomeVacc;
        }

        //TODO: Fix this: Problem: can't use commas in the browser, maybe find something different to put inbetween.
        // public IEnumerable<ATController> GetControllersByPosition(string positions)
        // {
        //     return _context.ATControllers(atc => atc.approvedPositions == positions);
        // }

        public IEnumerable<ATController> GetSignedOffControllers()
        {
            return _context.ATControllers.Where(atc => atc.HasSignOff).ToList();
        }

        public IEnumerable<ATController> GetSoloValidatedControllers()
        {
            return _context.ATControllers.Where(atc => atc.OnSolo).ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        // PUT
        public void UpdateATController(ATController atc)
        {
            // Nothing needs to be done... yet
        }
    }

}