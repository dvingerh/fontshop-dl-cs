using fontshop_dl_cs.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace fontshop_dl_cs
{
    public partial class MainForm : Form
    {
        private Uri downloadUrl;
        private FontshopTypeface typeface;
        public MainForm()
        {
            InitializeComponent();
            SaveToTextBox.Text = Application.StartupPath;
        }

        private void SelectButtonClicked(object sender, EventArgs e)
        {
            FolderBrowserDialog selectDialog = new FolderBrowserDialog();
            DialogResult selectDialogResult = selectDialog.ShowDialog();
            if (selectDialogResult == DialogResult.OK)
            {
                SaveToTextBox.Text = selectDialog.SelectedPath;
            }
        }

        private void FontUrlTextBoxChanged(object sender, EventArgs e)
        {
            try
            {
                downloadUrl = new Uri(FontUrlTextBox.Text);
                if(downloadUrl.Host != "www.fontshop.com")
                {
                    throw new Exception();
                }
                else
                {
                    StatusLabel.Text = "Getting font information...";
                    FontUrlTextBox.Enabled = false;
                    DownloadButton.Enabled = false;
                    ProgressBar.Style = ProgressBarStyle.Marquee;
                    ProgressBar.Value = 0;
                    GetFontInformation(downloadUrl);
                }
            }
            catch
            {
                StatusLabel.Text = "Last entered URL is invalid.";
            }
        }

        private void GetFontInformation(Uri url)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.RunWorkerCompleted += GetFontInformationCompleted;
            backgroundWorker.DoWork += (s, e) =>
            {
                string json = null;
                using (WebClient webClient = new WebClient())
                {
                    json = webClient.DownloadString(String.Format(Constants.BASE_URL, url.AbsolutePath.Split('/').Last<string>()));
                }
                JObject jsonObj = JObject.Parse(json);
                JToken fontObj = jsonObj.SelectToken("families").SelectToken("hits").SelectToken("hits")[0].SelectToken("_source");
                typeface = new FontshopTypeface(fontObj.SelectToken("clean_name").ToString(), new List<FontshopFont>());
                foreach (var fontData in fontObj.SelectToken("typeface_data"))
                {
                    var name = fontData.SelectToken("name").ToString();
                    var weightName = fontData.SelectToken("weight_name").ToString();
                    var fontId = fontData.SelectToken("layoutfont_id").ToString();
                    var available = fontData.SelectToken("webfont").SelectToken("url") != null;
                    FontshopFont font = new FontshopFont(name, weightName, fontId, available);
                    typeface.Fonts.Add(font);
                }
                int fontsAvailable = 0;
                foreach (FontshopFont font in typeface.Fonts)
                {
                    if (font.Available)
                    {
                        fontsAvailable += 1;
                    }
                }
                typeface.FontsAvailable = fontsAvailable;
                Invoke((Action)delegate
                {
                    StatusLabel.Text = $"Loaded {fontsAvailable}/{typeface.Fonts.Count} available fonts: {typeface.Name}";
                    DownloadButton.Enabled = true;
                    FontUrlTextBox.Enabled = true;
                });
            };
            backgroundWorker.RunWorkerAsync();
        }

        private void GetFontInformationCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show($"Could not get font information:\n\n{e.Error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ProgressBar.Style = ProgressBarStyle.Blocks;
        }

        private void DownloadButtonClicked(object sender, EventArgs e)
        {
            FontUrlTextBox.Enabled = false;
            SaveToTextBox.Enabled = false;
            SelectButton.Enabled = false;
            DownloadButton.Enabled = false;
            ProgressBar.Maximum = typeface.FontsAvailable + 1;
            ProgressBar.Value = 0;
            DownloadFonts();
        }

        private void DownloadFonts()
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.RunWorkerCompleted += DownloadFontsCompleted;
            backgroundWorker.ProgressChanged += DownloadFontsProgressChanged;
            backgroundWorker.DoWork += (s, e) =>
            {
                Regex regexCdn = new Regex(Constants.CDN_REGEX, RegexOptions.Multiline);
                int index = 1;
                foreach(FontshopFont font in typeface.Fonts)
                {
                    if (font.Available)
                    {
                        string cssString = null;
                        using (WebClient webClient = new WebClient())
                        {
                            cssString = webClient.DownloadString(String.Format(Constants.BASE_CSS, font.Id));
                            string cdnRegexMatch = "https://" + regexCdn.Match(cssString).Value;
                            Uri fontUri = new Uri(cdnRegexMatch);
                            webClient.Headers.Add("referer", "https://www.fontshop.com/");
                            webClient.DownloadFile(fontUri, Path.Combine(SaveToTextBox.Text, $"{font.Name}_{font.Id}.woff"));
                            backgroundWorker.ReportProgress(index);
                            index++;
                        }
                    }
                }
            };
            backgroundWorker.RunWorkerAsync();
        }

        private void DownloadFontsProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            StatusLabel.Text = $"Downloaded {e.ProgressPercentage}/{typeface.FontsAvailable} font files.";
            ProgressBar.Value = e.ProgressPercentage + 1;
            ProgressBar.Value = e.ProgressPercentage;
        }

        private void DownloadFontsCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StatusLabel.Text = "Finished downloading fonts.";
            ProgressBar.Maximum = typeface.FontsAvailable;
            DownloadButton.Enabled = true;
            SelectButton.Enabled = true;
            SaveToTextBox.Enabled = true;
            FontUrlTextBox.Enabled = true;
        }
    }
}
