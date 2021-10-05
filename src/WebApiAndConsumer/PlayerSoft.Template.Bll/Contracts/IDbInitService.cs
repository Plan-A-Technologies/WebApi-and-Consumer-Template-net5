using System.Threading.Tasks;

namespace PlayerSoft.Template.Bll.Contracts
{
    /// <summary>
    /// DB init interface.
    /// </summary>
    public interface IDbInitService
    {
        /// <summary>
        /// DB initialization.
        /// </summary>
        /// <returns></returns>
        Task InitDb();
    }
}
