using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Contact_Information_Form.Models;
using Newtonsoft.Json;

namespace Contact_Information_Form.Utilities
{
    // This class provides functionality to export contact information to a JSON file.
    public class JsonExporter
    {
        private readonly ResourceManagerHelper resourceManagerHelper;

        // Constructor to initialize an instance of JsonExporter with a ResourceManagerHelper
        public JsonExporter(ResourceManagerHelper resourceManagerHelper)
        {
            this.resourceManagerHelper = resourceManagerHelper;
        }

        // Method to export contact information to a JSON file
        public void ExportToJson(TextBox nameTextBox, TextBox lastNameTextBox, TextBox emailTextBox, TextBox rcTextBox1, TextBox rcTextBox2, DateTimePicker birthDatePicker, ComboBox genderComboBox, ComboBox stateComboBox, CheckBox gdprCheckBox)
        {
            try
            {
                // Create a Contact object from the current form's data
                Contact currentContact = CreateContactFromFormData(nameTextBox, lastNameTextBox, emailTextBox, rcTextBox1, rcTextBox2, birthDatePicker, genderComboBox, stateComboBox, gdprCheckBox);

                // Specify the file path for the JSON file, using the last name as the file name
                string fileName = $"{currentContact.Name}-{currentContact.LastName}.json";
                string folderPath = @"C:\Users\kbedd\iCloudDrive\Desktop apps\Contact_Information_Form\Contact_Information_Form\json";
                string filePath = Path.Combine(folderPath, fileName);

                // Serialize the single contact to JSON and write to the file
                string jsonData = JsonConvert.SerializeObject(currentContact, Formatting.Indented);
                File.WriteAllText(filePath, jsonData);

                // Show success message using ResourceManagerHelper
                this.resourceManagerHelper.ShowErrorMessage("JSONSuccess");

                // Open the folder containing the saved JSON file in File Explorer
                Process.Start("explorer.exe", folderPath);

                // Open the file with the default text editor (Notepad)
                Process.Start("notepad.exe", filePath);
            }
            catch (Exception ex)
            {
                // Show an error message if export fails
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Create a Contact object from the current form's data
        public Contact CreateContactFromFormData(TextBox nameTextBox, TextBox lastNameTextBox, TextBox emailTextBox, TextBox rcTextBox1, TextBox rcTextBox2, DateTimePicker birthDatePicker, ComboBox genderComboBox, ComboBox stateComboBox, CheckBox gdprCheckBox)
        {
            // Extract data from form controls
            string name = nameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string email = emailTextBox.Text;
            string rc = rcTextBox1.Text + "/" + rcTextBox2.Text;
            DateTime birthDate = birthDatePicker.Value;
            string gender = genderComboBox.SelectedItem?.ToString();
            string state = stateComboBox.SelectedItem?.ToString();
            bool gdprConsent = gdprCheckBox.Checked;

            // Create a new Contact instance with the form's data
            Contact contact = new Contact(name, lastName, email, rc, birthDate, gender, state, gdprConsent);

            return contact;
        }
    }
}
