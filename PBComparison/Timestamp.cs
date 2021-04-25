using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBComparison
{
    class Timestamp
    {
        private readonly decimal Value;

        private Timestamp(decimal value)
        {
            Value = value;
        }

        public Timestamp(string text)
        {
            var units = text.Split(":").Reverse().ToList();

            string seconds = units.First();
            Value = Decimal.Parse(seconds);

            if (units.Count > 1) //minutes
            {
                Value += Decimal.Parse(units[1]) * 60;
            }
            if (units.Count > 2) //hours
            {
                Value += Decimal.Parse(units[2]) * 3600;
            }
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static Timestamp operator +(Timestamp t1, Timestamp t2)
        {
            return new Timestamp(t1.Value + t2.Value);
        }

        public static bool operator <(Timestamp t1, Timestamp t2)
        {
            return t1.Value < t2.Value;
        }

        public static bool operator >(Timestamp t1, Timestamp t2)
        {
            return t1.Value > t2.Value;
        }

        public static Timestamp operator -(Timestamp t1, Timestamp t2)
        {
            return new Timestamp(t1.Value - t2.Value);
        }

        public static implicit operator Timestamp(string text)
        {
            return new Timestamp(text);
        }

        public static Timestamp Min(Timestamp t1, Timestamp t2)
        {
            return t1.Value <= t2.Value ? t1 : t2;
        }
    }
}
