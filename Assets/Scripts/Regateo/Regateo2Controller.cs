using System.Collections.Generic;
using UnityEngine;

// TODO Big refactor was necessary. Check if everythin works well.
public class Regateo2Controller : MonoBehaviour
{
    private List<RegateoProduct> allProducts = new List<RegateoProduct>() {
        new RegateoProduct("papa", 10, 0),
        new RegateoProduct("plátano", 20, 1),
        new RegateoProduct("cafe", 5, 2),
    };

    [SerializeField]
    private List<RegateoCharacterSO> allCharacters; 

    [SerializeField]
    [Range(0, 100)]
    private int priceIncreasePercent = 10;

    private List<RegateoCharacterSO> chosenCharacters = new List<RegateoCharacterSO>();

    private RegateoCharacter regateoCharacter;

    // Regateo View
    [SerializeField]
    private Regateo2View regateoView;

    private int pedidosDisponibles = 0;

    private States currentState;

    private void Start() {
        regateoCharacter = GenerateRegateoCharacter();
        pedidosDisponibles = regateoCharacter.OrdersCount();

        regateoView.GetSiguientePedidoEvent().AddListener(UpdateStateSiguiente);

        regateoView.GetOptRegatearEvent().AddListener(Regatear);
        regateoView.GetOptSiEvent().AddListener(AceptarOferta);
        regateoView.GetOptNoEvent().AddListener(RechazarOferta); 

        regateoView.UpdateCharacterImage(regateoCharacter.GetImage());
        regateoView.UpdateCharacterName(regateoCharacter.GetName());

        currentState = States.Saludo;
        UpdateStateSiguiente();
    }

    // Generate random character
    private RegateoCharacter GenerateRegateoCharacter() {
        RegateoCharacterSO randomRegateoCharacter = null;

        int maxIterations = 100;
        do {
            randomRegateoCharacter = allCharacters[Random.Range(0, allCharacters.Count)];
            maxIterations--;
        } while(chosenCharacters.Contains(randomRegateoCharacter) && maxIterations > 0);
        // TODO test para no repetir personajes
        
        if(maxIterations == 0) {
            Debug.LogError("No se pudo encontrar un personaje que no se haya usado, quizas haya muy pocos personajes comparado con la cantidad de personajes maxima");
            throw new System.Exception("No se pudo encontrar un personaje que no se haya usado, quizas haya muy pocos personajes comparado con la cantidad de personajes maxima");
        }

        chosenCharacters.Add(randomRegateoCharacter);

        RegateoCharacter regateoCharacter = RegateoCharacterFactory.CreateRegateoCharacter(randomRegateoCharacter, allProducts);

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
    private enum States {
        Saludo,
        Pedido,
        Despedida,
        Esperando,
    }

    private void UpdateStateSiguiente() {

        switch(currentState) {
            case States.Saludo:
                currentState = Saludo();
                break;
            case States.Pedido:
                currentState = Pedido();
                break;
            case States.Despedida:
                currentState = Despedida();
                break;
            
            default:
                Debug.LogError("Estado no valido");
                break;
        }
    }

    private States Saludo() {
        if(regateoCharacter == null) {
            Debug.Log("RegateoCharacter is null");
        }
        DialogOption();

        string saludo = regateoCharacter.GenerateSaludo();
        regateoView.UpdateDialogo(saludo);

        return States.Pedido;
    }

    private States Pedido() {
        // Check if pedidos left
        if(regateoCharacter.OrdersAvailable()) {
            // Get next order
            RegateoOrder nextOrder = regateoCharacter.orders[0];
            regateoCharacter.RemoveOrder(nextOrder);

            string pedido = regateoCharacter.GeneratePedido(nextOrder);
            regateoView.UpdateDialogo(pedido);
            regateoView.UpdateOferta(nextOrder.offer);

            // TODO check if the order product and amount are available and activate the buttons accordingly
            PedidoOption();

            int currentPrice = nextOrder.GetPrice();

            int newPrice = currentPrice + (currentPrice * priceIncreasePercent / 100);
            regateoView.SetOptRegatearText("Subir precio a " + newPrice + "$");

            return States.Pedido;
        }

        else {
            return States.Despedida;
        }
    }

    
    private States Despedida() {
        DialogOption();
        regateoView.UpdateDialogo(regateoCharacter.GenerateDespedida());

        // TODO salir del regateo
        Debug.Log("Regateo over");

        return States.Despedida;
    }

    private void PedidoOption() {
        regateoView.SetOptRegatearActive(true);
        regateoView.SetOfertaActive(true);
        regateoView.SetComentarioActive(true);
        regateoView.SetOptNoActive(true);
        regateoView.SetOptSiActive(true);
        regateoView.SetSiguientePedidoActive(false);
    }

    private void DialogOption() {
        regateoView.SetOfertaActive(false);
        regateoView.SetComentarioActive(false);
        regateoView.SetOptRegatearActive(false);
        regateoView.SetOptNoActive(false);
        regateoView.SetOptSiActive(false);
        regateoView.SetSiguientePedidoActive(true);
    }

    // Decision Options ----------------
    private void AceptarOferta() {
        DialogOption();
        regateoView.UpdateDialogo(regateoCharacter.GenerateTrato());
    }

    private void RechazarOferta() {
        DialogOption();
        regateoView.UpdateDialogo(regateoCharacter.GenerateRechazo());
    }

    private void Regatear() {
        DialogOption();

        float tol = regateoCharacter.GetTolerance();
        Debug.Log("Tolerance: " + tol);
        //random from 1 to 100
        float random = Random.Range(1, 100);

        Debug.Log("Random num for tolerance: " + random);

        string mensaje = "";

        if(random <= tol) {
            // Regateo exitoso
            mensaje = regateoCharacter.GenerateTrato();
            // TODO decrease products, increase money
        }
        else {
            // Regateo fallido
            mensaje = regateoCharacter.GenerateMalTrato();
        }

        regateoView.UpdateDialogo(mensaje);
        
    }
    // -------------------------------

}
