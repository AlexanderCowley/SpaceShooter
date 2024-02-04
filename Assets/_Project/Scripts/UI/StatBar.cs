using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    [SerializeField] CombatStat combatStat;
    Image _image;

    void Start()
    {
        _image = GetComponent<Image>();
        combatStat.ValueChangedHandler += UpdateBar;
    }

    void UpdateBar()
    {
        _image.fillAmount = Mathf.Clamp
            (((float)combatStat.StatValue / (float)combatStat.MaxValue), 0, 1f);
    }
}