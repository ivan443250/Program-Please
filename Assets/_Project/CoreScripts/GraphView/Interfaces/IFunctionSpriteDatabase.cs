using UnityEngine;

namespace ElementaryCase
{
    public interface IFunctionSpriteDatabase
    {
        Sprite GetById(string id);
    }
}