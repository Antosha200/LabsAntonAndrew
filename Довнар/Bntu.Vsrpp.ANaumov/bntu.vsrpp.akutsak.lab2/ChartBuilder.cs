// <copyright file="ChartBuilder.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Bntu.Vsrpp.Akutsak.Lab2
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
    using Bntu.Vsrpp.Akutsak.Сore;

    /// <summary>
    /// Класс для построения графиков динамики курса валюты.
    /// </summary>
    public partial class ChartBuilder : Form
    {
        private List<Rate> rates = new List<Rate>();
        private List<Currency> currencies = new List<Currency>();
        private List<string> rateNames = new List<string>();
        private List<RateShort> rateDynamic = new List<RateShort>();
        private Chart chart = new Chart();
        private Series series = new Series();
        private List<DateTime> days = new List<DateTime>();
        private List<decimal> rateDynamicValues = new List<decimal>();
        private List<Currency> foundCurrencies = new List<Currency>();
        private CurrencyOperations currencyOperations = new CurrencyOperations();

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartBuilder"/> class.
        /// </summary>
        /// <param name="rates">список курсов валют.</param>
        /// <param name="currencies">список валют.</param>
        /// <param name="rateNames">список имён валют.</param>
        public ChartBuilder(List<Rate> rates, List<Currency> currencies, List<string> rateNames)
        {
            InitializeComponent();

            dateTimePickerStart.MinDate = new DateTime(2016, 7, 1);
            dateTimePickerStart.MaxDate = DateTime.Today.Subtract(new TimeSpan(1, 0, 0, 0));
            dateTimePickerEnd.MinDate = new DateTime(2016, 7, 1);
            dateTimePickerEnd.MaxDate = DateTime.Today;

            this.rates = rates;
            this.currencies = currencies;
            this.rateNames = rateNames;

            rateDynamic = new List<RateShort>();

            cbCurrencies.Items.AddRange(rateNames.ToArray());

            cbCurrencies.SelectedIndex = 0;

            chart.Parent = this;
            chart.Location = new Point(30, 30);
            chart.Size = new Size(700, 350);
            chart.ChartAreas.Add(new ChartArea("Rates"));
            chart.ChartAreas[0].AxisY.Title = "Бел.руб";
            series.ChartType = SeriesChartType.Line;
        }

        private void DisplayResults()
        {
            chart.Series.Clear();
            series.Points.Clear();
            chart.Series.Add(CurrencyOperations.GetSeries(rateDynamic, series));
            lblMin.Visible = true;
            lblMax.Visible = true;
            lblAvg.Visible = true;
            lblMin.Text = "Min = " + rateDynamic.Min(a => a.Cur_OfficialRate);
            lblMax.Text = "Max = " + rateDynamic.Max(a => a.Cur_OfficialRate);
            lblAvg.Text = "Avg = " + string.Format("{0:0.0000}", rateDynamic.Average(a => a.Cur_OfficialRate));
        }

        private void BtnPlot_Click(object sender, EventArgs e)
        {
            btnPlot.Enabled = false;

            rateDynamic.Clear();

            if (rateDynamicValues.Count > 0)
            {
                rateDynamicValues.Clear();
            }

            foundCurrencies = CurrencyOperations.GetNecessaryCurrencies(
                currencies,
                cbCurrencies.SelectedItem.ToString(),
                dateTimePickerStart.Value);

            rateDynamic = CurrencyOperations.GetResultDynamic(
                foundCurrencies,
                dateTimePickerStart.Value,
                dateTimePickerEnd.Value);

            DisplayResults();

            btnPlot.Enabled = true;
        }
    }
}
