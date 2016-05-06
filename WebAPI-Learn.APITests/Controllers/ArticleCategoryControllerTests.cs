namespace WebAPI_Learn.APITests.Controllers
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using WebAPI_Learn.API.Controllers;

    [TestClass]
    public class ArticleCategoryControllerTests
    {
        [TestMethod]
        public void GetArticleCategoryTest()
        {
            ArticleCategoryController controller = new ArticleCategoryController();
            var result = controller.GetArticleCategory();
        }
    }
}