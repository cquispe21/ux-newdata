using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ux_newdata.application.interfaces;
using ux_newdata.domain.DTO;

namespace ux_newdata.infratructure.Repository.ApiConsulta
{
    public class ApiRepository : IApi
    {
        private readonly IConfiguration _configuration;
        public ApiRepository(IConfiguration configuration )
        {
            _configuration = configuration;
        }

        public async Task<List<ApiDto>> GetApi()
        {
            string apiUrl = _configuration["ApiSettings:BaseUrl"];

            using (var httpClient = new HttpClient())
            {
                try
                {
                    var response = await httpClient.GetStringAsync(apiUrl);

                    var apiResponse = JsonConvert.DeserializeObject<List<ApiDto>>(response);

                    return apiResponse;
                }
                catch (Exception ex)
                {
                    throw new Exception("Hubo un Error con la Api", ex);
                }
            }
        }
    }
}
