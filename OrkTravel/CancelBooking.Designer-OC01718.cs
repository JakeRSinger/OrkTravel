namespace OrkTravel
{
    partial class CancelBooking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CancelBooking));
            this.pnl_details = new System.Windows.Forms.Panel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_submit = new System.Windows.Forms.Button();
            this.lbl_heading = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.lbl_password = new System.Windows.Forms.Label();
            this.lbl_booking_id = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.cb_booking_id = new System.Windows.Forms.ComboBox();
            this.lbl_destination = new System.Windows.Forms.Label();
            this.lbl_passengers = new System.Windows.Forms.Label();
            this.lbl_departure = new System.Windows.Forms.Label();
            this.lbl_return = new System.Windows.Forms.Label();
            this.lbl_destination_out = new System.Windows.Forms.Label();
            this.lbl_passengers_out = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtp_departure = new System.Windows.Forms.DateTimePicker();
            this.dtp_return = new System.Windows.Forms.DateTimePicker();
            this.pnl_details.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_details
            // 
            this.pnl_details.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.pnl_details.Controls.Add(this.dtp_return);
            this.pnl_details.Controls.Add(this.dtp_departure);
            this.pnl_details.Controls.Add(this.lbl_passengers_out);
            this.pnl_details.Controls.Add(this.lbl_destination_out);
            this.pnl_details.Controls.Add(this.lbl_return);
            this.pnl_details.Controls.Add(this.lbl_departure);
            this.pnl_details.Controls.Add(this.lbl_passengers);
            this.pnl_details.Controls.Add(this.lbl_destination);
            this.pnl_details.Controls.Add(this.cb_booking_id);
            this.pnl_details.Controls.Add(this.txt_password);
            this.pnl_details.Controls.Add(this.txt_email);
            this.pnl_details.Controls.Add(this.lbl_booking_id);
            this.pnl_details.Controls.Add(this.lbl_password);
            this.pnl_details.Controls.Add(this.lbl_email);
            this.pnl_details.Controls.Add(this.lbl_heading);
            this.pnl_details.Location = new System.Drawing.Point(106, 57);
            this.pnl_details.Name = "pnl_details";
            this.pnl_details.Size = new System.Drawing.Size(627, 347);
            this.pnl_details.TabIndex = 0;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_cancel.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_cancel.Location = new System.Drawing.Point(12, 435);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(100, 60);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            // 
            // btn_submit
            // 
            this.btn_submit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.btn_submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_submit.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_submit.Location = new System.Drawing.Point(718, 435);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(100, 60);
            this.btn_submit.TabIndex = 7;
            this.btn_submit.Text = "Submit";
            this.btn_submit.UseVisualStyleBackColor = false;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // lbl_heading
            // 
            this.lbl_heading.AutoSize = true;
            this.lbl_heading.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.lbl_heading.Location = new System.Drawing.Point(221, 9);
            this.lbl_heading.Name = "lbl_heading";
            this.lbl_heading.Size = new System.Drawing.Size(183, 29);
            this.lbl_heading.TabIndex = 0;
            this.lbl_heading.Text = "Cancel Booking";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Location = new System.Drawing.Point(103, 86);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(62, 24);
            this.lbl_email.TabIndex = 1;
            this.lbl_email.Text = "Email:";
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(103, 131);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(97, 24);
            this.lbl_password.TabIndex = 2;
            this.lbl_password.Text = "Password:";
            // 
            // lbl_booking_id
            // 
            this.lbl_booking_id.AutoSize = true;
            this.lbl_booking_id.Location = new System.Drawing.Point(103, 176);
            this.lbl_booking_id.Name = "lbl_booking_id";
            this.lbl_booking_id.Size = new System.Drawing.Size(106, 24);
            this.lbl_booking_id.TabIndex = 3;
            this.lbl_booking_id.Text = "Booking ID:";
            // 
            // txt_email
            // 
            this.txt_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txt_email.Location = new System.Drawing.Point(211, 82);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(310, 30);
            this.txt_email.TabIndex = 4;
            this.txt_email.TextChanged += new System.EventHandler(this.txt_email_TextChanged);
            // 
            // txt_password
            // 
            this.txt_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txt_password.Location = new System.Drawing.Point(211, 127);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(310, 30);
            this.txt_password.TabIndex = 5;
            // 
            // cb_booking_id
            // 
            this.cb_booking_id.FormattingEnabled = true;
            this.cb_booking_id.Location = new System.Drawing.Point(211, 173);
            this.cb_booking_id.Name = "cb_booking_id";
            this.cb_booking_id.Size = new System.Drawing.Size(310, 32);
            this.cb_booking_id.TabIndex = 6;
            // 
            // lbl_destination
            // 
            this.lbl_destination.AutoSize = true;
            this.lbl_destination.Location = new System.Drawing.Point(16, 250);
            this.lbl_destination.Name = "lbl_destination";
            this.lbl_destination.Size = new System.Drawing.Size(107, 24);
            this.lbl_destination.TabIndex = 7;
            this.lbl_destination.Text = "Destination:";
            // 
            // lbl_passengers
            // 
            this.lbl_passengers.AutoSize = true;
            this.lbl_passengers.Location = new System.Drawing.Point(347, 250);
            this.lbl_passengers.Name = "lbl_passengers";
            this.lbl_passengers.Size = new System.Drawing.Size(114, 24);
            this.lbl_passengers.TabIndex = 8;
            this.lbl_passengers.Text = "Passengers:";
            // 
            // lbl_departure
            // 
            this.lbl_departure.AutoSize = true;
            this.lbl_departure.Location = new System.Drawing.Point(16, 296);
            this.lbl_departure.Name = "lbl_departure";
            this.lbl_departure.Size = new System.Drawing.Size(98, 24);
            this.lbl_departure.TabIndex = 9;
            this.lbl_departure.Text = "Departure:";
            // 
            // lbl_return
            // 
            this.lbl_return.AutoSize = true;
            this.lbl_return.Location = new System.Drawing.Point(347, 296);
            this.lbl_return.Name = "lbl_return";
            this.lbl_return.Size = new System.Drawing.Size(71, 24);
            this.lbl_return.TabIndex = 10;
            this.lbl_return.Text = "Return:";
            // 
            // lbl_destination_out
            // 
            this.lbl_destination_out.AutoSize = true;
            this.lbl_destination_out.Location = new System.Drawing.Point(140, 250);
            this.lbl_destination_out.Name = "lbl_destination_out";
            this.lbl_destination_out.Size = new System.Drawing.Size(100, 24);
            this.lbl_destination_out.TabIndex = 11;
            this.lbl_destination_out.Text = "                  ";
            // 
            // lbl_passengers_out
            // 
            this.lbl_passengers_out.AutoSize = true;
            this.lbl_passengers_out.Location = new System.Drawing.Point(467, 250);
            this.lbl_passengers_out.Name = "lbl_passengers_out";
            this.lbl_passengers_out.Size = new System.Drawing.Size(105, 24);
            this.lbl_passengers_out.TabIndex = 12;
            this.lbl_passengers_out.Text = "                   ";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 0;
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // dtp_departure
            // 
            this.dtp_departure.Enabled = false;
            this.dtp_departure.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_departure.Location = new System.Drawing.Point(120, 296);
            this.dtp_departure.Name = "dtp_departure";
            this.dtp_departure.Size = new System.Drawing.Size(200, 29);
            this.dtp_departure.TabIndex = 13;
            // 
            // dtp_return
            // 
            this.dtp_return.Enabled = false;
            this.dtp_return.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_return.Location = new System.Drawing.Point(424, 292);
            this.dtp_return.Name = "dtp_return";
            this.dtp_return.Size = new System.Drawing.Size(200, 29);
            this.dtp_return.TabIndex = 14;
            // 
            // CancelBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(830, 507);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.pnl_details);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximumSize = new System.Drawing.Size(850, 550);
            this.MinimumSize = new System.Drawing.Size(850, 550);
            this.Name = "CancelBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OrkTravel - Cancel";
            this.pnl_details.ResumeLayout(false);
            this.pnl_details.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_details;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label lbl_booking_id;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Label lbl_heading;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.ComboBox cb_booking_id;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label lbl_passengers_out;
        private System.Windows.Forms.Label lbl_destination_out;
        private System.Windows.Forms.Label lbl_return;
        private System.Windows.Forms.Label lbl_departure;
        private System.Windows.Forms.Label lbl_passengers;
        private System.Windows.Forms.Label lbl_destination;
        private System.Windows.Forms.DateTimePicker dtp_return;
        private System.Windows.Forms.DateTimePicker dtp_departure;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}