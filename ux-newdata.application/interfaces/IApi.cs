using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ux_newdata.domain.DTO;

namespace ux_newdata.application.interfaces
{
    public interface IApi
    {
        Task<List<ApiDto>> GetApi();
    }
}
