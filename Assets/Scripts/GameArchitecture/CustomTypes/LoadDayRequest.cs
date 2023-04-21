[System.Serializable]
public class LoadDayRequest
{
    public DaySO day;
    public LoadDayRequest(DaySO day) {
        this.day = day;
    }
}
