using System.Threading.Tasks;
using DisprzTraining.Models;

namespace DisprzTraining.DataAccess
{
    public class HelloWorldDAL : IHelloWorldDAL
    {
        public Task<HelloWorld> GetHelloWorldMessage()
        {
            return Task.FromResult(new HelloWorld { Message = "Hello, World!" });
        }
    }
}
