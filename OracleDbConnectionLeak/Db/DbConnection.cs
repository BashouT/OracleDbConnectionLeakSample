using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace OracleDbConnectionLeak.Db
{
    public class DbConnection : ICustomDbConnection
    {
        private readonly OracleConnection _oracleConnection;

        public DbConnection(OracleConnection oracleConnection)
        {
            _oracleConnection = oracleConnection;
        }

        public void Dispose()
        {
            _oracleConnection?.Close();
            _oracleConnection?.Dispose();
            OracleConnection.ClearPool(_oracleConnection);
        }

        public IEnumerable<T> Query<T>(string query, bool buffered, int commandTimeout)
        {
            IEnumerable<T> result = new List<T>();

            if (_oracleConnection.State == ConnectionState.Closed)
            {
                _oracleConnection.Open();
            }

            if (_oracleConnection.State == ConnectionState.Open)
            {
                try
                {
                    result = _oracleConnection.Query<T>(query, buffered: buffered, commandTimeout: commandTimeout);
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    //_oracleConnection.Close();
                    //_oracleConnection.Dispose();
                }
            }

            return result;
        }

    }
}
