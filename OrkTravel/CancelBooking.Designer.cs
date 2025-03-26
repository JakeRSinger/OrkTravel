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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtp_return = new System.Windows.Forms.DateTimePicker();
            this.dtp_departure = new System.Windows.Forms.DateTimePicker();
            this.lbl_passengers_out = new System.Windows.Forms.Label();
            this.lbl_destination_out = new System.Windows.Forms.Label();
            this.lbl_return = new System.Windows.Forms.Label();
            this.lbl_departure = new System.Windows.Forms.Label();
            this.lbl_passengers = new System.Windows.Forms.Label();
            this.lbl_destination = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.cb_booking_id = new System.Windows.Forms.ComboBox();
            this.lbl_booking_id = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.lbl_password = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.btn_submit = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.panel1.Controls.Add(this.dtp_return);
            this.panel1.Controls.Add(this.dtp_departure);
            this.panel1.Controls.Add(this.lbl_passengers_out);
            this.panel1.Controls.Add(this.lbl_destination_out);
            this.panel1.Controls.Add(this.lbl_return);
            this.panel1.Controls.Add(this.lbl_departure);
            this.panel1.Controls.Add(this.lbl_passengers);
            this.panel1.Controls.Add(this.lbl_destination);
            this.panel1.Controls.Add(this.lbl_title);
            this.panel1.Controls.Add(this.cb_booking_id);
            this.panel1.Controls.Add(this.lbl_booking_id);
            this.panel1.Controls.Add(this.txt_password);
            this.panel1.Controls.Add(this.txt_email);
            this.panel1.Controls.Add(this.lbl_password);
            this.panel1.Controls.Add(this.lbl_email);
            this.panel1.Location = new System.Drawing.Point(80, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 367);
            this.panel1.TabIndex = 0;
            // 
            // dtp_return
            // 
            this.dtp_return.Enabled = false;
            this.dtp_return.Location = new System.Drawing.Point(457, 306);
            this.dtp_return.Name = "dtp_return";
            this.dtp_return.Size = new System.Drawing.Size(200, 29);
            this.dtp_return.TabIndex = 20;
            // 
            // dtp_departure
            // 
            this.dtp_departure.Enabled = false;
            this.dtp_departure.Location = new System.Drawing.Point(120, 307);
            this.dtp_departure.Name = "dtp_departure";
            this.dtp_departure.Size = new System.Drawing.Size(200, 29);
            this.dtp_departure.TabIndex = 19;
            // 
            // lbl_passengers_out
            // 
            this.lbl_passengers_out.AutoSize = true;
            this.lbl_passengers_out.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_passengers_out.Location = new System.Drawing.Point(453, 255);
            this.lbl_passengers_out.Name = "lbl_passengers_out";
            this.lbl_passengers_out.Size = new System.Drawing.Size(115, 24);
            this.lbl_passengers_out.TabIndex = 18;
            this.lbl_passengers_out.Text = "                     ";
            // 
            // lbl_destination_out
            // 
            this.lbl_destination_out.AutoSize = true;
            this.lbl_destination_out.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_destination_out.Location = new System.Drawing.Point(116, 255);
            this.lbl_destination_out.Name = "lbl_destination_out";
            this.lbl_destination_out.Size = new System.Drawing.Size(115, 24);
            this.lbl_destination_out.TabIndex = 17;
            this.lbl_destination_out.Text = "                     ";
            // 
            // lbl_return
            // 
            this.lbl_return.AutoSize = true;
            this.lbl_return.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_return.Location = new System.Drawing.Point(333, 311);
            this.lbl_return.Name = "lbl_return";
            this.lbl_return.Size = new System.Drawing.Size(71, 24);
            this.lbl_return.TabIndex = 16;
            this.lbl_return.Text = "Return:";
            // 
            // lbl_departure
            // 
            this.lbl_departure.AutoSize = true;
            this.lbl_departure.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_departure.Location = new System.Drawing.Point(3, 311);
            this.lbl_departure.Name = "lbl_departure";
            this.lbl_departure.Size = new System.Drawing.Size(98, 24);
            this.lbl_departure.TabIndex = 15;
            this.lbl_departure.Text = "Departure:";
            // 
            // lbl_passengers
            // 
            this.lbl_passengers.AutoSize = true;
            this.lbl_passengers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_passengers.Location = new System.Drawing.Point(333, 255);
            this.lbl_passengers.Name = "lbl_passengers";
            this.lbl_passengers.Size = new System.Drawing.Size(114, 24);
            this.lbl_passengers.TabIndex = 14;
            this.lbl_passengers.Text = "Passengers:";
            // 
            // lbl_destination
            // 
            this.lbl_destination.AutoSize = true;
            this.lbl_destination.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_destination.Location = new System.Drawing.Point(3, 255);
            this.lbl_destination.Name = "lbl_destination";
            this.lbl_destination.Size = new System.Drawing.Size(107, 24);
            this.lbl_destination.TabIndex = 13;
            this.lbl_destination.Text = "Destination:";
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.lbl_title.Location = new System.Drawing.Point(243, 17);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(204, 31);
            this.lbl_title.TabIndex = 12;
            this.lbl_title.Text = "Cancel Booking";
            // 
            // cb_booking_id
            // 
            this.cb_booking_id.FormattingEnabled = true;
            this.cb_booking_id.Location = new System.Drawing.Point(267, 171);
            this.cb_booking_id.Name = "cb_booking_id";
            this.cb_booking_id.Size = new System.Drawing.Size(254, 32);
            this.cb_booking_id.TabIndex = 11;
            this.cb_booking_id.SelectedIndexChanged += new System.EventHandler(this.cb_booking_id_SelectedIndexChanged);
            // 
            // lbl_booking_id
            // 
            this.lbl_booking_id.AutoSize = true;
            this.lbl_booking_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_booking_id.Location = new System.Drawing.Point(159, 174);
            this.lbl_booking_id.Name = "lbl_booking_id";
            this.lbl_booking_id.Size = new System.Drawing.Size(106, 24);
            this.lbl_booking_id.TabIndex = 10;
            this.lbl_booking_id.Text = "Booking ID:";
            // 
            // txt_password
            // 
            this.txt_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txt_password.Location = new System.Drawing.Point(267, 131);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(254, 29);
            this.txt_password.TabIndex = 9;
            this.txt_password.TextChanged += new System.EventHandler(this.txt_password_TextChanged);
            // 
            // txt_email
            // 
            this.txt_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txt_email.Location = new System.Drawing.Point(267, 90);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(254, 29);
            this.txt_email.TabIndex = 8;
            this.txt_email.TextChanged += new System.EventHandler(this.txt_email_TextChanged);
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_password.Location = new System.Drawing.Point(159, 136);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(97, 24);
            this.lbl_password.TabIndex = 7;
            this.lbl_password.Text = "Password:";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_email.Location = new System.Drawing.Point(159, 95);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(62, 24);
            this.lbl_email.TabIndex = 6;
            this.lbl_email.Text = "Email:";
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
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_cancel.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_cancel.Location = new System.Drawing.Point(12, 435);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(100, 60);
            this.btn_cancel.TabIndex = 8;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 0;
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // CancelBooking
            // 
            this.AcceptButton = this.btn_submit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(830, 507);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(850, 550);
            this.MinimumSize = new System.Drawing.Size(850, 550);
            this.Name = "CancelBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrkTravel - Cancel";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cb_booking_id;
        private System.Windows.Forms.Label lbl_booking_id;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Label lbl_return;
        private System.Windows.Forms.Label lbl_departure;
        private System.Windows.Forms.Label lbl_passengers;
        private System.Windows.Forms.Label lbl_destination;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_passengers_out;
        private System.Windows.Forms.Label lbl_destination_out;
        private System.Windows.Forms.DateTimePicker dtp_return;
        private System.Windows.Forms.DateTimePicker dtp_departure;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label lbl_email;
    }
}