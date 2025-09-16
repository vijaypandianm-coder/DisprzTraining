using DisprzTraining.DataAccess;
using DisprzTraining.Models;
using System.Threading.Tasks;

namespace DisprzTraining.Business
{
    public class HelloWorldBL : IHelloWorldBL
    {
        private readonly IHelloWorldDAL _helloWorldDAL;
        public HelloWorldBL(IHelloWorldDAL helloWorldDAL)
        {
            _helloWorldDAL = helloWorldDAL;
        }

        public async Task<HelloWorld> SayHelloWorld()
        {
            var message = await _helloWorldDAL.GetHelloWorldMessage();

            // If your DAL can return null or empty, ensure you return a valid HelloWorld object
            if (message == null || string.IsNullOrEmpty(message.Message))
            {
                return new HelloWorld { Message = "Hello, World!" };
            }

            return message;
        }
    }
}
