using System.Collections.Generic;
using System.Linq;
using Bahrain.API.Models;

namespace Bahrain.API.Data
{
    public class SqlStaffRepo : IStaffRepo
    {

        private readonly BahrainDataContext _context;

        public SqlStaffRepo(BahrainDataContext context)
        {
            _context = context;
        }
        
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<StaffMember> GetAllStaff()
        {
            return _context.StaffMembers;
        }

        public StaffMember GetStaffById(int id)
        {
            return _context.StaffMembers.FirstOrDefault(staff => staff.Id == id);
        }

        public StaffMember GetStaffByNetworkId(string cid)
        {
            return _context.StaffMembers.FirstOrDefault(staff => staff.NetworkId == cid);
        }

        public StaffMember GetStaffByCallsign(string callsign)
        {
            return _context.StaffMembers.FirstOrDefault(staff => staff.StaffCallsign == callsign);
        }

        public string GetStaffCallsignByNetworkId(string cid)
        {
            return GetStaffByNetworkId(cid)?.StaffCallsign;
        }

        public string GetStaffCallsignById(int id)
        {
            return GetStaffById(id)?.StaffCallsign;
        }

        public int? GetPermissionPowerById(int id)
        {
            return GetStaffById(id)?.PermissionPower;
        }

        public int? GetPermissionPowerByCallsign(string callsign)
        {
            return GetStaffByCallsign(callsign)?.PermissionPower;
        }

        public string GetEmailById(int id)
        {
            return GetStaffById(id)?.StaffEmail;
        }

        public string GetEmailByCallsign(string callsign)
        {
            return GetStaffByCallsign(callsign)?.StaffEmail;
        }

        public string GetDepartmentByCallsign(string callsign)
        {
            return GetStaffByCallsign(callsign)?.Department;
        }

        public string GetDepartmentById(int id)
        {
            return GetStaffById(id)?.Department;
        }
    }
}