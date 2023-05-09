using ScriptableObjectArchitecture;

[System.Serializable]
public class NotificationContent
{
    public string title;
    public string content;

    public delegate void  Action();

    public Action action;

    public NotificationContent( string title, string content, Action action = null) {
        this.title = title;
        this.content = content;
        this.action = action;
    }

}
