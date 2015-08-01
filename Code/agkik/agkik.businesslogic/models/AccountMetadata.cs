using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using agkik.businesslogic.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.ObjectModel;
using log4net;
using System.Reflection;

namespace agkik.businesslogic
{
    [MetadataType(typeof(AccountMetadata))]
    public partial class account : IDataErrorInfo
    {
        public class AccountMetadata
        {
            [Required(ErrorMessage = "AccountName is required")]
            public String AccountName { get; set; }

            [Required(ErrorMessage = "AccountBalance is required")]
            //[RegularExpression("^(?:0|[1-9]\\d*)(?:\\.(?!.*000)\\d+)?{5}$", ErrorMessage = "Amount can only be decimal")]
            public Decimal AccountBalance { get; set; }
        }

        #region Private Members
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Dictionary<string, ICollection<string>> _validationErrors = new Dictionary<string, ICollection<string>>();
        #endregion



        #region IDataErrorInfo Members
        /// <summary>
        /// Not supported.
        /// </summary>
        [Obsolete]
        public string Error
        {
            get { throw new System.NotSupportedException(); }
        }

        /// <summary>
        /// Gets the validation error for a property whose name matches the specified <see cref="columnName"/>.
        /// </summary>
        /// <param name="columnName">The name of the property to validate.</param>
        /// <returns>Returns a validation error if there is one, otherwise returns null.</returns>
        public string this[string columnName]
        {
            get
            {
                return ValidateProperty(this, columnName);
            }
        }

        #endregion
        

        public static string ValidateProperty(object obj, string propertyName)
        {
            // get the MetadataType attribute on the object class
            Type metadatatype = obj.GetType().GetCustomAttributes(true).OfType<MetadataTypeAttribute>().First().MetadataClassType;
            // get the corresponding property on the MetaDataType class
            PropertyInfo property = metadatatype.GetProperty(propertyName);
            if (property != null)
            {
                // get the value of the property on the object
                object value = obj.GetType().GetProperty(propertyName).GetValue(obj, null);
                // run the value through the ValidationAttributes on the corresponding property
                List<string> errors = (from v in property.GetCustomAttributes(true).OfType<ValidationAttribute>() where !v.IsValid(value) select v.ErrorMessage).ToList();
                // return all the errors, or return null if there are none
                return (errors.Count > 0) ? String.Join("\r\n", errors) : null;
            }
            return null;
        }
    }
    
}
