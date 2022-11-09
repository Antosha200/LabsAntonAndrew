using System;
using System.ComponentModel.DataAnnotations;

namespace Bntu.Vsrpp.Akutsak.Сore
{
    /// <summary>
    /// Класс, описывающий валюту.
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Получает или устанавливает идентификатор валюты.
        /// </summary>
        [Key]
        public int Cur_ID { get; set; }

        /// <summary>
        /// Получает или устанавливает код, который используется для связи, при изменениях наименования,
        /// количества единиц к которому устанавливается курс белорусского рубля,
        /// буквенного, цифрового кодов и т.д. фактически одной и той же валюты.
        /// </summary>
        public Nullable<int> Cur_ParentID { get; set; }

        /// <summary>
        /// Получает или устанавливает цифровой код.
        /// </summary>
        public string Cur_Code { get; set; }

        /// <summary>
        /// Получает или устанавливает буквенный код.
        /// </summary>
        public string Cur_Abbreviation { get; set; }

        /// <summary>
        /// Получает или устанавливает наименование валюты на русском языке.
        /// </summary>
        public string Cur_Name { get; set; }

        /// <summary>
        /// Получает или устанавливает наименование валюты на белорусском языке.
        /// </summary>
        public string Cur_Name_Bel { get; set; }

        /// <summary>
        /// Получает или устанавливает наименование валюты на английском языке.
        /// </summary>
        public string Cur_Name_Eng { get; set; }

        /// <summary>
        /// Получает или устанавливает наименование валюты на русском языке, содержащее количество единиц.
        /// </summary>
        public string Cur_QuotName { get; set; }

        /// <summary>
        /// Получает или устанавливает наименование валюты на белорусском языке, содержащее количество единиц.
        /// </summary>
        public string Cur_QuotName_Bel { get; set; }

        /// <summary>
        /// Получает или устанавливает наименование валюты на ранглйском языке, содержащее количество единиц.
        /// </summary>
        public string Cur_QuotName_Eng { get; set; }

        /// <summary>
        /// Получает или устанавливает наименование валюты на русском языке во множественном числе.
        /// </summary>
        public string Cur_NameMulti { get; set; }

        /// <summary>
        /// Получает или устанавливает наименование валюты на белорусском языке во множественном числе.
        /// </summary>
        public string Cur_Name_BelMulti { get; set; }

        /// <summary>
        /// Получает или устанавливает наименование валюты на английском языке во множественном числе.
        /// </summary>
        public string Cur_Name_EngMulti { get; set; }

        /// <summary>
        /// Получает или устанавливает количество единиц иностранной валюты.
        /// </summary>
        public int Cur_Scale { get; set; }

        /// <summary>
        /// Получает или устанавливает периодичность установления курса (0 – ежедневно, 1 – ежемесячно).
        /// </summary>
        public int Cur_Periodicity { get; set; }

        /// <summary>
        /// Получает или устанавливает дату включения валюты в перечень валют,
        /// к которым устанавливается официальный курс бел. рубля.
        /// </summary>
        public System.DateTime Cur_DateStart { get; set; }

        /// <summary>
        /// Получает или устанавливает дату исключения валюты из перечня валют,
        /// к которым устанавливается официальный курс бел. рубля.
        /// </summary>
        public System.DateTime Cur_DateEnd { get; set; }
    }
}