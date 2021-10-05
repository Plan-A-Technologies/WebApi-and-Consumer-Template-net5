using PlayerSoft.Contracts.Contracts;

namespace PlayerSoft.Template.Bll.Models
{
    public class CreatePlayer : ICreatePlayer
    {
        public IPlayer Player { get; set; }
    }
}
