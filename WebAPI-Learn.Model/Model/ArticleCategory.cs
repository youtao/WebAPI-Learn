namespace WebAPI_Learn.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using WebAPI_Learn.ModelFactory;

    [Table("ArticleCategory")]
    public class ArticleCategory : BaseModel
    {
        public ArticleCategory()
        {
            this.Article = new HashSet<Article>();
        }

        public string Name { get; set; }

        public virtual ICollection<Article> Article { get; set; }
    }
}