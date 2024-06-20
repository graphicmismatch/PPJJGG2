using UnityEngine;
using UnityEngine.Events;

public class WinTileManager : MonoBehaviour
{
    [SerializeField] private CheckDistanceWithOther checkDistanceWithCharacterA;
    [SerializeField] private CheckDistanceWithOther checkDistanceWithCharacterB;
    [SerializeField] private float activationDistance;

    public UnityEvent win;

    private void Update()
    {
        if (!(checkDistanceWithCharacterA.getDistance() < activationDistance)) return;
        if (!(checkDistanceWithCharacterB.getDistance() < activationDistance)) return;

        win.Invoke();

        Debug.Log("Win event!");

        enabled = false;
    }
}