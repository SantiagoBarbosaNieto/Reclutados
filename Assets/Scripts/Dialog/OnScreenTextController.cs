using UnityEngine;

public class OnScreenTextController : MonoBehaviour
{
    [SerializeField]
    private GameObject textPrefab;

    public void DisplayText(OnScreenTextRequest request) {
        GameObject textObject = Instantiate(textPrefab, transform);
        textObject.SetActive(false);

        TextSceneController textSceneController = textObject.GetComponent<TextSceneController>();
        textSceneController.debugText = request.text;
        textSceneController.fadeTime = request.fadeTime;
        textSceneController.typeWriterSpeed = request.typeWriterSpeed;

        textObject.SetActive(true);
    }

}
