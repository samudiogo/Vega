using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VegaApi.ViewModels
{

    public class VehicleViewModel
    {
        public int Id { get; set; }
        public KeyValuePairViewModel Model { get; set; }
        public KeyValuePairViewModel Make { get; set; }
        public bool IsRegistered { get; set; }
        
        public ContactViewModel Contact { get; set; }

        public ICollection<KeyValuePairViewModel> Features { get; set; }
        public DateTime LastUpdate { get; set; }

        public VehicleViewModel() => Features = new Collection<KeyValuePairViewModel>();



    }
}