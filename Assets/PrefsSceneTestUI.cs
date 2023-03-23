using UnityEngine;
using TMPro;

public class PrefsSceneTestUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI valorDinero;

    [SerializeField]
    private TextMeshProUGUI valorColaboraciones;

    [SerializeField]
    private TextMeshProUGUI valorRamaFinal;

    private void Update() {
        valorDinero.text = PlayerPrefs.GetFloat(PrefsManager.MONEY).ToString() + "$";
        valorColaboraciones.text = PlayerPrefs.GetInt(PrefsManager.COLLABORATION).ToString();
        valorRamaFinal.text = PlayerPrefs.GetInt(PrefsManager.ENDBRANCH).ToString();
    }

}
