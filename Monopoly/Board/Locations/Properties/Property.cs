﻿using System;

namespace Monopoly.Board.Locations.Properties
{
    public class Property : Location
    {
        public Int32 Price { get; private set; }
        public Int32 BaseRent { get; private set; }
        public Boolean IsOwned { get { return this.Owner != null; } }
        public Player Owner { get; set; }

        public Property(Int32 locationIndex, Int32 price, Int32 baseRent)
            : base(locationIndex)
        {
            Price = price;
            BaseRent = baseRent;
            Owner = null;
        }
    }
}
