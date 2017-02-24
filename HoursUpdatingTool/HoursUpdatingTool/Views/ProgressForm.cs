using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoursUpdatingTool
{
    public partial class ProgressForm : Form
    {
        public ProgressForm()
        {
            InitializeComponent();
        }

        public void SetupProgressBar(object sender, ProgressInitializeEventArgs args)
        {
            SetProgressBar(args);
        }

        public void UpdateProgressBar(object sender, ProgressIncreaseEventArgs args)
        {
            MoveProgressBar();
        }

        private void SetProgressBar(ProgressInitializeEventArgs args)
        {
            progLabel.Text = args.Message;
            progBar.Minimum = args.Minimum;
            progBar.Maximum = args.Maximum;
            progBar.Step = args.StepValue;
            progBar.Value = args.Value;
        }

        private void MoveProgressBar()
        {
            progBar.PerformStep();
        }
    }
}
