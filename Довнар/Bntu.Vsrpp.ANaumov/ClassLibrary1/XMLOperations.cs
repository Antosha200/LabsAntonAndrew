using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Bntu.Vsrpp.Akutsak.Сore
{
    /// <summary>
    /// Класс, содержащий операции для работы с xml документами.
    /// </summary>
    public class XMLOperations
    {
        /// <summary>
        /// Метод для получения xml элементов.
        /// </summary>
        /// <param name="filePath">путь к файлу xml.</param>
        /// <returns>Возвращает список xml элементов.</returns>
        public List<XElement> GetXElements(string filePath)
        {
            var xDoc = new XDocument();
            xDoc = XDocument.Load(filePath);
            return xDoc.Root.Elements("Student").ToList();
        }

        /// <summary>
        /// Метод для получения имён элементов.
        /// </summary>
        /// <param name="items">список xml элементов.</param>
        /// <returns>Возвращает имена элементов xml.</returns>
        public List<string> GetElementNames(List<XElement> items)
        {
            List<string> elementNames = new List<string>();
            foreach (XElement xElement in items)
            {
                foreach (XElement xElement1 in xElement.Elements())
                {
                    if (!elementNames.Contains(xElement1.Name.ToString()))
                    {
                        elementNames.Add(xElement1.Name.ToString());
                    }
                }
            }

            return elementNames;
        }

        /// <summary>
        /// Метод для получения максимального числового значения параметра среди элементов.
        /// </summary>
        /// <param name="parameter">название параметра элемента.</param>
        /// <param name="items">список xml элементов.</param>
        /// <returns>Возвращает максимальное значение параметра.</returns>
        public int GetMaxValue(string parameter, List<XElement> items)
        {
            var maxValue = int.MinValue;
            List<Object> elements = new List<Object>();
            foreach (XElement xElement in items)
            {
                foreach (XElement xElement1 in xElement.Elements())
                {
                    if (xElement1.Name.LocalName.Equals(parameter))
                    {
                        elements.Add(xElement1);
                        var a = 0;
                        int.TryParse(xElement1.Value, out a);
                        if (a > maxValue)
                        {
                            maxValue = a;
                        }
                    }
                }
            }

            return maxValue;
        }

        /// <summary>
        /// Метод для получения минимального числового значения параметра среди элементов.
        /// </summary>
        /// <param name="parameter">название параметра элемента.</param>
        /// <param name="items">список xml элементов.</param>
        /// <returns>Возвращает минимальное значение параметра.</returns>
        public int GetMinValue(string parameter, List<XElement> items)
        {
            var minValue = int.MaxValue;
            List<Object> elements = new List<Object>();
            foreach (XElement xElement in items)
            {
                foreach (XElement xElement1 in xElement.Elements())
                {
                    if (xElement1.Name.LocalName.Equals(parameter))
                    {
                        elements.Add(xElement1);
                        var a = 0;
                        int.TryParse(xElement1.Value, out a);
                        if (a < minValue)
                        {
                            minValue = a;
                        }
                    }
                }
            }

            return minValue;
        }

        /// <summary>
        /// Метод для получения среднего числового значения параметра среди элементов.
        /// </summary>
        /// <param name="parameter">название параметра элемента.</param>
        /// <param name="items">список xml элементов.</param>
        /// <returns>Возвращает среднее значение параметра.</returns>
        public double GetAvgValue(string parameter, List<XElement> items)
        {
            var avgValue = double.MinValue;
            double sum = 0;
            List<Object> elements = new List<Object>();
            foreach (XElement xElement in items)
            {
                foreach (XElement xElement1 in xElement.Elements())
                {
                    if (xElement1.Name.LocalName.Equals(parameter))
                    {
                        elements.Add(xElement1);
                        double a = 0;
                        double.TryParse(xElement1.Value, out a);
                        sum += a;
                    }
                }
            }

            avgValue = sum / elements.Count;
            return avgValue;
        }

        /// <summary>
        /// Метод для получения максимального значения строковой длины параметра среди элементов.
        /// </summary>
        /// <param name="parameter">название параметра элемента.</param>
        /// <param name="items">список xml элементов.</param>
        /// <returns>Возвращает максимальное значение строковой длины параметра.</returns>
        public int GetMaxStringLength(string parameter, List<XElement> items)
        {
            var maxStringLength = int.MinValue;
            List<Object> elements = new List<Object>();
            foreach (XElement xElement in items)
            {
                foreach (XElement xElement1 in xElement.Elements())
                {
                    if (xElement1.Name.LocalName.Equals(parameter))
                    {
                        elements.Add(xElement1);
                        if (xElement1.Value.Length > maxStringLength)
                        {
                            maxStringLength = xElement1.Value.Length;
                        }
                    }
                }
            }

            return maxStringLength;
        }

        /// <summary>
        /// Метод для получения минимального значения строковой длины параметра среди элементов.
        /// </summary>
        /// <param name="parameter">название параметра элемента.</param>
        /// <param name="items">список xml элементов.</param>
        /// <returns>Возвращает минимальное значение строковой длины параметра.</returns>
        public int GetMinStringLength(string parameter, List<XElement> items)
        {
            var minStringLength = int.MaxValue;
            List<Object> elements = new List<Object>();
            foreach (XElement xElement in items)
            {
                foreach (XElement xElement1 in xElement.Elements())
                {
                    if (xElement1.Name.LocalName.Equals(parameter))
                    {
                        elements.Add(xElement1);
                        if (xElement1.Value.Length < minStringLength)
                        {
                            minStringLength = xElement1.Value.Length;
                        }
                    }
                }
            }

            return minStringLength;
        }

        /// <summary>
        /// Метод для получения среднего значения строковой длины параметра среди элементов.
        /// </summary>
        /// <param name="parameter">название параметра элемента.</param>
        /// <param name="items">список xml элементов.</param>
        /// <returns>Возвращает среднее значение строковой длины параметра.</returns>
        public double GetAvgStringLength(string parameter, List<XElement> items)
        {
            var avgStringLength = double.MinValue;
            double sum = 0;
            List<Object> elements = new List<Object>();
            foreach (XElement xElement in items)
            {
                foreach (XElement xElement1 in xElement.Elements())
                {
                    if (xElement1.Name.LocalName.Equals(parameter))
                    {
                        elements.Add(xElement1);
                        sum += xElement1.Value.Length;
                    }
                }
            }

            avgStringLength = sum / elements.Count;
            return avgStringLength;
        }

        /// <summary>
        /// Метод для получения списка возможных параметров для выполнения определённой операции.
        /// </summary>
        /// <param name="operation">выбранная операция.</param>
        /// <param name="items">список xml элементов.</param>
        /// <returns>Возвращает список параметров, для которых можно выполнить выбранную операцию.</returns>
        public List<string> GetPossibleParameters(string operation, List<XElement> items)
        {
            List<string> possibleParameters = new List<string>();
            foreach (string elem in GetElementNames(items))
            {
                if (items.All(a => a.Elements().Any(e => e.Name.ToString().Equals(elem))))
                {
                    possibleParameters.Add(elem);
                }
            }

            if (possibleParameters.Contains("Score"))
            {
                if (operation.Contains("string"))
                {
                    possibleParameters.Remove("Score");
                }
                else
                {
                    possibleParameters.Clear();
                    possibleParameters.Add("Score");
                }
            }

            return possibleParameters;
        }

        /// <summary>
        /// Метод для форматирования элементов и привидения их к одному виду.
        /// </summary>
        /// <param name="items">список xml элементов.</param>
        /// <param name="xDoc">объект класса XDocument.</param>
        public void ModifyElements(List<XElement> items, XDocument xDoc)
        {
            foreach (XElement xElement in items)
            {
                if (xElement.Elements().Any(a => a.Name.ToString().Equals("FullName")))
                {
                    string lastName = xElement.Element("FullName").ToString().Split(' ')[0];
                    lastName = lastName.Split('>')[1];

                    string firstName = xElement.Element("FullName").ToString().Split(' ')[1];

                    string secondName = xElement.Element("FullName").ToString().Split(' ')[2];
                    secondName = secondName.Split('<')[0];

                    xElement.Element("FullName").ReplaceWith(new XElement("LastName", lastName),
                        new XElement("FirstName", firstName), new XElement("SecondName", secondName));
                }

                if (!xElement.Elements().Any(a => a.Name.ToString().Equals("LastName")))
                {
                    xElement.Add(new XElement("LastName", "N/A"));
                }

                if (!xElement.Elements().Any(a => a.Name.ToString().Equals("FirstName")))
                {
                    xElement.Add(new XElement("FirstName", "N/A"));
                }

                if (!xElement.Elements().Any(a => a.Name.ToString().Equals("Email")))
                {
                    xElement.Add(new XElement("Email", "N/A"));
                }

                if (!xElement.Elements().Any(a => a.Name.ToString().Equals("SecondName")))
                {
                    xElement.Add(new XElement("SecondName", "N/A"));
                }

                if (!xElement.Elements().Any(a => a.Name.ToString().Equals("Score")))
                {
                    xElement.Add(new XElement("Score", "0"));
                }
            }

            xDoc.Save("output.xml");
        }
    }
}
