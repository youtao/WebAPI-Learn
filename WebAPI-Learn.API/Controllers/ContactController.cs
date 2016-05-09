namespace WebAPI_Learn.API.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Http;

    using WebAPI_Learn.Model.Context;

    public class ContactController : ApiController
    {
        private readonly WebAPILearnContext db = new WebAPILearnContext();

        public IEnumerable<Contact> Get()
        {
            return this.db.Contact.ToList();
        }

        public Contact Get(int? id)
        {
            return this.db.Contact.SingleOrDefault(e => e.Id == id);
        }


        public void Post(Contact model)
        {
            this.db.Contact.Add(model);
        }

        public void Put(Contact model)
        {
            if (!this.db.Contact.Any(e => e.Name == model.Name))
            {
                this.db.Contact.Add(model);
            }
        }

        public void Delete(int? id)
        {
            var entity = this.db.Contact.FirstOrDefault(e => e.Id == id);
            if (entity != null)
            {
                this.db.Entry(new Contact()).State = EntityState.Deleted;
                this.db.SaveChanges();
            }
        }
    }
}