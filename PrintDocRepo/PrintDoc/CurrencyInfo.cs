using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrintDoc
{
    class CurrencyInfo
    {
        public enum Currencies { USA = 0, UAE, SaudiArabia };
        #region Constructors

        public CurrencyInfo(Currencies currency)
        {
            switch (currency)
            {
                case Currencies.USA:
                    this.CurrencyID = 0;
                    this.CurrencyCode = "USD";
                    this.IsCurrencyNameFeminine = true;
                    this.EnglishCurrencyName = "U.S. dollar";
                    this.EnglishPluralCurrencyName = "U.S. dollars";
                    this.EnglishCurrencyPartName = "Cent";
                    this.EnglishPluralCurrencyPartName = "Cents";
                    this.Arabic1CurrencyName = "دولار أمريكي";
                    this.Arabic2CurrencyName = "دولاران أمريكي";
                    this.Arabic310CurrencyName = "دولارات أمريكية";
                    this.Arabic1199CurrencyName = "دولار أمريكي";
                    this.Arabic1CurrencyPartName = "سنت";
                    this.Arabic2CurrencyPartName = "سنتان";
                    this.Arabic310CurrencyPartName = "سنتا";
                    this.Arabic1199CurrencyPartName = "سنتا";
                    this.PartPrecision = 2;
                    this.IsCurrencyPartNameFeminine = false;
                    break;

                case Currencies.UAE:
                    this.CurrencyID = 1;
                    this.CurrencyCode = "AED";
                    this.IsCurrencyNameFeminine = false;
                    this.EnglishCurrencyName = "UAE Dirham";
                    this.EnglishPluralCurrencyName = "UAE Dirhams";
                    this.EnglishCurrencyPartName = "Fils";
                    this.EnglishPluralCurrencyPartName = "Fils";
                    this.Arabic1CurrencyName = "درهم إماراتي";
                    this.Arabic2CurrencyName = "درهمان إماراتيان";
                    this.Arabic310CurrencyName = "دراهم إماراتية";
                    this.Arabic1199CurrencyName = "درهماً إماراتياً";
                    this.Arabic1CurrencyPartName = "فلس";
                    this.Arabic2CurrencyPartName = "فلسان";
                    this.Arabic310CurrencyPartName = "فلوس";
                    this.Arabic1199CurrencyPartName = "فلساً";
                    this.PartPrecision = 2;
                    this.IsCurrencyPartNameFeminine = false;
                    break;

                case Currencies.SaudiArabia:
                    this.CurrencyID = 2;
                    this.CurrencyCode = "SAR";
                    this.IsCurrencyNameFeminine = false;
                    this.EnglishCurrencyName = "Saudi Riyal";
                    this.EnglishPluralCurrencyName = "Saudi Riyals";
                    this.EnglishCurrencyPartName = "Halala";
                    this.EnglishPluralCurrencyPartName = "Halalas";
                    this.Arabic1CurrencyName = "ريال سعودي";
                    this.Arabic2CurrencyName = "ريالان سعوديان";
                    this.Arabic310CurrencyName = "ريالات سعودية";
                    this.Arabic1199CurrencyName = "ريالاً سعودياً";
                    this.Arabic1CurrencyPartName = "هللة";
                    this.Arabic2CurrencyPartName = "هللتان";
                    this.Arabic310CurrencyPartName = "هللات";
                    this.Arabic1199CurrencyPartName = "هللة";
                    this.PartPrecision = 2;
                    this.IsCurrencyPartNameFeminine = true;
                    break;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Currency ID
        /// </summary>
        public int CurrencyID { get; set; }

        /// <summary>
        /// Standard Code
        /// Syrian Pound: SYP
        /// UAE Dirham: AED
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Is the currency name feminine ( Mua'anath مؤنث)
        /// ليرة سورية : مؤنث = true
        /// درهم : مذكر = false
        /// </summary>
        public Boolean IsCurrencyNameFeminine { get; set; }

        /// <summary>
        /// English Currency Name for single use
        /// Syrian Pound
        /// UAE Dirham
        /// </summary>
        public string EnglishCurrencyName { get; set; }

        /// <summary>
        /// English Plural Currency Name for Numbers over 1
        /// Syrian Pounds
        /// UAE Dirhams
        /// </summary>
        public string EnglishPluralCurrencyName { get; set; }

        /// <summary>
        /// Arabic Currency Name for 1 unit only
        /// ليرة سورية
        /// درهم إماراتي
        /// </summary>
        public string Arabic1CurrencyName { get; set; }

        /// <summary>
        /// Arabic Currency Name for 2 units only
        /// ليرتان سوريتان
        /// درهمان إماراتيان
        /// </summary>
        public string Arabic2CurrencyName { get; set; }

        /// <summary>
        /// Arabic Currency Name for 3 to 10 units
        /// خمس ليرات سورية
        /// خمسة دراهم إماراتية
        /// </summary>
        public string Arabic310CurrencyName { get; set; }

        /// <summary>
        /// Arabic Currency Name for 11 to 99 units
        /// خمس و سبعون ليرةً سوريةً
        /// خمسة و سبعون درهماً إماراتياً
        /// </summary>
        public string Arabic1199CurrencyName { get; set; }

        /// <summary>
        /// Decimal Part Precision
        /// for Syrian Pounds: 2 ( 1 SP = 100 parts)
        /// for Tunisian Dinars: 3 ( 1 TND = 1000 parts)
        /// </summary>
        public Byte PartPrecision { get; set; }

        /// <summary>
        /// Is the currency part name feminine ( Mua'anath مؤنث)
        /// هللة : مؤنث = true
        /// قرش : مذكر = false
        /// </summary>
        public Boolean IsCurrencyPartNameFeminine { get; set; }

        /// <summary>
        /// English Currency Part Name for single use
        /// Piaster
        /// Fils
        /// </summary>
        public string EnglishCurrencyPartName { get; set; }

        /// <summary>
        /// English Currency Part Name for Plural
        /// Piasters
        /// Fils
        /// </summary>
        public string EnglishPluralCurrencyPartName { get; set; }

        /// <summary>
        /// Arabic Currency Part Name for 1 unit only
        /// قرش
        /// هللة
        /// </summary>
        public string Arabic1CurrencyPartName { get; set; }

        /// <summary>
        /// Arabic Currency Part Name for 2 unit only
        /// قرشان
        /// هللتان
        /// </summary>
        public string Arabic2CurrencyPartName { get; set; }

        /// <summary>
        /// Arabic Currency Part Name for 3 to 10 units
        /// قروش
        /// هللات
        /// </summary>
        public string Arabic310CurrencyPartName { get; set; }

        /// <summary>
        /// Arabic Currency Part Name for 11 to 99 units
        /// قرشاً
        /// هللةً
        /// </summary>
        public string Arabic1199CurrencyPartName { get; set; }
        #endregion
    }
}
