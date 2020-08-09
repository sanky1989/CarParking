using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.Model
{
    public class Duration
    {
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public IEnumerable<string> Days { get; set; }
    }
}
