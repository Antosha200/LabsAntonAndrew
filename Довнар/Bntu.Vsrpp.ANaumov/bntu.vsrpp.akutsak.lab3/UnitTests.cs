using System.Collections.Generic;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using Bntu.Vsrpp.Akutsak.Сore;
using NUnit.Framework;

namespace bntu.vsrpp.akutsak.lab3
{
    /// <summary>
    /// Класс для проекта с Unit тестами.
    /// </summary>
    public class UnitTests
    {
        /// <summary>
        /// Метод для тестирования метода GetElementNames, когда в него передаются правильные данные и
        /// ожидается верный результат.
        /// </summary>
        [Test]
        public void GetElementNames_CorrectItems_ReturnTrue()
        {
            List<XElement> items = new List<XElement>();
            XElement xElementFirst = new XElement("FirstName");
            xElementFirst.Add(new XElement("firstElement"));
            xElementFirst.Add(new XElement("secondElement"));
            XElement xElementSecond = new XElement("SecondName");
            xElementSecond.Add(new XElement("firstElement"));
            xElementSecond.Add(new XElement("thirdElement"));
            items.AddRange(new XElement[] { xElementFirst, xElementSecond });

            XMLOperations xmlOperations = new XMLOperations();
            var expectedResult = new List<string>();
            expectedResult.AddRange(new string[] { "firstElement", "secondElement", "thirdElement" });
            Assert.AreEqual(expectedResult, xmlOperations.GetElementNames(items));
        }

        /// <summary>
        /// Метод для тестирования метода GetElementNames, когда в него передаются неправильные данные и
        /// ожидается неверный результат.
        /// </summary>
        [Test]
        public void GetElementNames_IncorrectItems_ReturnFalse()
        {
            List<XElement> items = new List<XElement>();
            XElement xElementFirst = new XElement("FirstName");
            xElementFirst.Add(new XElement("firstElement"));
            xElementFirst.Add(new XElement("secondElement"));
            XElement xElementSecond = new XElement("SecondName");
            xElementSecond.Add(new XElement("firstElement"));
            xElementSecond.Add(new XElement("thirdElement"));
            xElementSecond.Add(new XElement("fourthElement"));
            items.AddRange(new XElement[] { xElementFirst, xElementSecond });

            XMLOperations xmlOperations = new XMLOperations();
            var expectedResult = new List<string>();
            expectedResult.AddRange(new string[] { "firstElement", "secondElement", "thirdElement" });
            Assert.AreNotEqual(expectedResult, xmlOperations.GetElementNames(items));
        }

        /// <summary>
        /// Метод для тестирования метода GetMaxValue, когда в него передаются правильные данные и
        /// ожидается верный результат.
        /// </summary>
        [Test]
        public void GetMaxValue_CorrectItems_ReturnTrue()
        {
            List<XElement> items = new List<XElement>();
            XElement xElementFirst = new XElement("FirstName");
            xElementFirst.Add(new XElement("firstElement", 1));
            XElement xElementSecond = new XElement("SecondName");
            xElementSecond.Add(new XElement("firstElement", 3));
            items.AddRange(new XElement[] { xElementFirst, xElementSecond });

            XMLOperations xmlOperations = new XMLOperations();
            Assert.AreEqual(3, xmlOperations.GetMaxValue("firstElement", items));
        }

        /// <summary>
        /// Метод для тестирования метода GetMaxValue, когда в него передаются неправильные данные и
        /// ожидается неверный результат.
        /// </summary>
        [Test]
        public void GetMaxValue_IncorrectItems_ReturnFalse()
        {
            List<XElement> items = new List<XElement>();
            XElement xElementFirst = new XElement("FirstName");
            xElementFirst.Add(new XElement("firstElement", 1));
            XElement xElementSecond = new XElement("SecondName");
            xElementSecond.Add(new XElement("firstElement", 3));
            items.AddRange(new XElement[] { xElementFirst, xElementSecond });

            XMLOperations xmlOperations = new XMLOperations();
            Assert.AreNotEqual(1, xmlOperations.GetMaxValue("firstElement", items));
        }

