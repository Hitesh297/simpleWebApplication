using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleWebApplication.Models
{
    public class Risk
    {
        public virtual int RiskId { get; set; }
        public virtual string Rating { get; set; }
    }
}