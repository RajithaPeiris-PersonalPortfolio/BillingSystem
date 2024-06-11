using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CafeManagement;



namespace BillingSystem
{
    public partial class LOGIN : Form
    {
        public LOGIN()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=SD3;Initial Catalog=Seed_Cafe;Integrated Security=True");
        
        private void LOGIN_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username, user_password;

            username = txt_user.Text;
            user_password = txt_pass.Text;
           

            try
            {
                string query = "SELECT * FROM Login_new WHERE username ='"+txt_user.Text+"'AND Password ='"+txt_pass.Text+"'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = txt_user.Text;
                    user_password = txt_pass.Text;

                    // page that needed to be load nex
                    Menuform form1 = new Menuform();
                    form1.Show();
                    this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("Invalid Login details","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txt_user.Clear();
                    txt_pass.Clear();

                    // to focus username
                    txt_user.Focus();


                }
            }
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_user.Clear();
            txt_pass.Clear();

            txt_user.Focus();
        }

        private void txt_user_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
