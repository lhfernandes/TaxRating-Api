namespace Domain.Helpers
{
    public class Notification
    {
        public Notification(string message, string fieldname)
        {
            Message = message;
            FieldName = fieldname;
        }

        public string Message { get; }
        public string FieldName { get; }
    }
}
