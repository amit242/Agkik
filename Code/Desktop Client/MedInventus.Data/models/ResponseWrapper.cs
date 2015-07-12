namespace agkik.businesslogic.models
{
    public class ResponseWrapper
    {
        private bool _HasError;
        private string _ErrorMessage;

        public ResponseWrapper()
        {
        }

        public ResponseWrapper(bool hasError)
        {
            _HasError = hasError;
        }

        public ResponseWrapper(bool hasError, string errorMsg)
        {
            _HasError = hasError;
            _ErrorMessage = errorMsg;
        }

        public bool HasError
        {
            get { return _HasError; }
            set { _HasError = value; }
        }

        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set { _ErrorMessage = value; }
        }
    }
}
