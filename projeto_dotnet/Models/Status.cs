namespace projeto_dotnet.Models
{
    public class Status
    {
        public int Id{ get; set; }
        public int CoursesModelId { get; set; }
        public CoursesModel CoursesModel{ get; set; }
    }
}
