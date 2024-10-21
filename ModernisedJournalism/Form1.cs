using System;
using System.Net.Http;
using HtmlAgilityPack;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Policy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Collections.Generic;

namespace ModernisedJournalism
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tableLayoutPanel1.Controls.Add(BBCTableLayoutPanel);
            tableLayoutPanel1.Controls.Add(GuardianTableLayoutPanel);
            tableLayoutPanel1.Controls.Add(IndependentTableLayoutPanel);
            tableLayoutPanel1.Controls.Add(MailTableLayoutPanel);
            tableLayoutPanel1.Controls.Add(SkyTableLayoutPanel);
            tableLayoutPanel1.Controls.Add(SunTableLayoutPanel);
            setPositions();
            getNews();
        }

        string BBCurl = "https://www.bbc.com/news";
        string Guardianurl = "https://www.theguardian.com/uk";
        string Independenturl = "https://www.independent.co.uk/";
        string Mailurl = "https://www.dailymail.co.uk/news/index.html";
        string Skyurl = "https://news.sky.com";
        string Sunurl = "https://www.thesun.co.uk/news/";
        int amount = 10;
        string[] BBCHeadlines = new string[10];
        string[] GuardianHeadlines = new string[10];
        string[] IndependentHeadlines = new string[10];
        string[] MailHeadlines = new string[10];
        string[] SkyHeadlines = new string[10];
        string[] SunHeadlines = new string[10];

        private void setPositions()
        {
            BBCButton.Text = "Reveal source";
            GuardianButton.Text = "Reveal source";
            IndependentButton.Text = "Reveal source";
            MailButton.Text = "Reveal source";
            SkyButton.Text = "Reveal source";
            SunButton.Text = "Reveal source";
            TableLayoutPanel[] tableLayoutPanels = { BBCTableLayoutPanel, GuardianTableLayoutPanel, IndependentTableLayoutPanel, MailTableLayoutPanel, SkyTableLayoutPanel, SunTableLayoutPanel };

            List<(int Row, int Column)> positions = new List<(int Row, int Column)>
            {
                (0, 0), (0, 1), (0, 2),
                (2, 0), (2, 1), (2, 2)
            };

            // Shuffle the list to randomize the positions
            Random random = new Random();
            for (int i = 0; i < positions.Count; i++)
            {
                int randomIndex = random.Next(i, positions.Count);
                var temp = positions[i];
                positions[i] = positions[randomIndex];
                positions[randomIndex] = temp;
            }

            // Add the PictureBoxes to the TableLayoutPanel in random order
            for (int i = 0; i < tableLayoutPanels.Length; i++)
            {
                tableLayoutPanel1.Controls.Add(tableLayoutPanels[i]);
                tableLayoutPanel1.SetRow(tableLayoutPanels[i], positions[i].Row);
                tableLayoutPanel1.SetColumn(tableLayoutPanels[i], positions[i].Column);
            }

        }

        private async void getNews()
        {
            string[] BBCPaths = new string[10] {
            "/html/body/div[1]/div/div/div[2]/div/main/div[6]/div[1]/div/div/div[2]/ul/li[1]/div/div/div/div[1]/div",
            "/html/body/div[1]/div/div/div[2]/div/main/div[6]/div[1]/div/div/div[2]/ul/li[2]/div/div/div/div[1]/div[1]/a/span/p/span/text()",
            "/html/body/div[1]/div/div/div[2]/div/main/div[6]/div[1]/div/div/div[2]/ul/li[3]/div/div/div/div[1]/div[1]/a/span/p/span/text()",
            "/html/body/div[1]/div/div/div[2]/div/main/div[6]/div[1]/div/div/div[2]/ul/li[4]/div/div/div/div[1]/div[1]/a/span/p/span",
            "/html/body/div[1]/div/div/div[2]/div/main/div[6]/div[1]/div/div/div[2]/ul/li[5]/div/div/div/div[1]/div[1]/a/span/p/span",
            "/html/body/div[1]/div/div/div[2]/div/main/div[6]/div[1]/div/div/div[2]/ul/li[6]/div/div/div/div[1]/div[1]/a/span/p/span",
            "/html/body/div[1]/div/div/div[2]/div/main/div[6]/div[1]/div/div/div[2]/ul/li[7]/div/div/div/div[1]/div[1]/a/span/p/span",
            "/html/body/div[1]/div/div/div[2]/div/main/div[6]/div[1]/div/div/div[2]/ul/li[8]/div/div/div/div[1]/div[1]/a/span/p/span",
            "/html/body/div[1]/div/div/div[2]/div/main/div[6]/div[1]/div/div/div[2]/ul/li[9]/div/div/div/div[1]/div[1]/a/span/p/span",
            "/html/body/div[1]/div/div/div[2]/div/main/div[6]/div[1]/div/div/div[2]/ul/li[10]/div/div/div/div[1]/div[1]/a/span/p/span" };

            string[] GuardianPaths = new string[10] {
            "/html/body/main/section[1]/div[3]/ul[1]/li[1]/div/div/div[1]/div[2]/div[1]",
            "/html/body/main/section[1]/div[3]/ul[2]/li[1]/div/div/div[1]/div[2]/div[1]/div/h3/span/text()",
            "/html/body/main/section[1]/div[3]/ul[2]/li[2]/div/div/div[1]/div[2]/div[1]/div/h3/span",
            "/html/body/main/section[1]/div[3]/ul[2]/li[3]/ul/li[1]/div/div/div[1]/div/div[1]/div/h3/span",
            "/html/body/main/section[1]/div[3]/ul[2]/li[3]/ul/li[3]/div/div/div[1]/div/div[1]/div/h3/span",
            "/html/body/main/section[1]/div[3]/ul[2]/li[3]/ul/li[5]/div/div/div[1]/div/div[1]/div/h3/span",
            "/html/body/main/section[1]/div[3]/ul[1]/li[2]/div/div/div[1]/div[2]/div[1]/div/h3/span",
            "/html/body/main/section[1]/div[3]/ul[2]/li[3]/ul/li[2]/div/div/div[1]/div/div[1]/div/h3/span",
            "/html/body/main/section[1]/div[3]/ul[2]/li[3]/ul/li[4]/div/div/div[1]/div/div[1]/div/h3/span",
            "/html/body/main/section[1]/div[3]/ul[2]/li[3]/ul/li[6]/div/div/div[1]/div/div[1]/div/h3/span/text()" };

            string[] IndependentPaths = new string[10] {
            "/html/body/div[2]/div[3]/div[4]/div[1]/div[1]/div[2]/div[1]/div[3]/h2/a",
            "/html/body/div[2]/div[3]/div[4]/div[1]/div[1]/div[2]/div[2]/div[1]/div[3]/h2/a",
            "/html/body/div[2]/div[3]/div[4]/div[1]/div[1]/div[2]/div[2]/div[2]/div/div[2]/h2/a",
            "/html/body/div[2]/div[3]/div[4]/div[1]/div[1]/div[2]/div[2]/div[3]/div/div[2]/h2/a",
            "/html/body/div[2]/div[3]/div[4]/div[1]/div[2]/div/div[1]/div[2]/h2/a",
            "/html/body/div[2]/div[3]/div[4]/div[1]/div[2]/div/div[2]/div[2]/h2/a",
            "/html/body/div[2]/div[3]/div[4]/div[1]/div[2]/div/div[3]/div[2]/h2/a",
            "/html/body/div[2]/div[3]/div[4]/div[1]/div[3]/div/div[1]/h2/a",
            "/html/body/div[2]/div[3]/div[4]/div[1]/div[4]/div/div[1]/div[3]/h2/a",
            "/html/body/div[2]/div[3]/div[4]/div[1]/div[4]/div/div[2]/div[1]/div[3]/h2/a" };

            string[] MailPaths = new string[10] {
            "/html/body/div[2]/div[2]/div[4]/div[2]/div[1]/div/div[1]/div/p/text()",
            "/html/body/div[2]/div[2]/div[4]/div[2]/div[2]/div[1]/div/div[1]/div[1]/h2/a/text()",
            "/html/body/div[2]/div[2]/div[4]/div[2]/div[2]/div[1]/div/div[1]/div[2]/h2/a/text()",
            "/html/body/div[2]/div[2]/div[4]/div[2]/div[2]/div[1]/div/div[1]/div[3]/h2/a/text()",
            "/html/body/div[2]/div[2]/div[4]/div[2]/div[2]/div[1]/div/div[2]/div[1]/h2/a/text()",
            "/html/body/div[2]/div[2]/div[4]/div[2]/div[2]/div[1]/div/div[2]/div[2]/h2/a/text()",
            "/html/body/div[2]/div[2]/div[4]/div[2]/div[2]/div[1]/div/div[2]/div[3]/h2/a/text()",
            "/html/body/div[2]/div[2]/div[4]/div[2]/div[2]/div[1]/div/div[2]/div[4]/h2/a",
            "/html/body/div[2]/div[2]/div[4]/div[2]/div[2]/div[1]/div/div[2]/div[5]/h2/a/text()",
            "/html/body/div[2]/div[2]/div[4]/div[2]/div[3]/div[1]/div/h2/a/text()" };

            string[] SkyPaths = new string[10] {
            "/html/body/div[1]/main/div/section[1]/div/div[1]/article/div/div/div/div[2]/a/text()",
            "/html/body/div[1]/main/div/section[1]/div/div[2]/article/div/div/div/div[2]/a/text()",
            "/html/body/div[1]/main/div/section[1]/div/div[3]/article/div/div/div/div[2]/a/text()",
            "/html/body/div[1]/main/div/section[1]/div/div[4]/article/div/div/div/div[2]/a/text()",
            "/html/body/div[1]/main/div/section[1]/div/div[5]/article/div/div/div/div[2]/a/text()",
            "/html/body/div[1]/main/div/section[1]/div/div[6]/article/div/div/div/div[2]/a/text()",
            "/html/body/div[1]/main/div/section[1]/div/div[7]/article/div/div/div/div[2]/a/text()",
            "/html/body/div[1]/main/div/section[1]/div/div[8]/article/div/div/div/div[2]/a/text()",
            "/html/body/div[1]/main/div/section[1]/div/div[9]/article/div/div/div/div[2]/a/text()",
            "/html/body/div[1]/main/div/section[1]/div/div[10]/article/div/div/div/div[2]/a/text()" };

            string[] SunPaths = new string[10] {
            "/html/body/div[6]/main/div/div[1]/div/div/div/a/span/div/div/h3/span[2]/text()",
            "/html/body/div[6]/main/div/div[3]/div/div[1]/div/div[2]/a",
            "/html/body/div[6]/main/div/div[2]/div/div[1]/div/div[2]/a/h3",
            "/html/body/div[6]/main/div/div[2]/div/div[2]/div/div[2]/a/h3",
            "/html/body/div[6]/main/div/div[2]/div/div[3]/div/div[2]/a/h3",
            "/html/body/div[6]/main/div/div[3]/div/div[2]/div/div[2]/a/h3",
            "/html/body/div[6]/main/div/div[3]/div/div[3]/div/div[2]/a/h3",
            "/html/body/div[6]/main/div/div[3]/div/div[4]/div/div[2]/a/h3",
            "/html/body/div[6]/main/div/div[3]/div/div[5]/div/div[2]/a/h3",
            "/html/body/div[6]/main/div/div[5]/div/div[1]/div/div[2]/a" };

            for (int i = 0; i < amount; i++)
            {
                BBCHeadlines[i] = await GetInfomation(BBCurl, BBCPaths[i]);
                GuardianHeadlines[i] = await GetInfomation(Guardianurl, GuardianPaths[i]);
                IndependentHeadlines[i] = await GetInfomation(Independenturl, IndependentPaths[i]);
                MailHeadlines[i] = await GetInfomation(Mailurl, MailPaths[i]);
                SkyHeadlines[i] = await GetInfomation(Skyurl, SkyPaths[i]);
                SunHeadlines[i] = await GetInfomation(Sunurl, SunPaths[i]);
                progressBar1.Value += amount;
            }

            BBCHeadlineLabel.Text = BBCHeadlines[0];
            GuardianHeadlineLabel.Text = GuardianHeadlines[0];
            IndependentHeadlineLabel.Text = IndependentHeadlines[0];
            MailHeadlineLabel.Text = MailHeadlines[0];
            SkyHeadlineLabel.Text = SkyHeadlines[0];
            SunHeadlineLabel.Text = SunHeadlines[0];
        }

        private static async Task<string> GetInfomation(string url, string path)
        {
            HttpClient client = new HttpClient();

            // Get the HTML content of the page
            string html = await client.GetStringAsync(url);

            // For debugging purposes, log the HTML (you can output this to a file or the console)
            System.IO.File.WriteAllText("debug_html.txt", html);

            // Load the HTML into the HtmlDocument
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            // Inspect the class or structure on the live page and update the XPath
            var textNode = doc.DocumentNode.SelectSingleNode(path);

            // Return the text, or a default value if not found
            return textNode?.InnerText.Trim() ?? "Not found";
        }

        private void BBCButton_Click(object sender, EventArgs e)
        {
            Button_Click(BBCGuess, "bbc", BBCButton, BBCurl);
        }

        private void GuardianButton_Click(object sender, EventArgs e)
        {
            Button_Click(GuardianGuess, "guardian", GuardianButton, Guardianurl);
        }

        private void IndependentButton_Click(object sender, EventArgs e)
        {
            Button_Click(IndependentGuess, "independent", IndependentButton, Independenturl);
        }

        private void MailButton_Click(object sender, EventArgs e)
        {
            Button_Click(MailGuess, "mail", MailButton, Mailurl);
        }

        private void SkyButton_Click(object sender, EventArgs e)
        {
            Button_Click(SkyGuess, "sky", SkyButton, Skyurl);
        }

        private void SunButton_Click(object sender, EventArgs e)
        {
            Button_Click(SunGuess, "sun", SunButton, Sunurl);
        }

        private void Button_Click(TextBox guess, string name, Button button, string url)
        {
            if (guess.Text.ToLower().Contains(name))
            { guess.BackColor = System.Drawing.Color.Green; }
            else { guess.BackColor = System.Drawing.Color.Red; }
            if (button.Text.Trim() != url) { button.Text = url; }
            else { Process.Start(url); }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchedWord = SearchTextBox.Text.ToLower();
            bool BBCFound = false, GuardianFound = false, IndependentFound = false, MailFound = false, SkyFound = false, SunFound = false;
            for (int i = amount-1; i >= 0; i--)
            {
                if (BBCHeadlines[i].ToLower().Contains(searchedWord)) { BBCHeadlineLabel.Text = BBCHeadlines[i]; BBCFound = true; }
                if (GuardianHeadlines[i].ToLower().Contains(searchedWord)) { GuardianHeadlineLabel.Text = GuardianHeadlines[i]; GuardianFound = true; }
                if (IndependentHeadlines[i].ToLower().Contains(searchedWord)) { IndependentHeadlineLabel.Text = IndependentHeadlines[i]; IndependentFound = true; }
                if (MailHeadlines[i].ToLower().Contains(searchedWord)) { MailHeadlineLabel.Text = MailHeadlines[i]; MailFound = true; }
                if (SkyHeadlines[i].ToLower().Contains(searchedWord)) { SkyHeadlineLabel.Text = SkyHeadlines[i]; SkyFound = true; }
                if (SunHeadlines[i].ToLower().Contains(searchedWord)) { SunHeadlineLabel.Text = SunHeadlines[i]; SunFound = true; }
            }
            if (!BBCFound) { BBCHeadlineLabel.Text = "Not found"; }
            if (!GuardianFound) { GuardianHeadlineLabel.Text = "Not found"; }
            if (!IndependentFound) { IndependentHeadlineLabel.Text = "Not found"; }
            if (!MailFound) { MailHeadlineLabel.Text = "Not found"; }
            if (!SkyFound) { SkyHeadlineLabel.Text = "Not found"; }
            if (!SunFound) { SunHeadlineLabel.Text = "Not found"; }
        }

        private void RandomButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            setPositions();
            BBCHeadlineLabel.Text = BBCHeadlines[random.Next(0, amount)];
            GuardianHeadlineLabel.Text = GuardianHeadlines[random.Next(0, amount)];
            IndependentHeadlineLabel.Text = IndependentHeadlines[random.Next(0, amount)];
            MailHeadlineLabel.Text = MailHeadlines[random.Next(0, amount)];
            SkyHeadlineLabel.Text = SkyHeadlines[random.Next(0, amount)];
            SunHeadlineLabel.Text = SunHeadlines[random.Next(0, amount)];
        }
    }
}
