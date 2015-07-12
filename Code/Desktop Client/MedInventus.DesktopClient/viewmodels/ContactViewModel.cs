using agkik.businesslogic.models;

namespace agkik.desktopclient.ViewModels
{
    internal class ContactViewModel : ViewModelBase
    {
        #region Private Fields
        private Contact _Contact;
        #endregion

        #region Public Properties
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