        /// <summary>
        /// Метод для тестирования метода GetMinValue, когда в него передаются правильные данные и
        /// ожидается верный результат.
        /// </summary>
        [Test]
        public void GetMinValue_CorrectItems_ReturnTrue()
        {
            List<XElement> items = new List<XElement>();
            XElement xElementFirst = new XElement("FirstName");
            xElementFirst.Add(new XElement("firstElement", 1));
            XElement xElementSecond = new XElement("SecondName");
            xElementSecond.Add(new XElement("firstElement", 3));
            items.AddRange(new XElement[] { xElementFirst, xElementSecond });

            XMLOperations xmlOperations = new XMLOperations();
            Assert.AreEqual(1, xmlOperations.GetMinValue("firstElement", items));
        }

        /// <summary>
        /// Метод для тестирования метода GetMinValue, когда в него передаются неправильные данные и
        /// ожидается неверный результат.
        /// </summary>
        [Test]
        public void GetMinValue_IncorrectItems_ReturnFalse()
        {
            List<XElement> items = new List<XElement>();
            XElement xElementFirst = new XElement("FirstName");
            xElementFirst.Add(new XElement("firstElement", 1));
            XElement xElementSecond = new XElement("SecondName");
            xElementSecond.Add(new XElement("firstElement", 3));
            items.AddRange(new XElement[] { xElementFirst, xElementSecond });

            XMLOperations xmlOperations = new XMLOperations();
            Assert.AreNotEqual(3, xmlOperations.GetMinValue("firstElement", items));
        }

        /// <summary>
        /// Метод для тестирования метода GetAvgValue, когда в него передаются правильные данные и
        /// ожидается верный результат.
        /// </summary>
        [Test]
        public void GetAvgValue_CorrectItems_ReturnTrue()
        {
            List<XElement> items = new List<XElement>();
            XElement xElementFirst = new XElement("FirstName");
            xElementFirst.Add(new XElement("firstElement", 1));
            XElement xElementSecond = new XElement("SecondName");
            xElementSecond.Add(new XElement("firstElement", 3));
            items.AddRange(new XElement[] { xElementFirst, xElementSecond });

            XMLOperations xmlOperations = new XMLOperations();
            Assert.AreEqual(2, xmlOperations.GetAvgValue("firstElement", items));
        }

        /// <summary>
        /// Метод для тестирования метода GetAvgValue, когда в него передаются неправильные данные и
        /// ожидается неверный результат.
        /// </summary>
        [Test]
        public void GetAvgValue_IncorrectItems_ReturnFalse()
        {
            List<XElement> items = new List<XElement>();
            XElement xElementFirst = new XElement("FirstName");
            xElementFirst.Add(new XElement("firstElement", 1));
            XElement xElementSecond = new XElement("SecondName");
            xElementSecond.Add(new XElement("firstElement", 3));
            items.AddRange(new XElement[] { xElementFirst, xElementSecond });

            XMLOperations xmlOperations = new XMLOperations();
            Assert.AreNotEqual(3, xmlOperations.GetAvgValue("firstElement", items));
        }

        /// <summary>
        /// Метод для тестирования метода GetMaxStringLength, когда в него передаются правильные данные и
        /// ожидается верный результат.
        /// </summary>
        [Test]
        public void GetMaxStringLength_CorrectItems_ReturnTrue()
        {
            List<XElement> items = new List<XElement>();
            XElement xElementFirst = new XElement("FirstName");
            xElementFirst.Add(new XElement("firstElement", "first string"));
            XElement xElementSecond = new XElement("SecondName");
            xElementSecond.Add(new XElement("firstElement", "second string"));
            items.AddRange(new XElement[] { xElementFirst, xElementSecond });

            XMLOperations xmlOperations = new XMLOperations();
            Assert.AreEqual(13, xmlOperations.GetMaxStringLength("firstElement", items));
        }

