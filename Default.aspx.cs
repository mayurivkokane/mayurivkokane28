using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string str = "44-893547-1";

        string str1="448-935-471";

        string[] str3 =str.Split('-');
        string str4 = str3[0];
        string str5 = str3[1];
        string str6 = str3[2];
        string strop2 = "";

        string strop3 = "";
        
         str4 +=str5[0];
       
         str4 += '-';


         for (int i = 1; i < 4; i++)
         {
             strop2 += str5[i];
         }


         strop2 += '-';

         for (int i =4 ; i <6 ; i++)
         {
             strop3 += str5[i];
         }

         strop3 += str6[0];



         Label1.Text = str4 + strop2 + strop3;
      
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string str = "44-4555-55";
        string str1 = "444-55-55";
        string[] str2 = str.Split('-');
        string str3 = str2[0];
        string str4 = str2[1];
        string str5 = str2[2];
        string strop2 = "";
        string strop3 = "";
        str3 += str4[0];
        str3 += ('-');

        for (int i = 2; i < 4; i++)
        {

            strop2 += str4[i];
        }
        strop2 += ('-');


        for (int i = 6; i < 5; i++)
        {
            strop3 += str4[i];
        }

        
        Label2.Text = str3 + strop2 + str5;


    }
}