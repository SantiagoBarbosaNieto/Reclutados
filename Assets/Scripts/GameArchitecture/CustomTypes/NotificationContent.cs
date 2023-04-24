[System.Serializable]
public class NotificationContent
{
    public string title;
    public string content;

    public NotificationContent( string title, string content) {
        this.title = title;
        this.content = content;
    }

}