        /// <summary>
        /// Метод для тестирования метода GetMaxStringLength, когда в него передаются неправильные данные и
        /// ожидается неверный результат.
        /// </summary>
        [Test]
        public void GetMaxStringLength_IncorrectItems_ReturnFalse()
        {
            List<XElement> items = new List<XElement>();
            XElement xElementFirst = new XElement("FirstName");
            xElementFirst.Add(new XElement("firstElement", "first string"));
            XElement xElementSecond = new XElement("SecondName");
            xElementSecond.Add(new XElement("firstElement", "second string"));
            items.AddRange(new XElement[] { xElementFirst, xElementSecond });

            XMLOperations xmlOperations = new XMLOperations();
            Assert.AreNotEqual(12, xmlOperations.GetMaxStringLength("firstElement", items));
        }

        /// <summary>
        /// Метод для тестирования метода GetMinStringLength, когда в него передаются правильные данные и
        /// ожидается верный результат.
        /// </summary>
        [Test]
        public void GetMinStringLength_CorrectItems_ReturnTrue()
        {
            List<XElement> items = new List<XElement>();
            XElement xElementFirst = new XElement("FirstName");
            xElementFirst.Add(new XElement("firstElement", "first string"));
            XElement xElementSecond = new XElement("SecondName");
            xElementSecond.Add(new XElement("firstElement", "second string"));
            items.AddRange(new XElement[] { xElementFirst, xElementSecond });

            XMLOperations xmlOperations = new XMLOperations();
            Assert.AreEqual(12, xmlOperations.GetMinStringLength("firstElement", items));
        }

        /// <summary>
        /// Метод для тестирования метода GetMinStringLength, когда в него передаются неправильные данные и
        /// ожидается неверный результат.
        /// </summary>
        [Test]
        public void GetMinStringLength_IncorrectItems_ReturnFalse()
        {
            List<XElement> items = new List<XElement>();
            XElement xElementFirst = new XElement("FirstName");
            xElementFirst.Add(new XElement("firstElement", "first string"));
            XElement xElementSecond = new XElement("SecondName");
            xElementSecond.Add(new XElement("firstElement", "second string"));
            items.AddRange(new XElement[] { xElementFirst, xElementSecond });

            XMLOperations xmlOperations = new XMLOperations();
            Assert.AreNotEqual(13, xmlOperations.GetMinStringLength("firstElement", items));
        }

        /// <summary>
        /// Метод для тестирования метода GetAvgStringLength, когда в него передаются правильные данные и
        /// ожидается верный результат.
        /// </summary>
        [Test]
        public void GetAvgStringLength_CorrectItems_ReturnTrue()
        {
            List<XElement> items = new List<XElement>();
            XElement xElementFirst = new XElement("FirstName");
            xElementFirst.Add(new XElement("firstElement", "first string"));
            XElement xElementSecond = new XElement("SecondName");
            xElementSecond.Add(new XElement("firstElement", "second string"));
            items.AddRange(new XElement[] { xElementFirst, xElementSecond });

            XMLOperations xmlOperations = new XMLOperations();
            Assert.AreEqual(12.5, xmlOperations.GetAvgStringLength("firstElement", items));
        }

        /// <summary>
        /// Метод для тестирования метода GetAvgStringLength, когда в него передаются неправильные данные и
        /// ожидается неверный результат.
        /// </summary>
        [Test]
        public void GetAvgStringLength_IncorrectItems_ReturnFalse()
        {
            List<XElement> items = new List<XElement>();
            XElement xElementFirst = new XElement("FirstName");
            xElementFirst.Add(new XElement("firstElement", "first string"));
            XElement xElementSecond = new XElement("SecondName");
            xElementSecond.Add(new XElement("firstElement", "second string"));
            items.AddRange(new XElement[] { xElementFirst, xElementSecond });

            XMLOperations xmlOperations = new XMLOperations();
            Assert.AreNotEqual(12, xmlOperations.GetAvgStringLength("firstElement", items));
        }

