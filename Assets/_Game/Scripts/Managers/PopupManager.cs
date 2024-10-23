using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Utils;
namespace TowerDefense.UI
{
    public class PopupManager : MonoBehaviour
    {
        [SerializeField] UI_Popup _gameOverPopup;

        public void ShowPopup()
        {
            _gameOverPopup.ShowPopupUI();
        }

        public void ClosePopup()
        {
            _gameOverPopup.ClosePopupUI();
        }
    }
}