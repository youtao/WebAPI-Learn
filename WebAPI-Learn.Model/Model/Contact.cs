namespace WebAPI_Learn
{
    using WebAPI_Learn.ModelFactory;

    public class Contact : BaseModel
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }
    }
}