using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeInTravel
{
    public partial class Form1 : Form
    {
        public static string[] months =
        {
            "январь",
            "февраль",
            "март",
            "апрель",
            "май",
            "июнь",
            "июль",
            "август",
            "сентябрь",
            "октябрь",
            "ноябрь",
            "декабрь"
        };

        public Form1()
        {
            InitializeComponent();
            foreach (string m in months)
            {
                cb_from_month.Items.Add(m);
                cb_to_month.Items.Add(m);
            }
            CBChangeValues(cb_from_year, 1970, 2030);
            CBChangeValues(cb_to_year, 1970, 2030);
            CBChangeValues(cb_from_hour, 0, 23);
            CBChangeValues(cb_to_hour, 0, 23);
            CBChangeValues(cb_from_min, 0, 59);
            CBChangeValues(cb_to_min, 0, 59);
            cb_from_year.SelectedIndex = 0;
            cb_from_month.SelectedIndex = 0;
            cb_to_year.SelectedIndex = 0;
            cb_to_month.SelectedIndex = 0;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            DateTime dateFrom = new DateTime();
            DateTime dateTo = new DateTime();
            try
            {
                dateFrom = GetDate(cb_from_year, cb_from_month, cb_from_day, cb_from_hour, cb_from_min);
                dateTo = GetDate(cb_to_year, cb_to_month, cb_to_day, cb_to_hour, cb_to_min);
            }
            catch
            {
                MessageBox.Show("Даты указаны неверно");
                return;
            }
            
            if (dateFrom <= dateTo)
            {
                TimeSpan skipped = dateTo - dateFrom;
                int showMonths = (dateTo.Month - dateFrom.Month) + 12 * (dateTo.Year - dateFrom.Year);
                int showDays = CorrectDate(dateTo, dateFrom, ref showMonths);
                int showYears = showMonths / 12;
                showMonths = showMonths % 12;
                MessageBox.Show($"Прошло {showDays} д. " +
                    $"{showMonths} мес. " +
                    $"{showYears} г. " +
                    $"{skipped.Hours} ч. " +
                    $"{skipped.Minutes} мин.");
            }
            else
            {
                MessageBox.Show("Дата прибытия не может быть меньше даты отбытия");
            }
            
        }

        public static void CBChangeValues(ComboBox cb, int start, int end)
        {
            cb.Items.Clear();
            for(int i=start; i <= end;i++)
            {
                cb.Items.Add(i);
            }
        }

        private void cb_to_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            switch(cb.Tag)
            {
                case "From": CBChangeValues(cb_from_day,1,DayInMouth(cb_from_month.SelectedIndex, Convert.ToInt32(cb_from_year.SelectedItem)));break;
                case "To": CBChangeValues(cb_to_day, 1, DayInMouth(cb_to_month.SelectedIndex, Convert.ToInt32(cb_to_year.SelectedItem)));break;
            }

        }

        public static bool CheckNotVesokosYear(int year)
        {
            return (year % 4 != 0 || year % 100 == 0 && year % 400 != 0);
        }

        public static int DayInMouth(int m, int y)
        {
            int kolvo = 0;
            if (m != 1)
            {
                if (m < 7 && m % 2 == 0 || m >= 7 && m % 2 == 1)
                    kolvo = 31;
                else
                    kolvo = 30;
            }
            else
            {
                if (CheckNotVesokosYear(y))
                    kolvo = 28;
                else
                    kolvo = 29;
            }
            return kolvo;
        }

        public static int CorrectDate(DateTime dat1, DateTime dat2, ref int showMonths)
        {
            int days = 0;
            if (dat1.Day < dat2.Day)
            {
                showMonths--;
                days = DayInMouth(dat1.Month, dat1.Year);
                days -= dat2.Day;
                days += dat1.Day;
            }
            else
                days = dat1.Day - dat2.Day;
            if (dat1.Hour * 60 + dat1.Minute < dat2.Hour * 60 + dat2.Minute)
                days--;
            if (days < 0)
                days = 0;
            return days;
        }


        public static DateTime GetDate(ComboBox cbYear, ComboBox cbMonth, ComboBox cbDay, ComboBox cbHour, ComboBox cbMin)
        {
            DateTime date = new DateTime(Convert.ToInt32(cbYear.SelectedItem), cbMonth.SelectedIndex + 1, (int)cbDay.SelectedItem, (int)cbHour.SelectedItem, (int) cbMin.SelectedItem, 0);
            return date;
        }

        
    }
}
