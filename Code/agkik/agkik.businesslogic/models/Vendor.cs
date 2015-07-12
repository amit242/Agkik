using System;
using agkik.businesslogic.Common;
using System.ComponentModel.DataAnnotations;

namespace agkik.businesslogic.models
{
    public class Vendor : ObservableObject
    {
        #region Private Fields
        private int _VendorId;
        private string _FirstName;
        private string _LastName;
        private string _CompanyName;
        private Address _PrimaryAddress;
        private Address _AlternateAddress;
        private bool _ShowAltAddress = false;
        private Contact _Contact;
        private bool _forceAltAddressValidation = true;
        #endregion

        #region Public Properties
        public int VendorId
        {
            get { return _VendorId; }
            set
            {
                _VendorId = value;
                RaisePropertyChangedEvent("VendorId");
            }
        }

        [Required]
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (value != _FirstName)
                {
                    _FirstName = value;
                    RaisePropertyChangedEvent("FirstName");
                }
            }
        }
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (value != _LastName)
                {
                    _LastName = value;
                    RaisePropertyChangedEvent("LastName");
                }
            }
        }
        public string CompanyName
        {
            get { return _CompanyName; }
            set
            {
                if (value != _CompanyName)
                {
                    _CompanyName = value;
                    RaisePropertyChangedEvent("CompanyName");
                }
            }
        }

        public DateTime RegistrationDate { get; set; }

        public Address PrimaryAddress
        {
            get
            {
                if (_PrimaryAddress == null)
                    _PrimaryAddress = new Address();
                return _PrimaryAddress;
            }
            set
            {
                if (value != _PrimaryAddress)
                    _PrimaryAddress = value;
                RaisePropertyChangedEvent("PrimaryAddress");
            }
        }

        public Address AlternateAddress
        {
            get
            {
                if (_AlternateAddress == null && _ShowAltAddress)
                    _AlternateAddress = new Address();
                return _AlternateAddress;
            }
            set
            {
                if (value != _AlternateAddress)
                    _AlternateAddress = value;
                RaisePropertyChangedEvent("AlternateAddress");
            }
        }
        public bool ShowAltAddress
        {
            get { return _ShowAltAddress; }
            set
            {
                _ShowAltAddress = value;
                if (_ShowAltAddress && _forceAltAddressValidation)
                {
                    // This is done to fix the UI validation bug (Alternate address section is not getting validation messages by default)
                    _forceAltAddressValidation = false;
                    // TODO: find a better solution other than just assigning and removing values
                    AlternateAddress.AddressLine1 = "dummy";
                    AlternateAddress.AddressLine1 = null;
                    AlternateAddress.AddressLine2 = "dummy";
                    AlternateAddress.AddressLine2 = null;
                    AlternateAddress.City = "dummy";
                    AlternateAddress.City = null;
                    AlternateAddress.State = "dummy";
                    AlternateAddress.State = null;
                    AlternateAddress.Country = "dummy";
                    AlternateAddress.Country = null;
                    AlternateAddress.PIN = 123456;
                    AlternateAddress.PIN = null;

                    //RaisePropertyChangedEvent("AlternateAddressVM");
                    //AlternateAddressVM.OnValidate("AddressLine1");
                }
                RaisePropertyChangedEvent("ShowAltAddress");
            }
        }
        public Contact Contact
        {
            get
            {
                if (_Contact == null)
                    _Contact = new Contact();
                return _Contact;
            }
            set
            {
                if (value != _Contact)
                    _Contact = value;
                RaisePropertyChangedEvent("Contact");
            }
        }
        #endregion

        #region Methods


        #endregion
    }
}
