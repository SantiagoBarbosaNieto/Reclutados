using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// TODO Big refactor was necessary. Check if everythin works well.
public class Regateo2Controller : MonoBehaviour
{

    //This list should be generated from a global list of products
    private List<RegateoProduct> allProducts = new List<RegateoProduct>();

    [SerializeField]
    public UnityEvent OnRegateoTerminado;
    

    //This list should be generated from a global list of characters. It can also be customized in case the
    //current day requires it
    [SerializeField]
    private List<RegateoCharacterSO> currentAvailableCharacters = new List<RegateoCharacterSO>();

    [SerializeField]
    [Range(0, 100)]
    private int priceIncreasePercent = 10;

    private RegateoCharacter regateoCharacter;

    // Regateo View
    [SerializeField]
    private Regateo2View regateoView;

    private int pedidosDisponibles = 0;

    private States currentState;

    private void Start()
    {
        regateoView.GetSiguientePedidoEvent().AddListener(UpdateStateSiguiente);
        regateoView.GetOptRegatearEvent().AddListener(Regatear);
        regateoView.GetOptSiEvent().AddListener(AceptarOferta);
        regateoView.GetOptNoEvent().AddListener(RechazarOferta);

        // Sets the current available characters and products from the GameStateManager
        if(GameStateManager.Instance != null) {
            allProducts = GameStateManager.Instance.GetAllProducts();
            currentAvailableCharacters = new List<RegateoCharacterSO>(GameStateManager.Instance.GetAllCharacters());
        }

        CreateRegateoCharacter();
        currentState = States.Saludo;
        UpdateStateSiguiente();
    }

    public void CreateRegateoCharacter()
    {
        if (currentAvailableCharacters.Count == 0)
        {
            Debug.LogError("No hay personajes disponibles para este regateo. Quizas quieras refrescar el controlador");
            return;
        }

        regateoCharacter = GenerateRegateoCharacter();
        pedidosDisponibles = regateoCharacter.OrdersCount();
    }

    // Generate random character
    private RegateoCharacter GenerateRegateoCharacter()
    {
        RegateoCharacterSO randomRegateoCharacter = null;

        randomRegateoCharacter = currentAvailableCharacters[Random.Range(0, currentAvailableCharacters.Count)];

        RegateoCharacter regateoCharacter = RegateoCharacterFactory.CreateRegateoCharacter(randomRegateoCharacter, allProducts);

        currentAvailableCharacters.Remove(randomRegateoCharacter);

        return regateoCharacter;
    }

    // States
    // Saludo -> (mensaje saludo) -> Pedido
    // Pedido -> Siguiente active -> Oferta
    // Oferta -> Regatear, Si, No active
    //          Rechazo -> (mensaje rechazo) Siguiente active
    //          Acepto -> (mensaje acepto y actualiza) Siguiente active
    // 

    //Finite State Machine
    private enum States
    {
        Saludo,
        Pedido,
        RegateoTerminado,
    }

    private void UpdateStateSiguiente()
    {

        Debug.Log("Current State: " + currentState);
        switch (currentState)
        {
            case States.Saludo:
                currentState = Saludo();
                break;
            case States.Pedido:
                currentState = Pedido();
                break;
            case States.RegateoTerminado:
                OnRegateoTerminado.Invoke();
                break;

            default:
                Debug.LogError("Estado no valido");
                break;
        }
    }

    private States Saludo()
    {
        if (regateoCharacter == null)
        {
            Debug.Log("RegateoCharacter is null");
        }
        DialogOption();
        regateoView.UpdateCharacterImage(regateoCharacter.GetImage());
        regateoView.UpdateCharacterName(regateoCharacter.GetName());

        string saludo = regateoCharacter.GenerateSaludo();
        regateoView.UpdateDialogo(saludo);

        return States.Pedido;
    }

    private States Pedido()
    {
        // Check if pedidos left
        if (regateoCharacter.OrdersAvailable())
        {
            // Get next order
            RegateoOrder nextOrder = regateoCharacter.orders[0];
            regateoCharacter.RemoveOrder(nextOrder);

            string pedido = regateoCharacter.GeneratePedido(nextOrder);
            regateoView.UpdateDialogo(pedido);
            regateoView.UpdateOferta(nextOrder.offer);

            PedidoOption();

            // Check if there is enough stock for the order.


            int currentPrice = nextOrder.GetPrice();

            int newPrice = currentPrice + (currentPrice * priceIncreasePercent / 100);
            regateoView.SetOptRegatearText("Subir precio a " + newPrice + "$");

            return States.Pedido;
        }

        //If not, check if there are characters available
        else
        {
            DialogOption();
            regateoView.UpdateDialogo(regateoCharacter.GenerateDespedida());
            if (currentAvailableCharacters.Count == 0)
            {
                Debug.Log("No hay mas personajes disponibles");
                Debug.Log("Regateo over");
                return States.RegateoTerminado;
            }

            else
            {
                CreateRegateoCharacter();
                return States.Saludo;
            }
        }
    }

    private void PedidoOption()
    {
        regateoView.SetOptRegatearActive(true);
        regateoView.SetOfertaActive(true);
        regateoView.SetComentarioActive(true);
        regateoView.SetOptNoActive(true);
        regateoView.SetOptSiActive(true);
        regateoView.SetSiguientePedidoActive(false);
    }

    private void DialogOption()
    {
        regateoView.SetOfertaActive(false);
        regateoView.SetComentarioActive(false);
        regateoView.SetOptRegatearActive(false);
        regateoView.SetOptNoActive(false);
        regateoView.SetOptSiActive(false);
        regateoView.SetSiguientePedidoActive(true);
    }

    // Decision Options ----------------
    private void AceptarOferta()
    {
        DialogOption();
        regateoView.UpdateDialogo(regateoCharacter.GenerateTrato());
        //TODO decrease products, increase money
    }

    private void RechazarOferta()
    {
        DialogOption();
        regateoView.UpdateDialogo(regateoCharacter.GenerateRechazo());
    }

    private void Regatear()
    {
        DialogOption();

        float tol = regateoCharacter.GetTolerance();
        Debug.Log("Tolerance: " + tol);
        //random from 1 to 100
        float random = Random.Range(1, 100);

        Debug.Log("Random num for tolerance: " + random);

        string mensaje = "";

        if (random <= tol)
        {
            // Regateo exitoso
            mensaje = regateoCharacter.GenerateTrato();
            // TODO decrease products, increase money
        }
        else
        {
            // Regateo fallido
            mensaje = regateoCharacter.GenerateMalTrato();
        }

        regateoView.UpdateDialogo(mensaje);

    }
    // -------------------------------

}
