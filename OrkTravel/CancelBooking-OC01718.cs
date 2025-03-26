using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrkTravel
{
    public partial class CancelBooking : Form
    {
        public CancelBooking()
        {
            InitializeComponent();
        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            DatabaseHandler db = new DatabaseHandler();
            List<int> bookingIDs = db.SelectBookingId(txt_email.Text);
            PopulateBookingIDs(bookingIDs);
        }

        private bool ValidateFields()
        {
            bool isValid = true;

            errorProvider.Clear();

            // Validate Email
            if (string.IsNullOrWhiteSpace(txt_email.Text) || !Regex.IsMatch(txt_email.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorProvider.SetError(txt_email, "Invalid email address.");
                isValid = false;
            }

            if (string.IsNullOrEmpty (txt_password.Text) )
            {
                errorProvider.SetError(txt_password, "Invalid password.");
                isValid = false;
            }

            if (cb_booking_id.SelectedIndex == -1)
            {
                errorProvider.SetError(cb_booking_id, "Select an ID.");
                isValid = false;
            }

            if (cb_booking_id.Text == "No Booking IDs Found.")
            {
                errorProvider.SetError(cb_booking_id, "No Booking IDs Found.");
            }

            return isValid;
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                DatabaseHandler db = new DatabaseHandler();
                LoginDetails myDetails = db.Login(txt_email.Text, txt_password.Text);

                if (myDetails.loginAuth)
                {
                    bool cancelled = db.DeleteBooking(Int32.Parse(cb_booking_id.SelectedValue.ToString()));
                }
            }
        }

        private void PopulateBookingIDs(List<int> bookingIDs)
        {
            cb_booking_id.Items.Clear();

            if (bookingIDs.Count > 0)
            {
                foreach (int bookingID in bookingIDs)
                {
                    cb_booking_id.Items.Add(bookingID);
                }
            }
            else
            {
                cb_booking_id.Items.Add("No Booking IDs Found.");
            }
        }
    }
}
