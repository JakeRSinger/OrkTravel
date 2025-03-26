using DocumentFormat.OpenXml.Wordprocessing;
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

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            // Close current form and open Home form
            Home home = new Home();
            home.Show();            
            this.Close();
        }

        private bool ValidateFields()
        {
            bool isValid = true;

            // Reset previous error messages
            errorProvider.Clear();

            // Validate Email
            if (string.IsNullOrWhiteSpace(txt_email.Text) || !Regex.IsMatch(txt_email.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorProvider.SetError(txt_email, "Invalid email address.");
                isValid = false;
            }

            // Validate Password
            if (string.IsNullOrWhiteSpace(txt_password.Text) || !UserAuth())
            {
                errorProvider.SetError(txt_password, "Valid password is required.");
                isValid = false;
            }

            // Validate Booking ID
            if (cb_booking_id.SelectedIndex == -1 || cb_booking_id.Text == "No Booking IDs found with this email.")
            {
                errorProvider.SetError(cb_booking_id, "Select a valid booking ID.");
                isValid = false;
            }

            if (dtp_departure.Value < DateTime.Today.AddDays(1))
            {
                errorProvider.SetError(cb_booking_id, "Tour must be in future to cancel.");
                isValid = false;
            }

            return isValid;
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if (ValidateFields() && UserAuth())
            {
                try
                {
                    string bookingID = cb_booking_id.Text;

                    DatabaseHandler db = new DatabaseHandler();

                    bool cancelled = db.CancelBooking(bookingID);

                    if (cancelled)
                    {
                        MessageBox.Show("Cancellation Successful.");
                        ResetForm();
                    }
                    else
                    {
                        MessageBox.Show("Cancellation Unsuccessful. Try Again Later.");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while cancelling the booking: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ResetForm()
        {
            txt_email.Clear();
            txt_password.Clear();
            cb_booking_id.Items.Clear();
            cb_booking_id.SelectedIndex = -1;
            lbl_destination_out.Text = string.Empty;
            lbl_passengers_out.Text = string.Empty;
            dtp_departure.Value = DateTime.Now;
            dtp_return.Value = DateTime.Now;
        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {
            GetBookings();
        }

        private void GetBookings()
        {
            string email = txt_email.Text.Trim();
            const string noIDs = "No Booking IDs found with this email.";

            if (!UserAuth())
            {
                cb_booking_id.Items.Clear();
                return;
            }

            try
            {
                DatabaseHandler db = new DatabaseHandler();
                List<string> bookingIDs = db.FetchBookings(email);

                cb_booking_id.Items.Clear();
                if (bookingIDs != null && bookingIDs.Any())
                {
                    cb_booking_id.Items.AddRange(bookingIDs.ToArray());
                }
                else
                {
                    cb_booking_id.Items.Add(noIDs);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching booking IDs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cb_booking_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bookingID = cb_booking_id.Text;

            if (!UserAuth())
            {
                cb_booking_id.Items.Clear();
                return;
            }

            try
            {
                DatabaseHandler db = new DatabaseHandler();
                List<string> tourDetails = db.FetchCancelTourDetails(bookingID);

                if (tourDetails != null && tourDetails.Count >= 4)
                {
                    lbl_destination_out.Text = tourDetails[0];
                    lbl_passengers_out.Text = tourDetails[1];

                    if (DateTime.TryParseExact(tourDetails[2], "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime departureDate))
                    {
                        dtp_departure.Value = departureDate;
                    }

                    if (DateTime.TryParseExact(tourDetails[3], "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime returnDate))
                    {
                        dtp_return.Value = returnDate;
                    }
                }
                else
                {
                    MessageBox.Show("No details found for the selected booking ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching tour details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool UserAuth()
        {

            DatabaseHandler db = new DatabaseHandler();
            LoginDetails myDetails = db.Login(txt_email.Text, txt_password.Text);

            return myDetails.loginAuth;

        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            GetBookings();
        }
    }
}
