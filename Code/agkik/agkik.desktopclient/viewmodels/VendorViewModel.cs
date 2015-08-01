using System;
using System.Windows.Input;
using System.ComponentModel.DataAnnotations;

using agkik.businesslogic.Common;
using agkik.desktopclient.Utils;
using agkik.desktopclient.Command;
using agkik.businesslogic.businessapi;
using agkik.businesslogic.models;
using System.Collections.Generic;
using agkik.desktopclient.Services;
using System.Windows;


namespace agkik.desktopclient.viewmodels
{
    internal class VendorViewModel : ViewModelBase
    {
        #region Private Fields
        private Vendor _NewVendor;
        private Vendor _SelectedVendor;

        private List<Vendor> _VendorList;

        private ICommand _AddVendorCommand;
        private ICommand _UpdateVendorCommand;
        private ICommand _SelectVendorCommand;
        #endregion

        #region Public Properties
        public Vendor NewVendor
        {
            get
            {
                if (_NewVendor == null)
                    _NewVendor = new Vendor();
                return _NewVendor;
            }
            set
            {
                _NewVendor = value;
                RaisePropertyChangedEvent("NewVendor");
            }
        }

        public Vendor SelectedVendor
        {
            get
            {
                if (_SelectedVendor == null)
                {
                    _SelectedVendor = new Vendor();
                }
                return _SelectedVendor;
            }
            set
            {
                _SelectedVendor = value;
                RaisePropertyChangedEvent("SelectedVendor");
            }
        }

        public List<Vendor> VendorList
        {
            get
            {
                _VendorList = getVendors();
                if (_SelectedVendor == null && _VendorList != null)
                {
                    ShowSelectedVendor(_VendorList[0]);
                }
                return _VendorList;
            }
            set
            {
                _VendorList = value;
                RaisePropertyChangedEvent("VendorList");
            }
        }
        #endregion

        #region Constructor
        internal VendorViewModel()
        {
            _AddVendorCommand = new RelayCommand(AddVendor, CanExecuteAddVendor);
            _UpdateVendorCommand = new RelayCommand(UpdateVendor, CanExecuteUpdateVendor); ;
            _SelectVendorCommand = new RelayCommand(ShowSelectedVendor, CanExecuteSelectVendor);
        }
        #endregion

        #region Commands
        public ICommand AddVendorCommand
        {
            get
            {
                return _AddVendorCommand;
            }
            set
            {
                _AddVendorCommand = value;
            }
        }

        public ICommand UpdateVendorCommand
        {
            get
            {
                return _UpdateVendorCommand;
            }
            set
            {
                _UpdateVendorCommand = value;
            }
        }

        public ICommand SelectVendorCommand
        {
            get { return _SelectVendorCommand; }
            set { _SelectVendorCommand = value; }
        }
        #endregion
        
        #region Methods
        private List<Vendor> getVendors()
        {
            return VendorManager.GetVendors();
        }

        private bool CanExecuteAddVendor(object param)
        {
            return !(NewVendor.HasErrors || NewVendor.PrimaryAddress.HasErrors || (NewVendor.ShowAltAddress && NewVendor.AlternateAddress.HasErrors) || NewVendor.Contact.HasErrors);
        }

        private bool CanExecuteUpdateVendor(object param)
        {
            return !(SelectedVendor.HasErrors || SelectedVendor.PrimaryAddress.HasErrors || (SelectedVendor.ShowAltAddress && SelectedVendor.AlternateAddress.HasErrors) || SelectedVendor.Contact.HasErrors);
        }

        private bool CanExecuteSelectVendor(object param)
        {
            // write validation logic

            return true;
        }

        private void ShowSelectedVendor(object param)
        {
            Vendor vendor = (Vendor)param;
            SelectedVendor = VendorManager.FindVendorById(vendor.VendorId);
        }

        private void AddVendor(object param)
        {
            if (!NewVendor.ShowAltAddress)
            {
                NewVendor.AlternateAddress = null; 
            }
            bool isSuccess = VendorManager.AddVendor(NewVendor);

            IsMessageVisible = true;

            // TODO: review logic for isSuccess
            if (isSuccess)
            {
                VendorList = getVendors();
                DisplayMessage = "Vendor Successfully Added";
            }
            else
            {
                DisplayMessage = "There was an error while adding the vendor";
            }

            var msgBox = base.GetService<IMessageBoxService>();
            if (msgBox != null)
            {
                msgBox.Show(DisplayMessage, "Alert!");
            }
            if (isSuccess)
            {
                VendorList = getVendors();
                NewVendor.FirstName = null;
                NewVendor.LastName = null;
                NewVendor.CompanyName = null;
                NewVendor.PrimaryAddress = null;
                NewVendor.AlternateAddress = null;
                NewVendor.Contact = null;
            }
        }

        private void UpdateVendor(object param)
        {
            var msgBox = base.GetService<IMessageBoxService>();
            if (msgBox != null)
            {
               MessageBoxResult msgboxResponse = msgBox.Show("Are you sure you want to update the vendor: " + SelectedVendor.FirstName + "?", "Alert!", MessageBoxButton.YesNo, MessageBoxImage.Question);
               if (msgboxResponse == MessageBoxResult.No)
                   return;
            }
            if (!SelectedVendor.ShowAltAddress)
            {
                SelectedVendor.AlternateAddress = null;
            }
            bool isSuccess = VendorManager.UpdateVendor(SelectedVendor);

            IsMessageVisible = true;

            // TODO: review logic for isSuccess
            if (isSuccess)
            {
                VendorList = getVendors();
                //SelectedVendor = VendorList.Find(x => x.VendorId == SelectedVendor.VendorId);
                DisplayMessage = "Vendor Successfully Updated";
            }
            else
            {
                DisplayMessage = "There was an error while Updating the vendor";
            }

            
            if (msgBox != null)
            {
                msgBox.Show(DisplayMessage, "Alert!");
            }
        }

        //private Address makeAddress(Address addressVM)
        //{
        //    return new Address()
        //    {
        //        AddressLine1 = addressVM.AddressLine1,
        //        AddressLine2 = addressVM.AddressLine2,
        //        City = new City()
        //        {
        //            CityName = addressVM.City,
        //            State = addressVM.State,
        //            Country = addressVM.Country
        //        },
        //        PINCode = Convert.ToInt32(addressVM.PIN)
        //    };
        //}
        #endregion
    }
}
