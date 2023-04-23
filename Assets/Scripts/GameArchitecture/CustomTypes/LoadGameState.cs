
using System.Collections.Generic;

[System.Serializable]
public class LoadGameState
{
    public int dia;
    public float moneyDayStart;

    public Dictionary<int, List<GameStateManager.Evento>> eventos;

    public LoadGameState(int dia, float moneyDayStart, Dictionary<int, List<GameStateManager.Evento>> eventos) {
        this.dia = dia;
        this.moneyDayStart = moneyDayStart;
        this.eventos = eventos;
    }

}
