﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Responses
{
    public class OrderRemoveResponse : Response
    {
        public Order order { get; set; }

        public int orderNumber;

        public string orderDate;
    }
}