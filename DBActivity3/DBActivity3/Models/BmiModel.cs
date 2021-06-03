using System;
using System.Collections.Generic;
using System.Text;

namespace DBActivity3.Models
{
    public class BmiModel
    {
        public Guid BmiId { get; set; }
        public int IdNum { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Bmi { get; set; }
        public string BmiCategory { get; set; }
    }
}
