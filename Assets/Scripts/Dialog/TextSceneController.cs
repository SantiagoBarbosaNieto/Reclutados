using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TextSceneController : MonoBehaviour
{

    [SerializeField]
    private TMP_Text text;

    [SerializeField]
    [TextArea(6, 10)]
    private string debugText;

    [SerializeField]
    private Button exit;

    [SerializeField]
    private Image image;

    [SerializeField]
    private float fadeTime = 100f;

    [SerializeField]
    [Range(0, 20)]
    private int typeWriterSpeed = 0;

    private void Start() {
        exit.gameObject.SetActive(false);
        exit.onClick.AddListener(OnExit);
        StartCoroutine(PrintTextCoroutine());
    }

    public void Init(string text) {
        this.text.text = text;
        exit.gameObject.SetActive(true);
    }

    public void OnExit() {
        Destroy(text.gameObject);
        Destroy(exit.gameObject);
        StartCoroutine(FadeOutScene());
    }


    IEnumerator FadeOutScene() {

        float elapsedTime = 0.0f;
        Color color = image.color;

        while (elapsedTime < fadeTime) {
            Debug.Log("Fading out scene");
            // Calculate the alpha value based on the elapsed time
            float alpha = Mathf.Lerp(1.0f, 0.0f, elapsedTime / fadeTime);

            // Set the alpha value of the Image
            color.a = alpha;
            image.color = color;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Debug.Log("Unloading scene");
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Text"));
    }

    private IEnumerator PrintTextCoroutine()
    {
        float delay = 1f / typeWriterSpeed;
        for (int i = 0; i < debugText.Length; i++)
        {
            text.text += debugText[i];
            yield return new WaitForSeconds(delay);
        }
        exit.gameObject.SetActive(true);
    }

}
