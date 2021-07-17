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
            bool _highestBid = false;
            if (GetAllBidByVehicleId(bidObject.VehicleIdentyficator).Count > 0)
            {
                foreach (var item in GetAllBidByVehicleId(bidObject.VehicleIdentyficator))
                {

                    if (item.BidValue > bidObject.BidValue)
                    {
                        _highestBid = false;
                    }
                    else
                    {
                        if(item.UserIdentyficator!= bidObject.UserIdentyficator)
                        {
                            _highestBid = true;
                        }
                    }
                }
            }
            else
            {
                _highestBid = true;
            }
            if (GetUserTotalAccountBalance(bidObject.UserIdentyficator) > bidObject.BidValue && _highestBid)
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

        public List<Bid> GetAllBidByVehicleId(int vehicleId)
        {
            var bids = _dbContext
                            .Bids
                            .Where(r => r.VehicleIdentyficator == vehicleId).ToList();
            return bids;
        }
        public List<Bid> GetAllActiveBid()
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

        private long GetUserTotalAccountBalance(int userId)
        {
            var user = _dbContext
                            .Users
                            .FirstOrDefault(r => r.Id == userId);

            long _accountBalance = user.AccountBalance;

            foreach (var item in GetAllActiveBid())
            {
                if (item.UserIdentyficator == userId)
                {
                    _accountBalance = _accountBalance - item.BidValue;
                }
            };

            return _accountBalance;
        }

        public Bid GetHighestBidByVehicleId(int vehicleId)
        {
            var bid = _dbContext
                            .Bids
                            .Where(r => r.VehicleIdentyficator == vehicleId)
                            .Where(r=> r.Active == true)
                            .OrderByDescending(r => r.BidValue).ToList();

            return bid[0];

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
