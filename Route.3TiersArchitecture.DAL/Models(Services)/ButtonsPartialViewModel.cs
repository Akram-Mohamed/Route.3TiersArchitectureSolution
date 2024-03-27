using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Route._3TiersArchitecture.DAL.Models_Services_
{
    public class ButtonsPartialViewModel
    {
        public int Id { get; set; }
        public string ActionName { get; set; }
        public ButtonsPartialViewModel(int id, string actionName)
        {
            Id = id;
            ActionName = actionName;
        }



    }
}
