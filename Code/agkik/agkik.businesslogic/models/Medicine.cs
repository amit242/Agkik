using agkik.businesslogic.Common;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using agkik.businesslogic.businessapi;

namespace agkik.businesslogic.models
{
    public class Medicine : ObservableObject
    {
        #region Private Fields
        private int _MedicineId;
        private string _MedicineName;
        private string _GenericName;

        private UOM _Uom;

        private short _QuantityAlert;
        private short _QuantityAlertDays;

        private bool _IsRetail = true;
        private bool _IsH1 = false;      
        #endregion

        #region Public Properties

        public int MedicineId
        {
            get { return _MedicineId; }
            set
            {
                if (value != _MedicineId)
                {
                    _MedicineId = value;
                    RaisePropertyChangedEvent("MedicineId");
                }
            }
        }

        [Required]
        public string MedicineName
        {
            get { return _MedicineName; }
            set
            {
                if (value != _MedicineName)
                {
                    _MedicineName = value;
                    RaisePropertyChangedEvent("MedicineName");
                }
            }
        }
        [Required]
        public string GenericName
        {
            get { return _GenericName; }
            set
            {
                if (value != _GenericName)
                {
                    _GenericName = value;
                    RaisePropertyChangedEvent("GenericName");
                }
            }
        }

        public UOM Uom
        {
            get { return _Uom; }
            set
            {
                if (value != _Uom)
                {
                    _Uom = value;
                    RaisePropertyChangedEvent("Uom");
                }
            }
        }

        [Required(ErrorMessage = "Enter a number")]
        [Range(1, 999, ErrorMessage = "Enter a number")]
        public short QuantityAlert
        {
            get { return _QuantityAlert; }
            set
            {
                if (value != _QuantityAlert)
                {
                    _QuantityAlert = value;
                    RaisePropertyChangedEvent("QuantityAlert");
                }
            }
        }

        [Required(ErrorMessage = "Enter a number")]
        [Range(1, 999, ErrorMessage = "Enter a number")]
        public short QuantityAlertDays
        {
            get { return _QuantityAlertDays; }
            set
            {
                if (value != _QuantityAlertDays)
                {
                    _QuantityAlertDays = value;
                    RaisePropertyChangedEvent("QuantityAlertDays");
                }
            }
        }

        public bool IsH1
        {
            get { return _IsH1; }
            set
            {
                _IsH1 = value;
                RaisePropertyChangedEvent("IsH1");
            }
        }

        public bool IsRetail
        {
            get { return _IsRetail; }
            set
            {
                _IsRetail = value;
                RaisePropertyChangedEvent("IsRetail");
            }
        }
        #endregion
    }
}
