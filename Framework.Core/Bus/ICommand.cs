namespace Framework.Core.Bus
{
    public interface ICommand
    {
        void Validate();
    }

    public abstract class CommandBase : ICommand
    {
        protected CommandValidationResult validationResult = new CommandValidationResult();


        protected void AddError(string error)
        {
            validationResult.AddError(error);
        }

        public abstract void RunValidationRules();
        public void Validate()
        {
            RunValidationRules();
            if (validationResult.HasError())
                throw new System.Exception(string.Join(",", validationResult.ValidationErrors));
        }
    }
}
