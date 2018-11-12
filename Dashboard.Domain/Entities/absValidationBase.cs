namespace Dashboard.Domain.Entities
{
    public abstract class absValidationBase
    {
        protected bool isValid;
        protected string message;

        public bool IsValid()
        {
            return isValid;
        }

        public string GetMessage()
        {
            return message;
        }

        protected bool IsNumeric(string data)
        {
            char[] datachars = data.ToCharArray();

            foreach (var datachar in datachars)
                if (!char.IsDigit(datachar))
                    return false;

            return true;
        }
    }
}
