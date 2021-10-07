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
        Task InitDb();

        /// <summary>
        /// Checks the connection to DB.
        /// </summary>
        Task<bool> CheckConnection();
    }
}
