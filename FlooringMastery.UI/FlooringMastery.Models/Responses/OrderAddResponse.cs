﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Responses
{
    public class OrderAddResponse : Response
    {
        public Order order { get; set; }

        public string orderDate;

        public string customerName;

        public string state;

        public string productType;

        public decimal area;
    }
}
