using System;
using System.Threading.Tasks;

namespace CSharpWinFormsPOCs
{
    public interface IUserService
    {
        Task LoadUsers(
            Action<string> onSuccess,
            Action<Exception> onError);
    }
}