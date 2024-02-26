using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contact_Information_Form.Utilities
{
    // This class provides helper methods for managing resources, such as retrieving strings from resource files.
    public class ResourceManagerHelper
    {
        public  ResourceManager resourceManager;

        // Static constructor to initialize the ResourceManager with the default resource file
         public ResourceManagerHelper()
        {
            // Initialize the ResourceManager with the default resource file
            resourceManager = new ResourceManager("Contact_Information_Form.Resources.Messages.Messages", typeof(ResourceManagerHelper).Assembly);
        }

        // Retrieve a string from the resource file based on the specified key
        public  string GetString(string key)
        {
            // Get the string based on the key from the resource manager
            return resourceManager.GetString(key);
        }

        // Show an error message using a key to retrieve the message from the resource file
        public void ShowErrorMessage(string key)
        {
            // Get the error message based on the key from the resource manager
            string errorMessage = resourceManager.GetString(key);

            // Show the error message in a MessageBox
            MessageBox.Show(errorMessage);
        }
    }
}
