// MCDB Client Beta
// StukInformationSystem.Data
// IAsDataTable.cs
// 
// 06 04 2019
// 
// Katharina Bentsche

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using NKM.Base.Definition.Common.Result;

namespace StukInformationSystem.Data.Definitions.Select.SelectFrom {
    public interface IAsDataTable {
        IResult<DataTable> SelectSqlQueryAsDataTable(string query);
        IResult<DataTable> SelectSqlQueryAsDataTable(string query, List<SqlParameter> parameters);


    }
}