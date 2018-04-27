using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //await ChangeProgressBar();

            //await LoopAlphabet();

            await RunTasksAsync();

            LoopAlphabet();
        }

        private async Task ChangeProgressBar(ProgressBar progressBar)
        {
            rTB_log.Text += DateTime.Now.ToString("mm:ss:fff") + " : " + progressBar.Name + " change started ...\n";

            for (int i = 0; i <= progressBar1.Maximum; i++)
            {
                await Task.Delay(100);

                progressBar.Value = i;
            }

            rTB_log.Text += DateTime.Now.ToString("mm:ss:fff") + " : " + progressBar.Name + "  full.\n";
        }

        private async Task LoopAlphabet()
        {
            List<char> alphabet = new List<char>();

            for (char i = 'a'; i <= 'z'; i++)
                alphabet.Add(i);
            
            rTB_log.Text += DateTime.Now.ToString("mm:ss:fff") + " : Alphabet loop started ...\n";

            for (int i = 0; i < alphabet.Count; i++)
            {
                await Task.Delay(1);

                tB_alphabet.Text += alphabet[i] + "\n";
            }

            rTB_log.Text += DateTime.Now.ToString("mm:ss:fff") + " : Alphabet loop ended.\n";
        }

        private async Task RunTasksAsync()
        {
            var taskList = new List<Task>();

            taskList.Add(ChangeProgressBar(progressBar1));
            taskList.Add(LoopAlphabet());
            taskList.Add(ChangeProgressBar(progressBar2));

            await Task.WhenAll(taskList.ToArray());
        }
    }
}
