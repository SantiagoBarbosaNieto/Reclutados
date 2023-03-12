using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogProgressionSO : ScriptableObject
{
    [SerializeField]
    public List<DialogSO> dialogProgression;

    [SerializeField]
    public AudioClip musicClip;
}
