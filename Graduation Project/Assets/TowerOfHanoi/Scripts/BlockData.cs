using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TowerOfHanoi/Block", order = 1)]
public class BlockData : ScriptableObject
{
    public int size;
    public Color Color;

    [HideInInspector] public bool isOnAbove;
}
