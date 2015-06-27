using WcfRestService1.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using WcfRestService1;

namespace WebServiceTest
{
    
    [TestClass()]
    public class CorredorControllerTest
    {

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for AdicionaCorredor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Rick\\Documents\\Visual Studio 2010\\Projects\\WcfRestService1\\WcfRestService1", "/")]
        [UrlToTest("http://localhost:64670/NecessarioParaPoderRodarTestes.aspx")]
        public void AdicionaCorredorTest()
        {
            corredor instance = new corredor() {idCorredor=0, nome = "Teste1", cidade = "Fpolis", 
                data_nascimento = DateTime.Now, estado = "SC", status = "Confirmado" };
            
            corredor actual = CorredorController.AdicionaCorredor(instance);
            Assert.AreEqual("Teste1", actual.nome);
            Assert.AreEqual("Fpolis", actual.cidade);

            CorredorController.ExcluiCorredor("0");
        }

        /// <summary>
        ///A test for AtualizaCorredor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Rick\\Documents\\Visual Studio 2010\\Projects\\WcfRestService1\\WcfRestService1", "/")]
        [UrlToTest("http://localhost:64670/NecessarioParaPoderRodarTestes.aspx")]
        public void AtualizaCorredorTest()
        {
            string id = "1";
            corredor instance = new corredor()
            {
                nome = "Jeisisclaison",
                cidade = "Fpolis",
                data_nascimento = DateTime.Now,
                estado = "SC",
                status = "OK"
            };
            
            corredor actual = CorredorController.AtualizaCorredor(id, instance);
            Assert.AreEqual("Jeisisclaison", actual.nome);

            instance.nome = "Maria";
            instance.cidade = "Florianópolis";
            CorredorController.AtualizaCorredor(id, instance);
        }

        /// <summary>
        ///A test for ExcluiCorredor
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("C:\\Users\\Rick\\Documents\\Visual Studio 2010\\Projects\\WcfRestService1\\WcfRestService1", "/")]
        [UrlToTest("http://localhost:64670/NecessarioParaPoderRodarTestes.aspx")]
        public void ExcluiCorredorTest()
        {
            corredor instance = new corredor()
            {
                idCorredor = 999,
                nome = "Teste5",
                cidade = "Fpolis",
                data_nascimento = DateTime.Now,
                estado = "SC",
                status = "OK"
            };
            corredor c = CorredorController.AdicionaCorredor(instance);
            string id = c.idCorredor.ToString();
            CorredorController.ExcluiCorredor(id);
            try
            {
                CorredorController.RetornaCorredor(id);
            }
            catch (Exception e)
            {
                //quando nao conseguiu encontrar ele retorna esse erro
                Assert.IsInstanceOfType(e, typeof(InvalidOperationException));
            }
        }
    }
}
