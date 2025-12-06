using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuUIHandler : MonoBehaviour
{
    #region Properties
    [Header("Components Reference")]
    [SerializeField] private TMP_Dropdown gridSelectionDropdown = null;
    #endregion

    #region Getter And Setter
    public int GridIndex { get; private set; }
    #endregion

    #region UI Events Functions
    public void OnClick_PlayBtn()
    {
        GameCanvasManager.Instance.SwitchCanvasUIScreen(UIScreen.GameplayUI);
    }

    public void OnValueChange_SelectGrid()
    {
        GridIndex = gridSelectionDropdown.value;
    }

    public void OnClick_LoadGameBtn()
    {
        // Todo: Work on loading saved progress
    }
    #endregion
}
