// <copyright file="CurrenciesParser.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Bntu.Vsrpp.Akutsak.Lab2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Bntu.Vsrpp.Akutsak.Сore;

    /// <summary>
    /// Класс формы для работы непосредственно с интерфейсом.
    /// </summary>
    public partial class CurrenciesParser : Form
    {
        private List<Currency> currencies = new List<Currency>();
        private List<Rate> rates = new List<Rate>();
        private List<Rate> ratesDaily = new List<Rate>();
        private DateTime date = default(DateTime);
        private Rate currentRate = new Rate();
        private Rate targetRate = new Rate();
        private List<string> rateNames = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrenciesParser"/> class.
        /// Конструктор основного класса формы.
        /// </summary>
        public CurrenciesParser()
        {
            this.InitializeComponent();
            this.date = DateTime.Today;
            this.tbValueInput.Text = "1";
            this.tbValueOutput.Text = "1";
            this.dateTimePicker.MaxDate = DateTime.Today;
            this.dateTimePicker.MinDate = new DateTime(2016, 7, 1);
        }

        private void ClearData()
        {
            if (this.currencies.Count > 0)
            {
                this.currencies.Clear();
            }

            if (this.rates.Count > 0)
            {
                this.rates.Clear();
            }

            if (this.ratesDaily.Count > 0)
            {
                this.ratesDaily.Clear();
            }

            if (this.rateNames.Count > 0)
            {
                this.rateNames.Clear();
            }

            if (this.cbCurrencyInput.Items.Count > 0)
            {
                this.cbCurrencyInput.Items.Clear();
            }

            if (this.cbCurrencyOutput.Items.Count > 0)
            {
                this.cbCurrencyOutput.Items.Clear();
            }
        }

        private void AddDataToComboboxes()
        {
            foreach (Currency item in this.currencies)
            {
                if (this.rates.Any(a => a.Cur_ID.Equals(item.Cur_ID)))
                {
                    this.cbCurrencyInput.Items.Add(item.Cur_Name);
                    this.cbCurrencyOutput.Items.Add(item.Cur_Name);
                }
            }

            this.cbCurrencyInput.Items.Add("Белорусский рубль");
            this.cbCurrencyOutput.Items.Add("Белорусский рубль");
        }

        private void SortDataInComboboxes()
        {
            foreach (object item in this.cbCurrencyInput.Items)
            {
                this.rateNames.Add((string)item);
            }

            this.rateNames.Sort();
            this.cbCurrencyInput.Items.Clear();
            this.cbCurrencyInput.Items.AddRange(this.rateNames.ToArray());
            this.rateNames.Clear();

            foreach (object item in this.cbCurrencyOutput.Items)
            {
                this.rateNames.Add((string)item);
            }

            this.rateNames.Sort();
            this.cbCurrencyOutput.Items.Clear();
            this.cbCurrencyOutput.Items.AddRange(this.rateNames.ToArray());
        }

        private void BtnGetCurrencies_Click(object sender, EventArgs e)
        {
            this.btnGetCurrencies.Enabled = false;
            this.btnResult.Enabled = false;
            this.btnSwitch.Enabled = false;
            var currentCurrency = string.Empty;
            var targetCurrency = string.Empty;
            if (this.cbCurrencyInput.Items.Count != 0)
            {
                currentCurrency = this.cbCurrencyInput.SelectedItem.ToString();
            }

            if (this.cbCurrencyOutput.Items.Count != 0)
            {
                targetCurrency = this.cbCurrencyOutput.SelectedItem.ToString();
            }

            this.ClearData();

            this.currencies.AddRange(CurrencyOperations.GetCurrencies());
            this.rates.AddRange(CurrencyOperations.GetRatesDaily(this.date));
            this.ratesDaily.AddRange(this.rates.ToArray());
            this.rates.AddRange(CurrencyOperations.GetRatesMonthly(this.date));

            this.AddDataToComboboxes();

            this.SortDataInComboboxes();

            this.cbCurrencyInput.SelectedItem = currentCurrency;
            this.cbCurrencyOutput.SelectedItem = targetCurrency;

            MessageBox.Show(
                "Данные получены",
                "Данные получены",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.btnGetCurrencies.Enabled = true;
            this.btnResult.Enabled = true;
            this.btnSwitch.Enabled = true;
            this.btnGraph.Enabled = true;
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (this.dateTimePicker.Value < DateTime.Today)
            {
                this.date = this.dateTimePicker.Value;
            }
        }

        private void BtnResult_Click(object sender, EventArgs e)
        {
            this.tbValueOutput.Text = CurrencyOperations.GetValueResult(
                tbValueInput.Text,
                currencies,
                rates,
                cbCurrencyOutput.SelectedItem.ToString(),
                cbCurrencyInput.SelectedItem.ToString());
        }

        private void BtnSwitch_Click(object sender, EventArgs e)
        {
            string currency;
            if (!this.cbCurrencyInput.SelectedItem.Equals(null) && !this.cbCurrencyOutput.SelectedItem.Equals(null) &&
                this.cbCurrencyOutput.Items.Contains(this.cbCurrencyInput.SelectedItem) &&
                this.cbCurrencyInput.Items.Contains(this.cbCurrencyOutput.SelectedItem))
            {
                currency = this.cbCurrencyInput.Text;
                this.cbCurrencyInput.SelectedItem = this.cbCurrencyOutput.SelectedItem;
                this.cbCurrencyOutput.SelectedIndex = this.cbCurrencyOutput.Items.IndexOf(currency);
            }
        }

        private void BtnGraph_Click(object sender, EventArgs e)
        {
            this.rateNames.Clear();
            foreach (Rate rate in this.ratesDaily)
            {
                this.rateNames.Add(this.currencies.Find(a => a.Cur_ID.Equals(rate.Cur_ID)).Cur_QuotName);
            }

            this.rateNames.Remove("Белорусский рубль");
            ChartBuilder chartBuilder = new ChartBuilder(this.ratesDaily, this.currencies, this.rateNames);
            chartBuilder.Show();
        }
    }
}
