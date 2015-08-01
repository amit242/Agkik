using System.Windows;
using agkik.businesslogic.models;
using System.Collections.Generic;
using agkik.businesslogic.businessapi;
using System.Windows.Input;
using agkik.desktopclient.Command;
using agkik.desktopclient.Services;
using log4net;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace agkik.desktopclient.viewmodels
{
    class UomViewModel : ViewModelBase
    {

        #region Private Fields
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private UOM _SelectedUOM;
        private string _NewUomName = "";
        private int _prevConvFactor;
        private List<UOM> _UOMList;

        private ICommand _AddUOMCommand;
        private ICommand _UpdateUOMCommand;
        #endregion

        #region Public Properties

        [Required(ErrorMessage = "UOM is required")]
        [StringLength(20, ErrorMessage = "Can not enter more than 20 characters")]
        public string NewUomName
        {
            get { return _NewUomName; }
            set
            { 
                _NewUomName = value;
                //logger.Debug("NewUomName_SelectedUOM:" + _SelectedUOM.UomName + "|_NewUomName:" + _NewUomName);
                if (_SelectedUOM == null)
                {
                    //logger.Debug("adding:" + _NewUomName);
                    SelectedUOM = new UOM();
                    SelectedUOM.UomName = _NewUomName;
                }
                else if ((_SelectedUOM.UomId == 0 && !string.IsNullOrEmpty(_NewUomName)))
                {
                    //logger.Debug("modifying:" + _NewUomName);
                    SelectedUOM.UomName = _NewUomName;
                }
                else if (string.IsNullOrEmpty(_NewUomName))
                {
                    SelectedUOM = null;
                }
                RaisePropertyChangedEvent("NewUomName");
            }
        }

        public UOM SelectedUOM
        {
            get
            {
                if (_SelectedUOM == null)
                {
                    _SelectedUOM = new UOM();
                }
                return _SelectedUOM;
            }
            set
            {
                if (_SelectedUOM != null)
                {
                    _SelectedUOM.UOMConversionFactor = _prevConvFactor;
                }
                _SelectedUOM = value;
                if (_SelectedUOM != null)
                {
                    _prevConvFactor = _SelectedUOM.UOMConversionFactor;
                    NewUomName = _SelectedUOM.UomName;
                }
                RaisePropertyChangedEvent("SelectedUOM");
            }
        }

        public List<UOM> UOMList
        {
            get
            {
                /*if (_UOMList == null)
                    _UOMList = InventoryManager.GetUOMList();*/
                return _UOMList;
            }
            set
            {
                _UOMList = value;
                RaisePropertyChangedEvent("UOMList");
            }
        }
        #endregion

        #region Constructor
        internal UomViewModel()
        {
            _AddUOMCommand = new RelayCommand(AddUom, CanExecuteAddUom);
            _UpdateUOMCommand = new RelayCommand(UpdateUom, CanExecuteUpdateUom);
        }
        #endregion

        #region Commands
        public ICommand AddUOMCommand
        {
            get
            {
                return _AddUOMCommand;
            }
            set
            {
                _AddUOMCommand = value;
            }
        }

        public ICommand UpdateUOMCommand
        {
            get
            {
                return _UpdateUOMCommand;
            }
            set
            {
                _UpdateUOMCommand = value;
            }
        }
        #endregion

        #region Methods
        private bool CanExecuteAddUom(object param)
        {
            logger.Debug("SelectedUOMName:" + SelectedUOM.UomName + "|_NewUomName:" + _NewUomName + "|SelectedUOM.HasErrors?:" + SelectedUOM.HasErrors + "|SelectedUOM.UomId=" + SelectedUOM.UomId);
            return !SelectedUOM.HasErrors && (SelectedUOM.UomId == 0 || (SelectedUOM.UomName != _NewUomName));
        }

        private bool CanExecuteUpdateUom(object param)
        {
            //logger.Debug("SelectedUOMName:" + SelectedUOM.UomName + "|UOMConversionFactor:" + SelectedUOM.UOMConversionFactor + "|SelectedUOM.HasErrors?:" + SelectedUOM.HasErrors);
            return !SelectedUOM.HasErrors && SelectedUOM.UomId != 0 && (SelectedUOM.UomName != _NewUomName || SelectedUOM.UOMConversionFactor != _prevConvFactor);
        }

        private void AddUom(object param)
        {
            var msgBox = base.GetService<IMessageBoxService>();
            
            SelectedUOM.UomId = 0;
            DisplayMessage = string.Format("UOM \"{0}\" Successfully Added", SelectedUOM.UomName);
            AddUpdateUOM(msgBox);
        }

        private void UpdateUom(object param)
        {
            var msgBox = base.GetService<IMessageBoxService>();
            if (msgBox != null)
            {
                MessageBoxResult result = msgBox.Show(string.Format("Are you sure you want to update the existing uom [{0},{1}]\nwith new value [{2},{3}]?", SelectedUOM.UomName,_prevConvFactor, NewUomName, SelectedUOM.UOMConversionFactor), "Alert!", MessageBoxButton.YesNo, MessageBoxImage.Information);

                if (result == MessageBoxResult.Yes)
                {
                    DisplayMessage = string.Format("UOM \"{0}\" Successfully Updated", SelectedUOM.UomName);
                    AddUpdateUOM(msgBox);
                }
            }
        }

        private void AddUpdateUOM(IMessageBoxService msgBox)
        {
            SelectedUOM.UomName = _NewUomName;
            /*ResponseWrapper isSuccess = InventoryManager.AddUpdateUom(SelectedUOM);
            // TODO: review logic for isSuccess
            if (isSuccess.HasError)
            {
                DisplayMessage = isSuccess.ErrorMessage;
            }
            else
            {
                UOMList = InventoryManager.GetUOMList();
            }

            if (msgBox != null)
            {
                msgBox.Show(DisplayMessage, "Alert!");
            }*/
        }
        #endregion
    }
}
