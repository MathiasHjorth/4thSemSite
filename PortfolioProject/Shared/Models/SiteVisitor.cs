using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioSite.Shared.Models
{
    public class SiteVisitor
    {
        public int SiteVisitorId { get; set; }
        public string IpAddress { get; set; }
        public DateTime? VisitDate { get; set; }
    }
}
