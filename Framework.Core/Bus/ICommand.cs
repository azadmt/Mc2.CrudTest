namespace Framework.Core.Bus
{
    public interface ICommand
    {
        CommandValidationResult Validate();
    }

    public abstract class CommandBase : ICommand
    {
        protected CommandValidationResult validationResult = new CommandValidationResult();


        protected void AddError(string error)
        {
            validationResult.AddError(error);
        }

        public abstract void RunValidationRules();
        public  CommandValidationResult Validate()
        {
            RunValidationRules();
            return validationResult;
        }
    }
}
