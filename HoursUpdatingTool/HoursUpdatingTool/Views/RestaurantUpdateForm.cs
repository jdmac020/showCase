using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoursUpdatingTool
{
    public partial class RestaurantUpdateForm : Form
    {
        private readonly Controller control;

        private string restaurantFile;
        public RestaurantUpdateForm()
        {
            InitializeComponent();
            control = new Controller();
            restaurantFile = Properties.Settings.Default.filePath1;
        }

        private void selectSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog sourceSelector = new OpenFileDialog();
            //sourceSelector.Filter = "All Files (*.*)|*.*";
            //sourceSelector.FilterIndex = 1;
            sourceSelector.Multiselect = false;

            if (sourceSelector.ShowDialog() == DialogResult.OK)
            {
                restaurantFile = sourceSelector.FileName;
                Properties.Settings.Default.filePath = sourceSelector.FileName;
                filePathLabel.Text = restaurantFile;
                EnableListGeneration();
            }
        }

        private void createListButton_Click(object sender, EventArgs e)
        {
            control.GetRestaurantList(restaurantFile);
            EnableUpdateHoursMenuItem();
            MessageBox.Show("File Imported and Ready to Go!", "List Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EnableListGeneration()
        {
            if (string.IsNullOrEmpty(restaurantFile))
            {
                createListButton.Enabled = false;
            }
            else
            {
                createListButton.Enabled = true;
            }
        }

        private void EnableUpdateHoursMenuItem()
        {
            updateHoursMenuItem.Enabled = true;
            viewEditHoursButton.Enabled = true;
        }

        private void RestaurantUpdateForm_Load(object sender, EventArgs e)
        {
            if (restaurantFile == string.Empty)
            {
                filePathLabel.Text = "No File Selected. Please Go to File Menu to Choose a File.";
                EnableListGeneration();
            }
            else
            {
                filePathLabel.Text = restaurantFile;
                EnableListGeneration();
            }
            
        }

        private void updateAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            control.OpenHoursUpdaterForm();
            updateFileButton.Enabled = true;
        }

        private void UpdateFileButton_Click(object sender, EventArgs e)
        {
            control.UpdateRestaurantFile(restaurantFile);
            MessageBox.Show("Changes Have Been Successfully Made To Your Source File!", "Good Happy Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RestaurantUpdateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (restaurantFile != string.Empty)
            {
                DialogResult savePrompt = MessageBox.Show("Do You Want To Update Your Source File?", "Save Changes?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                if (savePrompt == DialogResult.Yes)
                {
                    UpdateFileButton_Click(sender, e);
                }

            }

            

            //UpdateRestaurantPath(restaurantFile);
        }

        //private static void UpdateRestaurantPath(string restaurantFile)
        //{
        //    Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //    configuration.AppSettings.Settings["filePath1"].Value = Properties.Settings.Default.filePath;
        //    configuration.Save();

        //    ConfigurationManager.RefreshSection("appSettings");
        //}
    }
}
