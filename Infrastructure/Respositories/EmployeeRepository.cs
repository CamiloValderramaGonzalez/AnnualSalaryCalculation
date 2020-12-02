using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Domain.EmployeeAggregate.Interfaces;
using Domain.EmployeeAggregate.Entities;

namespace Infrastructure.Respositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HttpClient _httpClient;
        public EmployeeRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task<List<Employee>> IEmployeeRepository.EmployeesGet()
        {
            try
            {
                string uri = $"Employees";
                var response = await _httpClient.GetAsync(uri);

                response.EnsureSuccessStatusCode();

                var responseTask = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Employee>>(responseTask);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // Para detectar llamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: elimine el estado administrado (objetos administrados).
                }

                // TODO: libere los recursos no administrados (objetos no administrados) y reemplace el siguiente finalizador.
                // TODO: configure los campos grandes en nulos.

                disposedValue = true;
            }
        }

        // TODO: reemplace un finalizador solo si el anterior Dispose(bool disposing) tiene código para liberar los recursos no administrados.
        // ~Employee() {
        //   // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
        //   Dispose(false);
        // }

        // Este código se agrega para implementar correctamente el patrón descartable.
        void IDisposable.Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el anterior Dispose(colocación de bool).
            Dispose(true);
            // TODO: quite la marca de comentario de la siguiente línea si el finalizador se ha reemplazado antes.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
