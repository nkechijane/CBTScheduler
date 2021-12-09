using CbtScheduler.Core.Entities;
using CbtScheduler.Core.Entities.Dtos;
using CbtScheduler.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbtScheduler.Application.StudentScheduleService
{
    public class StudentScheduleService : IStudentScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentScheduleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseDto> AddAsync(StudentSchedule entity)
        {
            ResponseDto response = new ResponseDto();
            try
            {

                var result = await _unitOfWork.StudentSchedules.AddAsync(entity);
                response.Status = "success";
                response.Message = "Data Successfully Inserted";
                response.Payload = entity;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = "Fail";
                response.Message = "An error occured!:" + ex.Message;
                response.Payload = entity;
                return response;
            }
        }

        public async Task<ResponseDto> DeleteAsync(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                var result = await _unitOfWork.StudentSchedules.DeleteAsync(id);
                response.Status = "Success";
                response.Message = $"Data with {id} was Successfully deleted";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = "Fail";
                response.Message = "An error occured!:" + ex.Message;
                return response;
            }
        }

        public async Task<ResponseDto> GetAllAsync()
        {
            ResponseDto response = new ResponseDto();
            try
            {
                var result = await _unitOfWork.StudentSchedules.GetAllAsync();
                response.Status = "Success";
                response.Message = "Data Successfully fetched";
                response.Payload = result.ToList();
                return response;
            }
            catch (Exception ex)
            {
                response.Status = "Fail";
                response.Message = "An error occured!:" + ex.Message;
                return response;
            }
        }

        public async Task<ResponseDto> GetStudentByDateAsync(DateTime time)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                var result = await _unitOfWork.StudentSchedules.GetAllStudentByDateAsync(time);
                response.Status = "Success";
                response.Message = "All Records Successfully fetched";
                response.Payload = result.ToList();
                return response;
            }
            catch (Exception ex)
            {
                response.Status = "Fail";
                response.Message = "An error occured!:" + ex.Message;
                return response;
            }
        }

        public async Task<ResponseDto> GetByIdAsync(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                var result = await _unitOfWork.StudentSchedules.GetByIdAsync(id);
                response.Status = "Success";
                response.Message = "Data Successfully fetched";
                response.Payload = result;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = "Fail";
                response.Message = "An error occured!:" + ex.Message;
                return response;
            }
        }

        public async Task<ResponseDto> GetStudentByMatricNoAsync(string matricNumber)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                var result = await _unitOfWork.StudentSchedules.GetStudentDataAsync(matricNumber);
                response.Status = "Success";
                response.Message = "Data Successfully fetched";
                response.Payload = result;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = "Fail";
                response.Message = "An error occured!:" + ex.Message;
                return response;
            }
        }

        public async Task<ResponseDto> UpdateAsync(UpdateDto entity)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                var repodata = new StudentSchedule()
                {
                    Id = entity.Id,
                    DayAndTime = entity.DayAndTime,
                    Hall = entity.Hall,
                    Lab = entity.Lab,
                    UpdatedOn = entity.UpdatedOn
                };

                var result = await _unitOfWork.StudentSchedules.UpdateAsync(repodata);
                response.Status = "Success";
                response.Message = $" The record with {repodata.Id} Successfully updated";
                return response;

            }
            catch (Exception ex)
            {
                response.Status = "Fail";
                response.Message = "An error occured!:" + ex.Message;
                return response;
            }
        }
    }
}
