using Application.Persistence;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class DapperRepository : IDapperRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<DapperRepository> _log;
        private readonly IConfiguration configuration;
        private IDbConnection db;
        private IDbTransaction _trans;


        public DapperRepository(ILogger<DapperRepository> _log, IConfiguration configuration)
        {
            this._log = _log;
            this.configuration = configuration;
            _connectionString = configuration.GetConnectionString("PizzaDb");
        }

        public void StartTransaction()
        {
            db.Open();
            _trans = db.BeginTransaction();
        }
        public void CommitTransaction()
        {
            _trans?.Commit();
            db?.Close();
        }
        public void RollbackTransaction()
        {
            _trans?.Rollback();
            db?.Close();
        }
        public void Dispose()
        {
            CommitTransaction();
        }

        public List<T0> ExecuteQueryWithTransaction<T0>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure)
        {
            try
            {

                var result = db.QueryMultiple(sqlQuery, sqlParam, transaction: _trans, commandTimeout: 30000, commandType: queryType);
                var res = result.Read<T0>().ToList();
                return res;
            }
            catch (Exception ex)
            {
                _log.LogError("LogError on Database Operation. LogError Details As: {0}", ex.StackTrace);
                throw;
            }


        }

        public async Task<List<T0>> ExecuteQueryWithTransactionAsync<T0>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure)
        {
            try
            {
                var result = await db.QueryMultipleAsync(sqlQuery, sqlParam, transaction: _trans, commandTimeout: 30000, commandType: queryType);
                var res = result.Read<T0>().ToList();
                return res;
            }
            catch (Exception ex)
            {
                _log.LogError("LogError on Database Operation. LogError Details As: {0}", ex.StackTrace);
                throw;
            }
        }

        public List<T0> ExecuteQuery<T0>(string sqlQuery, object sqlParam, System.Data.CommandType queryType = System.Data.CommandType.StoredProcedure)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlConnection.Open();
                    var result = sqlConnection.QueryMultiple(sqlQuery, sqlParam, commandTimeout: 30000,
                        commandType: queryType);
                    var res = result.Read<T0>().ToList();
                    return res;
                }
                catch (Exception ex)
                {
                    _log.LogError("LogError on Database Operation. LogError Details As: {0}", ex.StackTrace);
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
        public List<object> ExecuteQuery<T0, T1>(string sqlQuery, object sqlParam, System.Data.CommandType queryType = System.Data.CommandType.StoredProcedure)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                sqlConnection.Open();
                var result = sqlConnection.QueryMultiple(sqlQuery, sqlParam, commandTimeout: 30000, commandType: queryType);
                var res = new List<object>();
                res.Add(result.Read<T0>().ToList());

                res.Add(result.Read<T1>().ToList());
                sqlConnection.Close();
                return res;
            }
        }
        public List<object> ExecuteQuery<T0, T1, T2>(string sqlQuery, object sqlParam, System.Data.CommandType queryType = System.Data.CommandType.StoredProcedure)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlConnection.Open();
                    var result = sqlConnection.QueryMultiple(sqlQuery, sqlParam, commandTimeout: 30000, commandType: queryType);
                    var res = new List<object>();
                    res.Add(result.Read<T0>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T1>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T2>().ToList());
                    return res;
                }
                catch (Exception ex)
                {
                    _log.LogError("LogError on Database Operation. LogError Details As: {0}", ex.StackTrace);
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
        public List<object> ExecuteQuery<T0, T1, T2, T3>(string sqlQuery, object sqlParam, System.Data.CommandType queryType = System.Data.CommandType.StoredProcedure)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlConnection.Open();
                    var result = sqlConnection.QueryMultiple(sqlQuery, sqlParam, commandTimeout: 30000, commandType: queryType);
                    var res = new List<object>();
                    res.Add(result.Read<T0>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T1>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T2>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T3>().ToList());
                    return res;
                }
                catch (Exception ex)
                {
                    _log.LogError("LogError on Database Operation. LogError Details As: {0}", ex.StackTrace);
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
        public List<object> ExecuteQuery<T0, T1, T2, T3, T4>(string sqlQuery, object sqlParam, System.Data.CommandType queryType = System.Data.CommandType.StoredProcedure)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlConnection.Open();
                    var result = sqlConnection.QueryMultiple(sqlQuery, sqlParam, commandTimeout: 30000, commandType: queryType);
                    var res = new List<object>();
                    res.Add(result.Read<T0>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T1>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T2>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T3>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T4>().ToList());
                    return res;
                }
                catch (Exception ex)
                {
                    _log.LogError("LogError on Database Operation. LogError Details As: {0}", ex.StackTrace);
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
        public List<object> ExecuteQuery<T0, T1, T2, T3, T4, T5>(string sqlQuery, object sqlParam, System.Data.CommandType queryType = System.Data.CommandType.StoredProcedure)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlConnection.Open();
                    var result = sqlConnection.QueryMultiple(sqlQuery, sqlParam, commandTimeout: 30000, commandType: queryType);
                    var res = new List<object>();
                    res.Add(result.Read<T0>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T1>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T2>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T3>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T4>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T5>().ToList());
                    return res;
                }
                catch (Exception ex)
                {
                    _log.LogError("LogError on Database Operation. LogError Details As: {0}", ex.StackTrace);
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
        public List<object> ExecuteQuery<T0, T1, T2, T3, T4, T5, T6>(string sqlQuery, object sqlParam, System.Data.CommandType queryType = System.Data.CommandType.StoredProcedure)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlConnection.Open();
                    var result = sqlConnection.QueryMultiple(sqlQuery, sqlParam, commandTimeout: 30000, commandType: queryType);
                    var res = new List<object>();
                    res.Add(result.Read<T0>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T1>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T2>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T3>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T4>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T5>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T6>().ToList());

                    return res;
                }
                catch (Exception ex)
                {
                    _log.LogError("LogError on Database Operation. LogError Details As: {0}", ex.StackTrace);
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
        public List<object> ExecuteQuery<T0, T1, T2, T3, T4, T5, T6, T7>(string sqlQuery, object sqlParam, System.Data.CommandType queryType = System.Data.CommandType.StoredProcedure)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlConnection.Open();
                    var result = sqlConnection.QueryMultiple(sqlQuery, sqlParam, commandTimeout: 30000, commandType: queryType);
                    var res = new List<object>();
                    res.Add(result.Read<T0>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T1>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T2>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T3>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T4>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T5>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T6>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T7>().ToList());

                    return res;
                }
                catch (Exception ex)
                {
                    _log.LogError("LogError on Database Operation. LogError Details As: {0}", ex.StackTrace);
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
        public List<object> ExecuteQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8>(string sqlQuery, object sqlParam, System.Data.CommandType queryType = System.Data.CommandType.StoredProcedure)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlConnection.Open();
                    var result = sqlConnection.QueryMultiple(sqlQuery, sqlParam, commandTimeout: 30000, commandType: queryType);
                    var res = new List<object>();
                    res.Add(result.Read<T0>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T1>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T2>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T3>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T4>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T5>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T6>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T7>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T8>().ToList());

                    return res;
                }
                catch (Exception ex)
                {
                    _log.LogError("LogError on Database Operation. LogError Details As: {0}", ex.StackTrace);
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
        public List<object> ExecuteQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9>(string sqlQuery, object sqlParam, System.Data.CommandType queryType = System.Data.CommandType.StoredProcedure)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlConnection.Open();
                    var result = sqlConnection.QueryMultiple(sqlQuery, sqlParam, commandTimeout: 30000, commandType: queryType);
                    var res = new List<object>();
                    res.Add(result.Read<T0>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T1>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T2>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T3>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T4>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T5>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T6>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T7>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T8>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T9>().ToList());

                    return res;
                }
                catch (Exception ex)
                {
                    _log.LogError("LogError on Database Operation. LogError Details As: {0}", ex.StackTrace);
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
        public List<object> ExecuteQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string sqlQuery, object sqlParam, System.Data.CommandType queryType = System.Data.CommandType.StoredProcedure)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlConnection.Open();
                    var result = sqlConnection.QueryMultiple(sqlQuery, sqlParam, commandTimeout: 30000, commandType: queryType);
                    var res = new List<object>();
                    res.Add(result.Read<T0>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T1>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T2>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T3>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T4>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T5>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T6>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T7>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T8>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T9>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T10>().ToList());
                    return res;
                }
                catch (Exception ex)
                {
                    _log.LogError("LogError on Database Operation. LogError Details As: {0}", ex.StackTrace);
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
        public List<object> ExecuteQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(string sqlQuery, object sqlParam, System.Data.CommandType queryType = System.Data.CommandType.StoredProcedure)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlConnection.Open();
                    var result = sqlConnection.QueryMultiple(sqlQuery, sqlParam, commandTimeout: 30000, commandType: queryType);
                    var res = new List<object>();
                    res.Add(result.Read<T0>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T1>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T2>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T3>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T4>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T5>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T6>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T7>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T8>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T9>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T10>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T11>().ToList());
                    return res;
                }
                catch (Exception ex)
                {
                    _log.LogError("LogError on Database Operation. LogError Details As: {0}", ex.StackTrace);
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
        public List<object> ExecuteQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(string sqlQuery, object sqlParam, System.Data.CommandType queryType = System.Data.CommandType.StoredProcedure)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlConnection.Open();
                    var result = sqlConnection.QueryMultiple(sqlQuery, sqlParam, commandTimeout: 30000, commandType: queryType);
                    var res = new List<object>();
                    res.Add(result.Read<T0>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T1>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T2>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T3>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T4>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T5>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T6>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T7>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T8>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T9>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T10>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T11>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T12>().ToList());
                    return res;
                }
                catch (Exception ex)
                {
                    _log.LogError("LogError on Database Operation. LogError Details As: {0}", ex.StackTrace);
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
        public List<object> ExecuteQuery<T0, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(string sqlQuery, object sqlParam, System.Data.CommandType queryType = System.Data.CommandType.StoredProcedure)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlConnection.Open();
                    var result = sqlConnection.QueryMultiple(sqlQuery, sqlParam, commandTimeout: 30000, commandType: queryType);
                    var res = new List<object>();
                    res.Add(result.Read<T0>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T1>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T2>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T3>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T4>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T5>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T6>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T7>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T8>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T9>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T10>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T11>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T12>().ToList());
                    if (result.IsConsumed) return res;
                    res.Add(result.Read<T13>().ToList());
                    return res;
                }
                catch (Exception ex)
                {
                    _log.LogError("LogError on Database Operation. LogError Details As: {0}", ex.StackTrace);
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public async Task<List<T0>> ExecuteQueryAsync<T0>(string sqlQuery, object sqlParam, System.Data.CommandType queryType = System.Data.CommandType.StoredProcedure)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlConnection.Open();
                    var result = sqlConnection.QueryMultiple(sqlQuery, sqlParam, commandTimeout: 30000,
                        commandType: queryType);
                    var res = await result.ReadAsync<T0>();
                    return res.ToList();
                }
                catch (Exception ex)
                {
                    _log.LogError("LogError on Database Operation. LogError Details As: {0}", ex.StackTrace);
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
        public async Task<List<object>> ExecuteQueryAsync<T0, T1>(string sqlQuery, object sqlParam, System.Data.CommandType queryType = System.Data.CommandType.StoredProcedure)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                sqlConnection.Open();
                var result = sqlConnection.QueryMultiple(sqlQuery, sqlParam, commandTimeout: 30000, commandType: queryType);
                var res = new List<object>();
                res.Add(await result.ReadAsync<T0>());
                res.Add(await result.ReadAsync<T1>());
                sqlConnection.Close();
                return res;
            }
        }
        public async Task<List<object>> ExecuteQueryAsync<T0, T1, T2>(string sqlQuery, object sqlParam, System.Data.CommandType queryType = System.Data.CommandType.StoredProcedure)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlConnection.Open();
                    var result = sqlConnection.QueryMultiple(sqlQuery, sqlParam, commandTimeout: 30000, commandType: queryType);
                    var res = new List<object>();
                    res.Add(await result.ReadAsync<T0>());
                    if (result.IsConsumed) return res;
                    res.Add(await result.ReadAsync<T1>());
                    if (result.IsConsumed) return res;
                    res.Add(await result.ReadAsync<T2>());
                    return res;
                }
                catch (Exception ex)
                {
                    _log.LogError("LogError on Database Operation. LogError Details As: {0}", ex.StackTrace);
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }


        public string GetDataTableToString(DataTable dt)
        {
            string xml = null;
            using (TextWriter writer = new StringWriter())
            {
                dt.WriteXml(writer);
                xml = writer.ToString();
            }
            return xml;
        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable("dt");

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public string GetConnectionString()
        {
            return _connectionString ?? "";
        }

        public async Task<List<T0>> ExecuteSqlQuery<T0>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.Text)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                sqlConnection.Open();
                var result = await sqlConnection.QueryAsync<T0>(sqlQuery, sqlParam, commandTimeout: 30000, commandType: queryType);

                sqlConnection.Close();
                return result.ToList();
            }
        }

        public List<T0> GetAll<T0>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlConnection.Open();
                    var result = sqlConnection.Query<T0>(sqlQuery, sqlParam, commandTimeout: 30000, commandType: queryType).ToList();

                    return result;
                }
                catch (Exception ex)
                {
                    _log.LogError("LogError on Database Operation. LogError Details As: {0}", ex.StackTrace);
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public T0 GetById<T0>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlConnection.Open();
                    var result = sqlConnection.Query<T0>(sqlQuery, sqlParam, commandTimeout: 30000, commandType: queryType).FirstOrDefault();

                    return result;
                }
                catch (Exception ex)
                {
                    _log.LogError("LogError on Database Operation. LogError Details As: {0}", ex.StackTrace);
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public T0 Add<T0>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlConnection.Open();
                    var result = sqlConnection.Query<T0>(sqlQuery, sqlParam, commandTimeout: 30000, commandType: queryType).FirstOrDefault();

                    return result;
                }
                catch (Exception ex)
                {
                    _log.LogError("LogError on Database Operation. LogError Details As: {0}", ex.StackTrace);
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public T0 Update<T0>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlConnection.Open();
                    var result = sqlConnection.Query<T0>(sqlQuery, sqlParam, commandTimeout: 30000, commandType: queryType).FirstOrDefault();

                    return result;
                }
                catch (Exception ex)
                {
                    _log.LogError("LogError on Database Operation. LogError Details As: {0}", ex.StackTrace);
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        public T0 Delete<T0>(string sqlQuery, object sqlParam, CommandType queryType = CommandType.StoredProcedure)
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlConnection.Open();
                    var result = sqlConnection.Query<T0>(sqlQuery, sqlParam, commandTimeout: 30000, commandType: queryType).FirstOrDefault();

                    return result;
                }
                catch (Exception ex)
                {
                    _log.LogError("LogError on Database Operation. LogError Details As: {0}", ex.StackTrace);
                    throw;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }

        }
    }
}

