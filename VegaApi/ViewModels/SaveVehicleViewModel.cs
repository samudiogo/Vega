using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace VegaApi.ViewModels
{

    public class SaveVehicleViewModel
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public bool IsRegistered { get; set; }
        [Required]
        public ContactViewModel Contact { get; set; }

        public ICollection<int> Features { get; set; } = new Collection<int>();

    }
}