using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agkik.businesslogic.Common
{
    public abstract class MessageableObject : ObservableObject
    {
        #region Private Fields
        private bool _IsMessageVisible;
        private string _DisplayMessage;
        #endregion

        #region Public Properties
        public bool IsMessageVisible
        {
            get { return _IsMessageVisible; }
            set
            {
                if (value != _IsMessageVisible)
                {
                    _IsMessageVisible = value;
                    RaisePropertyChangedEvent("IsMessageVisible");
                }
            }
        }

        public string DisplayMessage
        {
            get { return _DisplayMessage; }
            set
            {
                if (value != _DisplayMessage)
                {
                    _DisplayMessage = value;
                    RaisePropertyChangedEvent("DisplayMessage");
                }
            }
        }
        #endregion
    }
}
