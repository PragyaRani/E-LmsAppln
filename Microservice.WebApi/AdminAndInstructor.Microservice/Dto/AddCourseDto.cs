namespace AdminAndInstructor.Microservice.Dto
{
    public class AddCourseDto
    {
       
        public string CourseName { get; set; }
        public string Tag { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Language { get; set; }
        public string TopicName { get; set; }
        public decimal Hours { get; set; }
        public int Ratings { get; set; }
    }
}
