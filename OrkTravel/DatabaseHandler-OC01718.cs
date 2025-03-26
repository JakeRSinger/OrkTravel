using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrkTravel
{
    internal class DatabaseHandler
    {
        string connectionString = "server=comp-server.uhi.ac.uk;uid=IN21011375;pwd=21011375;database=IN21011375";
        MySqlConnection conn;
        

        public LoginDetails Login(string username, string password)
        {
            using (conn = new MySqlConnection(connectionString)) 
            {
                try
                {
                    conn.Open();

                    // Change command once database is created
                    MySqlCommand cmd = new MySqlCommand("SELECT traveller_id FROM ot_traveller WHERE traveller_email = @username AND traveller_password = @password;", conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    LoginDetails details;

                    if (reader.HasRows)
                    {
                        reader.Read();
                        details = new LoginDetails(true, reader.GetInt32(0).ToString());
                    }
                    else
                    {
                        details = new LoginDetails(false, "Username And Password Incorrect.");
                    }

                    reader.Close();
                    conn.Close();
                    return details;
                }
                catch (Exception ex)
                {
                    conn.Close();
                    return new LoginDetails(false, ex.Message);
                }
            }
        }

        public bool Register(List<string> regDetails)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Format the date to YYYY-MM-DD
                    string formattedDob = DateTime.Parse(regDetails[3]).ToString("yyyy-MM-dd");

                    // Insert query
                    string query = @"
                        INSERT INTO ot_traveller
                        (traveller_title, traveller_forename, traveller_surname, traveller_dob, traveller_addr_1, traveller_addr_2, traveller_town, traveller_postcode, traveller_email, traveller_tel_no, traveller_password) 
                        VALUES 
                        (@title, @forename, @surname, @dob, @address1, @address2, @town, @postcode, @email, @phone, @password);";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@title", regDetails[0]);
                    cmd.Parameters.AddWithValue("@forename", regDetails[1]);
                    cmd.Parameters.AddWithValue("@surname", regDetails[2]);
                    cmd.Parameters.AddWithValue("@dob", formattedDob);
                    cmd.Parameters.AddWithValue("@address1", regDetails[4]);
                    cmd.Parameters.AddWithValue("@address2", regDetails[5]);
                    cmd.Parameters.AddWithValue("@town", regDetails[6]);
                    cmd.Parameters.AddWithValue("@postcode", regDetails[7]);
                    cmd.Parameters.AddWithValue("@email", regDetails[8]);
                    cmd.Parameters.AddWithValue("@phone", regDetails[9]);
                    cmd.Parameters.AddWithValue("@password", regDetails[10]);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return false;
                }
            }
        }

        public List<Tour> UpdateTourDetails(List<string> tourDetails)
        {
            if (tourDetails == null || tourDetails.Count < 3)
                throw new ArgumentException("tourDetails must contain at least 3 elements.");

            List<Tour> tourList = new List<Tour>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT * 
                             FROM ot_tour
                             WHERE tour_length LIKE CONCAT('%', @length, '%')
                             AND tour_company LIKE CONCAT('%', @company, '%')
                             AND tour_destination LIKE CONCAT('%', @destination, '%');";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@length", tourDetails[0]);
                    cmd.Parameters.AddWithValue("@company", tourDetails[1]);
                    cmd.Parameters.AddWithValue("@destination", tourDetails[2]);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Tour tour = new Tour
                            {
                                TourCompany = reader["tour_company"].ToString(),
                                TourCode = reader["tour_code"].ToString(),
                                TourLength = reader["tour_length"].ToString(),
                                TourDestination = reader["tour_destination"].ToString(),
                                TourPrice = reader["tour_price"].ToString()
                            };

                            tourList.Add(tour);
                        }
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    Console.WriteLine($"An error occurred: {ex.Message}");

                }
            }

            return tourList;
        }


        public bool InsertTourDetails(List<string> traveller, List<string> tour, List<string> price)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    int travellerId;

                    // Verify traveller and get ID
                    string verifyTravellerQuery = "SELECT traveller_id FROM ot_traveller WHERE traveller_email = @Email;";
                    using (MySqlCommand cmd = new MySqlCommand(verifyTravellerQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", traveller[8]);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                Console.WriteLine("User not verified.");
                                return false;
                            }
                            travellerId = Convert.ToInt32(reader["traveller_id"]);
                        }
                    }

                    // Insert booking
                    string insertBookingQuery = @"
                                                INSERT INTO ot_booking (booking_tour_id, booking_people, booking_departure, booking_return)
                                                VALUES (@TourId, @People, @Departure, @Return);
                                                SELECT LAST_INSERT_ID();";

                    int bookingId;
                    using (MySqlCommand bookingCmd = new MySqlCommand(insertBookingQuery, conn))
                    {
                        bookingCmd.Parameters.AddWithValue("@TourId", tour[0]);
                        bookingCmd.Parameters.AddWithValue("@People", tour[3]);
                        bookingCmd.Parameters.AddWithValue("@Departure", tour[1]);
                        bookingCmd.Parameters.AddWithValue("@Return", tour[2]);
                        bookingId = Convert.ToInt32(bookingCmd.ExecuteScalar());
                    }

                    // Insert into traveller_booking
                    string insertTravellerBookingQuery = @"
                                                        INSERT INTO ot_traveller_booking (tb_traveller_id, tb_booking_id)
                                                        VALUES (@TravellerId, @BookingId);";

                    using (MySqlCommand tbCmd = new MySqlCommand(insertTravellerBookingQuery, conn))
                    {
                        tbCmd.Parameters.AddWithValue("@TravellerId", travellerId);
                        tbCmd.Parameters.AddWithValue("@BookingId", bookingId);
                        tbCmd.ExecuteNonQuery();
                    }

                    // Insert pricing
                    string insertPricingQuery = @"
                                                INSERT INTO ot_cost (cost_holiday_cost, cost_vat, cost_deposit, cost_remaining, cost_deposit_paid, cost_booking_id)
                                                VALUES (@Cost, @VAT, @Deposit, @Remaining, @Paid, @BookingId);";

                    using (MySqlCommand pricingCmd = new MySqlCommand(insertPricingQuery, conn))
                    {
                        pricingCmd.Parameters.AddWithValue("@Cost", price[0]);
                        pricingCmd.Parameters.AddWithValue("@VAT", price[1]);
                        pricingCmd.Parameters.AddWithValue("@Deposit", price[2]);
                        pricingCmd.Parameters.AddWithValue("@Remaining", price[3]);
                        pricingCmd.Parameters.AddWithValue("@Paid", price[4]);
                        pricingCmd.Parameters.AddWithValue("@BookingId", bookingId);
                        pricingCmd.ExecuteNonQuery();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        public List<string> SelectInvoiceDetails(string email)
        {
            List<string> result = new List<string>();

            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email parameter is null or empty.");
                return result;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"SELECT ot_traveller.traveller_id, ot_traveller_booking.tb_booking_date, 
                                    ot_booking.booking_id, ot_cost.cost_id
                                    FROM ot_traveller
                                    JOIN ot_traveller_booking ON ot_traveller.traveller_id = ot_traveller_booking.tb_traveller_id
                                    JOIN ot_booking ON ot_traveller_booking.tb_booking_id = ot_booking.booking_id
                                    JOIN ot_cost ON ot_booking.booking_id = ot_cost.cost_booking_id
                                    WHERE ot_traveller.traveller_email = @Email
                                    ORDER BY ot_booking.booking_id DESC
                                    LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Add all selected fields to the result list
                                result.Add(reader.GetInt32("traveller_id").ToString());
                                result.Add(reader.GetDateTime("tb_booking_date").ToString("yyyy-MM-dd"));
                                result.Add(reader.GetInt32("booking_id").ToString());
                                result.Add(reader.GetInt32("cost_id").ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return result;
        }

        public List<int> SelectBookingId(string email)
        {
            List<int> result = new List<int>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {

                conn.Open();

                try
                {
                    string query = @"SELECT tb_booking_id 
                                    FROM ot_traveller_booking 
                                    JOIN ot_traveller 
                                    ON ot_traveller.traveller_id = ot_traveller_booking.tb_traveller_id
                                    WHERE ot_traveller.traveller_email = '@email';";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.ExecuteReader();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Add to the result list
                            result.Add(reader.GetInt32("traveller_id"));
                        }
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine($"An error occurred fetching booking IDs: {ex.Message}");
                }
             
            }

            return result;
        }

        public bool DeleteBooking(int bookingId)
        {
            bool cancelled = false;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string travellerQuery = @"SELECT tb_traveller_id FROM ot_traveller_booking WHERE tb_booking_id = @BookingID";
                MySqlCommand cmd = new MySqlCommand( travellerQuery, conn);

                

                // FINISH THIS!!!====================================================================================
            }

            return cancelled;
        }

    }
}
