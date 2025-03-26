namespace OrkTravel
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.pb_book = new System.Windows.Forms.PictureBox();
            this.lbl_book = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_cancel_booking = new System.Windows.Forms.Label();
            this.pb_cancel = new System.Windows.Forms.PictureBox();
            this.btn_close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_book)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_cancel)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_book
            // 
            this.pb_book.Image = global::OrkTravel.Properties.Resources.booking1;
            this.pb_book.Location = new System.Drawing.Point(115, 15);
            this.pb_book.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pb_book.Name = "pb_book";
            this.pb_book.Size = new System.Drawing.Size(200, 197);
            this.pb_book.TabIndex = 0;
            this.pb_book.TabStop = false;
            this.pb_book.Click += new System.EventHandler(this.pb_book_Click);
            // 
            // lbl_book
            // 
            this.lbl_book.AutoSize = true;
            this.lbl_book.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbl_book.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_book.Location = new System.Drawing.Point(115, 215);
            this.lbl_book.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_book.Name = "lbl_book";
            this.lbl_book.Padding = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.lbl_book.Size = new System.Drawing.Size(193, 29);
            this.lbl_book.TabIndex = 1;
            this.lbl_book.Text = "Make Booking";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.panel1.Controls.Add(this.lbl_cancel_booking);
            this.panel1.Controls.Add(this.pb_cancel);
            this.panel1.Controls.Add(this.pb_book);
            this.panel1.Controls.Add(this.lbl_book);
            this.panel1.Location = new System.Drawing.Point(136, 154);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(867, 277);
            this.panel1.TabIndex = 2;
            // 
            // lbl_cancel_booking
            // 
            this.lbl_cancel_booking.AutoSize = true;
            this.lbl_cancel_booking.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbl_cancel_booking.ForeColor = System.Drawing.SystemColors.Control;
            this.lbl_cancel_booking.Location = new System.Drawing.Point(556, 215);
            this.lbl_cancel_booking.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_cancel_booking.Name = "lbl_cancel_booking";
            this.lbl_cancel_booking.Padding = new System.Windows.Forms.Padding(13, 0, 13, 0);
            this.lbl_cancel_booking.Size = new System.Drawing.Size(209, 29);
            this.lbl_cancel_booking.TabIndex = 3;
            this.lbl_cancel_booking.Text = "Cancel Booking";
            // 
            // pb_cancel
            // 
            this.pb_cancel.Image = global::OrkTravel.Properties.Resources.cancelBooking;
            this.pb_cancel.Location = new System.Drawing.Point(561, 15);
            this.pb_cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pb_cancel.Name = "pb_cancel";
            this.pb_cancel.Size = new System.Drawing.Size(200, 197);
            this.pb_cancel.TabIndex = 2;
            this.pb_cancel.TabStop = false;
            this.pb_cancel.Click += new System.EventHandler(this.pb_cancel_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.btn_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_close.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_close.Location = new System.Drawing.Point(12, 547);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(100, 60);
            this.btn_close.TabIndex = 9;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1109, 619);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1131, 670);
            this.MinimumSize = new System.Drawing.Size(1131, 670);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrkTravel - Home";
            ((System.ComponentModel.ISupportInitialize)(this.pb_book)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_cancel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_book;
        private System.Windows.Forms.Label lbl_book;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_cancel_booking;
        private System.Windows.Forms.PictureBox pb_cancel;
        private System.Windows.Forms.Button btn_close;
    }
}