using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using agkik.businesslogic.Common;
using agkik.businesslogic.businessapi;


namespace agkik.businesslogic.models
{
    public class Address : ObservableObject
    {
        #region Private Fields
        private string _AddressLine1;
        private string _AddressLine2;
        private string _City;
        private string _State;
        private string _Country;
        private int? _PIN;
        private List<City> _CityList;
        private List<string> _Cities;
        private List<string> _States;
        private List<string> _Countries;
        #endregion

        #region Public Properties
        [Required]
        public string AddressLine1
        {
            get { return _AddressLine1; }
            set
            {
                if (value != _AddressLine1)
                {
                    _AddressLine1 = value;
                    RaisePropertyChangedEvent("AddressLine1");
                }
            }
        }

        public string AddressLine2
        {
            get { return _AddressLine2; }
            set
            {
                if (value != _AddressLine2)
                {
                    _AddressLine2 = value;
                    RaisePropertyChangedEvent("AddressLine2");
                }
            }
        }
        [Required]
        [StringLength(20, ErrorMessage = "Can not enter more than 20 characters")]
        public string City
        {
            get { return _City; }
            set
            {
                if (value != _City)
                {
                    _City = value;
                    RaisePropertyChangedEvent("City");
                }
            }
        }

        public List<string> Cities
        {
            get
            {
                getCities();
                _Cities = _CityList.Select(o => o.CityName).Distinct().ToList();
                return _Cities;
            }
        }
        [Required]
        [StringLength(20, ErrorMessage = "Can not enter more than 20 characters")]
        public string State
        {
            get { return _State; }
            set
            {
                if (value != _State)
                {
                    _State = value;
                    RaisePropertyChangedEvent("State");
                }
            }
        }

        public List<string> States
        {
            get
            {
                getCities();
                _States = _CityList.Select(o => o.State).Distinct().OrderBy(x => x).ToList();
                return _States;
            }
        }
        [Required]
        [StringLength(20, ErrorMessage = "Can not enter more than 20 characters")]
        public string Country
        {
            get { return _Country; }
            set
            {
                if (value != _Country)
                {
                    _Country = value;
                    RaisePropertyChangedEvent("Country");
                }
            }
        }

        public List<string> Countries
        {
            get
            {
                getCities();
                _Countries = _CityList.Select(o => o.Country).Distinct().OrderBy(x => x).ToList();
                return _Countries;
            }
        }


        [Required]
        [Range(100000, 999999, ErrorMessage = "Enter a 6 digit PIN")]
        public int? PIN
        {
            get { return _PIN; }
            set
            {
                if (value != _PIN)
                {
                    _PIN = value;
                    RaisePropertyChangedEvent("PIN");
                }
            }
        }
        #endregion

        #region Methods
        private void getCities()
        {
            if (_CityList == null)
                _CityList = AddressManager.getCities();
        }
        #endregion
    }
}
