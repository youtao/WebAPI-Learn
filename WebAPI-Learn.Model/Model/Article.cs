namespace WebAPI_Learn.Model
{
    using System.ComponentModel.DataAnnotations.Schema;

    using WebAPI_Learn.ModelFactory;

    [Table("Article")]
    public class Article : BaseModel
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual ArticleCategory Category { get; set; }
    }
}