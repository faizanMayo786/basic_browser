using EasyTabs;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser
{
    public partial class browserForm : Form
    {
        public browserForm()
        {
            InitializeComponent();
            //var appName = System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe";
            //using (var Key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true))
            //    Key.SetValue(appName, 99999, RegistryValueKind.DWord);

            Task.Run(() =>
            {
                webBrowser1.Navigate("https://www.google.com");
            });
        }
        protected TitleBarTabs ParentTabs
        {
            get
            {
                return (ParentForm as TitleBarTabs);
            }


        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            txtSearch.Text = webBrowser1.Url.AbsoluteUri;
        }

        private async void BtnBackward_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {

                if (webBrowser1.CanGoBack) webBrowser1.GoBack();
            });

        }

        private async void BtnForward_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {

                if (webBrowser1.CanGoForward) webBrowser1.GoForward();
            });

        }

        private async void BtnHome_Click(object sender, EventArgs e)
        {
            btnHome.Enabled = false;
            await Task.Run(() =>
            {
                webBrowser1.Navigate("https://www.google.com");
            });
            
            btnHome.Enabled = true;

        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                webBrowser1.Refresh();
            });

        }

        private void TxtSearch_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && txtSearch.Text.Trim().Length > 0) 
            {
                if (txtSearch.Text.Contains("."))
                {
                    webBrowser1.Navigate(txtSearch.Text.Trim());
                }
                else

                {
                    webBrowser1.Navigate("https://www.google.com/search?q=" + txtSearch.Text.Trim().Replace(" ", "+") + "&oq=" + txtSearch.Text.Trim().Replace(" ", "+") + "&aqs=chrome..69i57j0i433i512j46i199i433i465i512j0i433i512j46i433i512l2j0i512l2j0i433i512j0i512.2005j0j7&sourceid=chrome&ie=UTF-8");
                }
            }

        }
    }
}
