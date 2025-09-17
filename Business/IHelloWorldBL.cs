using DisprzTraining.Models;
using System.Threading.Tasks;

namespace DisprzTraining.Business
{
    public interface IHelloWorldBL
    {
        Task<HelloWorld> SayHelloWorld();
    }
}
