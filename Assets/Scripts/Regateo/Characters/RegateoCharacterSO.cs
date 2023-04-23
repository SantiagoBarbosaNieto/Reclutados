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

    [Header("Distribucion de probabilidades: La suma debe ser 100%")]
    [SerializeField]
    [Range(0, 100)]
    private int percentPlatanos;

    [SerializeField]
    [Range(0, 100)]
    private int percentPapas;

    [SerializeField]
    [Range(0, 100)]
    private int percentCafe;

    [Space(10)]
    [Header("Tolerancia al regateo")]
    [Tooltip("A mayor tolerancia, mas dificil es regatear")]
    [Range(0, 100)]
    [SerializeField]
    private float toleranciaBase;
    
    public float tolerancia {get; private set;}


    [Space (10)]
    [Tooltip ("Se pueden cambiar o dejar default")]
    [Header ("Dialogos")]

    [SerializeField]
    private List<string> saludos = new List<string>(){
        "Buenas joven como le va?",
        "Buenas tardes",
        "Buenas mijo como esta?"
    };  

    [SerializeField]
    private List<string> pedidos = new List<string>() {
        "Regaleme por favor x y",
        "Por favor x y",
        "Deme x y"
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
        "Esta muy caro mijo",
        "Antes no era tan caro"
    };

    [SerializeField]
    private List<string> trato = new List<string>() {
        "Listo pues mijo",
        "Lo compro",
        "Esta bien joven, se lo compro"
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
    

    public string GeneratePedido(int cantidad, string producto)
    {
        bool plurable = producto == "plátano" || producto == "papa";
        string nombreProd = plurable && cantidad > 1? producto + "s" : producto;

        string pedido = pedidos[Random.Range(0, pedidos.Count)];
        pedido = pedido.Replace("x", cantidad.ToString());
        pedido = pedido.Replace("y", nombreProd);

        return pedido;
    }

    public int GetPlatanosProbability() {
        return percentPlatanos;
    }

    public int GetPapasProbability() {
        return percentPapas;
    }

    public int GetCafeProbability() {
        return percentCafe;
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

}
