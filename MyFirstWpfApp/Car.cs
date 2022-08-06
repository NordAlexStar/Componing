using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWpfApp
{
    public enum CarClass
    {
        Lux, Buisness, Smart, Family, Sport, Truck
    }

    public enum FuelType
    {
        gasoline, Diesel
    }
    public class Car
    {
        public string? Marka { get; set; }
        public string? Number { get; set; }

        public FuelType FuelType { get; set; }
        public string? Color { get; set; }

        public Dictionary<DateTime?, People?> Owners { get; set; } = new Dictionary<DateTime?, People?>();

        public CarClass? Class { get; set; }

        public override string ToString()
        {
            string Ownrs = string.Empty;
            foreach (var item in Owners)
            {
                Ownrs += $@"{item.Key?.ToString("dd.MM.yyyy")} {item.Value}
";
            }

            return $@"{Marka} {Number}
" + Ownrs;

        }

        internal object Datums(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}
