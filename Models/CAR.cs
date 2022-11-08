﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class CAR
    {
        public int Carid { get; set; }
        public string Carname { get; set; }
        public string CarType { get; set; }
        public Nullable<int> PerDayCharge { get; set; }
        public Nullable<int> ChargePerKm { get; set; }
    }
}