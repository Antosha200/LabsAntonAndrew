namespace Bntu.Vsrpp.Akutsak.Сore
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Windows.Forms.DataVisualization.Charting;
    using Newtonsoft.Json;

    /// <summary>
    /// Класс, содержащий методы для работы с программой для работы с валютами.
    /// </summary>
    public class CurrencyOperations
    {
        private static HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Метод для получения списка всех валют.
        /// </summary>
        /// <returns>Возвращает массив валют.</returns>
        public static Currency[] GetCurrencies()
        {
            string obj = null;

            HttpResponseMessage responseMessage = httpClient.
                GetAsync($"https://www.nbrb.by/api/exrates/currencies").Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                obj = responseMessage.Content.ReadAsStringAsync().Result;
                Currency[] currencies = JsonConvert.DeserializeObject<Currency[]>(obj);
                return currencies;
            }

            return null;
        }

        /// <summary>
        /// Метод для получения курсов валют, обновляющихся ежедневно.
        /// </summary>
        /// <param name="date">Дата, на которую запрашивается курс.</param>
        /// <returns>Возвращает массив курсов валют.</returns>
        public static Rate[] GetRatesDaily(DateTime date)
        {
            string obj = null;

            HttpResponseMessage responseMessage = httpClient.GetAsync(
                $"https://www.nbrb.by/api/exrates/rates?ondate={date.ToString("s")}" +
                "&periodicity=0").Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                obj = responseMessage.Content.ReadAsStringAsync().Result;
                Rate[] rates = JsonConvert.DeserializeObject<Rate[]>(obj);
                return rates;
            }

            System.Threading.Thread.Sleep(300);

            return null;
        }

        /// <summary>
        /// Метод для получения курсов валют, обновляющихся ежемесячно.
        /// </summary>
        /// <param name="date">Дата, на которую запрашивается курс.</param>
        /// <returns>Возвращает массив курсов валют.</returns>
        public static Rate[] GetRatesMonthly(DateTime date)
        {
            string obj = null;

            HttpResponseMessage responseMessage = httpClient.GetAsync(
                $"https://www.nbrb.by/api/exrates/rates?ondate={date.ToString("s")}" +
                "&periodicity=1").Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                obj = responseMessage.Content.ReadAsStringAsync().Result;
                Rate[] rates = JsonConvert.DeserializeObject<Rate[]>(obj);
                return rates;
            }

            System.Threading.Thread.Sleep(300);

            return null;
        }

        /// <summary>
        /// Метод для получения динамики курса валюты с определённым идентификатором.
        /// </summary>
        /// <param name="currentRateId">идентификатор валюты.</param>
        /// <param name="dateTimeStart">начальная дата периода.</param>
        /// <param name="dateTimeEnd">конечная дата периода.</param>
        /// <returns>Возвращает список курсов валюты с определённым идентификатором.</returns>
        public static List<RateShort> GetRateDynamic(int currentRateId, DateTime dateTimeStart, DateTime dateTimeEnd)
        {
            string obj = null;

            HttpResponseMessage responseMessage = httpClient.GetAsync("https://www.nbrb.by/API/ExRates/Rates/Dynamics/" +
                    $"{currentRateId}?startDate={dateTimeStart.ToString("s")}" +
                    $"&endDate={dateTimeEnd.ToString("s")}").Result;

            System.Threading.Thread.Sleep(300);

            if (responseMessage.IsSuccessStatusCode)
            {
                obj = responseMessage.Content.ReadAsStringAsync().Result;
                List<RateShort> rates = JsonConvert.DeserializeObject<List<RateShort>>(obj);
                return rates;
            }

            return null;
        }

        /// <summary>
        /// Метод для расчёта конвертации валюты.
        /// </summary>
        /// <param name="valueInputText">значение исходной валюты в строковом виде.</param>
        /// <param name="currencies">список валют.</param>
        /// <param name="rates">список курсов валют.</param>
        /// <param name="targetRateName">наименование курса валюты, в которую конвертируется исходная валюта.</param>
        /// <param name="currentRateName">наименование курса исходной валюты, которая будет конвертироваться.</param>
        /// <returns>Возвращает результирующее значение в строковом виде.</returns>
        public static string GetValueResult(string valueInputText, List<Currency> currencies, List<Rate> rates, string targetRateName, string currentRateName)
        {
            decimal valueInput = 0;
            decimal curRateValue = 0;
            decimal targetRateValue = 0;
            decimal curRateScale = 0;
            decimal targetRateScale = 0;
            var currentId = currencies.Find(a => a.Cur_Name.Equals(currentRateName) && a.Cur_DateEnd > DateTime.Today).Cur_ID;
            var targetId = currencies.Find(a => a.Cur_Name.Equals(targetRateName) && a.Cur_DateEnd > DateTime.Today).Cur_ID;
            if (valueInputText.Length > 0)
            {
                decimal.TryParse(valueInputText, out valueInput);
            }

            if (currentRateName.Equals("Белорусский рубль"))
            {
                curRateValue = 1;
                curRateScale = 1;
            }
            else
            {
                curRateValue = (decimal)rates.Find(a => a.Cur_ID.Equals(currentId)).Cur_OfficialRate;
                curRateScale = rates.Find(a => a.Cur_ID.Equals(currentId)).Cur_Scale;
            }

            if (targetRateName.Equals("Белорусский рубль"))
            {
                targetRateValue = 1;
                targetRateScale = 1;
            }
            else
            {
                targetRateValue = (decimal)rates.Find(a => a.Cur_ID.Equals(targetId)).Cur_OfficialRate;
                targetRateScale = rates.Find(a => a.Cur_ID.Equals(targetId)).Cur_Scale;
            }

            return (valueInput * curRateValue * targetRateScale /
                targetRateValue / curRateScale).ToString();
        }

        /// <summary>
        /// Метод для составления набора данных в виде точек на графике.
        /// </summary>
        /// <param name="rateDynamic">список курсов валюты за определённый период.</param>
        /// <param name="series">пустой набор данных для графика.</param>
        /// <returns>Возвращает набор данных для построения графика.</returns>
        public static Series GetSeries(List<RateShort> rateDynamic, Series series)
        {
            var days = new List<DateTime>();
            var rateDynamicValues = new List<decimal>();
            foreach (RateShort item in rateDynamic)
            {
                days.Add(item.Date);
                rateDynamicValues.Add((decimal)item.Cur_OfficialRate);
                series.Points.AddXY(item.Date, item.Cur_OfficialRate);
            }

            return series;
        }

        /// <summary>
        /// Метод для получения необходимых валют с одним названием, но разными идентификаоторами,
        /// использующихся в выбранном периоде.
        /// </summary>
        /// <param name="currencies">список всех валют.</param>
        /// <param name="rateName">название требуемых валют.</param>
        /// <param name="dateTimeStart">начальная дата выбранного периода.</param>
        /// <returns>Возвращает список валют, входящих в выбранный период.</returns>
        public static List<Currency> GetNecessaryCurrencies(List<Currency> currencies, string rateName, DateTime dateTimeStart)
        {
            var foundCurrencies = currencies.FindAll(a => a.Cur_QuotName.Equals(rateName));
            List<Currency> foundCurrenciesChanged = new List<Currency>();
            foundCurrenciesChanged.AddRange(foundCurrencies.ToArray());

            foreach (Currency item in foundCurrencies)
            {
                if (item.Cur_DateEnd < dateTimeStart)
                {
                    foundCurrenciesChanged.Remove(item);
                }
            }

            return foundCurrenciesChanged;
        }

        /// <summary>
        /// Метод для получения конечной даты очередного периода, передаваемого в запрос к API.
        /// </summary>
        /// <param name="foundCurrencies">список валют с выбранным названием, попадающими в выбранный период.</param>
        /// <param name="curDateTime">первая дата очередного периода, передаваемого в запрос к API.</param>
        /// <param name="dateTimeEnd">конечная дата всего выбранного периода.</param>
        /// <param name="currentRateId">текущий идентификатор валюты.</param>
        /// <returns>Возвращает конечную дату очередного периода, передаваемого в запрос к API.</returns>
        public static DateTime GetNextDateTime(List<Currency> foundCurrencies, DateTime curDateTime, DateTime dateTimeEnd, int currentRateId)
        {
            var nextDateTime = dateTimeEnd;

            if (curDateTime.AddDays(365) < foundCurrencies.Find(a => a.
                        Cur_ID.Equals(currentRateId)).Cur_DateEnd)
            {
                if (curDateTime.AddDays(365) < dateTimeEnd)
                {
                    nextDateTime = curDateTime.AddDays(365);
                }
                else
                {
                    nextDateTime = dateTimeEnd;
                }
            }
            else
            {
                nextDateTime = foundCurrencies.Find(a => a.
                    Cur_ID.Equals(currentRateId)).Cur_DateEnd;
            }

            return nextDateTime;
        }

        /// <summary>
        /// Метод для получения динамики курса выбранной валюты за выбранный период.
        /// </summary>
        /// <param name="foundCurrencies">список валют с одним названием, но разными идентификаторами,
        /// попадающими в выбранный период.</param>
        /// <param name="dateStart">начальная дата всего периода.</param>
        /// <param name="dateEnd">конечная дата всего периода.</param>
        /// <returns>Возвращает список курсов валюты за выбранный период.</returns>
        public static List<RateShort> GetResultDynamic(List<Currency> foundCurrencies, DateTime dateStart, DateTime dateEnd)
        {
            var curDateTime = new DateTime();
            var nextDateTime = new DateTime();
            var currentRateId = foundCurrencies[0].Cur_ID;
            List<RateShort> rateDynamic = new List<RateShort>();
            curDateTime = dateStart;
            nextDateTime = dateEnd;

            for (; ;)
            {
                nextDateTime = GetNextDateTime(
                    foundCurrencies,
                    curDateTime,
                    dateEnd,
                    currentRateId);

                rateDynamic.AddRange(GetRateDynamic(
                    currentRateId,
                    curDateTime,
                    nextDateTime));

                curDateTime = nextDateTime.AddDays(1);

                if (nextDateTime.Equals(dateEnd))
                {
                    return rateDynamic;
                }

                if (curDateTime > foundCurrencies.Find(a => a.
                    Cur_ID.Equals(currentRateId)).Cur_DateEnd)
                {
                    if (foundCurrencies.Any(a => a.Cur_DateStart.Equals(curDateTime)))
                    {
                        currentRateId = foundCurrencies.Find(a => a.Cur_DateStart.Equals(curDateTime)).
                            Cur_ID;
                    }
                    else
                    {
                        return rateDynamic;
                    }
                }
            }
        }
    }
}
