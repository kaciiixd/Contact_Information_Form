using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Runtime.ConstrainedExecution;

namespace Contact_Information_Form.Utilities
{
    // Helper class for handling and validating information related to 'rc'
    public class RCHelper
    {
        // Flag to ignore 'rc' TextBox TextChanged events during certain operations
        private bool ignoreRCTextChanged = false;

        // Helper class for managing resources (error messages)
        private ResourceManagerHelper resourceManagerHelper;

        // Constructor initializes the resource manager helper
        public RCHelper()
        {
            resourceManagerHelper = new ResourceManagerHelper();
        }

        // Method to validate input in 'rc' TextBoxes
        public bool ValidateInputs(TextBox rc_tbox1, TextBox rc_tbox2)
        {
            // Extract text from TextBoxes
            string rc1 = rc_tbox1.Text;
            string rc2 = rc_tbox2.Text;

            // Check for empty input
            if (string.IsNullOrWhiteSpace(rc1) || string.IsNullOrWhiteSpace(rc2))
            {
                resourceManagerHelper.ShowErrorMessage("EmptyInputError");
                ClearForm(rc_tbox1);
                ClearForm(rc_tbox2);
                return false;
            }

            // Check for non-numeric input
            if (!rc1.All(char.IsDigit) || !rc2.All(char.IsDigit))
            {
                resourceManagerHelper.ShowErrorMessage("NonNumericError");
                ClearForm(rc_tbox1);
                ClearForm(rc_tbox2);
                return false;
            }

            // Check for valid input length
            if (rc1.Length != 6 || (rc2.Length != 3 && rc2.Length != 4))
            {
                resourceManagerHelper.ShowErrorMessage("InvalidLengthError");
                ClearForm(rc_tbox1);
                ClearForm(rc_tbox2);
                return false;
            }
            // If all validation passes, return true
            return true;
        }

        // Method to clear the content of a TextBox and temporarily ignore its TextChanged events
        public void ClearForm(TextBox textBox)
        {
            // Set flag to ignore TextChanged events temporarily
            ignoreRCTextChanged = true;

            // Clear the content of the TextBox
            textBox.Clear();

            // Reset the flag after clearing
            ignoreRCTextChanged = false;
        }

        // Method to execute various methods based on 'rc' TextBoxes and other UI elements
        public void ExecuteMethods(TextBox rc_tbox1, TextBox rc_tbox2, DateTimePicker bDate_pick, CheckBox bezRC_cbox, ComboBox gender_combo)
        {
            // Validate 'rc' TextBox inputs; stop further execution if validation fails
            if (!ValidateInputs(rc_tbox1, rc_tbox2))
            {
                return;
            }

            // Set the date value from 'rc' TextBoxes to the DateTimePicker
            SetDateFromRc(rc_tbox1, rc_tbox2, bDate_pick);

            // Perform additional logic related to 'bezRC_cbox', 'rc' TextBoxes, and 'gender_combo'
            BDateManually(bezRC_cbox, rc_tbox1, rc_tbox2);
            GenderFromRC(rc_tbox1, gender_combo);
        }


