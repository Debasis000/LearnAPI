using AutoMapper;
using Azure;
using LearnAPI.Helper;
using LearnAPI.Modal;
using LearnAPI.Repos;
using LearnAPI.Repos.Models;
using LearnAPI.Service;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LearnAPI.Container
{
    public class CustomerService : ICustomerService
    {
        private readonly LearndataContextb context;
        private readonly IMapper mapper;
        private  ILogger<CustomerService> logger;
        public CustomerService(LearndataContextb context, IMapper mapper, ILogger<CustomerService> logger) {
            this.context = context; 
            this.mapper = mapper;
        }    
        public async Task<List<Customermodal>> GetAll()
        {
          List<Customermodal> _response = new List<Customermodal>();
          var _data = await this.context.TblCustomers.ToListAsync();
            if (_data != null) {
                _response = this.mapper.Map<List<TblCustomer>, List<Customermodal>>(_data);
            }
            return _response;
        }
        public async Task<Customermodal> GetBycode(string code) {
            Customermodal _response = new Customermodal();
            var _data = await this.context.TblCustomers.FindAsync(code);
            if (_data != null)
            {
                _response = this.mapper.Map<TblCustomer, Customermodal>(_data);
            }
            return _response;
        }

        public async Task<APIResponse> Remove(string code) {

            APIResponse response = new APIResponse();
            try
            { 
                var _customer = await this.context.TblCustomers.FindAsync(code); 
                if(_customer != null)
                {
                    this.context.TblCustomers.Remove(_customer);
                    await this.context.SaveChangesAsync();
                    
                }
                response.ResponseCode = 201;
                response.Errormessage = "Data not found";

            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.Errormessage = "Data not Found";
            }
            return response;
        }

        public async Task<APIResponse> Update(Customermodal data, string code) {
            APIResponse response = new APIResponse();
            try
            {
                var _customer = await this.context.TblCustomers.FindAsync(code);
                if (_customer != null)
                {
                    _customer.Name = data.Name;
                    _customer.Email = data.Email;
                    _customer.Phone = data.Phone;
                    _customer.IsActive = data.IsActive;
                    _customer.CreditLimit = data.CreditLimit;
                    await this.context.SaveChangesAsync();
                    response.ResponseCode = 200;

                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.Errormessage = "Data not Found";
            }
            return response;
        }

        public async Task<APIResponse> Create(Customermodal data)
        {
            APIResponse response = new APIResponse();  
            try
            {
                this.logger.LogInformation("Create Begins");
                TblCustomer _customer = this.mapper.Map<Customermodal, TblCustomer>(data);
                this.context.TblCustomers.Add(_customer);
                await this.context.SaveChangesAsync();
                response.ResponseCode = 200;
                response.Result = data.Code;

            }
            catch (Exception ex) {
                response.ResponseCode = 400;
                response.Errormessage = ex.Message;
                
            }
            return response;
        }

    }
}
