using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace GrabbaRide.Database
{
    public partial class Ride : INotifyPropertyChanging, INotifyPropertyChanged
    {
        public int SearchRank { get; set; }
    }
}
