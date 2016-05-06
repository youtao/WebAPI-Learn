using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI_Learn.Model;
using WebAPI_Learn.Model.Context;

namespace WebAPI_Learn.API.Controllers
{
    public class ArticleController : ApiController
    {
        private WebAPILearnContext db = new WebAPILearnContext();

        // GET: api/Article
        public IQueryable<Article> GetArticle()
        {
            return this.db.Article;
        }

        // GET: api/Article/5
        [ResponseType(typeof(Article))]
        public IHttpActionResult GetArticle(int id)
        {
            Article article = this.db.Article.Find(id);
            if (article == null)
            {
                return this.NotFound();
            }

            return this.Ok(article);
        }

        // PUT: api/Article/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArticle(int id, Article article)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != article.Id)
            {
                return this.BadRequest();
            }

            this.db.Entry(article).State = EntityState.Modified;

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.ArticleExists(id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Article
        [ResponseType(typeof(Article))]
        public IHttpActionResult PostArticle(Article article)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.db.Article.Add(article);
            this.db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = article.Id }, article);
        }

        // DELETE: api/Article/5
        [ResponseType(typeof(Article))]
        public IHttpActionResult DeleteArticle(int id)
        {
            Article article = this.db.Article.Find(id);
            if (article == null)
            {
                return this.NotFound();
            }

            this.db.Article.Remove(article);
            this.db.SaveChanges();

            return this.Ok(article);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }

        private bool ArticleExists(int id)
        {
            return this.db.Article.Count(e => e.Id == id) > 0;
        }
    }
}