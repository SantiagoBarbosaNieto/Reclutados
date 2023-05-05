using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

// TODO Big refactor was necessary. Check if everythin works well.
public class Regateo2Controller : MonoBehaviour
{

    //This list should be generated from a global list of products
    private List<RegateoProduct> allProducts = new List<RegateoProduct>();

    [SerializeField]
    private GameEvent advanceDayRequest;

    [SerializeField]
    private AddMoneyGameEvent addMoneyGameEvent;

    [SerializeField]
    private IntGameEvent decreaseBackpackItemEvent;

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

    private RegateoOrder currentOffer;
    private float currentOfferRegateoPrice;

    [SerializeField]
    private AudioClip regateoAudio;

    private void Start()
    {
        if(AudioManager.Instance != null && regateoAudio != null) {
            AudioManager.Instance.PlaySoundLooped(regateoAudio);
        }
        regateoView.GetSiguientePedidoEvent().AddListener(UpdateStateSiguiente);
        regateoView.GetOptRegatearEvent().AddListener(Regatear);
        regateoView.GetOptSiEvent().AddListener(AceptarOferta);
        regateoView.GetOptNoEvent().AddListener(RechazarOferta);

        // Sets the current available characters and products from the GameStateManager
        if(GameStateManager.Instance != null) {
            allProducts = GameStateManager.Instance.GetAllProducts();
            currentAvailableCharacters = new List<RegateoCharacterSO>(GameStateManager.Instance.GetCurrentDayCharacters());
            Debug.Log("Loaded " + currentAvailableCharacters.Count + " characters for this day");
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
            //TODO find a way to advance the day.
                if(AudioManager.Instance != null && regateoAudio != null) {
                    AudioManager.Instance.StopSound();
                }
                advanceDayRequest.Raise();
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
            currentOffer = regateoCharacter.orders[0];
            regateoCharacter.RemoveOrder(currentOffer);

            // Check if there is enough stock for the order.
            List<RegateoInventoryProduct> inventoryProducts = GameStateManager.Instance._backpack._items;

            //Get the quantity of the inventoryProduct that has a regateoProduct equal to nextOrder.product
            int inventoryQuantity = inventoryProducts.Find(x => x.regateoProduct == currentOffer.product).quantity;

            Debug.Log("Inventory Quantity for this pedido: " + inventoryQuantity);

            string pedido = regateoCharacter.GeneratePedido(currentOffer);
            regateoView.UpdateDialogo(pedido);

            PedidoOption();

            if(inventoryQuantity == 0) {
                Debug.Log("No hay inventario en la mochila para este pedido");

                regateoView.SetOptNoText("No me queda");
                regateoView.SetOptRegatearActive(false);
                regateoView.SetOptSiActive(false);
            }

            else if(inventoryQuantity < currentOffer.amount) {
                Debug.Log("No hay suficiente inventario en la mochila para este pedido");
                regateoView.SetOptRegatearActive(false);

                // Ofrece solo la cantidad que hay en el inventario. Actualiza la oferta
                currentOffer = new RegateoOrder(currentOffer.product, inventoryQuantity);

                regateoView.UpdateOferta(currentOffer.offer);
            }

            else {
                int currentPrice = currentOffer.GetPrice();
                int newPrice = currentPrice + (currentPrice * priceIncreasePercent / 100);
                currentOfferRegateoPrice = newPrice;
                regateoView.SetOptRegatearText("Subir precio a " + newPrice + "$");
            }

            
            regateoView.UpdateOferta(currentOffer.offer);

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
        regateoView.SetOptNoText("No");
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
        AddMoney eventInfo = new AddMoney(currentOffer.GetPrice(), "Se vendio " + currentOffer.amount + " " + currentOffer.product.name + " a " + currentOffer.GetPrice() + "$", true);
        addMoneyGameEvent.Raise(eventInfo);
        for (int i = 0; i < currentOffer.amount; i++)
            decreaseBackpackItemEvent.Raise(currentOffer.product.id);
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
            AddMoney eventInfo = new AddMoney(currentOffer.GetPrice(), "Se vendio " + currentOffer.amount + " " + currentOffer.product.name + " a " + currentOfferRegateoPrice + "$", true);
            addMoneyGameEvent.Raise(eventInfo);
            for (int i = 0; i < currentOffer.amount; i++)
                decreaseBackpackItemEvent.Raise(currentOffer.product.id);
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
