[System.Serializable]
public class OnScreenTextRequest
{
    public string text;
    public float fadeTime;
    public int typeWriterSpeed;

    public OnScreenTextRequest(string text, float fadeTime, int typeWriterSpeed)
    {
        this.text = text;
        this.fadeTime = fadeTime;
        this.typeWriterSpeed = typeWriterSpeed;
    }
}
