using PlayerSoft.Contracts.Contracts;

namespace PlayerSoft.Template.Bll.Models
{
    /// <inheritdoc/>
    public class CreatePlayer : ICreatePlayer
    {
        /// <inheritdoc/>
        public IPlayer Player { get; set; }
    }
}
