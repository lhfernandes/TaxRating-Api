using AutoMapper;
using Domain.Entities;
using TaxRating.ViewModels.ConverterTax;
using TaxRating.ViewModels.Segment;

namespace TaxRating.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            #region TaxRating

            CreateMap<CreateSegmentViewModel, Segment>().ReverseMap();

            CreateMap<GetSegmentViewModel, Segment>().ReverseMap();

            CreateMap<UpdateSegmentViewModel, Segment>().ReverseMap();

            CreateMap<GetConverterTaxViewModel, ConverterTax>().ReverseMap();

            #endregion
        }
    }
}
