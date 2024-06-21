using UnityEngine;
using UnityEngine.Events;
public class GemHolder : MonoBehaviour
{

    public Transform finalPos;

    public CheckDistanceWithOther cd;
    public bool activated;
    public float activationDistance;
    public UnityEvent activate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cd.getDistance() <= activationDistance)
        {
            if (cd.otherTransform.GetComponent<PlayerMovement>().hasGem)
            {
                cd.otherTransform.GetComponent<PlayerMovement>().hasGem = false;
                Gem g = cd.otherTransform.GetComponent<PlayerMovement>().g;
                cd.otherTransform.GetComponent<PlayerMovement>().g = null;
                g.gs = GemState.HOLD;
                g.transform.position = finalPos.position;
                activated = true;
                activate.Invoke();
            }
        }
    }
}
