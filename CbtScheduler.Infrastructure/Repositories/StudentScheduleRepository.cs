using CbtScheduler.Application.Interfaces;
using CbtScheduler.Core.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbtScheduler.Infrastructure.Repositories
{
    class StudentScheduleRepository : IStudentScheduleRepository
    {
        private readonly IConfiguration _configuration;
        public StudentScheduleRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<int> AddAsync(StudentSchedule entity)
        {
            entity.CreatedOn = DateTime.Now;
            var sql = "Insert into StudentSchedule (MatricNumber, SessionId, SemesterId, Class, CourseCode," +
                " Day, Time, All, CreatedOn, CreatedTime)";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM StudentSchedule WHERE Id = @id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<StudentSchedule>> GetAllAsync()
        {
            var sql = "SELECT * FROM StudentSchedule";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                connection.Open();
                var result = await connection.QueryAsync<StudentSchedule>(sql);
                return result.ToList();
            }
        }

        public async Task<StudentSchedule> GetByIdAsync(int id)
        {
            var sql = "SELECT FROM StudentSchedule WHERE Id = @id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                connection.Open();
                var result = await connection.QueryFirstOrDefaultAsync<StudentSchedule>(sql);
                return result;
            }
        }

        public async Task<int> UpdateAsync(StudentSchedule entity)
        {
            var sql = "UPDATE StudentSchedule SET (MatricNumber, SessionId, SemesterId, Class, CourseCode, " +
                "Day, Time, Hall, CreatedOn, CreatedTime, FROM CbtSchedule, Lab) VALUES (@MatricNumber, @SessionId, @SemesterId, @Class, @CourseCode, " +
                "@Day, @Time, @Hall, @CreatedOn, @CreatedTime, @FROM @CbtSchedule, @Lab)";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<IReadOnlyList<StudentSchedule>> GetAllStudentByTimeAsync(DateTime time)
        {
            var dateData = time.Date.ToShortDateString();
            var timeData = time.ToLongTimeString();
            var sql = "SELECT * FROM StudentSchedule WHERE Time = @timeData AND Day = @dateData";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                connection.Open();
                var result = await connection.QueryAsync<StudentSchedule>(sql,new {timeData,dateData });
                return result.ToList();
            }
        }

        public async Task<StudentSchedule> GetStudentDataAsync(string matricNumber)
        {
            var sql = "SELECT FROM StudentSchedule WHERE MatricNumber = @matricNumber";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                connection.Open();
                var result = await connection.QueryFirstOrDefaultAsync<StudentSchedule>(sql);
                return result;
            }
        }

        public async Task<IReadOnlyList<StudentSchedule>> GetAllStudentByDayAsync(DateTime date)
        {
            var sql = "SELECT FROM StudentSchedule WHERE Date = @date";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                connection.Open();
                var result = await connection.QueryAsync<StudentSchedule>(sql);
                return result.ToList();
            }
        }
    }
}
