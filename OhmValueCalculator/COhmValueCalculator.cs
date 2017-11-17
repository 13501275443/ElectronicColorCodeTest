using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmValueCalculator
{
    public class COhmValueCalculator : IOhmValueCalculator
    {
        public COhmValueCalculator() 
        {
            m_SignificantFigureMap =new Dictionary<string, int>{
                { "BLACK",  0 },
                { "BROWN",  1 },
                { "RED",    2 },
                { "ORANGE", 3 },
                { "YELLOW", 4 },
                { "GREEN",  5 },
                { "BLUE",   6 },
                { "VIOLET", 7 },
                { "GRAY",   8 },
                { "WHITE",  9 }};

            m_MultiplierMap = new Dictionary<string, float>{
                { "PINK",   0.001f },
                { "SILVER", 0.01f },
                { "GOLD",   0.1f },
                { "BLACK",  1 },
                { "BROWN",  10 },
                { "RED",    100 },
                { "ORANGE", 1000 },
                { "YELLOW", 10000 },
                { "GREEN",  100000 },
                { "BLUE",   1000000 },
                { "VIOLET", 10000000 },
                { "GRAY",   100000000 },
                { "WHITE",  1000000000 }};

            m_ToleranceMap = new Dictionary<string, float>{
                { "",       0.2f },
                { "SILVER", 0.1f },
                { "GOLD",   0.05f },
                { "BROWN",  0.01f },
                { "RED",    0.02f },
                { "GREEN",  0.005f },
                { "BLUE",   0.0025f },
                { "VIOLET", 0.001f },
                { "GRAY",   0.0005f }};

        }
        public float CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor, out float fToleranceRange)
        {
            bandAColor = bandAColor.ToUpper();
            bandBColor = bandBColor.ToUpper();
            bandCColor = bandCColor.ToUpper();
            bandDColor = bandDColor.ToUpper();
            if(!( m_SignificantFigureMap.ContainsKey(bandAColor) &&
                  m_SignificantFigureMap.ContainsKey(bandBColor) &&
                  m_MultiplierMap.ContainsKey(bandCColor) &&
                  m_ToleranceMap.ContainsKey(bandDColor)))
            {
                fToleranceRange = 0.0f;
                return float.NaN;
            }
                
            float ret = (m_SignificantFigureMap[bandAColor] * 10 + m_SignificantFigureMap[bandBColor]) * m_MultiplierMap[bandCColor];
            fToleranceRange = m_ToleranceMap.ContainsKey(bandDColor) ? m_ToleranceMap[bandDColor] : 0.0f;
            return ret;
        }

        //public List<string> GetSignificantFigure()
        //{
        //    List<string> listSignificantFigure = new List<string>();
        //    foreach(string key in m_SignificantFigureMap.Keys)
        //    {
        //        listSignificantFigure.Add(key);
        //    }
        //    return listSignificantFigure;
        //}

        private Dictionary<string, int> m_SignificantFigureMap;

        public Dictionary<string, int> SignificantFigureMap
        {
            get { return m_SignificantFigureMap; }            
        }
        private Dictionary<string, float> m_MultiplierMap;

        public Dictionary<string, float> MultiplierMap
        {
            get { return m_MultiplierMap; }            
        }
        private Dictionary<string, float> m_ToleranceMap;

        public Dictionary<string, float> ToleranceMap
        {
            get { return m_ToleranceMap; }
        }      
    }
}
