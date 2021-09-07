using NaughtyAttributes;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
	[System.NonSerialized] [ShowNonSerializedField] public int Score = 0;
}
