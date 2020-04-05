using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Giełda2
{
    public partial class Form1 : Form
    {
        // Adding variables with different URLs to different stocks 

        string urlCDR = @"https://www.gpw.pl/spolka?isin=PLOPTTC00011";
        string urlUMT = @"https://www.sharewise.com/us/instruments/UMT_United";
        string urlPILAB = @"https://www.gpw.pl/spolka?isin=PLPILAB00012";
        string urlWASKO = @"https://www.gpw.pl/spolka?isin=PLHOGA000041";
        //string path = @"d:\MyTest.txt";
        string webContentCDR;
        string webContentUMT;
        string webContentPILAB;
        string webContentWASKO;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            {
                webContentCDR = DownloadWebPage(urlCDR);
                webContentUMT = DownloadWebPage(urlUMT);
                webContentPILAB = DownloadWebPage(urlPILAB);
                webContentWASKO = DownloadWebPage(urlWASKO);

                //--> if you need to preview url code you can paste it to a notepad from clipboard
                //Clipboard.SetText(webContentUMT);

                //Regular Expressions parsing the code to find a desired value

                string pattern = "<span class=\"summary\">\\d*,\\d\\d";
                string numberInPattern = "\\d*,\\d\\d";
                string patternUMT = "<span data-original-title=\"Price\" role=\"tooltip\" data-toggle=\"tooltip\">\\D\\d.\\d\\d</span>";
                string numberInPatternUMT = "\\D\\d.\\d\\d";
                
                //PULLING CODE FOR CDR

                string inputCDR = webContentCDR;
                Match mCDR = Regex.Match(inputCDR, pattern, RegexOptions.IgnoreCase);
                if (mCDR.Success)
                {
                    Match nCDR = Regex.Match(mCDR.Value, numberInPattern, RegexOptions.IgnoreCase);
                    textBox1.Text = nCDR.Value;
                }
                else
                {
                    textBox1.Text = "Invalid";
                }

                //PULLING CODE FOR PILAB

                string inputPILAB = webContentPILAB;
                Match mPILAB = Regex.Match(inputPILAB, pattern, RegexOptions.IgnoreCase);
                if (mPILAB.Success)
                {
                    Match nPILAB = Regex.Match(mPILAB.Value, numberInPattern, RegexOptions.IgnoreCase);
                    textBox4.Text = nPILAB.Value;
                }
                else
                {
                    textBox4.Text = "Invalid";
                }

                //PULLING CODE FOR WASKO

                string inputWASKO = webContentWASKO;
                Match mWASKO = Regex.Match(inputWASKO, pattern, RegexOptions.IgnoreCase);
                if (mWASKO.Success)
                {
                    Match nWASKO = Regex.Match(mWASKO.Value, numberInPattern, RegexOptions.IgnoreCase);
                    textBox5.Text = nWASKO.Value;
                }
                else
                {
                    textBox5.Text = "Invalid";
                }

                //PULLING CODE FOR UMT

                string inputUMT = webContentUMT;
                Match mUMT = Regex.Match(inputUMT, patternUMT, RegexOptions.IgnoreCase);
                if (mUMT.Success)
                {
                    Match nUMT = Regex.Match(mUMT.Value, numberInPatternUMT, RegexOptions.IgnoreCase);
                    textBox3.Text = nUMT.Value;
                }
                else
                {
                    textBox3.Text = "Invalid";
                }
            }
        }

        // This method downloads the code from the website
        public static string DownloadWebPage(string theURL)
        {
            //download a web page to a string
            WebClient client = new WebClient();
            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            Stream data = client.OpenRead(theURL);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            return s;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void label3_Click(object sender, EventArgs e)
        {
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
