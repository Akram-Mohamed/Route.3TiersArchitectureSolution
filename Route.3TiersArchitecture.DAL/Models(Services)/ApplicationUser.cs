using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route._3TiersArchitecture.DAL.Models_Services_
{
	public class ApplicationUser:IdentityUser
	{

        public  string FName { get; set; }
        public  string LName { get; set; }
        public bool IsAgree { get; set; }
    }
}
