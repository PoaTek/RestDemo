using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestDemo.Lib.Business
{
    /// <summary>
    /// Handle city search criteria fields
    /// </summary>
    public class CityCriteria
    {
        public string Name { get; set; }
        public int? PopulationFrom { get; set; }
        public int? PopulationTo { get; set; }
    }
}
