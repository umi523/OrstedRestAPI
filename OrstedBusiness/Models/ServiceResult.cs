namespace OrstedBusiness.Models
{
    /// <summary>
    /// Class to have common properties, a generic type to be returned to frontend.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResult<T>
    {
        #region Properties

        public string? Message
        {
            get;
            private set;
        }

        public bool Success
        {
            get;
            private set;
        }

        public T? Data
        {
            get;
            private set;
        }

        #endregion

        #region Constructors

        public ServiceResult(T data, string? message = null, bool success = true)
        {
            Data = data;
            Message = message;
            Success = success;
        }

        public ServiceResult(bool success, string? message = null)
        {
            Message = message;
            Success = success;
        }

        public ServiceResult()
        {
        }

        #endregion
    }
}
