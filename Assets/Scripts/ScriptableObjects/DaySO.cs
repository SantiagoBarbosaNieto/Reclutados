using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDay", menuName = "Scriptable Objects/Day")]
public class DaySO : ScriptableObject
{
    public int number;
    public List<LoadDialogSceneRequest> greeting;

    public LoadSceneRequest level;

    public List<LoadDialogSceneRequest> sales;

    [HideInInspector]
    public LoadSceneRequest regateo;

    public List<LoadDialogSceneRequest> dayEnd;

    public LoadSceneRequest transition;


    //Desde aca los cambios
    public bool isEnding;

    public List<RegateoCharacterSO> regateoDayCharacters;
    
}
