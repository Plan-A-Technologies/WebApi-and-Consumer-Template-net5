using System.Threading.Tasks;

namespace Template.Bll.Services.Abstractions
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
