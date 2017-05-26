using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VegaApi.ViewModels
{
    public class MakeViewModel : KeyValuePairViewModel
    {
        public ICollection<KeyValuePairViewModel> Models { get; set; }

        public MakeViewModel()
        {
            Models = new Collection<KeyValuePairViewModel>();
        }
    }
}