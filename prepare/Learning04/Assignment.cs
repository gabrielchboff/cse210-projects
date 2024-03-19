namespace Learning04
{
    public class Assignment
    {
        protected string _studentName { get; set; }
        protected string _topic { get; set; }

        public Assignment(string studentName, string topic)
        {
            _studentName = studentName;
            _topic = topic;
        }

        public string GetSummary()
        {
            return $"{_studentName} - {_topic}";
        }

        public string GetStudentName()
        {
            return _studentName;
        }
    }
}
