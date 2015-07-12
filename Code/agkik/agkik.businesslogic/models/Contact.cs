using System.ComponentModel.DataAnnotations;
using agkik.businesslogic.Common;

namespace agkik.businesslogic.models
{
    public class Contact : ObservableObject
    {
        #region Private Fields
        private string _MobileNo;
        private string _PhoneNo;
        private string _Email;
        private string _AltEmail;
        private string _Fax;
        #endregion

        #region Public Properties
        [Required]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Mobile No must contain 10 digits, e.g. 1234567890")]
        public string MobileNo
        {
            get { return _MobileNo; }
            set
            {
                if (value != _MobileNo)
                {
                    _MobileNo = value;
                    RaisePropertyChangedEvent("MobileNo");
                }
            }
        }
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Phone No must contain 10 digits, e.g. 1234567890")]
        public string PhoneNo
        {
            get { return _PhoneNo; }
            set
            {
                if (value != _PhoneNo)
                {
                    _PhoneNo = value;
                    RaisePropertyChangedEvent("PhoneNo");
                }
            }
        }
        [Required]
        //\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Please enter valid email, e.g. a_b@test.com")]
        public string Email
        {
            get { return _Email; }
            set
            {
                if (value != _Email)
                {
                    _Email = value.ToLower();
                    RaisePropertyChangedEvent("Email");
                }
            }
        }

        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Please enter valid email, e.g. a_b@test.com")]
        public string AltEmail
        {
            get { return _AltEmail; }
            set
            {
                if (value != _AltEmail)
                {
                    _AltEmail = value.ToLower();
                    RaisePropertyChangedEvent("AltEmail");
                }
            }
        }

        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Fax must contain 10 digits, e.g. 1234567890")]
        public string Fax
        {
            get { return _Fax; }
            set
            {
                if (value != _Fax)
                {
                    _Fax = value;
                    RaisePropertyChangedEvent("Fax");
                }
            }
        }
        #endregion
    }
}
