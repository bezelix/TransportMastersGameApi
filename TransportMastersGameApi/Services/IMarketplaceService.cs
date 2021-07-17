using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportMastersGameApi.Entities;

namespace TransportMastersGameApi.Services
{
    public interface IMarketplaceService
    {
        bool AddBid(Bid bidObject);
        List<Bid> GetAllBidByVehicleId(int vehicleId);
        List<Bid> GetAllActiveBid();
        Bid GetHighestBidByVehicleId(int vehicleId);
    }
}
