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
            m_BandAColor = firstSignificant;
            m_BandBColor = secondSignificant;
            m_BandCColor = multiplierColor;
            m_BandDColor = toleranceColor;
            if (m_BandDColor.Length == 0)
                m_BandDColor = "none";
            float fOhmValue = m_OhmValueCalculator.CalculateOhmValue(firstSignificant, secondSignificant, multiplierColor, toleranceColor, out m_ToleranceRange);

            m_OhmValueString = ConvertFloatToString(fOhmValue);
            return ;

        }

        private string ConvertFloatToString(float fOhmValue)
        {
            if (fOhmValue / 1000 < 1.0)
                return fOhmValue.ToString();
            else if(fOhmValue / 1000 > 1.0f && fOhmValue / 1000 < 1000.0f)
            {
                fOhmValue = fOhmValue / 1000;
                return fOhmValue.ToString()+"K";
            }
            else if(fOhmValue / 1000000 >1.0f && fOhmValue /1000000<1000.0f)
            {
                fOhmValue = fOhmValue / 1000000;
                return fOhmValue.ToString()+"M";
            }
            else
            {
                fOhmValue = fOhmValue / 1000000000;
                return fOhmValue.ToString() + "B";
            }

        }
        public string OhmValue
        {
            get { return m_OhmValueString; }
        }

        public float ToleranceRange
        {
            get { return m_ToleranceRange; }

        }
        public string BandAColor
        {
            get { return m_BandAColor; }
        }

        public string BandBColor
        {
            get { return m_BandBColor; }
        }

        public string BandCColor
        {
            get { return m_BandCColor; }
        }

        public string BandDColor
        {
            get { return m_BandDColor; }            
        } 
        private COhmValueCalculator m_OhmValueCalculator;
        private string m_OhmValueString;
        private float m_ToleranceRange;
        private string m_BandAColor;
        private string m_BandBColor;
        private string m_BandCColor;
        private string m_BandDColor;

               
    }
}