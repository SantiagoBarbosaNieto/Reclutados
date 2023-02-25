using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class DialogPanelSO : ScriptableObject
{
    [SerializeField]
    public Sprite background;   

    [SerializeField]
    public TextAsset inkText;

    [SerializeField]
    public Sprite character1;

    [SerializeField]
    public Sprite character2;
    
    [SerializeField]
    public Sprite characterSingle;
    
}
