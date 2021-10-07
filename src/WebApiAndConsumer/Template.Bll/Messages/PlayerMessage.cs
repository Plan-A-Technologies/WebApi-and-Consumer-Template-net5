using Template.Shared.DtoContracts;
using Template.Shared.Messages;

namespace Template.Bll.Messages
{
    /// <inheritdoc/>
    public class PlayerMessage : IPlayerMessage
    {
        /// <inheritdoc/>
        public IPlayerDto PlayerDto { get; set; }
    }
}
