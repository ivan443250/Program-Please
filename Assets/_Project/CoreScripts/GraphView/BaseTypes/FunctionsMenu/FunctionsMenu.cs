using System;
using UnityEngine;
using Zenject;

namespace ElementaryCase
{
    public class FunctionsMenu : MonoBehaviour
    {
        private Options _options;

        private FunctionsMenuSlot[] _currentSlots;

        private IFunctionSpriteDatabase _spriteDatabase;

        [Inject]
        public void Construct(Options options, IFunctionSpriteDatabase spriteDatabase)
        {
            _options = options;
            _spriteDatabase = spriteDatabase;
        }

        public void Initialize()
        {
            _currentSlots = new FunctionsMenuSlot[_options.FunctionNames.Length];

            for (int i = 0; i < _options.FunctionNames.Length; i++)
            {
                _currentSlots[i] = Instantiate(_options.SlotPrefab, _options.SlotParent);
                //_currentSlots[i].Initialize(_spriteDatabase.GetById(_options.FunctionNames[i]));
            }
        }

        [Serializable]
        public class Options
        {
            public Transform SlotParent;
            public FunctionsMenuSlot SlotPrefab;
            public string[] FunctionNames;
        }
    }
}
