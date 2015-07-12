using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agkik.businesslogic.models
{
    public class City : ResponseWrapper
    {
        private string _CityName;
        private string _State;
        private string _Country;

        public string CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
        }
        
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }


        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
    }
}
