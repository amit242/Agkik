using agkik.businesslogic.Common;
using agkik.desktopclient.Services;

namespace agkik.desktopclient.viewmodels
{
    internal abstract class ViewModelBase : MessageableObject
    {
        #region Private Fields
        
        #endregion

        #region Public Properties
         
        #endregion

        #region Methods
        /// <summary>
        /// Retrieves a service object identified by <typeparamref name="TServiceContract"/>.
        /// </summary>
        /// <typeparam name="TServiceContract">The type identifier of the service.</typeparam>
        public TServiceContract GetService<TServiceContract>() where TServiceContract : class
        {
            return ServiceContainer.Instance.GetService<TServiceContract>();
        }
        #endregion
    }
}
