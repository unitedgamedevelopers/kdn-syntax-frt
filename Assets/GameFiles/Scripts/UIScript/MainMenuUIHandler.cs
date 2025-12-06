using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuUIHandler : MonoBehaviour
{
    #region Properties
    [Header("Components Reference")]
    [SerializeField] private TMP_Dropdown gridSelectionDropdown = null;
    [SerializeField] private GridDataHolder gridDataHolder = null;
    #endregion

    #region MonoBehaviour Functions
    private void Start()
    {
        // Setup grid options
        SetupGridDropdownMenu();
    }
    #endregion

    #region Getter And Setter
    public int GridIndex { get; private set; }
    #endregion

    #region Private Core Functions
    // Setup grid dropdown menu options
    private void SetupGridDropdownMenu()
    {
        gridSelectionDropdown.ClearOptions();

        for (int i = 0; i < gridDataHolder.GetGridDataPackLength(); i++)
        {
            GridData data = gridDataHolder.GetGridDataByIndex(i);
            TMP_Dropdown.OptionData od = new TMP_Dropdown.OptionData();
            od.text = $"{data.Column}x{data.Row} Grid";
            gridSelectionDropdown.options.Add(od);
        }
    }
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