        public void SetDateFromRc(TextBox rc_tbox1, TextBox rc_tbox2, DateTimePicker bDate_pick)
        {
            // Validate 'rc' TextBox inputs; stop further execution if validation fails
            if (!ValidateInputs(rc_tbox1, rc_tbox2))
            {
                return;
            }

            // Extract 'rc' values from TextBoxes
            string rc1 = rc_tbox1.Text;
            string rc2 = rc_tbox2.Text;

            // Extract year, month, and day components from 'rc1'
            string yearStr = rc1.Substring(0, 2);
            string monthStr = rc1.Substring(2, 2);
            string dayStr = rc1.Substring(4, 2);

            // Convert components to integers
            int year = Convert.ToInt32(yearStr);
            int month = Convert.ToInt32(monthStr);
            int day = Convert.ToInt32(dayStr);

            // Adjust the year based on the condition
            if (year < 54)
            {
                // Check the length of 'rc2'
                if (rc2.Length == 4)
                {
                    // Adjust the year for the specified condition
                    year += 2000;

                    // Validate month and day
                    if (month >= 1 && month <= 12)
                    {
                        if (day >= 1 && day <= DateTime.DaysInMonth(year, month))
                        {
                            // Parse the values and set the value of bDate_pick
                            bDate_pick.Value = new DateTime(year, month, day);
                        }
                        else
                        {
                            resourceManagerHelper.ShowErrorMessage("InvalidDayError");
                            ClearForm(rc_tbox1);
                        }
                    }
                    // Handle the case where month is shifted by 50 (women)
                    else if (month >= 51 && month <= 62)
                    {
                        month -= 50;

                        // Validate month and day
                        if (day >= 1 && day <= DateTime.DaysInMonth(year, month))
                        {
                            // Parse the values and set the value of bDate_pick
                            bDate_pick.Value = new DateTime(year, month, day);
                        }
                        else
                        {
                            resourceManagerHelper.ShowErrorMessage("InvalidDayError");
                            ClearForm(rc_tbox1);
                        }
                    }
                    else
                    {
                        resourceManagerHelper.ShowErrorMessage("InvalidMonthError");
                        ClearForm(rc_tbox1);
                    }

                }
                // Handle the case where 'rc2' length is 3
                else if (rc2.Length == 3)
                {
                    // Adjust the year for the specified condition
                    year += 1900;

                    // Validate month and day
                    if (month >= 1 && month <= 12)
                    {
                        if (day >= 1 && day <= DateTime.DaysInMonth(year, month))
                        {
                            // Parse the values and set the value of bDate_pick
                            bDate_pick.Value = new DateTime(year, month, day);
                        }
                        else
                        {
                            resourceManagerHelper.ShowErrorMessage("InvalidDayError");
                            ClearForm(rc_tbox1);
                        }
                    }
                    // Handle the case where month is shifted by 50 (women)
                    else if (month >= 51 && month <= 62)
                    {
                        month -= 50;

                        // Validate month and day
                        if (day >= 1 && day <= DateTime.DaysInMonth(year, month))
                        {
                            // Parse the values and set the value of bDate_pick
                            bDate_pick.Value = new DateTime(year, month, day);
                        }
                        else
                        {
                            resourceManagerHelper.ShowErrorMessage("InvalidDayError");
                            ClearForm(rc_tbox1);
                        }
                    }
                    else
                    {
                        resourceManagerHelper.ShowErrorMessage("InvalidMonthError");
                        ClearForm(rc_tbox1);
                    }
                }
            }
            // Handle the case where 'rc1' year is greater than or equal to 54
            else
            {
                // Adjust the year for the specified condition
                year += 1900;

                // Validate month and day
                if (month >= 1 && month <= 12)
                {
                    if (day >= 1 && day <= DateTime.DaysInMonth(year, month))
                    {
                        // Parse the values and set the value of bDate_pick
                        bDate_pick.Value = new DateTime(year, month, day);
                    }
                    else
                    {
                        resourceManagerHelper.ShowErrorMessage("InvalidDayError");
                        ClearForm(rc_tbox1);
                    }
                }
                // Handle the case where month is shifted by 50 (women)
                else if (month >= 51 && month <= 62)
                {
                    month -= 50;

                    // Validate month and day
                    if (day >= 1 && day <= DateTime.DaysInMonth(year, month))
                    {
                        // Parse the values and set the value of bDate_pick
                        bDate_pick.Value = new DateTime(year, month, day);
                    }
                    else
                    {
                        resourceManagerHelper.ShowErrorMessage("InvalidDayError");
                        ClearForm(rc_tbox1);
                    }
                }
                else
                {
                    resourceManagerHelper.ShowErrorMessage("InvalidMonthError");
                    ClearForm(rc_tbox1);
                }
            }
        }

        public void BDateManually(CheckBox bezRC_cbox, TextBox rc_tbox1, TextBox rc_tbox2)
        {
            // Check if the checkbox for manually entering birthdate is checked
            if (bezRC_cbox.Checked)
            {
                // If the checkbox is checked, disable the 'rc' textboxes
                rc_tbox1.Enabled = false;
                rc_tbox2.Enabled = false;

                // Clear the content of 'rc' textboxes only if they are not empty
                if (!string.IsNullOrWhiteSpace(rc_tbox1.Text))
                {
                    ClearForm(rc_tbox1);
                }
                if (!string.IsNullOrWhiteSpace(rc_tbox2.Text))
                {
                    ClearForm(rc_tbox2);
                }
            }
            else
            {
                // If the checkbox is unchecked, enable the 'rc' textboxes
                rc_tbox1.Enabled = true;
                rc_tbox2.Enabled = true;
            }
        }



        public void GenderFromRC(TextBox rc_tbox1, ComboBox gender_combo)
        {
            // Check if 'rc_tbox1' is empty
            if (string.IsNullOrWhiteSpace(rc_tbox1.Text))
            {
                // Show an error message and return if input is empty
                resourceManagerHelper.ShowErrorMessage("EmptyInputError");
                return;
            }

            // Extract 'rc' value from the TextBox
            string rc1 = rc_tbox1.Text;

            // Check for the correct length and all characters being digits in 'rc1'
            if (rc1.Length != 6 || !rc1.All(char.IsDigit))
            {
                // Show an error message, clear the TextBox, and return if 'rc1' is invalid
                resourceManagerHelper.ShowErrorMessage("InvalidRCFError");
                ClearForm(rc_tbox1);
                return;
            }

            // Extract the month component from 'rc1'
            string monthStr = rc1.Substring(2, 2);

            // Determine gender based on the month component
            if (monthStr.StartsWith("5") || monthStr.StartsWith("6"))
            {
                // Set the ComboBox to "Žena" (Woman) if the month starts with '5' or '6'
                gender_combo.SelectedItem = "Žena";
            }
            else
            {
                // Set the ComboBox to "Muž" (Man) if the month doesn't start with '5' or '6'
                gender_combo.SelectedItem = "Muž";
            }
        }
    }
}
