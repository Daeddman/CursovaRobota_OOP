using CursovaRobota.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CursovaRobota.Views
{
    /// <summary>
    /// Діалог «Назва / Опис / (необов’язково) свято + анімація».
    /// Використовується і для створення, і для редагування події / свята.
    /// </summary>
    public partial class WindowInputDialog : Window
    {
        /*────────────  ПУБЛІЧНІ ВЛАСТИВОСТІ  ────────────*/
        public string EventTitle => TitleBox.Text.Trim();
        public string EventDescription => DescriptionBox.Text.Trim();
        public bool IsHoliday => HolidayCheckBox.IsChecked == true;
        public string SelectedAnimation => AnimBox.SelectedItem as string;
        public Frequency ResultFreq { get; private set; } = Frequency.None;
        public int ResultInterval { get; private set; } = 1;
        public TimeSpan ResultFrom { get; private set; } = new TimeSpan(9, 0, 0);
        public TimeSpan ResultTo { get; private set; } = new TimeSpan(19, 0, 0);
        public bool RepeatEnabled { get; private set; }
        public DayOfWeek[] ResultDays { get; private set; }





        /* Колекція ключів анімацій для ComboBox */
        public IEnumerable<string> AnimationKeys { get; }

        /*────────────  КОНСТРУКТОРИ  ────────────*/

        /// <summary>Базовий: нова подія.</summary>
        private WindowInputDialog(string prompt, string windowTitle)
            : this(prompt, windowTitle, string.Empty, string.Empty, false) { }

        /// <summary>
        /// Конструктор для редагування / передзаповнення полів.
        /// </summary>
        private WindowInputDialog(string prompt, string windowTitle,
                                  string initTitle, string initDescription,
                                  bool showHolidayControls)
        {
            InitializeComponent();

            /* Список storyboard-ключів — підлаштуйте під свій словник */
            AnimationKeys = new[]
            {
                "No_anim",
                "newyear_anim",
                "valentine_anim",
                "flower_anim",
                "earthday_anim",
                "halloween_anim",
                "christmas_anim",
                "birthday_anim",
                "anniversary_anim"
            };

            DataContext = this;
            TxtPrompt.Text = prompt;
            Title = windowTitle;

            TitleBox.Text = initTitle;
            DescriptionBox.Text = initDescription;
            HolidayCheckBox.IsChecked = showHolidayControls;

            TitleBox.Focus();
        }

        /*────────────  КНОПКИ  ────────────*/

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            RepeatEnabled = RepeatCheck.IsChecked == true;

            if (RepeatEnabled)
            {
                ResultFreq = (Frequency)Enum.Parse(typeof(Frequency),
                                FreqBox.SelectedValue.ToString());

                if (!int.TryParse(IntervalBox.Text, out var iv) || iv < 1) iv = 1;
                ResultInterval = iv;

                if (ResultFreq == Frequency.Weekly)
                {
                    var tmp = new List<DayOfWeek>();
                    foreach (CheckBox cb in WeekdayPanel.Children)
                        if (cb.IsChecked == true)
                            tmp.Add((DayOfWeek)Enum.Parse(typeof(DayOfWeek), cb.Tag.ToString()));
                    ResultDays = tmp.ToArray();
                }
            }
            else
            {
                ResultFreq = Frequency.None;
                ResultInterval = 1;
                ResultDays = null;
            }
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e) => DialogResult = false;

        /*────────────  СТАТИЧНИЙ API  ────────────*/

        public static (
            string Title,
            string Description,
            bool IsHoliday,
            string AnimKey,
            bool RepeatEnabled,
            Frequency Freq,
            int Interval,
            TimeSpan From,
            TimeSpan To,
            DayOfWeek[] DaysOfWeek)        // 10-те поле
        Show(string prompt, string windowTitle)
        {
            var dlg = new WindowInputDialog(prompt, windowTitle)
            {
                Owner = Application.Current.MainWindow
            };

            return dlg.ShowDialog() == true
                ? (dlg.EventTitle,
                   dlg.EventDescription,
                   dlg.IsHoliday,
                   dlg.IsHoliday ? dlg.SelectedAnimation : null,
                   dlg.RepeatEnabled,
                   dlg.ResultFreq,
                   dlg.ResultInterval,
                   dlg.ResultFrom,
                   dlg.ResultTo,
                   dlg.ResultDays)       
                : (null, null, false, null, false,
                   Frequency.None, 1,
                   default(TimeSpan), default(TimeSpan), null);
        }



        public static (bool Confirmed, string Title, string Description)
            EditEvent(string prompt, string windowTitle,
                      string initTitle, string initDescription)
        {
            var dlg = new WindowInputDialog(prompt, windowTitle,
                                            initTitle, initDescription, false)
            {
                Owner = Application.Current.MainWindow
            };

            bool? ok = dlg.ShowDialog();
            return (ok == true, dlg.EventTitle, dlg.EventDescription);
        }


        public static (
            bool Confirmed,
            string Title,
            string Description,
            string AnimKey,
            Frequency Freq,
            int Interval)
        EditHoliday(string prompt, string windowTitle,
                    string initTitle, string initDesc,
                    string initAnim, Frequency initFreq,
                    int initInterval)
        {
            var dlg = new WindowInputDialog(prompt, windowTitle,
                                            initTitle, initDesc, true)
            {
                Owner = Application.Current.MainWindow
            };

            dlg.AnimBox.SelectedItem = initAnim;
            dlg.RepeatCheck.IsChecked = initFreq != Frequency.Yearly || initInterval != 1;
            dlg.FreqBox.SelectedValue = initFreq.ToString();
            dlg.IntervalBox.Text = initInterval.ToString();

            bool? ok = dlg.ShowDialog();
            return (ok == true,
                    dlg.EventTitle,
                    dlg.EventDescription,
                    dlg.SelectedAnimation,
                    dlg.RepeatCheck.IsChecked == true ? dlg.ResultFreq : Frequency.Yearly,
                    dlg.RepeatCheck.IsChecked == true ? dlg.ResultInterval : 1);
        }


        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
