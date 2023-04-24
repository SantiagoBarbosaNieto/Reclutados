using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class Regateo2View : MonoBehaviour
{

    [SerializeField] private Image characterImage;
    [SerializeField] private TMP_Text characterName;
    [SerializeField] private TMP_Text dialogo;
    [SerializeField] private TMP_Text oferta;
    [SerializeField] private TMP_Text comentario;

    [SerializeField] private Button optRegatear;
    [SerializeField] private Button optSi;
    [SerializeField] private Button optNo;
    [SerializeField] private Button siguientePedido;

    public void UpdateDialogo(string text) {
        dialogo.text = text;
    }

    public void UpdateOferta(string text) {
        oferta.text = text;
    }

    public void UpdateComentario(string text) {
        comentario.text = text;
    }

    public void UpdateCharacterImage(Sprite sprite) {
        characterImage.sprite = sprite;
    }

    public void UpdateCharacterName(string text) {
        characterName.text = text;
    }

    public void SetOfertaActive(bool active) {
        oferta.gameObject.SetActive(active);
    }

    public void SetComentarioActive(bool active) {
        comentario.gameObject.SetActive(active);
    }

    public void SetOptRegatearActive(bool active) {
        optRegatear.gameObject.SetActive(active);
    }

    public void SetOptRegatearText(string text) {
        optRegatear.GetComponentInChildren<TMP_Text>().text = text;
    }

    public void SetOptSiActive(bool active) {
        optSi.gameObject.SetActive(active);
    }

    public void SetOptNoActive(bool active) {
        optNo.gameObject.SetActive(active);
    }

    public void SetSiguientePedidoActive(bool active) {
        siguientePedido.gameObject.SetActive(active);
    }

    public UnityEvent GetSiguientePedidoEvent() {
        return siguientePedido.onClick;
    }

    public UnityEvent GetOptSiEvent() {
        return optSi.onClick;
    }

    public UnityEvent GetOptNoEvent() {
        return optNo.onClick;
    }
    
    public UnityEvent GetOptRegatearEvent() {
        return optRegatear.onClick;
    }

    

}
