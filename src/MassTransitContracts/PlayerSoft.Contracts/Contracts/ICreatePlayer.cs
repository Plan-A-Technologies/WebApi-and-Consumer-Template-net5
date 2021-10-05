namespace PlayerSoft.Contracts.Contracts
{
    /// <summary>
    /// The create player contract.
    /// </summary>
    public interface ICreatePlayer
    {
        /// <summary>
        /// The player entity.
        /// </summary>
        IPlayer Player { get; set; }
    }
}
