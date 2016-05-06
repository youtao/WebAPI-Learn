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
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public class ArticleCategoryController : ApiController
    {
        private WebAPILearnContext db = new WebAPILearnContext();

        public HttpResponseMessage GetArticleCategory()
        {
            var result = this.db.ArticleCategory.Select(e => new { e.Id, e.Name, e.CreateTime }).ToList();
            return this.Request.CreateResponse(HttpStatusCode.OK, result);
        }

        public IHttpActionResult GetArticleCategory(int id)
        {
            var entity = this.db.ArticleCategory.FirstOrDefault(e => e.Id == id);
            if (entity == null)
            {
                return this.NotFound();
            }

            return this.Ok(new { entity.Id, entity.Name, entity.CreateTime });
        }

        // PUT: api/ArticleCategory/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArticleCategory(int id, ArticleCategory articleCategory)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (id != articleCategory.Id)
            {
                return this.BadRequest();
            }

            this.db.Entry(articleCategory).State = EntityState.Modified;

            try
            {
                this.db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.ArticleCategoryExists(id))
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

        // POST: api/ArticleCategory
        [ResponseType(typeof(ArticleCategory))]
        public IHttpActionResult PostArticleCategory([FromBody]ArticleCategory articleCategory)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.db.ArticleCategory.Add(articleCategory);
            this.db.SaveChanges();

            return this.CreatedAtRoute("DefaultApi", new { id = articleCategory.Id }, articleCategory);
        }

        // DELETE: api/ArticleCategory/5
        [ResponseType(typeof(ArticleCategory))]
        public IHttpActionResult DeleteArticleCategory(int id)
        {
            ArticleCategory articleCategory = this.db.ArticleCategory.Find(id);
            if (articleCategory == null)
            {
                return this.NotFound();
            }

            this.db.ArticleCategory.Remove(articleCategory);
            this.db.SaveChanges();

            return this.Ok(articleCategory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }

            base.Dispose(disposing);
        }

        private bool ArticleCategoryExists(int id)
        {
            return this.db.ArticleCategory.Count(e => e.Id == id) > 0;
        }
    }
}