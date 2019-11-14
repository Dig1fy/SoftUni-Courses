using MilitaryElite_SecondTry.Enums;

namespace MilitaryElite_SecondTry.Contracts
{
    public interface IMission
    {
        string CodeName { get; }

        string State { get; }

        void CompleteMission();
    }
}
