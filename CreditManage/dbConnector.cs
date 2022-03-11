using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CreditManage
{
   // Database Connection  
public class dbConnector  
{  
private SqlConnection SqlConn = null;

    public SqlConnection GetConnection
    {
        get { return SqlConn; }
        set { SqlConn = value; }
    }

    public dbConnector()
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString;
        SqlConn = new SqlConnection(ConnectionString);
    }
}  
}