namespace ElementaryCase
{
    public interface IRuntimeVariableCollection
    {
        void Clear();
        void SetVariable(string name, string value);
        string GetVariable(string name);
    }
}
