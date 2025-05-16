using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FotoHelper_Pro
{
    public partial class ProgressDialog : Form
    {
        internal event EventHandler<EventArgs> Completed;
        public ProgressDialog()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            ControlBox = false;

        }

        public ProgressDialog(string title, Action<BackgroundWorker> action) 
            : this()
        {
            Text = title;

            ProgressBar.Minimum = 0;
            ProgressBar.Maximum = 100;
            ProgressBar.Value = 0;
            StatusLabel.Text = "Starter...";

            BackgroundWorker worker = new BackgroundWorker
            {
                WorkerReportsProgress = true
            };

            worker.DoWork += (s, args) => action(worker);

            worker.ProgressChanged += (s, args) =>
            {
                ProgressBar.Value = args.ProgressPercentage;
                StatusLabel.Text = args.UserState.ToString();
            };

            worker.RunWorkerCompleted += (s, args) =>
            {
                Completed?.Invoke(this, EventArgs.Empty);
                Close();
            };

            Show();
            worker.RunWorkerAsync();
        }


        public ProgressBar ProgressBar => progressBar;

        public Label StatusLabel => lblStatus;
    }
}
