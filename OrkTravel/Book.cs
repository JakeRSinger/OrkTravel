using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrkTravel
{
    public partial class Book : Form
    {

        List<string> tourDetails = new List<string> { "", "", "" };

        public Book()
        {
            InitializeComponent();

            UpdateTourFilters();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Close();
            home.Show();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            CapitaliseFields(); // Capitalise fields before validation
            bool isValid = ValidateFields();

            // Format dates to fit with database formatting
            string formattedDob = DateTime.Parse(dtp_dob.Text).ToString("yyyy-MM-dd");
            string formattedDeparture = DateTime.Parse(dtp_departure_date.Text).ToString("yyyy-MM-dd");
            string formattedReturn = DateTime.Parse(dtp_return_date.Text).ToString("yyyy-MM-dd");

            

            if (isValid)
            {
                // Collect traveller details
                List<string> travellerDetails = new List<string>
                {
                    cb_title.Text,
                    txt_forename.Text,
                    txt_surname.Text,
                    formattedDob,
                    txt_addr_1.Text,
                    txt_addr_2.Text,
                    txt_town.Text,
                    mtxt_postcode.Text,
                    txt_email.Text,
                    mtxt_tel_no.Text,
                };

                // Collect tour details
                List<string> tourDetails = new List<string>
                {
                    lbl_tour_code_out.Text,
                    formattedDeparture,
                    formattedReturn,
                    cb_tour_passengers.Text,
                    cb_tour_destination.Text,
                    cb_tour_length.Text,
                    cb_tour_company.Text
                };

                // Collect price details
                List<string> pricingDetails = new List<string>
                {
                    tourPrice.ToString(),
                    vat.ToString(),
                    deposit.ToString(),
                    remaining.ToString(),
                    paid.ToString(),
                    totalPrice.ToString()
                };

                // Pass details to DatabaseHandler
                try
                {
                    DatabaseHandler db = new DatabaseHandler();
                    bool inserted = db.InsertTourDetails(travellerDetails, tourDetails, pricingDetails);

                    if (inserted)
                    {
                        Invoice invoice = new Invoice(travellerDetails, tourDetails, pricingDetails);
                        this.Close();
                        invoice.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Validation
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

            // Validate Date of Birth
            if (dtp_dob.Value >= DateTime.Now.AddYears(-18))
            {
                errorProvider.SetError(dtp_dob, "You must be at least 18 years old.");
                isValid = false;
            }


            // Tour Details

            // Validate Tour Company
            if (cb_tour_company.SelectedIndex == -1)
            {
                errorProvider.SetError(cb_tour_company, "Select a tour company.");
                isValid = false;
            }

            // Validate Tour Destination
            if (cb_tour_destination.SelectedIndex == -1)
            {
                errorProvider.SetError(cb_tour_destination, "Select a destination.");
                isValid = false;
            }

            // Validate Tour Length
            if (cb_tour_length.SelectedIndex == -1)
            {
                errorProvider.SetError(cb_tour_length, "Select a tour length.");
                isValid = false;
            }

            // Validate Tour Date
            if (dtp_departure_date.Value <= DateTime.Now)
            {
                errorProvider.SetError(dtp_departure_date, "You must select a date in the future.");
                isValid = false;
            }

            // Validate Tour Passengers
            if (cb_tour_passengers.SelectedIndex == -1)
            {
                errorProvider.SetError(cb_tour_passengers, "You must select a number of passengers.");
                isValid = false;
            }
            

            return isValid;
        }


        // Fetch tour details
        private bool hasShownNoToursMessage = false;

        // Filter the tours with selections
        private async void UpdateTourFilters()
        {
            DatabaseHandler db = new DatabaseHandler();
            List<Tour> filteredTours = await Task.Run(() => db.UpdateTourDetails(tourDetails));

            if (filteredTours.Any())
            {
                PopulateTourDetails(filteredTours);
                hasShownNoToursMessage = false; // Reset the flag
            }
            else if (!hasShownNoToursMessage)
            {
                hasShownNoToursMessage = true; // Set the flag
                MessageBox.Show("No tours found with the current filters.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear all related ComboBoxes
                cb_tour_company.Items.Clear();
                cb_tour_destination.Items.Clear();
                cb_tour_length.Items.Clear();
            }
        }

        // Event listners to update tours
        private void cb_tour_company_SelectedIndexChanged(object sender, EventArgs e)
        {   

            tourDetails[1] = cb_tour_company.Text;

            UpdateTourFilters();
        }

        private void cb_tour_length_SelectedIndexChanged(object sender, EventArgs e)
        {
            tourDetails[0] = cb_tour_length.Text;

            UpdateReturnDate();
            UpdateTourFilters();
        }

        private void cb_tour_destination_SelectedIndexChanged(object sender, EventArgs e)
        {
            tourDetails[2] = cb_tour_destination.Text;

            UpdateTourFilters();
        }

        // Tour details population
        private void PopulateTourDetails(List<Tour> tours)
        {
            // Preserve current selections
            string selectedCompany = cb_tour_company.Text;
            string selectedDestination = cb_tour_destination.Text;
            string selectedLength = cb_tour_length.Text;

            // Temporarily disable events
            cb_tour_company.SelectedIndexChanged -= cb_tour_company_SelectedIndexChanged;
            cb_tour_destination.SelectedIndexChanged -= cb_tour_destination_SelectedIndexChanged;
            cb_tour_length.SelectedIndexChanged -= cb_tour_length_SelectedIndexChanged;

            // Update ComboBoxes
            cb_tour_company.Items.Clear();
            cb_tour_destination.Items.Clear();
            cb_tour_length.Items.Clear();

            foreach (Tour tour in tours)
            {
                if (!cb_tour_company.Items.Contains(tour.TourCompany))
                    cb_tour_company.Items.Add(tour.TourCompany);

                if (!cb_tour_destination.Items.Contains(tour.TourDestination))
                    cb_tour_destination.Items.Add(tour.TourDestination);

                if (!cb_tour_length.Items.Contains(tour.TourLength))
                    cb_tour_length.Items.Add(tour.TourLength);
            }

            // Restore previous selections if still valid
            cb_tour_company.SelectedItem = cb_tour_company.Items.Contains(selectedCompany) ? selectedCompany : null;
            cb_tour_destination.SelectedItem = cb_tour_destination.Items.Contains(selectedDestination) ? selectedDestination : null;
            cb_tour_length.SelectedItem = cb_tour_length.Items.Contains(selectedLength) ? selectedLength : null;

            // Re-enable events
            cb_tour_company.SelectedIndexChanged += cb_tour_company_SelectedIndexChanged;
            cb_tour_destination.SelectedIndexChanged += cb_tour_destination_SelectedIndexChanged;
            cb_tour_length.SelectedIndexChanged += cb_tour_length_SelectedIndexChanged;

            PricingCalculations(tours);
        }


        // Clear filters
        private void btn_clear_tour_Click(object sender, EventArgs e)
        {
            // Temporarily disable ComboBox events to avoid recursive updates
            cb_tour_company.SelectedIndexChanged -= cb_tour_company_SelectedIndexChanged;
            cb_tour_destination.SelectedIndexChanged -= cb_tour_destination_SelectedIndexChanged;
            cb_tour_length.SelectedIndexChanged -= cb_tour_length_SelectedIndexChanged;

            // Clear the ComboBox selections
            cb_tour_company.SelectedIndex = -1;
            cb_tour_destination.SelectedIndex = -1;
            cb_tour_length.SelectedIndex = -1;
            cb_tour_passengers.SelectedIndex = -1;

            // Set DateTimePickers
            dtp_departure_date.Value = DateTime.Now;
            dtp_return_date.Value = DateTime.Now;

            // Reset the tourDetails list
            tourDetails = new List<string> { "", "", "" };

            // Re-enable ComboBox events
            cb_tour_company.SelectedIndexChanged += cb_tour_company_SelectedIndexChanged;
            cb_tour_destination.SelectedIndexChanged += cb_tour_destination_SelectedIndexChanged;
            cb_tour_length.SelectedIndexChanged += cb_tour_length_SelectedIndexChanged;

            // Refresh the filtered tours
            UpdateTourFilters();

            // Show a confirmation message
            MessageBox.Show("Tour filters cleared.", "Clear Filters", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        // Return date
        private void UpdateReturnDate()
        {
            if (int.TryParse(cb_tour_length.Text, out int tourLength))
            {
                // Add the tour length (in days) to the departure date
                dtp_return_date.Value = dtp_departure_date.Value.AddDays(tourLength);
            }
            else if (cb_tour_length.SelectedIndex == -1) 
            {
                dtp_return_date.Value = dtp_departure_date.Value;
            }
        }


        // Pricing constants
        private const decimal VAT_RATE = 0.20m;
        private const decimal DEPOSIT_RATE = 0.10m;

        // Pricing-related fields
        private string tourCode;
        private decimal tourPrice;
        private decimal vat;
        private decimal totalPrice;
        private decimal deposit;
        private decimal remaining;
        private int paid = 0;

        private void PricingCalculations(List<Tour> tours)
        {
            try
            {
                // Validate input
                if (cb_tour_destination.SelectedIndex == -1
                    || cb_tour_company.SelectedIndex == -1
                    || cb_tour_length.SelectedIndex == -1)
                {
                    Console.WriteLine("Please select all required tour options.");
                    return;
                }

                if (tours == null || tours.Count == 0)
                {
                    Console.WriteLine("No tours available for pricing calculations.");
                    return;
                }

                // Fetch the selected tour
                var selectedTour = tours[0];

                // Extract tour details
                tourCode = selectedTour.TourCode;
                if (!decimal.TryParse(selectedTour.TourPrice, out tourPrice))
                {
                    Console.WriteLine("Invalid tour price format.");
                    return;
                }

                // Perform calculations
                vat = decimal.Round(tourPrice * VAT_RATE, 2);
                totalPrice = tourPrice + vat;
                deposit = decimal.Round(totalPrice * DEPOSIT_RATE, 2);
                remaining = paid == 1 ? totalPrice - deposit : totalPrice;

                // Update UI
                lbl_tour_code_out.Text = tourCode;
                lbl_price_out.Text = FormatCurrency(tourPrice);
                lbl_vat_out.Text = FormatCurrency(vat);
                lbl_total_out.Text = FormatCurrency(totalPrice);
                lbl_deposit_out.Text = FormatCurrency(deposit);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during pricing calculations: {ex.Message}");
            }
        }

        private string FormatCurrency(decimal amount)
        {
            return $"£{amount:F2}";
        }


        private void dtp_departure_date_ValueChanged(object sender, EventArgs e)
        {
            UpdateReturnDate();
        }

        private void ckbx_paid_CheckedChanged(object sender, EventArgs e)
        {
            paid = ckbx_paid.Checked ? 1 : 0;
            UpdateTourFilters();
        }
    }
}

