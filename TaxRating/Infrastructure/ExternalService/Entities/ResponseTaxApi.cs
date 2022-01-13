using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ExternalService.Entities
{
    public class ResponseTaxApi
	{
        public string Disclaimer { get; set; }
        public string License { get; set; }
        public int TimeStamp { get; set; }
        public string Base { get; set; }
        public Dictionary<string,double> Rates { get; set; }
       
    }

}
