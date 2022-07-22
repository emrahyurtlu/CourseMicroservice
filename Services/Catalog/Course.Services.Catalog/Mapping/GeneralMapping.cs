using System;
using AutoMapper;
using Courses.Services.Catalog.Dtos;
using Courses.Services.Catalog.Models;

namespace Courses.Services.Catalog.Mapping
{
    public class GeneralMapping: Profile
    {
        public GeneralMapping()
        {
            CreateMap<Courses.Services.Catalog.Models.Course, CourseDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();

            CreateMap<Courses.Services.Catalog.Models.Course, CourseCreateDto>().ReverseMap();
            CreateMap<Courses.Services.Catalog.Models.Course, CourseUpdateDto>().ReverseMap();
        }
    }
}