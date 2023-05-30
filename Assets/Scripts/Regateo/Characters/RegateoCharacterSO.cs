using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Regateo Character", menuName = "Regateo/Regateo Character", order = 0)]
public class RegateoCharacterSO : ScriptableObject 
{
    [SerializeField]
    private new string name;

    [SerializeField]
    private Sprite sprite;
    

    [Space (10)]

    [Header("Distribucion de probabilidades")]
    [SerializeField]
    private RegateoCharacterProbabilidadProducto[] productosProbabilidad;

    [Space(10)]
    [Header("Tolerancia al regateo")]
    [Tooltip("A mayor tolerancia, mas difícil es regatear")]
    [Range(0, 100)]
    [SerializeField]
    private float toleranciaBase;
    
    public float tolerancia {get; private set;}


    [Space (10)]
    [Tooltip ("Se pueden cambiar o dejar default")]
    [Header ("Dialogos")]

    [SerializeField]
    private List<string> saludos = new List<string>(){
        "Buenas joven cómo le va?",
        "Buenas tardes",
        "Buenas mijo cómo está?"
    };  

    [SerializeField]
    private List<string> pedidos = new List<string>() {
        "Regáleme por favor x z",
        "Por favor x z",
        "Deme x z"
    };

    [SerializeField]
    private List<string> despedidas = new List<string>() {
        "Gracias joven, hasta luego",
        "Gracias mijo, que le vaya bien",
        "Hasta luego joven se me cuida"
    };

    [SerializeField]
    private List<string> malTrato = new List<string>() {
        "No joven no me alcanza",
        "Está muy caro mijo",
        "Antes no era tan caro"
    };

    [SerializeField]
    private List<string> trato = new List<string>() {
        "Listo pues mijo",
        "Lo compro",
        "Está bien joven, se lo compro"
    };

    [SerializeField]
    private List<string> rechazo = new List<string>() {
        "Bueno pues",
    };

    private void OnEnable() {
        tolerancia = toleranciaBase;
    }

    public string GenerateSaludo()
    {
        return saludos[Random.Range(0, saludos.Count)];
    }
    

    public string GeneratePedido(int cantidad, string nombreProducto, string nombreProductoPlural)
    {
        string pedido = pedidos[Random.Range(0, pedidos.Count)];

        if(cantidad > 1) 
            pedido = pedido.Replace("z", nombreProductoPlural);
        else
            pedido = pedido.Replace("z", nombreProducto);
        pedido = pedido.Replace("x", cantidad.ToString());

        return pedido;
    }

    public int GetProductProbability(int id) {
        foreach(RegateoCharacterProbabilidadProducto producto in productosProbabilidad) {
            if(producto.idProducto == id) {
                return producto.probabilidad;
            }
        }
        return 0;
    }

    public string GenerateDespedida()
    {
        return despedidas[Random.Range(0, despedidas.Count)];
    }

    public string GenerateMalTrato()
    {
        return malTrato[Random.Range(0, malTrato.Count)];
    }

    public string GenerateTrato()
    {
        return trato[Random.Range(0, trato.Count)];
    }

    public string GenerateRechazo() {
        return rechazo[Random.Range(0, rechazo.Count)];
    }

    public void DecreaseTolerancia(float decrement) {
        tolerancia -= decrement;
    }

    public string GetName() {
        return name;
    }

    public Sprite GetSprite() {
        return sprite;
    }

    public RegateoCharacterProbabilidadProducto[] GetProductosProbabilidad() {
        return productosProbabilidad;
    }

}
