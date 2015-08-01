using agkik.businesslogic.models;

namespace agkik.desktopclient.viewmodels
{
    class MedicineViewModel : ViewModelBase
    {
        #region Private Fields
        private Medicine _NewMedicine;
        private UomViewModel _UomVM;
        #endregion

        #region Public Properties
        public Medicine NewMedicine
        {
            get
            {
                if (_NewMedicine == null)
                {
                    _NewMedicine = new Medicine();
                }
                return _NewMedicine;
            }
            set
            {
                _NewMedicine = value;
                RaisePropertyChangedEvent("NewMedicine");
            }
        }

        public UomViewModel UomVM
        {
            get
            {
                if (_UomVM == null)
                    _UomVM = new UomViewModel();
                return _UomVM;
            }
            set
            {
                _UomVM = value;
                RaisePropertyChangedEvent("UomVM");
            }
        }
        #endregion
    }
}
