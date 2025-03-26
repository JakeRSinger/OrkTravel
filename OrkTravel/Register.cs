using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OrkTravel
{
    public partial class Register : Form
    {
        Form globalForm;

        public Register(Form passed_form)
        {
            InitializeComponent();
            globalForm = passed_form;
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            CapitaliseFields(); // Capitalise fields before validation
            bool isValid = ValidateFields();

            if (isValid)
            {
                // Collecting registration details
                List<string> regDetails = new List<string>
                {
                    cb_title.Text,
                    txt_forename.Text,
                    txt_surname.Text,
                    dtp_dob.Text,
                    txt_addr_1.Text,
                    txt_addr_2.Text,
                    txt_town.Text,
                    mtxt_postcode.Text,
                    txt_email.Text,
                    mtxt_tel_no.Text,
                    txt_password.Text
                };

                // Pass details to DatabaseHandler
                try
                {
                    DatabaseHandler databaseHandler = new DatabaseHandler();
                    databaseHandler.Register(regDetails);
                    MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    globalForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CapitaliseFields()
        {
            // Capitalise the first letter of Forename, Surname, Address Line 1/2, Town
            txt_forename.Text = CapitaliseFirstLetter(txt_forename.Text);
            txt_surname.Text = CapitaliseFirstLetter(txt_surname.Text);
            txt_addr_1.Text = CapitaliseFirstLetter(txt_addr_1.Text);
            txt_addr_2.Text = CapitaliseFirstLetter(txt_addr_2.Text);
            txt_town.Text = CapitaliseFirstLetter(txt_town.Text);

            // Convert Postcode to uppercase
            mtxt_postcode.Text = mtxt_postcode.Text.ToUpperInvariant();
        }

        private string CapitaliseFirstLetter(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            // Convert the first letter to uppercase and retain the rest
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        private bool ValidateFields()
        {
            bool isValid = true;

            // Reset previous error messages
            errorProvider.Clear();

            // Validate Title
            if (cb_title.SelectedIndex == -1)
            {
                errorProvider.SetError(cb_title, "Please select a title.");
                isValid = false;
            }

            // Validate Forename
            if (string.IsNullOrWhiteSpace(txt_forename.Text))
            {
                errorProvider.SetError(txt_forename, "Forename is required.");
                isValid = false;
            }

            // Validate Surname
            if (string.IsNullOrWhiteSpace(txt_surname.Text))
            {
                errorProvider.SetError(txt_surname, "Surname is required.");
                isValid = false;
            }

            // Validate Address Line 1
            if (string.IsNullOrWhiteSpace(txt_addr_1.Text))
            {
                errorProvider.SetError(txt_addr_1, "Address Line One is required.");
                isValid = false;
            }

            // Validate Town
            if (string.IsNullOrWhiteSpace(txt_town.Text))
            {
                errorProvider.SetError(txt_town, "Town is required.");
                isValid = false;
            }

            // Validate Postcode
            if (!Regex.IsMatch(mtxt_postcode.Text, @"^[A-Z]{1,2}\d{1,2}\s?\d[A-Z]{2}$"))
            {
                errorProvider.SetError(mtxt_postcode, "Invalid postcode format.");
                isValid = false;
            }

            // Validate Phone Number
            if (!Regex.IsMatch(mtxt_tel_no.Text, @"^\d{5}\s?\d{6}$"))
            {
                errorProvider.SetError(mtxt_tel_no, "Invalid phone number format.");
                isValid = false;
            }

            // Validate Email
            if (string.IsNullOrWhiteSpace(txt_email.Text) || !Regex.IsMatch(txt_email.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorProvider.SetError(txt_email, "Invalid email address.");
                isValid = false;
            }

            // Validate Password
            if (string.IsNullOrWhiteSpace(txt_password.Text) || txt_password.Text.Length < 6)
            {
                errorProvider.SetError(txt_password, "Password must be at least 6 characters.");
                isValid = false;
            }

            // Validate Date of Birth
            if (dtp_dob.Value >= DateTime.Now.AddYears(-18))
            {
                errorProvider.SetError(dtp_dob, "You must be at least 18 years old.");
                isValid = false;
            }

            return isValid;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
            globalForm.Show();
        }
    }
}
