using Zenject;

namespace ElementaryCase.Test
{
    public class SceneEntryPoint : IInitializable
    {
        private readonly RuntimeConsoleLibrary _runtimeConsoleLibrary;
        private readonly TextEditor _textEditor;

        public SceneEntryPoint(RuntimeConsoleLibrary runtimeConsoleLibrary, TextEditor textEditor)
        {
            _runtimeConsoleLibrary = runtimeConsoleLibrary;
            _textEditor = textEditor;
        }

        public void Initialize()
        {
            _runtimeConsoleLibrary.Initialize();
            _textEditor.Initialize();
        }
    }
}
