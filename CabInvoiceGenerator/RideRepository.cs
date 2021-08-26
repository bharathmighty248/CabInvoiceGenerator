using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> userRides = null;

        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        public void AddRides(string userName, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userName);
            try
            {
                if (!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userName, list);
                }
            }
            catch
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDE, "Rides are null");
            }
        }

        public Ride[] GetRides(string userName)
        {
            try
            {
                return this.userRides[userName].ToArray();
            }
            catch
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_Name, "Invalid User Name");
            }
        }
    }
}
