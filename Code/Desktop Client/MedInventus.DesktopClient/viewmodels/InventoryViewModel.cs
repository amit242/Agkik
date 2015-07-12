using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;

using agkik.businesslogic.models;
using agkik.desktopclient.Command;
using agkik.businesslogic.businessapi;
using agkik.desktopclient.Services;
using log4net;
using System.Reflection;

namespace agkik.desktopclient.ViewModels
{
    internal class InventoryViewModel : ViewModelBase
    {
        #region Private Fields
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private MedicineViewModel _MedicineVM;
        private List<Medicine> _MedicineList;
        private MedicineViewModel _SelectedMedicineVM;
        
        private ICommand _AddMedicineCommand;
        private ICommand _UpdateMedicineCommand;
        private ICommand _SelectMedicineCommand;
        #endregion

        #region Public Properties
        public MedicineViewModel MedicineVM
        {
            get
            {
                if (_MedicineVM == null)
                    _MedicineVM = new MedicineViewModel();
                return _MedicineVM;
            }
            set
            {
                _MedicineVM = value;
                RaisePropertyChangedEvent("MedicineVM");
            }
        }

        public List<Medicine> MedicineList
        {
            get
            {
                //_MedicineList = getMedicineList();
                if (_SelectedMedicineVM == null)
                {
                    ShowSelectedMedicine(_MedicineList[0]);
                }
                return _MedicineList;
            }
            set
            {
                _MedicineList = value;
                RaisePropertyChangedEvent("MedicineList");
            }
        }
        
        public MedicineViewModel SelectedMedicineVM
        {
            get
            {
                if (_SelectedMedicineVM == null)
                {
                    _SelectedMedicineVM = new MedicineViewModel();
                }
                return _SelectedMedicineVM;
            }
            set
            {
                _SelectedMedicineVM = value;
                RaisePropertyChangedEvent("SelectedMedicineVM");
            }
        }
        #endregion

        #region Constructor
        internal InventoryViewModel()
        {
            _AddMedicineCommand = new RelayCommand(AddMedicine, CanExecuteAddMedicine);
            _SelectMedicineCommand = new RelayCommand(ShowSelectedMedicine, CanExecuteSelectMedicine);
            _UpdateMedicineCommand = new RelayCommand(UpdateMedicine, CanExecuteUpdateMedicine);
        }
        #endregion

        #region Commands
        public ICommand AddMedicineCommand
        {
            get
            {
                return _AddMedicineCommand;
            }
            set
            {
                _AddMedicineCommand = value;
            }
        }

        public ICommand SelectMedicineCommand
        {
            get
            {
                return _SelectMedicineCommand;
            }
            set
            {
                _SelectMedicineCommand = value;
            }
        }

        public ICommand UpdateMedicineCommand
        {
            get
            {
                return _UpdateMedicineCommand;
            }
            set
            {
                _UpdateMedicineCommand = value;
            }
        }
        #endregion
        
        #region Methods
        //private List<Medicine> getMedicineList()
        //{
        //    return InventoryManager.GetMedicineList();
        //}

        private bool CanExecuteAddMedicine(object param)
        {
            logger.Debug(string.Format("Add med: NewMedicine.HasErrors={0}, UomVM.HasErrors={0}", MedicineVM.NewMedicine.HasErrors, MedicineVM.UomVM.HasErrors));
            return !(MedicineVM.NewMedicine.HasErrors || MedicineVM.UomVM.HasErrors);
        }

        private bool CanExecuteUpdateMedicine(object param)
        {
            logger.Debug(string.Format("Update med: NewMedicine.HasErrors={0}, UomVM.HasErrors={0}", SelectedMedicineVM.NewMedicine.HasErrors, SelectedMedicineVM.UomVM.HasErrors));
            return !(SelectedMedicineVM.NewMedicine.HasErrors || SelectedMedicineVM.UomVM.HasErrors);
        }

        private bool CanExecuteSelectMedicine(object param)
        {
            // write validation logic
            return true;
        }

        private void AddMedicine(object param)
        {
            List<Medicine> duplicateList = _MedicineList.Where(m => m.MedicineName == MedicineVM.NewMedicine.MedicineName).ToList();
            var msgBox = base.GetService<IMessageBoxService>();
            if (duplicateList.Count > 0)
            {
                if (msgBox != null)
                {
                    string errMsg = string.Format("Could not add : Duplicate Medicine exists :id:{0}, name:{1}\nPlease go to the update section to change an already added medicine, or provide a different name", duplicateList.First<Medicine>().MedicineId, duplicateList.First<Medicine>().MedicineId);
                    logger.Error(errMsg);
                    msgBox.Show(errMsg, "Alert!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                return;
            }

            MedicineVM.NewMedicine.Uom = MedicineVM.UomVM.SelectedUOM;
            //ResponseWrapper isSuccess = InventoryManager.AddNewMedicine(MedicineVM.NewMedicine);

            //IsMessageVisible = true;

            //// TODO: review logic for isSuccess
            //if (isSuccess.HasError)
            //{
            //    DisplayMessage = isSuccess.ErrorMessage;
            //}
            //else
            //{
            //    MedicineList = getMedicineList();
            //    DisplayMessage = "Medicine Successfully Added";
            //}

            //if (msgBox != null)
            //{
            //    msgBox.Show(DisplayMessage, "Alert!");
            //}
        }

        private void UpdateMedicine(object param)
        {
            List<Medicine> duplicateList = _MedicineList.Where(m => m.MedicineName == SelectedMedicineVM.NewMedicine.MedicineName && m.MedicineId != SelectedMedicineVM.NewMedicine.MedicineId).ToList();
            var msgBox = base.GetService<IMessageBoxService>();
            if (duplicateList.Count > 0)
            {
                if (msgBox != null)
                {
                    string errMsg = string.Format("Could not add : Duplicate Medicine exists :id:{0}, name:{1}\nPlease provide a different name.", duplicateList.First<Medicine>().MedicineId, duplicateList.First<Medicine>().MedicineName);
                    logger.Error(errMsg);
                    msgBox.Show(errMsg, "Alert!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                return;
            }

            SelectedMedicineVM.NewMedicine.Uom = SelectedMedicineVM.UomVM.SelectedUOM;
            //ResponseWrapper isSuccess = InventoryManager.UpdateMedicine(SelectedMedicineVM.NewMedicine);

            //// TODO: review logic for isSuccess
            //if (isSuccess.HasError)
            //{
            //    DisplayMessage = isSuccess.ErrorMessage;
            //}
            //else
            //{
            //    MedicineList = getMedicineList();
            //    DisplayMessage = "Medicine Successfully Updated";
            //}

            
            if (msgBox != null)
            {
                msgBox.Show(DisplayMessage, "Alert!");
            }
        }
        
        private void ShowSelectedMedicine(object param)
        {
            Medicine med = (Medicine)param;
            //UOM selectedUOM = InventoryManager.FindUOMById(med.Uom.UomId);
            SelectedMedicineVM.NewMedicine = med;
            //SelectedMedicineVM.UomVM.SelectedUOM = selectedUOM;
        }
        #endregion
    }
}
