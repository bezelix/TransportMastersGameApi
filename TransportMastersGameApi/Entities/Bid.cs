﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransportMastersGameApi.Entities
{
    public class Bid
    {
        public int id { get; set; }
        public int UserIdentyficator { get; set; }
        public int VehicleIdentyficator { get; set; }
        public long BidValue { get; set; }
        public bool Active { get; set; }
        public DateTime Date { get; set; }


    }
}
