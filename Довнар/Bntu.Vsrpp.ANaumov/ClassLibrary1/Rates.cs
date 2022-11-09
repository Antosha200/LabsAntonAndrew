using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bntu.Vsrpp.Akutsak.Сore
{
    /// <summary>
    /// Класс, соедржащий официальный курс белорусского рубля по отношению к иностранным валютам,
    /// устанавливаемый Национальным банком на конкретную дату.
    /// </summary>
    public class Rate
    {
        /// <summary>
        /// Получает или устанавливает идентификатор валюты.
        /// </summary>
        [Key]
        public int Cur_ID { get; set; }

        /// <summary>
        /// Получает или устанавливает дату, на которую запрашивается курс.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Получает или устанавливает идентификатор валюты.
        /// </summary>
        public string Cur_Abbreviation { get; set; }

        /// <summary>
        /// Получает или устанавливает буквенный код.
        /// </summary>
        public int Cur_Scale { get; set; }

        /// <summary>
        /// Получает или устанавливает наименование валюты на русском языке во множественном,
        /// либо в единственном числе, в зависимости от количества единиц.
        /// </summary>
        public string Cur_Name { get; set; }

        /// <summary>
        /// Получает или устанавливает курс валюты.
        /// </summary>
        public decimal? Cur_OfficialRate { get; set; }
    }

    /// <summary>
    /// Класс, соедржащий официальный курс белорусского рубля по отношению к иностранным валютам,
    /// устанавливаемый Национальным банком на конкретную дату, имеющий минимальный набор свойств.
    /// </summary>
    public class RateShort
    {
        /// <summary>
        /// Получает или устанавливает идентификатор валюты.
        /// </summary>
        public int Cur_ID { get; set; }

        /// <summary>
        /// Получает или устанавливает дату, на которую запрашивается курс.
        /// </summary>
        [Key]
        public System.DateTime Date { get; set; }

        /// <summary>
        /// Получает или устанавливает курс валюты.
        /// </summary>
        public decimal? Cur_OfficialRate { get; set; }
    }
}