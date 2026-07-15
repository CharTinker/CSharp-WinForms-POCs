using CSharpWinFormsPOCs._07_Caching.Models;
using CSharpWinFormsPOCs._07_Caching.Repositories;
using CSharpWinFormsPOCs._07_Caching.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpWinFormsPOCs._07_Caching
{
    public partial class cacheForm : Form
    {
        private readonly CustomerCacheService _customerService;
        public cacheForm(CustomerCacheService customerService)
        {
            if (customerService == null)
            {
                throw new ArgumentNullException(
                    "customerService");
            }

            InitializeComponent();


            ICustomerRepository repository =
                new SlowCustomerRepository();

            _customerService = customerService;
        }

        private async void btnLoad_Click(
       object sender,
       EventArgs e)
        {
            await LoadCustomerAsync(false);
        }

        private async Task LoadCustomerAsync(bool forceRefresh)
        {
            string customerId = txtCustomerId.Text.Trim();

            if (string.IsNullOrWhiteSpace(customerId))
            {
                MessageBox.Show("Enter a customer ID.");
                return;
            }

            SetLoadingState(true);

            Stopwatch stopwatch = Stopwatch.StartNew();

            try
            {
                CacheResult<Customer> result;

                if (forceRefresh)
                {
                    result = await _customerService
                        .RefreshAsync(customerId);
                }
                else
                {
                    result = await _customerService
                        .GetAsync(customerId);
                }

                stopwatch.Stop();

                dgvCustomer.DataSource =
                    new[] { result.Value };

                lblSource.Text = result.IsCacheHit
                    ? "Source: Cache"
                    : "Source: Repository";

                lblElapsed.Text =
                    "Elapsed: " +
                    stopwatch.ElapsedMilliseconds +
                    " ms";

                lblCacheStats.Text = string.Format(
                    "Hits: {0} | Misses: {1}",
                    _customerService.CacheHits,
                    _customerService.CacheMisses);

                lstActivity.Items.Insert(
                    0,
                    string.Format(
                        "{0:T} - Customer {1}: {2} ({3} ms)",
                        DateTime.Now,
                        customerId,
                        result.IsCacheHit
                            ? "CACHE HIT"
                            : "CACHE MISS",
                        stopwatch.ElapsedMilliseconds));
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    exception.Message,
                    "Customer lookup failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                SetLoadingState(false);
            }
        }


        private void btnClearCache_Click(
    object sender,
    EventArgs e)
        {
            _customerService.Clear();

            dgvCustomer.DataSource = null;
            lblSource.Text = "Source: --";
            lblElapsed.Text = "Elapsed: --";
            lblCacheStats.Text = "Hits: 0 | Misses: 0";

            lstActivity.Items.Insert(
                0,
                DateTime.Now.ToLongTimeString() +
                " - Cache cleared");
        }

        private void SetLoadingState(bool isLoading)
        {
            btnLoad.Enabled = !isLoading;
            btnForceRefresh.Enabled = !isLoading;
            UseWaitCursor = isLoading;

            if (isLoading)
                lblSource.Text = "Loading...";
        }


    }
}
