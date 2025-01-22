using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ux_newdata.domain.DTO.ApiResponse
{
    public class ApiResponse<T>
    {


        public ApiResponse()
        {
            Resultado = false;
        }

        public string Message { get; set; }
        public T Data { get; set; }
        public bool Resultado { get; set; }
       
    }
}
