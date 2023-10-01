using AutoMapper;
using Courses.Services.Catalog.Dtos;
using Courses.Services.Catalog.Models;

namespace Courses.Services.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            // Conversion is from Course => CourseDto and vise versa with the help of ReverseMap()
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();

            CreateMap<Course, CourseCreateDto>().ReverseMap();
            CreateMap<Course, CourseUpdateDto>().ReverseMap();
        }
    }
}