namespace ElementaryCase
{
    public interface IFunctionModulesImporter
    {
        void Import(ILibrary library);
        void Remove(ILibrary library);
    }
}
