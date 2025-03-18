using System.ComponentModel.DataAnnotations;

namespace project_demo.Model
{
    public class Category
    {
        [Key]
        public int category_id { get; set; }
        public string category_Name { get; set; }
    }
}
