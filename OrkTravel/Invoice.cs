using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;
using Org.BouncyCastle.Crypto.Engines;

namespace OrkTravel
{
    public partial class Invoice : Form
    {

        public Invoice(List<string> travellerDetails, List<string> tourDetails, List<string> pricingDetails)
        {
            InitializeComponent();

            SetDetails(travellerDetails, tourDetails, pricingDetails);
        }


        private void SetDetails(List<string> travellerDetails, List<string> tourDetails, List<string> pricingDetails)
        {
            try
            {
                // Set traveller details
                if (travellerDetails.Count >= 10)
                {
                    cb_title.Text = travellerDetails[0];
                    txt_forename.Text = travellerDetails[1];
                    txt_surname.Text = travellerDetails[2];
                    if (DateTime.TryParseExact(travellerDetails[3], "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime dob))
                    {
                        dtp_dob.Value = dob;
                    }
                    txt_addr_1.Text = travellerDetails[4];
                    txt_addr_2.Text = travellerDetails[5];
                    txt_town.Text = travellerDetails[6];
                    mtxt_postcode.Text = travellerDetails[7];
                    txt_email.Text = travellerDetails[8];
                    mtxt_tel_no.Text = travellerDetails[9];
                }

                // Set tour details
                if (tourDetails.Count >= 6)
                {
                    lbl_tour_code_out.Text = tourDetails[0];
                    if (DateTime.TryParseExact(tourDetails[1], "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime departureDate))
                    {
                        dtp_departure_date.Value = departureDate;
                    }
                    if (DateTime.TryParseExact(tourDetails[2], "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime returnDate))
                    {
                        dtp_return_date.Value = returnDate;
                    }
                    cb_tour_passengers.Text = tourDetails[3];
                    cb_tour_destination.Text = tourDetails[4];
                    cb_tour_length.Text = tourDetails[5];
                    cb_tour_company.Text = tourDetails[6];
                }

                // Set pricing details
                if (pricingDetails.Count >= 6)
                {
                    lbl_price_out.Text = pricingDetails[0];
                    lbl_vat_out.Text = pricingDetails[1];
                    lbl_deposit_out.Text = pricingDetails[2];
                    lbl_remaining_out.Text = pricingDetails[3];
                    ckbx_paid.Checked = pricingDetails[4] == "1";
                    lbl_total_out.Text = pricingDetails[5];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while setting details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Close();
            home.Show();
        }


        private void btn_print_Click(object sender, EventArgs e)
        {
            DatabaseHandler db = new DatabaseHandler();
            List<string> invoiceDetails = db.SelectInvoiceDetails(txt_email.Text);

            if (invoiceDetails.Count < 4)
            {
                MessageBox.Show("Insufficient details retrieved for the invoice.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string suggestedFileName = $"{invoiceDetails[0]}_{invoiceDetails[1]}_{invoiceDetails[2]}.xlsx";
            string template = "invoice_template.xlsx";

            // Get the Downloads folder path
            string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";

            // Open a SaveFileDialog for user to choose save location
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = downloadsFolder;
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.*)|*.*";
                saveFileDialog.FileName = suggestedFileName;
                saveFileDialog.Title = "Save Invoice";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        // Ensure the template file exists
                        if (!File.Exists(template))
                        {
                            MessageBox.Show($"Template file '{template}' not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Copy the template to the selected file path
                        File.Copy(template, filePath, overwrite: true);

                        // Open the copied file using ClosedXML
                        using (XLWorkbook workbook = new XLWorkbook(filePath))
                        {
                            var worksheet = workbook.Worksheet(1); // Index 1-based

                            // Traveller Information
                            worksheet.Cell("A1").Value += invoiceDetails[0];
                            worksheet.Cell("B3").Value = cb_title.Text;
                            worksheet.Cell("E3").Value = txt_forename.Text;
                            worksheet.Cell("B4").Value = txt_surname.Text;
                            worksheet.Cell("E4").Value = dtp_dob.Value;
                            worksheet.Cell("C5").Value = txt_addr_1.Text;
                            worksheet.Cell("C6").Value = txt_addr_2.Text;
                            worksheet.Cell("C7").Value = txt_town.Text;
                            worksheet.Cell("C8").Value = mtxt_postcode.Text;
                            worksheet.Cell("C9").Value = txt_email.Text;
                            worksheet.Cell("C10").Value = mtxt_tel_no.Text;


                            // Holiday Information
                            worksheet.Cell("A13").Value += invoiceDetails[2];
                            worksheet.Cell("A16").Value = cb_tour_company.Text;
                            worksheet.Cell("B16").Value = lbl_tour_code_out.Text;
                            worksheet.Cell("C16").Value = Decimal.Parse(lbl_price_out.Text);
                            worksheet.Cell("D16").Value = Int32.Parse(cb_tour_length.Text);
                            worksheet.Cell("E16").Value = cb_tour_destination.Text;
                            worksheet.Cell("F16").Value = Int32.Parse(cb_tour_passengers.Text);
                            worksheet.Cell("G16").Value = dtp_departure_date.Value;
                            worksheet.Cell("H16").Value = dtp_return_date.Value;

                            if (DateTime.TryParseExact(invoiceDetails[1], "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime bookingDate))
                            {
                                worksheet.Cell("I16").Value = bookingDate;
                            }


                            // Cost Information
                            string paid = ckbx_paid.Checked ? "C25" : "E25";

                            worksheet.Cell("A19").Value += invoiceDetails[3];
                            worksheet.Cell("B21").Value = Decimal.Parse(lbl_price_out.Text);
                            worksheet.Cell("B22").Value = Decimal.Parse(lbl_vat_out.Text);
                            worksheet.Cell("B23").Value = Decimal.Parse(lbl_total_out.Text);
                            worksheet.Cell("B24").Value = Decimal.Parse(lbl_deposit_out.Text);
                            worksheet.Cell(paid).Value = "X";
                            worksheet.Cell("B26").Value = Decimal.Parse(lbl_remaining_out.Text);

                            worksheet.Column("A").Width = 20;
                            worksheet.Column("B").Width = 10;
                            worksheet.Column("C").Width = 10;
                            worksheet.Column("D").Width = 15;
                            worksheet.Column("E").Width = 12;
                            worksheet.Column("F").Width = 12;
                            worksheet.Column("G").Width = 18;
                            worksheet.Column("H").Width = 18;
                            worksheet.Column("I").Width = 18;

                            workbook.Save();
                        }

                        MessageBox.Show($"Invoice saved successfully at {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


    }
}
