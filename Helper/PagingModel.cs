﻿using System;

namespace TichHopEntityFramwork.Helper
//TichHopEntityFramwork.Helper.PagingModel
{
    public class PagingModel
    {
        public int currentpage { get; set; }
        public int countpage { get; set; }
        public Func<int?, string> generateUrl {get; set;}
    }
}
