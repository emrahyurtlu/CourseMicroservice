﻿using Courses.Services.Catalog.Dtos;
using Courses.Services.Catalog.Models;
using Courses.Shared.Models;

namespace Courses.Services.Catalog.Services
{
    public interface ICourseService
    {
        Task<Response<List<CourseDto>>> GetAllAsync();

        Task<Response<CourseDto>> CreateAsync(Course course);

        Task<Response<CourseDto>> GetByIdAsync(string id);

        Task<Response<CourseDto>> GetByUserIdAsync(string userId);

        Task<Response<CourseDto>> CreaseAsync(CourseCreateDto courseCreateDto);

        Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto);

        Task<Response<NoContent>> DeleteAsync(string id);
    }
}

