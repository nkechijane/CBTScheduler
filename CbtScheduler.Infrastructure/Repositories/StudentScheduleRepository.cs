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
            var sql = "Insert into StudentSchedule (MatricNumber, SessionId, SemesterId, Class, CourseCode, " +
                "CreatedOn, CreatedTime) VALUES (@MatricNumber, @SessionId, @SemesterId, @Class, @CourseCode, " +
                "@CreatedOn, @CreatedTime)";
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

        public async Task<List<StudentSchedule>> GetAllAsync()
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
            var sql = "UPDATE StudentSchedule SET DayAndTime = @DayAndTime, Hall = @Hall, UpdatedOn = @UpdatedOn, Lab = @Lab WHERE Id = @id";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                connection.Open();
                return await connection.ExecuteAsync(sql, entity);                
            }
        }

        public async Task<List<StudentSchedule>> GetAllStudentByDateAsync(DateTime DayAndTime)
        {
            var sql = "SELECT * FROM StudentSchedule WHERE DayAndTime = @DayAndTime";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                connection.Open();
                var result = await connection.QueryAsync<StudentSchedule>(sql, DayAndTime);
                return result.ToList();
            }
        }

        public async Task<StudentSchedule> GetStudentDataAsync(string matricNumber)
        {
            var sql = "SELECT FROM StudentSchedule WHERE MatricNumber = @matricNumber";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("ConnStr")))
            {
                connection.Open();
                return await connection.QueryFirstOrDefaultAsync<StudentSchedule>(sql);
            }
        }
    }
}
