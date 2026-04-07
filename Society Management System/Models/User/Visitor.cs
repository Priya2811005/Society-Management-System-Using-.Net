using System;

namespace Society_Management_System.Models
{
    public class Visitor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public DateTime VisitDate { get; set; }
        public string Purpose { get; set; }
    }
}