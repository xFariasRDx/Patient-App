using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientApp.Core.Domain.Entities
{
    public class Prueba_Lab
    {
        public int Id { get; set; }
        public string Prueba { get; set; }
        
        //Navigation Property
        public ICollection<Result_Lab> resultLab { get; set; }

    }
}
