using Template.Shared.DtoContracts;

namespace Template.Shared.Messages
{
    /// <summary>
    /// The create player contract.
    /// </summary>
    public interface IPlayerMessage
    {
        /// <summary>
        /// The player entity.
        /// </summary>
        IPlayerDto PlayerDto { get; set; }
    }
}
