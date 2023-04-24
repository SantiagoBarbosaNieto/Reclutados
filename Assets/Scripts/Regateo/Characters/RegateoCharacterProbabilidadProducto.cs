using UnityEngine;

[System.Serializable]
public class RegateoCharacterProbabilidadProducto
{
    [Range(0, 100)]
    public int probabilidad;
    [Range(0, 100)]
    public int idProducto;
}
