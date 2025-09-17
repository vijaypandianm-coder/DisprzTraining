using System.Threading.Tasks;
using DisprzTraining.Models;

namespace DisprzTraining.DataAccess
{
    public interface IHelloWorldDAL
    {
        Task<HelloWorld> GetHelloWorldMessage();
    }
}
