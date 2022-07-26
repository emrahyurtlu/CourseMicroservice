using AutoMapper;
using Courses.Services.Catalog.Dtos;
using Courses.Services.Catalog.Models;
using Courses.Services.Catalog.Settings;
using Courses.Shared.Dtos;
using MongoDB.Driver;

namespace Courses.Services.Catalog.Services
{
    public class CourseService : ICourseService
    {
        private readonly IMongoCollection<Course> _courseCollection;

        private readonly IMongoCollection<Category> _categoryCollection;

        private readonly IMapper _mapper;

        public CourseService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _courseCollection = database.GetCollection<Course>(databaseSettings.CourseCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<Response<CourseDto>> CreateAsync(Course category)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<CourseDto>>> GetAllAsync()
        {
            var courses = await _courseCollection.Find<Course>(f => true).ToListAsync();

            return Response<List<CourseDto>>.Found(_mapper.Map<List<CourseDto>>(courses));
        }

        public async Task<Response<CourseDto>> GetByIdAsync(string id)
        {
            var course = await _courseCollection.Find<Course>(c => c.Id == id).FirstOrDefaultAsync();

            if (course is null)
            {
                return Response<CourseDto>.NotFound("Course not found");
            }

            course.Category = await _categoryCollection.Find<Category>(c => c.Id == course.CategoryId).FirstAsync();

            return Response<CourseDto>.Found(_mapper.Map<CourseDto>(course));
        }

        public async Task<Response<CourseDto>> GetByUserIdAsync(string userId)
        {
            var course = await _courseCollection.Find<Course>(f => f.UserId == userId).FirstOrDefaultAsync();

            if (course is not null)
            {
                course.Category = await _categoryCollection.Find<Category>(f => f.Id == course.CategoryId).FirstAsync();
            }
            else
            {
                course = new Course();
            }

            return Response<CourseDto>.Found(_mapper.Map<CourseDto>(course));
        }

        public async Task<Response<CourseDto>> CreaseAsync(CourseCreateDto courseCreateDto)
        {
            var newCourse = _mapper.Map<Course>(courseCreateDto);
            await _courseCollection.InsertOneAsync(newCourse);

            return Response<CourseDto>.Created(_mapper.Map<CourseDto>(newCourse));
        }

        public async Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto)
        {
            var course = _mapper.Map<Course>(courseUpdateDto);

            var result = await _courseCollection.FindOneAndReplaceAsync(t => t.Id == courseUpdateDto.Id, course);

            if (result is null)
            {
                return Response<NoContent>.NotFound("Course not found");
            }
            else
            {
                return Response<NoContent>.Updated();
            }
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await _courseCollection.DeleteOneAsync<Course>(t => t.Id == id);

            if (result.DeletedCount > 0)
            {
                return Response<NoContent>.Deleted();
            }
            else
            {
                return Response<NoContent>.NotFound("Course not found");
            }
        }
    }
}

