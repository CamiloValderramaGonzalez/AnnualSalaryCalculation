using Newtonsoft.Json;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd.Services
{
    public class EmployeeService
    {
        private readonly HttpClient _httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EmployeeDTO>> EmployeesGet(int? id)
        {
            try
            {
                string uri = $"Employee" + (id.HasValue ? "/" + id.Value.ToString() : "");
                var response = await _httpClient.GetAsync(uri);

                response.EnsureSuccessStatusCode();

                var responseTask = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<EmployeeDTO>>(responseTask);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
