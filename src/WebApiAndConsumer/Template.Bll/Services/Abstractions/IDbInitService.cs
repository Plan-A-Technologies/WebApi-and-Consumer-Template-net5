using System.Threading.Tasks;
using Template.Bll.Dto;

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
        Task<PingDbDto> CheckConnection();
    }
}
