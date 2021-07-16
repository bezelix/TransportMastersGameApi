using AutoMapper;
using FirstStepsDotNet.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportMastersGameApi.Entities;

namespace TransportMastersGameApi.Services
{
    public class MarketplaceService : IMarketplaceService
    {
        private TransportMastersGameDbContext _dbContext;
        private IMapper _mapper;
        private ILogger<DriverService> _logger;

        public MarketplaceService(TransportMastersGameDbContext dbContext, IMapper mapper, ILogger<DriverService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public bool AddBid(Bid bidObject)
        {

            var _user = GetUserById(bidObject.UserIdentyficator);
            bool _highestBid=false;

            foreach (var item in GetBidByVehicleId(bidObject.VehicleIdentyficator))
            {
                if (item.BidValue >= bidObject.BidValue)
                {
                    _highestBid = false;
                }
                else
                {
                    _highestBid = true;
                }

            }

            if (_user.AccountBalance >= bidObject.BidValue && _highestBid)
            {
                _dbContext.Bids.Add(bidObject);
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Bid> GetBidByVehicleId(int vehicleId)
        {
            var bids = _dbContext
                            .Bids
                            .Where(r => r.VehicleIdentyficator == vehicleId).ToList();
            return bids;
        }
        public List<Bid> GetAllBid()
        {
            var bids = _dbContext
                            .Bids
                            .Where(r => r.Active == true)
                            .ToList();
            return bids;
        }
        private User GetUserById(int userId)
        {
            var user = _dbContext
                            .Users
                            .FirstOrDefault(r => r.Id == userId);

            if (user is null)
                throw new NotFoundException("User not found");
            return user;
        }
        //void AccountBalanceUpdate(int id, long value)
        //{
        //    var user = _dbContext
        //        .Users
        //        .FirstOrDefault(r => r.Id == id);

        //    user.AccountBalance = user.AccountBalance - value;
        //    _dbContext.SaveChanges();
        //}
    }
}
