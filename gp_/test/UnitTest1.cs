using NUnit.Framework;
using gp_;
namespace test
{
    public class Tests
    {
        gp_.Controllers.errorController ec;
        [SetUp]
        public void Setup()
        {
            ec = new gp_.Controllers.errorController();
        }

        [Test]
        public void Test1()
        {
            ec.httpstatuscodehandler(404);
        }
    }
}