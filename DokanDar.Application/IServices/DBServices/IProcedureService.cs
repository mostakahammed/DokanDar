using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokanDar.Application.IServices.DBServices
{
    public interface IProcedureService
    {
        public DataSet GetDataWithParameter(object parameterName, string procedureName);
        public DataSet GetDataWithoutParameter(string procedureName);
    }
}
