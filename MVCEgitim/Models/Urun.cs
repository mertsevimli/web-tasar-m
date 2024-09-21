using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCEgitim.Models
{
    public class Urun
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string? Resmi { get; set; }
        public decimal Fiyati { get; set; }
        public int Stok { get; set; }
    }
}