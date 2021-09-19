using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace OracleDbConnectionLeak.Db
{
    public class DirectDbConnectionFactory : IDirectDbConnectionFactory
    {
        private const string connectionString = "";
        private const string username = "";
        private const string pw = "";

        public DirectDbConnectionFactory()
        {
        }

        public ICustomDbConnection GetInstance()
        {
            OracleCredential oracleCredentials = GetCurrentCredentials();

            var ora = new OracleConnection(connectionString, oracleCredentials);

            var mosaicDirectDatabaseConnection = new DbConnection(ora);

            return mosaicDirectDatabaseConnection;
        }

        private OracleCredential GetCurrentCredentials()
        {
            var securePw = new SecureString();

            foreach (char c in pw)
                securePw.AppendChar(c);

            securePw.MakeReadOnly();

            var oCredential = new OracleCredential(username, securePw);
            return oCredential;
        }
    }
}
