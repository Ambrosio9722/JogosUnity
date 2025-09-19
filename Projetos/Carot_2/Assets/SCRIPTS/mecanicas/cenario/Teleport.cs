using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform destino;

    public Transform GetDestination()
    {
        return destino;
    }
}
