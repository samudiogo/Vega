using System.Linq;
using AutoMapper;
using Vega.Domain.Entities;
using Vega.Domain.Queries;
using VegaApi.ViewModels;

namespace VegaApi.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {




            //Domain to APi ViewModel
            CreateMap<Make, MakeViewModel>();
            CreateMap<Make, KeyValuePairViewModel>();
            CreateMap<Model, KeyValuePairViewModel>();
            CreateMap<Feature, KeyValuePairViewModel>();
            CreateMap<Vehicle, SaveVehicleViewModel>()
            .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactViewModel { Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone }))
            .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(f => f.FeatureId)));

            CreateMap<Vehicle, VehicleViewModel>()
            .ForMember(vr => vr.Make, opt => opt.MapFrom(v => v.Model.Make))
             .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactViewModel { Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone }))
             .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => new KeyValuePairViewModel { Id = vf.Feature.Id, Name = vf.Feature.Name })));

            //ViewModel to Domain

            CreateMap<VehicleQueryViewModel, VehicleQuery>();

            CreateMap(typeof(QueryResult<>), typeof(QueryResultViewModel<>));

            CreateMap<SaveVehicleViewModel, Vehicle>()
            .ForMember(v => v.Id, opt => opt.Ignore()) //ignora o mapeamento deste campo
            .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
            .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
            .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
            //.ForMember(v => v.Features, opt => opt.MapFrom(vr => vr.Features.Select(id => new VehicleFeature { FeatureId = id })))
            .ForMember(v => v.Features, opt => opt.Ignore())
            .AfterMap((vr, v) =>
            {
                var removedfeatures = v.Features.Where(f => !vr.Features.Contains(f.FeatureId)).ToList();
                //remove unselected features

                removedfeatures.ForEach(f => v.Features.Remove(f));

                //add new features
                // foreach (var id in vr.Features)
                // {
                //     if (!v.Features.Any(f => f.FeatureId == id))
                //         v.Features.Add(new VehicleFeature { FeatureId = id });
                // }

                vr.Features.Where(id => !v.Features.Any(f => f.FeatureId == id))
                .ToList()
                .ForEach(id => v.Features.Add(new VehicleFeature { FeatureId = id }));



            })

            ;


        }
    }
}