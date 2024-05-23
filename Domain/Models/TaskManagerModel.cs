using Domain.Enums;

namespace Domain.Models
{
    public class TaskManagerModel
    {
        public string Id { get; set; }
        public string IdUser { get; set; }
        public string Title { get; set; }
        public Status StatusTask { get; set; }
        public string Detail { get; set; } 
        public DateTime ExpirationDate { get; set; }
        public Priority Priority { get; set; }
        public User? User { get; set; }


    }

    
}
