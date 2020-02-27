using MeegaFleeexTool.Online;
using MeegaFleeexTool.Timbrature;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeegaFleeexTool
{
    public partial class MainForm : Form
    {
        private TimbratureBuilder timbrature;

        private List<TextBox> entrateList;
        private List<TextBox> usciteList;
        private List<TextBox> diffList;
        private List<TextBox> rolList;
        private List<TextBox> ritardoList;

        private System.ComponentModel.BackgroundWorker backgroundWorker;

        public MainForm()
        {
            InitializeComponent();

            dateTimePicker.MinDate = new DateTime(2020, 1, 1);

            entrateList = new List<TextBox>() { lunEntrataTextBox, marEntrataTextBox, merEntrataTextBox, gioEntrataTextBox, venEntrataTextBox };
            usciteList = new List<TextBox>() { lunUscitaTextBox, marUscitaTextBox, merUscitaTextBox, gioUscitaTextBox, venUscitaTextBox };
            diffList = new List<TextBox>() { lunDiffTextBox, marDiffTextBox, merDiffTextBox, gioDiffTextBox, venDiffTextBox };
            rolList = new List<TextBox>() { lunROLTextBox, marROLTextBox, merROLTextBox, gioROLTextBox, venROLTextBox };
            ritardoList = new List<TextBox>() { lunRitardoTextBox, marRitardoTextBox, merRitardoTextBox, gioRitardoTextBox, venRitardoTextBox };

            backgroundWorker = new System.ComponentModel.BackgroundWorker();
            backgroundWorker.DoWork +=
                new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(
            backgroundWorker_RunWorkerCompleted);
            backgroundWorker.ProgressChanged +=
                new ProgressChangedEventHandler(
            backgroundWorker_ProgressChanged);

            BuildWeekDayNumber(dateTimePicker.Value.Date);
        }

        private void FillSummary(int total)
        {
            if (total == 0)
            {
                resultTextBox.Text = "Risultato perfetto, 0 minuti, qua non si regala un cazzo.";
                resultTextBox.BackColor = Color.LightBlue;
            }
            else if (total > 0)
            {
                resultTextBox.Text = "Sei in positivo di " + total + " minuti";
                resultTextBox.BackColor = Color.Green;
            }
            else
            {
                resultTextBox.Text = "Hai fallito di " + -total + " minuti";
                resultTextBox.BackColor = Color.Red;
            }
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {

            // Assign the result of the computation
            // to the Result property of the DoWorkEventArgs
            // object. This is will be available to the 
            // RunWorkerCompleted eventhandler.

            CredentialsGetter credential = new CredentialsGetter();

            if (!credential.HasValidCredentials())
            {
                PickCredentialForm form = new PickCredentialForm();
                form.Show();

                return;
            }
            downloadButton.Enabled = false;
            resultTextBox.Text = "Downloading...";
            DateTime date = dateTimePicker.Value.Date;
            backgroundWorker.RunWorkerAsync(date);
            
        }

        private void FillCurrentWeek()
        {
            if (timbrature == null)
                return;

            DateTime date = dateTimePicker.Value.Date;

            BuildWeekDayNumber(date);

            int firstDayNumber = Utils.GetFirstWorkingDayOfWeek(date);
            BuildEntrateUscite(firstDayNumber - 1);

            int total = UpdateDiffWeek();
            FillSummary(total);
        }

        private int UpdateDiffWeek()
        {
            int totalDiff = 0;
            for(int i = 0; i < 5; i++)
            {
                int entrata = Math.Max(8 * 60 + 45, Utils.StringToMinutes(entrateList[i].Text));
                int uscita = Math.Min(20 * 60, Utils.StringToMinutes(usciteList[i].Text));
                int rol = Math.Max(0, Utils.StringToMinutes(rolList[i].Text));
                int ritardoPranzo = Math.Max(0, Utils.StringToMinutes(ritardoList[i].Text));

                // todo check if work should consider 1 hour to eat.
                // Max is 10:15 hours for a working day (from 8:45 to 20:00 with 1 hour for eating)
                int diff = uscita > 0 && entrata > 0 ? Math.Min(uscita - entrata + rol - ritardoPranzo - 9 * 60, 10 * 60 + 15) : 0;
                diffList[i].Text = uscita > 0 && entrata > 0 ? Utils.MinutesToString(diff) : "";

                totalDiff += diff;
            }

            totalDiffTextBox.Text = Utils.MinutesToString(totalDiff);

            return totalDiff;
        }

        private void BuildEntrateUscite(int index)
        {
            DateTime date = dateTimePicker.Value.Date;
            DateTime today = DateTime.Now;
            bool includesToday = date.Year == today.Year && today.DayOfYear <= (date.DayOfYear + 5);

            for(int i = 0; i < 5; i++)
            {

                if(includesToday && i > (int)today.DayOfWeek-1)
                {
                    entrateList[i].Text = "";
                    usciteList[i].Text  = "";
                }
                else
                {
                    DayDescriptor day = timbrature.Days[i];

                    bool bWorkingDay = day.DayType == WorkDayType.Normal;
                    if(includesToday && i == (int)today.DayOfWeek - 1)
                    {
                        if(bWorkingDay && day.OrarioEntrata > 0 && today.Hour >= 17 && day.OrarioUscita <= 0)
                        {
                            day.SetWorkedHours(day.OrarioEntrata, (today.Hour*60)+today.Minute);
                        }
                    }

                    entrateList[i].Text = bWorkingDay && day.OrarioEntrata > 0 ? Utils.MinutesToString(day.OrarioEntrata) : "";
                    usciteList[i].Text  = bWorkingDay && day.OrarioUscita  > 0 ? Utils.MinutesToString(day.OrarioUscita)  : "";
                    ritardoList[i].Text = bWorkingDay && day.Ritardi       > 0 ? Utils.MinutesToString(day.Ritardi) : "";
                    rolList[i].Text     = bWorkingDay && day.Giustificativi > 0 ? Utils.MinutesToString(day.Giustificativi) : "";
                }
            }
        }

        private void BuildWeekDayNumber(DateTime dateTime)
        {
            DateTime firstDayNumber = Utils.getFirstWorkingDayOfWeekAsDate(dateTime);

            firstDay.Text   = (firstDayNumber.Day).ToString();
            secondDay.Text  = (firstDayNumber.AddDays(1).Day).ToString();
            thirdDay.Text   = (firstDayNumber.AddDays(2).Day).ToString();
            fourthDay.Text  = (firstDayNumber.AddDays(3).Day).ToString();
            fifthDay.Text   = (firstDayNumber.AddDays(4).Day).ToString();
        }

        private void computeButton_Click(object sender, EventArgs e)
        {
            int total = UpdateDiffWeek();
            FillSummary(total);
        }

        private void backgroundWorker_DoWork(object sender,
            DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;
            CredentialsGetter credential = new CredentialsGetter();


            ZucchettiPageDownloader downloader = new ZucchettiPageDownloader();

            TimbratureBuilder localtimbrature = new TimbratureBuilder(Utils.getFirstWorkingDayOfWeekAsDate(dateTimePicker.Value.Date));
            var collection = downloader.DownloadTimbratureCurrentMonth(credential.GetUser(), credential.GetPassword(), (DateTime)e.Argument, localtimbrature, worker);
            e.Result = localtimbrature;

            downloader.Cleanup();
        }

        // This event handler deals with the results of the
        // background operation.
        private void backgroundWorker_RunWorkerCompleted(
            object sender, RunWorkerCompletedEventArgs e)
        {
            resultTextBox.Text = "Processing...";
            timbrature = (TimbratureBuilder) e.Result;
            // First, handle the case where an exception was thrown.
            int total = timbrature.ComputeCurrentWeek();

            FillSummary(total);
            FillCurrentWeek();

            downloadButton.Enabled = true;
        }

        // This event handler updates the progress bar.
        private void backgroundWorker_ProgressChanged(object sender,
            ProgressChangedEventArgs e)
        {
            resultTextBox.Text = "Downloading..." + e.ProgressPercentage + "%";
        }
    }
}
