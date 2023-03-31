[System.Serializable]
public class DialogEvent {
    public int day;
    public string queue;
    public DialogProgressionSO dp;

    public DialogEvent(int day, string queue, DialogProgressionSO dp) {
        this.day = day;
        this.queue = queue;
        this.dp = dp;
    }
}