using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence
{
    public interface IDapperRepository
    {
        List<T0> ExecuteQuery<T0>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure);
        List<T0> GetAll<T0>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure);
        T0 GetById<T0>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure);
        T0 Add<T0>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure);
        T0 Update<T0>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure);
        T0 Delete<T0>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure);
        List<T0> ExecuteQueryWithTransaction<T0>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure);
        List<object> ExecuteQuery<T0, T1>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure);
        List<object> ExecuteQuery<T0, T1, T2>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure);
        List<object> ExecuteQuery<T0, T1, T2, T3>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure);
        List<object> ExecuteQuery<T0, T1, T2, T3, T4>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure);
        List<object> ExecuteQuery<T0, T1, T2, T3, T4, T5>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure);
        List<object> ExecuteQuery<T0, T1, T2, T3, T4, T5, T6>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure);
        List<object> ExecuteQuery<T0, T1, T2, T3, T4, T5, T6, T7>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure);
        List<object> ExecuteQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure);
        List<object> ExecuteQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure);
        List<object> ExecuteQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure);
        List<object> ExecuteQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure);
        List<object> ExecuteQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure);
        List<object> ExecuteQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure);
        Task<List<T0>> ExecuteQueryAsync<T0>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure);
        Task<List<T0>> ExecuteQueryWithTransactionAsync<T0>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure);
        Task<List<object>> ExecuteQueryAsync<T0, T1>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure);
        Task<List<object>> ExecuteQueryAsync<T0, T1, T2>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure);

        void StartTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        string GetConnectionString();
    }
}
