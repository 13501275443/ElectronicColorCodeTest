using OhmValueCalculator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOhmDemo.Models
{
    public class COhmModel
    {
        public COhmModel()
        {
            m_OhmValueCalculator = new COhmValueCalculator();
            SetupColorBand("BLACK", "BLACK", "BLACK", string.Empty);
        }

        public COhmModel(string firstSignificant, string secondSignificant, string multiplierColor, string toleranceColor)
        {
            m_OhmValueCalculator = new COhmValueCalculator();
            SetupColorBand(firstSignificant, secondSignificant, multiplierColor, toleranceColor);
        }
        //public void CalculateOhmValue(string firstSignificant, string secondSignificant, string multiplierColor, string toleranceColor)
        //{
        //    m_OhmValue = m_OhmValueCalculator.CalculateOhmValue(firstSignificant, secondSignificant, multiplierColor, toleranceColor, out m_ToleranceRange);
        //}
        public string GetOhmValue()
        {
            return m_OhmValue.ToString();
        }

        [DisplayName("FirstSignificantFigureList")]
        public SelectList FirstSignificantFigureList
        {
            get;
            set;
        }

        [DisplayName("SecondSignificantFigureList")]
        public SelectList SecondSignificantFigureList
        {
            get;
            set;
        }

        [DisplayName("MultiplierList")]
        public SelectList MultiplierList
        {
            get;
            set;
        }

        [DisplayName("ToleranceList")]
        public SelectList ToleranceList
        {
            get;
            set;
        }
        private void SetupColorBand(string firstSignificant, string secondSignificant, string multiplierColor, string toleranceColor)
        {
            List<string> list = new List<string>();
            foreach (string key in m_OhmValueCalculator.SignificantFigureMap.Keys)
            {
                list.Add(key);
            }
            FirstSignificantFigureList = new SelectList(list, firstSignificant);
            SecondSignificantFigureList = new SelectList(list, secondSignificant);

            list = new List<string>();
            foreach (string key in m_OhmValueCalculator.MultiplierMap.Keys)
            {
                list.Add(key);

            }
            MultiplierList = new SelectList(list,multiplierColor);

            list = new List<string>();
            foreach (string key in m_OhmValueCalculator.ToleranceMap.Keys)
            {
                list.Add(key);
            }
            ToleranceList = new SelectList(list, toleranceColor);

            m_OhmValue = m_OhmValueCalculator.CalculateOhmValue(firstSignificant, secondSignificant, multiplierColor, toleranceColor, out m_ToleranceRange);
            return ;

        }

        private COhmValueCalculator m_OhmValueCalculator;
        private float m_OhmValue;
        private float m_ToleranceRange;
    }
}