        /// <summary>
        /// Метод для тестирования метода GetPossibleParameters, когда в него передается правильная операция
        /// для поля Score и ожидается верный результат.
        /// </summary>
        [Test]
        public void GetPossibleParameters_CorrectOpeartionForScore_ReturnTrue()
        {
            List<XElement> items = new List<XElement>();
            XElement xElementFirst = new XElement("FirstName");
            xElementFirst.Add(new XElement("Email", "first string"));
            xElementFirst.Add(new XElement("Score", 11));
            XElement xElementSecond = new XElement("SecondName");
            xElementSecond.Add(new XElement("Email", "second string"));
            xElementSecond.Add(new XElement("Score", 12));
            items.AddRange(new XElement[] { xElementFirst, xElementSecond });

            XMLOperations xmlOperations = new XMLOperations();
            var expectedResult = new List<string>();
            expectedResult.Add("Score");
            Assert.AreEqual(expectedResult, xmlOperations.GetPossibleParameters("Avg value", items));
        }

        /// <summary>
        /// Метод для тестирования метода GetPossibleParameters, когда в него передается неправильная операция
        /// для поля Email и ожидается неверный результат.
        /// </summary>
        [Test]
        public void GetPossibleParameters_IncorrectOperationForEmail_ReturnFalse()
        {
            List<XElement> items = new List<XElement>();
            XElement xElementFirst = new XElement("FirstName");
            xElementFirst.Add(new XElement("Email", "first string"));
            xElementFirst.Add(new XElement("Score", 11));
            XElement xElementSecond = new XElement("SecondName");
            xElementSecond.Add(new XElement("Email", "second string"));
            xElementSecond.Add(new XElement("Score", 12));
            items.AddRange(new XElement[] { xElementFirst, xElementSecond });

            XMLOperations xmlOperations = new XMLOperations();
            var expectedResult = new List<string>();
            expectedResult.Add("Email");
            Assert.AreNotEqual(expectedResult, xmlOperations.GetPossibleParameters("Avg value", items));
        }

        /// <summary>
        /// Метод для тестирования метода GetPossibleParameters, когда в него передается правильная операция
        /// для поля Email и ожидается верный результат.
        /// </summary>
        [Test]
        public void GetPossibleParameters_CorrectOpeartionForEmail_ReturnTrue()
        {
            List<XElement> items = new List<XElement>();
            XElement xElementFirst = new XElement("FirstName");
            xElementFirst.Add(new XElement("Email", "first string"));
            xElementFirst.Add(new XElement("Score", 11));
            XElement xElementSecond = new XElement("SecondName");
            xElementSecond.Add(new XElement("Email", "second string"));
            xElementSecond.Add(new XElement("Score", 12));
            items.AddRange(new XElement[] { xElementFirst, xElementSecond });

            var xmlOperations = new XMLOperations();
            var expectedResult = new List<string>();
            expectedResult.Add("Email");
            Assert.AreEqual(expectedResult, xmlOperations.GetPossibleParameters("Max string length", items));
        }

        /// <summary>
        /// Метод для тестирования метода GetPossibleParameters, когда в него передается неправильная операция
        /// для поля Score и ожидается неверный результат.
        /// </summary>
        [Test]
        public void GetPossibleParameters_IncorrectOperationForScore_ReturnFalse()
        {
            List<XElement> items = new List<XElement>();
            XElement xElementFirst = new XElement("FirstName");
            xElementFirst.Add(new XElement("Email", "first string"));
            xElementFirst.Add(new XElement("Score", 11));
            XElement xElementSecond = new XElement("SecondName");
            xElementSecond.Add(new XElement("Email", "second string"));
            xElementSecond.Add(new XElement("Score", 12));
            items.AddRange(new XElement[] { xElementFirst, xElementSecond });

            var xmlOperations = new XMLOperations();
            var expectedResult = new List<string>();
            expectedResult.Add("Score");
            Assert.AreNotEqual(expectedResult, xmlOperations.GetPossibleParameters("Max string length", items));
        }

