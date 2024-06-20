using UnityEngine;

public class MovableBlockReflection : MonoBehaviour
{
    [SerializeField] private Transform sourceBlockTransform;

    private void Update()
    {
        var currentPosition = transform.position;
        var newTransform = new Vector3(sourceBlockTransform.position.x, currentPosition.y, currentPosition.z);

        transform.position = newTransform;
    }
}