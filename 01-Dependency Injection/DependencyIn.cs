using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace CSharpWinFormsPOCs
{
    public partial class DependencyIn : Form
    {
        private readonly IUserService _service;

        //Spinner to show progress to user
        private readonly Timer _spinnerTimer = new Timer();

        private readonly string[] _spinnerFrames =
         {
            ".",
            "..",
            "...",
            "....",
            "....."
        };

        private int _spinnerIndex = 0;

        public DependencyIn(IUserService service)
        {
            InitializeComponent();
            _service = service;

            //Spinner configuration
            _spinnerTimer.Interval = 120;
            _spinnerTimer.Tick += SpinnerTimer_Tick;
        }

        private void SpinnerTimer_Tick(object sender, EventArgs e)
        {
            // Update status on every tick.
            lblStatus.Text = $"Fetching users {_spinnerFrames[_spinnerIndex]}";
            _spinnerIndex = (_spinnerIndex + 1) % _spinnerFrames.Length;
        }

        private void btnLoadWithCallback_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;

            var stopwatch = Stopwatch.StartNew();

            // reset spinner
            _spinnerIndex = 0;
            _spinnerTimer.Start();

            lblStatus.Text = "Starting..";
            btnLoadWithCallback.Enabled = false;

            _service.LoadUsers(
                onSuccess: json =>
                {
                    stopwatch.Stop();

                    BeginInvoke(new Action(() =>
                    {
                        _spinnerTimer.Stop();

                        richTextBox1.Text = json;

                        var users = JsonSerializer.Deserialize<List<User>>(json);

                        int count = users?.Count ?? 0;

                        lblStatus.Text =
                            $"✓ {count} records loaded in {stopwatch.ElapsedMilliseconds} ms";

                        btnLoadWithCallback.Enabled = true;
                    }));
                },
                onError: ex =>
                {
                    stopwatch.Stop();

                    BeginInvoke(new Action(() =>
                    {
                        _spinnerTimer.Stop();

                        lblStatus.Text =
                            $"Failed after {stopwatch.ElapsedMilliseconds} ms";

                        MessageBox.Show(
                            ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        btnLoadWithCallback.Enabled = true;
                    }));
                });
        }
    }
}