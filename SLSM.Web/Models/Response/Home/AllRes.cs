﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLSM.Web.Models.Response.Home
{
    public class AllRes
    {
        public string sessionId { get; set; }
        public List<string> list { get; set; }
    }
}