        /// <summary>
        /// Метод для тестирования метода GetCurrentRate, когда в него передаются правильные данные
        /// и ожидается верный результат.
        /// </summary>
        [Test]
        public void GetValueResult_CorrectItems_ReturnTrue()
        {
            var rates = new List<Rate>();
            var currencies = new List<Currency>();
            var currencyEuro = new Currency(); var currencyUSDollar = new Currency();
            currencyEuro.Cur_Name = "Евро"; currencyUSDollar.Cur_Name = "Доллар США";
            currencyEuro.Cur_ID = 451; currencyUSDollar.Cur_ID = 431;
            currencyEuro.Cur_DateEnd = new System.DateTime(2050, 1, 1);
            currencyUSDollar.Cur_DateEnd = new System.DateTime(2050, 1, 1);
            currencies.Add(currencyEuro); currencies.Add(currencyUSDollar);
            var rateEuro = new Rate(); var rateUSDollar = new Rate();
            rateEuro.Cur_Name = "Евро"; rateUSDollar.Cur_Name = "Доллар США";
            rateEuro.Cur_ID = 451; rateUSDollar.Cur_ID = 431;
            rateEuro.Cur_OfficialRate = (decimal?)2.8; rateUSDollar.Cur_OfficialRate = (decimal?)2.5;
            rateEuro.Cur_Scale = 1; rateUSDollar.Cur_Scale = 1;
            rates.Add(rateEuro); rates.Add(rateUSDollar);
            Assert.AreEqual(
                (15 * 2.8 / 2.5).ToString(),
                CurrencyOperations.GetValueResult("15", currencies, rates, "Доллар США", "Евро"));
        }

        /// <summary>
        /// Метод для тестирования метода GetCurrentRate, когда в него передаются неправильные данные
        /// и ожидается неверный результат.
        /// </summary>
        [Test]
        public void GetValueResult_IncorrectItems_ReturnFalse()
        {
            var rates = new List<Rate>();
            var currencies = new List<Currency>();
            var currencyEuro = new Currency(); var currencyUSDollar = new Currency();
            currencyEuro.Cur_Name = "Евро"; currencyUSDollar.Cur_Name = "Доллар США";
            currencyEuro.Cur_ID = 451; currencyUSDollar.Cur_ID = 431;
            currencyEuro.Cur_DateEnd = new System.DateTime(2050, 1, 1);
            currencyUSDollar.Cur_DateEnd = new System.DateTime(2050, 1, 1);
            currencies.Add(currencyEuro); currencies.Add(currencyUSDollar);
            var rateEuro = new Rate(); var rateUSDollar = new Rate();
            rateEuro.Cur_Name = "Евро"; rateUSDollar.Cur_Name = "Доллар США";
            rateEuro.Cur_ID = 451; rateUSDollar.Cur_ID = 431;
            rateEuro.Cur_OfficialRate = (decimal?)2.8; rateUSDollar.Cur_OfficialRate = (decimal?)2.5;
            rateEuro.Cur_Scale = 1; rateUSDollar.Cur_Scale = 1;
            rates.Add(rateEuro); rates.Add(rateUSDollar);
            Assert.AreNotEqual(
                (15 * 2.8 / 2.5).ToString(),
                CurrencyOperations.GetValueResult("15", currencies, rates, "Евро", "Доллар США"));
        }

        /// <summary>
        /// Метод для тестирования метода GetNecessaryCurrencies, когда в него передаются неправильные данные
        /// и ожидается неверный результат.
        /// </summary>
        [Test]
        public void GetNecessaryCurrencies_CorrectItems_ReturnTrue()
        {
            var currencies = new List<Currency>();
            var euro292 = new Currency(); var euro451 = new Currency();
            euro292.Cur_ID = 292; euro451.Cur_ID = 451;
            euro292.Cur_QuotName = "1 Евро"; euro451.Cur_QuotName = "1 Евро";
            euro292.Cur_DateEnd = new System.DateTime(2021, 7, 8);
            euro451.Cur_DateEnd = new System.DateTime(2050, 1, 1);
            currencies.AddRange(new Currency[] { euro292, euro451 });
            var expectedResult = new List<Currency>();
            expectedResult.Add(euro451);
            Assert.AreEqual(expectedResult, CurrencyOperations.GetNecessaryCurrencies(
                currencies,
                "1 Евро",
                new System.DateTime(2021, 9, 9)));
        }

