using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TowerDefense.UI
{ 
public abstract class UI_Popup : MonoBehaviour
{
    public abstract void Init();
    public virtual void ClosePopupUI()
    {
        gameObject.SetActive(false);
    }
    public virtual void ShowPopupUI()
    {
        gameObject.SetActive(true);
    }
}
}