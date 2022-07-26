using System;
using Courses.Services.Catalog.Dtos;
using Courses.Services.Catalog.Models;
using Courses.Shared.Dtos;

namespace Courses.Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();

        Task<Response<CategoryDto>> CreateAsync(Category category);

        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}

