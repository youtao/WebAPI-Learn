namespace WebAPI_Learn.Model.Context
{
    using System.Data.Entity;

    public class WebAPILearnContext : DbContext
    {
        public WebAPILearnContext() : base("WebAPILearnContext")
        {
        }

        public virtual DbSet<Article> Article { get; set; }

        public virtual DbSet<ArticleCategory> ArticleCategory { get; set; }

        public virtual DbSet<Contact> Contact { get; set; }
    }
}