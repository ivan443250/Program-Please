using PrimeTween;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ElementaryCase
{
    [RequireComponent(typeof(RectTransform))]
    public class FunctionsMenuSlot : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _mainSprite;
        [SerializeField] private GameObject _selectedPanel;

        private Action _onClick;

        private string _funcName;

        public void Initialize(Sprite functionSprite, string funcName)
        {
            _funcName = funcName;

            _mainSprite.sprite = functionSprite;
            _mainSprite.preserveAspect = true;
            Unselect();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _onClick?.Invoke();
        }

        public void Select()
        {
            _mainSprite.enabled = false;
            _selectedPanel.SetActive(true);
        }

        public void Unselect()
        {
            _mainSprite.enabled = true;
            _selectedPanel.SetActive(false);
        }
    }
}
