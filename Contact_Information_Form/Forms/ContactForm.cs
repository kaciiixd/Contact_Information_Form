using Contact_Information_Form.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Contact_Information_Form.Utilities;
using System.Resources;
using System.Globalization;
using Contact_Information_Form.Utilities;

namespace Contact_Information_Form
{
    public partial class ContactForm : Form
    {
        public ResourceManagerHelper resourceManagerHelper;
        public JsonExporter jsonExporter;

        public ContactForm()
        {
            InitializeComponent();
            resourceManagerHelper = new ResourceManagerHelper();
            jsonExporter = new JsonExporter(resourceManagerHelper);
        }


        // -----------------------Buttons-----------------------------//
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Retrieve values from form controls
            string name = name_tbox.Text;
            string lastName = lastname_tbox.Text;
            string email = email_tbox.Text;
            string rc = rc_tbox1.Text + "/" + rc_tbox2.Text;
            DateTime birthDate = bDate_pick.Value;
            string gender = gender_combo.SelectedItem?.ToString(); // Use ?. to handle null in case nothing is selected
            string state = state_combo.SelectedItem?.ToString(); // Use ?. to handle null in case nothing is selected
            bool gdprConsent = gdpr_cbox.Checked;

            // Check if GDPR consent checkbox is checked
            if (!gdprConsent)
            {
                // Display an error message or take appropriate action
                resourceManagerHelper.ShowErrorMessage("GDPRError");
                return; // Stop further processing since GDPR consent is required
            }

            // Establish a database connection
            using (SqlConnection connection = new SqlConnection("Data Source=KATIE;Initial Catalog=ContactDb;Integrated Security=True;TrustServerCertificate=True"))
            {
                connection.Open();

                // SQL query with parameters
                string sqlQuery = "INSERT INTO Contacts " +
                    "(Jmeno, Prijmeni, RodneCislo, DatumNarozeni, Pohlavi, Email, StatPrislusnost, GDPRSouhlas) " +
                    "VALUES (@Jmeno, @Prijmeni, @RodneCislo, @DatumNarozeni, @Pohlavi, @Email, @StatPrislusnost, @GDPRSouhlas)";

                // Create and execute the SQL command
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@Jmeno", name);
                    command.Parameters.AddWithValue("@Prijmeni", lastName);
                    command.Parameters.AddWithValue("@RodneCislo", rc);
                    command.Parameters.AddWithValue("@DatumNarozeni", birthDate);
                    command.Parameters.AddWithValue("@Pohlavi", gender);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@StatPrislusnost", state);
                    command.Parameters.AddWithValue("@GDPRSouhlas", gdprConsent);

                    command.ExecuteNonQuery();
                }
            }

            jsonExporter.ExportToJson(name_tbox, lastname_tbox, email_tbox, rc_tbox1, rc_tbox2, bDate_pick, gender_combo, state_combo, gdpr_cbox);

            // Clear form controls
            resourceManagerHelper.ShowErrorMessage("SavedSucces");
            this.Controls.Clear();
            this.InitializeComponent();
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            // Clear form controls
            name_tbox.Clear();
            lastname_tbox.Clear();
            email_tbox.Clear();
            rc_tbox1.Clear();
            rc_tbox2.Clear();
            bDate_pick.Value = DateTime.Now; // Set to default value or any default date
            gender_combo.SelectedIndex = -1; // Deselect the item
            state_combo.SelectedIndex = -1; // Deselect the item
            gdpr_cbox.Checked = false;
        }

        private void lang_cbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (lang_cbox.SelectedIndex)
            {
                case 0:
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("cs");
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("cs");
                    break;
                case 1:
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                    break;
            }

            this.Controls.Clear();
            InitializeComponent();
        }




        private bool ignoreTextChanged = false;

        private void name_tbox_TextChanged(object sender, EventArgs e)
        {
            if (ignoreTextChanged)
            {
                return;
            }

            string enteredName = name_tbox.Text;

            // Check if the entered name contains only letters
            if (!string.IsNullOrWhiteSpace(enteredName) && enteredName.All(char.IsLetter))
            {
                // Name is valid, no need to clear the textbox
            }
            else
            {
                // Display an error message, set the flag to ignore events, and set the text to an empty string
                resourceManagerHelper.ShowErrorMessage("NameLetters");
                ignoreTextChanged = true;
                name_tbox.Text = string.Empty;
                ignoreTextChanged = false;
            }
        }

        private bool ignoreLastNameChanged = false;

        private void lastname_tbox_TextChanged(object sender, EventArgs e)
        {
            if (ignoreLastNameChanged)
            {
                return;
            }

            string enteredLastName = lastname_tbox.Text;

            // Check if the entered last name contains only letters
            if (!string.IsNullOrWhiteSpace(enteredLastName) && enteredLastName.All(char.IsLetter))
            {
                // Last name is valid, no need to clear the textbox
            }
            else
            {
                // Display an error message, set the flag to ignore events, and set the text to an empty string
                resourceManagerHelper.ShowErrorMessage("LastNameLetters");
                ignoreLastNameChanged = true;
                lastname_tbox.Text = string.Empty;
                ignoreLastNameChanged = false;
            }
        }



        // -----------------------E-mail-----------------------------//
        private void email_tbox_Leave(object sender, EventArgs e)
        {
            ValidateEmail();
        }

        private void ValidateEmail()
        {
            string enteredEmail = email_tbox.Text;

            // Check if the entered email is a valid email address
            try
            {
                var addr = new System.Net.Mail.MailAddress(enteredEmail);

                // Email is valid, enable the save button
                saveButton.Enabled = true;
            }
            catch
            {
                // Display an error message or take appropriate action
                resourceManagerHelper.ShowErrorMessage("InvalidEmailError");
                // You may also choose to clear the textbox or set it to a valid default value
                email_tbox.Clear();
                // Disable the save button until a valid email is entered
                saveButton.Enabled = false;
            }
        }




        // -----------------RC & Birth Date & Gender-----------------------//

        RCHelper helper = new RCHelper();

        private bool ignoreRCTextChanged = false;

        private void checkRC_button_Click(object sender, EventArgs e)
        {
            helper.SetDateFromRc(rc_tbox1, rc_tbox2, bDate_pick);
            helper.GenderFromRC(rc_tbox1, gender_combo);
        }

        private void bezRC_cbox_CheckedChanged(object sender, EventArgs e)
        {
            helper.BDateManually(bezRC_cbox, rc_tbox1, rc_tbox2);
        }

        private void bDate_pick_ValueChanged(object sender, EventArgs e)
        {
            helper.SetDateFromRc(rc_tbox1, rc_tbox2, bDate_pick);
        }

        private void gender_combo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        // -----------------------Nationality-----------------------------//
        private void state_combo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        // -----------------------GDPR-----------------------------//
        private void gdpr_cbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void gdpr_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Specify the path to your PDF file
                string pdfFilePath = @"C:\Users\kbedd\iCloudDrive\Desktop apps\Contact_Information_Form\Contact_Information_Form\Resources\GDPR.pdf";

                // Open the default web browser to display the PDF file
                Process.Start(new ProcessStartInfo(pdfFilePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }

}
