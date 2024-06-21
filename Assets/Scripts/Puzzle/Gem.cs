using UnityEngine;

public enum GemState { 
    REST,FOLLOW,HOLD
}
public class Gem : MonoBehaviour
{
    public GemState gs;
    public CheckDistanceWithOther cd;
    public float activationDistance;
    public Transform leader;
    public float followSharpness = 0.05f;
    public Vector2 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gs = GemState.REST;
    }

    // Update is called once per frame
    void Update()
    {
        switch (gs) {
            case GemState.REST:
                if (cd.getDistance() <= activationDistance) {
                    if (!cd.otherTransform.GetComponent<PlayerMovement>().hasGem)
                    {
                        leader = cd.otherTransform;
                        cd.otherTransform.GetComponent<PlayerMovement>().hasGem = true;
                        cd.otherTransform.GetComponent<PlayerMovement>().g = this;
                        gs = GemState.FOLLOW;
                    }
                }
                break;
            case GemState.FOLLOW:
                transform.position += ((leader.position+new Vector3(offset.x*((leader.GetComponent<PlayerMovement>().facingRight)?1:-1),offset.y,0) )- transform.position) * followSharpness;
                break;
            case GemState.HOLD:
                break;
            default:
                break;
        }
    }
}