        /// <summary>
        /// Метод для тестирования метода GetNecessaryCurrencies, когда в него передаются неправильные данные
        /// и ожидается неверный результат.
        /// </summary>
        [Test]
        public void GetNecessaryCurrencies_IncorrectItems_ReturnFalse()
        {
            var currencies = new List<Currency>();
            var euro292 = new Currency(); var euro451 = new Currency();
            euro292.Cur_ID = 292; euro451.Cur_ID = 451;
            euro292.Cur_QuotName = "1 Евро"; euro451.Cur_QuotName = "10 Евро";
            euro292.Cur_DateEnd = new System.DateTime(2021, 7, 8);
            euro451.Cur_DateEnd = new System.DateTime(2050, 1, 1);
            currencies.AddRange(new Currency[] { euro292, euro451 });
            var expectedResult = new List<Currency>();
            expectedResult.Add(euro451);
            Assert.AreNotEqual(expectedResult, CurrencyOperations.GetNecessaryCurrencies(
                currencies,
                "1 Евро",
                new System.DateTime(2021, 9, 9)));
        }

        /// <summary>
        /// Метод для тестирования метода GetNecessaryDateTime, когда в него передаются правильные данные
        /// для периода не превышающего во времени 365 дней и ожидается верный результат.
        /// </summary>
        [Test]
        public void GetNextDateTime_ForLessThanYearCorrectItems_ReturnTrue()
        {
            var currencies = new List<Currency>();
            var euro451 = new Currency();
            euro451.Cur_ID = 451;
            euro451.Cur_DateEnd = new System.DateTime(2050, 1, 1);
            currencies.AddRange(new Currency[] { euro451 });
            Assert.AreEqual(new System.DateTime(2021, 10, 10), CurrencyOperations.GetNextDateTime(
                currencies,
                new System.DateTime(2021, 8, 10),
                new System.DateTime(2021, 10, 10),
                451));
        }

        /// <summary>
        /// Метод для тестирования метода GetNecessaryDateTime, когда в него передаются правильные данные
        /// для периода превышающего во времени 365 дней и ожидается верный результат.
        /// </summary>
        [Test]
        public void GetNextDateTime_ForMoreThanYearCorrectItems_ReturnTrue()
        {
            var currencies = new List<Currency>();
            var euro451 = new Currency();
            euro451.Cur_ID = 451;
            euro451.Cur_DateEnd = new System.DateTime(2050, 1, 1);
            currencies.AddRange(new Currency[] { euro451 });
            Assert.AreEqual(new System.DateTime(2022, 8, 10), CurrencyOperations.GetNextDateTime(
                currencies,
                new System.DateTime(2021, 8, 10),
                new System.DateTime(2022, 10, 10),
                451));
        }

        /// <summary>
        /// Метод для тестирования метода GetNecessaryDateTime, когда в него передаются правильные данные
        /// для периода не превышающего во времени 365 дней и ожидается неверный результат.
        /// </summary>
        [Test]
        public void GetNextDateTime_ForLessThanYearIncorrectItems_ReturnFalse()
        {
            var currencies = new List<Currency>();
            var euro451 = new Currency();
            euro451.Cur_ID = 451;
            euro451.Cur_DateEnd = new System.DateTime(2050, 1, 1);
            currencies.AddRange(new Currency[] { euro451 });
            Assert.AreNotEqual(new System.DateTime(2021, 10, 10), CurrencyOperations.GetNextDateTime(
                currencies,
                new System.DateTime(2021, 8, 10),
                new System.DateTime(2022, 10, 10),
                451));
        }

        /// <summary>
        /// Метод для тестирования метода GetNecessaryDateTime, когда в него передаются правильные данные
        /// для периода превышающего во времени 365 дней и ожидается неверный результат.
        /// </summary>
        [Test]
        public void GetNextDateTime_ForMoreThanYearIncorrectItems_ReturnFalse()
        {
            var currencies = new List<Currency>();
            var euro451 = new Currency();
            euro451.Cur_ID = 451;
            euro451.Cur_DateEnd = new System.DateTime(2050, 1, 1);
            currencies.AddRange(new Currency[] { euro451 });
            Assert.AreNotEqual(new System.DateTime(2022, 8, 10), CurrencyOperations.GetNextDateTime(
                currencies,
                new System.DateTime(2021, 9, 10),
                new System.DateTime(2022, 10, 10),
                451));
        }
    }
}