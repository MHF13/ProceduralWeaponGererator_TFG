using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class PanelSlider : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private TMPro.TextMeshProUGUI Text;

    private PauseManager pauseManager;

    private int actualvalue , ID;

    public void SetNewValues(int id, int value, string name, PauseManager pm)
    {
        pauseManager = pm;
        ID = id;
        actualvalue = value;
        slider.value = actualvalue;

        Text.text = name;
    }

    public void SetValue(int value)
    {
        slider.value = value;
    }
    public void Postition(float newPos)
    {
        this.transform.position = new Vector3(0, newPos, 0);
    }

    public void SendNewValue()
    {
        pauseManager.UpdateBS(ID, actualvalue);
    }
    
    public void ChangeValue()
    {
        actualvalue = (int)slider.value;
        SendNewValue();
    }

}
