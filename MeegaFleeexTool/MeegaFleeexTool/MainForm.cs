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

        public MainForm()
        {
            InitializeComponent();

            dateTimePicker.MinDate = new DateTime(2020, 1, 1);

            entrateList = new List<TextBox>() { lunEntrataTextBox, marEntrataTextBox, merEntrataTextBox, gioEntrataTextBox, venEntrataTextBox };
            usciteList = new List<TextBox>() { lunUscitaTextBox, marUscitaTextBox, merUscitaTextBox, gioUscitaTextBox, venUscitaTextBox };
            diffList = new List<TextBox>() { lunDiffTextBox, marDiffTextBox, merDiffTextBox, gioDiffTextBox, venDiffTextBox };
            rolList = new List<TextBox>() { lunROLTextBox, marROLTextBox, merROLTextBox, gioROLTextBox, venROLTextBox };
            ritardoList = new List<TextBox>() { lunRitardoTextBox, marRitardoTextBox, merRitardoTextBox, gioRitardoTextBox, venRitardoTextBox };

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
            CredentialsGetter credential = new CredentialsGetter();

            if(!credential.HasValidCredentials())
            {
                PickCredentialForm form = new PickCredentialForm();
                form.Show();

                return;
            }

            resultTextBox.Text = "Downloading...";

            ZucchettiPageDownloader downloader = new ZucchettiPageDownloader();
            var collection = downloader.DownloadTimbratureCurrentMonth(credential.GetUser(), credential.GetPassword());

            resultTextBox.Text = "Processing...";

            timbrature = new TimbratureBuilder(dateTimePicker.Value.Date, collection);
            int total = timbrature.ComputeCurrentWeek();

            FillSummary(total);
            FillCurrentWeek();

            downloader.Cleanup();
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

            int todayIndex = date.Day - 1;
            int endIndex = Math.Min(todayIndex, index + 5);

            for(int i = 0; i < 5; i++)
            {
                if (index + i < 0)
                    continue; // todo: get from previous month.

                if(index + i > todayIndex)
                {
                    entrateList[i].Text = "";
                    usciteList[i].Text  = "";
                }
                else
                {
                    DayDescriptor day = timbrature.Month.Days[i + index];

                    bool bWorkingDay = day.DayType == WorkDayType.Normal;

                    entrateList[i].Text = bWorkingDay && day.OrarioEntrata > 0 ? Utils.MinutesToString(day.OrarioEntrata) : "";
                    usciteList[i].Text  = bWorkingDay && day.OrarioUscita  > 0 ? Utils.MinutesToString(day.OrarioUscita)  : "";
                    ritardoList[i].Text = bWorkingDay && day.Ritardi       > 0 ? Utils.MinutesToString(day.Ritardi) : "";
                    rolList[i].Text     = bWorkingDay && day.Giustificativi > 0 ? Utils.MinutesToString(day.Giustificativi) : "";
                }
            }
        }

        private void BuildWeekDayNumber(DateTime dateTime)
        {
            int firstDayNumber = Utils.GetFirstWorkingDayOfWeek(dateTime);

            firstDay.Text   = (firstDayNumber).ToString();
            secondDay.Text  = (firstDayNumber + 1).ToString();
            thirdDay.Text   = (firstDayNumber + 2).ToString();
            fourthDay.Text  = (firstDayNumber + 3).ToString();
            fifthDay.Text   = (firstDayNumber + 4).ToString();
        }

        private void computeButton_Click(object sender, EventArgs e)
        {
            UpdateDiffWeek();
        }
    }
}
