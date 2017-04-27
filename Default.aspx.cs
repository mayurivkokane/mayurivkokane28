using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

public partial class _Default : System.Web.UI.Page 
{
    Books_connection con = new Books_connection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            Bindgriddata();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        con.insertdata("INSERT INTO books(booknm,author,publiher,Price)VALUES('"+TextBox1.Text+"','"+TextBox2.Text+"','"+TextBox3.Text+"','"+TextBox4.Text+"');");
        ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Books Data Inserted Successfully')", true);
        Bindgriddata();
    }
    public void clear_all()
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        TextBox4.Text = "";

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        clear_all();
    }
    public void Bindgriddata()
    {
        DataTable dt = new DataTable();
        dt = con.selectdata("select * from books where flag!=-1");
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        string bookname = (row.FindControl("lblbookName") as Label).Text;
        string author = (row.FindControl("bookauthortxt") as TextBox).Text;
        string publisher = (row.FindControl("bookpublishertxt") as TextBox).Text;
        string price = (row.FindControl("txtprice") as TextBox).Text;
      con.insertdata("update books set author='" + author + "',publiher='" + publisher + "',price='" + price + "' where booknm='" + bookname + "'");
      GridView1.EditIndex =- 1;
      this.Bindgriddata();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        this.Bindgriddata();

    }
    protected void GridView1_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label booknm = GridView1.Rows[e.RowIndex].FindControl("lblbookName") as Label;
        int flag = -1;
        con.insertdata("update books set flag='" + flag + "' where booknm='" + booknm.Text + "'");    
        Bindgriddata();
    }
}