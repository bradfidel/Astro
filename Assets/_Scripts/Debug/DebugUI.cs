using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DebugUI : MonoBehaviour
{
    public static DebugUI instance = null;

    [SerializeField]
    private TextMeshProUGUI debugText = null;

    private List<string> waitingStrings = new List<string>();
    
    private void Awake()
    {
        instance = this;
    }

    public void DisplayValue(string valueToDisplay)
    {
        waitingStrings.Add(valueToDisplay);
    }

    private void LateUpdate()
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        for(int i = 0; i < waitingStrings.Count; i++)
        {
            sb.AppendLine(waitingStrings[i]);
        }
        debugText.text = sb.ToString();

        waitingStrings.Clear();
    }
}
