namespace AdminAndInstructor.Microservice.Models
{
    public class Content
    {
        public int Id { get; set; }
        public string ContentName { get; set; }
        public string Resource { get; set; }
    }
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string SubCategory { get; set; }
        public Topic Topics { get; set; }
    }
    public class Topic
    {
        public int Id { get; set; }
        public string TopicName { get; set; }
    }
}
