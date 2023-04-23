using System.Collections.Generic;
using UnityEngine;

public class Regateo2Controller : MonoBehaviour
{
    [SerializeField]
    private List<RegateoProduct> allProducts;

    [SerializeField]
    private List<RegateoCharacterSO> allCharacters; 

    private RegateoCharacterController regateoCC;

    // Regateo View
    private Regateo2View regateoView;

    private void Start() {
        // TODO evitar repetir personajes
        RegateoCharacterSO randomRegateoCharacter = allCharacters[Random.Range(0, allCharacters.Count)];

        RegateoCharacter regateoCharacter = RegateoCharacterFactory.CreateRegateoCharacter(randomRegateoCharacter, allProducts);

        regateoCC = new RegateoCharacterController(regateoCharacter);
    }

    private void FullIteration() {

        // Set greeting
        regateoCC.Greet();

        while(regateoCC.OrdersAvailable()) {
            
        }        

    }
}
