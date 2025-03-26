using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrkTravel
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void pb_book_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.Show();
            this.Close();
        }

        private void pb_cancel_Click(object sender, EventArgs e)
        {
            CancelBooking cb = new CancelBooking();
            cb.Show();
            this.Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
