// Name: Menzi Hlope
// STDNum: PT2010-0520

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class _Default : System.Web.UI.Page 
{
    static string sConnect = "Provider = Microsoft.ACE.OleDb.12.0; Data Source = |DATADIRECTORY|concert.mdb";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            OleDbConnection odConnect = new OleDbConnection(sConnect);
            odConnect.Open();

            OleDbCommand odCommand = odConnect.CreateCommand();

            odCommand.CommandText = "SELECT COUNT(*) AS [Total] FROM [Ticket]";

            OleDbDataReader QRead = odCommand.ExecuteReader();
            QRead.Read();

            int iCount = (int)QRead["Total"];

            int iTotal = 1000 - iCount;

            lblTickets.Text = iTotal.ToString();
            txtSeat.Focus();
        }
    }
    protected void btnBook_Click(object sender, EventArgs e)
    {
        OleDbConnection odConnect = new OleDbConnection(sConnect);
        odConnect.Open();

        OleDbCommand odCommand = odConnect.CreateCommand();

        odCommand.CommandText = "SELECT * FROM [Ticket] WHERE [SeatNum] = @seat";
        odCommand.Parameters.Add("@seat", OleDbType.Integer).Value = txtSeat.Text;

        OleDbDataReader QRead = odCommand.ExecuteReader();

        if (QRead.HasRows == true)
        {
            lblMessage.Text = "This seat has already been taken. Please choose another one.";
            lblMessage.ForeColor = System.Drawing.Color.Maroon;
        }
        else
        {
            QRead.Close();
            odCommand.Parameters.Clear();

            odCommand.CommandText = "INSERT INTO [Ticket] ([FoodChoice], [SeatNum], [Name]) VALUES (@food, @seat, @name)";
            odCommand.Parameters.Add("@food", OleDbType.VarChar).Value = radFood.SelectedValue;
            odCommand.Parameters.Add("@seat", OleDbType.Integer).Value = txtSeat.Text;
            odCommand.Parameters.Add("@name", OleDbType.VarChar).Value = txtName.Text;

            odCommand.ExecuteNonQuery();

            odCommand.CommandText = "SELECT COUNT(*) AS [Total] FROM [Ticket]";

            QRead = odCommand.ExecuteReader();
            QRead.Read();

            int iCount = (int)QRead["Total"];

            int iTotal = 1000 - iCount;

            lblTickets.Text = iTotal.ToString();
            txtSeat.Focus();

            lblMessage.Text = string.Format("Successfully booked {0} at seat {1}.", txtName.Text, txtSeat.Text);
            lblMessage.ForeColor = System.Drawing.Color.DarkGreen;


        }
    }
}
