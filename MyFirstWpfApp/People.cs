using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWpfApp
{
    public class People
    {
        public string? Name { get; set; }

        public override string ToString()
        {
            return Name ?? string.Empty;
        }

        public static readonly People Default = new People()
        {
            Name = "Unknown",
        };

    }
}
//Kommentarij