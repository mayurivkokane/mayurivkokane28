using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

/// <summary>
/// Summary description for Books_connection
/// </summary>
public class Books_connection
{
  
	public Books_connection()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void insertdata(string qry)
    {
        MySqlConnection con = new MySqlConnection("server=localhost;User Id=root;database=Books;Password=manager1");
        con.Open();
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        try
        {
            cmd.CommandText = qry;
            cmd.ExecuteNonQuery();
            con.Close();

        }
        catch (Exception e)
        {
            e.ToString();

        }
        finally
        {
            con.Dispose();
            cmd.Dispose();
        }

    }
    public DataTable selectdata(string qry)
    {
        DataTable dt = new DataTable();
        MySqlConnection con = new MySqlConnection("server=localhost;User Id=root;database=Books;password=manager1");
        con.Open();
        MySqlCommand cmd = new MySqlCommand();
        MySqlDataReader dr = default(MySqlDataReader);
        cmd.Connection = con;
        try
        {
            cmd.CommandText = qry;
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
        finally
        {
            cmd.Dispose();
            con.Dispose();
        }
        return dt;
    }
    //public void del(string qry)
    //        {
    //            MySqlConnection con = new MySqlConnection("server=localhost;User Id=root;database=Books;password=manager1");
    //            con.Open();
    //    MySqlCommand cmd = new MySqlCommand();
    //    cmd.Connection = con;
    //    try
    //    {
    //   cmd.CommandText = qry;
    //        cmd.ExecuteNonQuery();
    //        con.Close();

    //    }
    //    catch (Exception e)
    //    {
    //        e.ToString();

    //    }
    //    finally
    //    {
    //        con.Dispose();
    //        cmd.Dispose();
    //    }
    //}
    
}