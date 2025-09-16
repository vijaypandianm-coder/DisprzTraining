using DisprzTraining.Models;
using System.Threading.Tasks;

namespace DisprzTraining.DataAccess
{
    public class HelloWorldDAL : IHelloWorldDAL
    {
        public Task<HelloWorld> GetHelloWorldMessage()
        {
            // Return a valid HelloWorld message - you can hardcode for now
            return Task.FromResult(new HelloWorld { Message = "Hello, World!" });
        }
    }
}
