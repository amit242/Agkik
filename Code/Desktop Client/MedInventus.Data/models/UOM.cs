using agkik.businesslogic.Common;
using System.ComponentModel.DataAnnotations;

namespace agkik.businesslogic.models
{
    public class UOM : ObservableObject
    {
        #region Private Fields
        private int _UomId;
        private string _UomName;
        private int _UOMConversionFactor;
        #endregion

        #region Public Properties
        public int UomId
        {
            get { return _UomId; }
            set
            {
                _UomId = value;
                RaisePropertyChangedEvent("UomId");
            }
        }

        [Required]
        [StringLength(20, ErrorMessage = "Can not enter more than 20 characters")]
        public string UomName
        {
            get { return _UomName; }
            set
            {
                _UomName = value;
                RaisePropertyChangedEvent("UomName");
            }
        }

        [Required(ErrorMessage = "Enter a number")]
        [Range(1, 999999, ErrorMessage = "Enter a number")]
        public int UOMConversionFactor
        {
            get { return _UOMConversionFactor; }
            set
            {
                _UOMConversionFactor = value;
                RaisePropertyChangedEvent("UOMConversionFactor");
            }
        }
        #endregion
    }
}
