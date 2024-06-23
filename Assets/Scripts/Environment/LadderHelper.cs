using UnityEngine;

public class LadderHelper : MonoBehaviour
{
    public BoxCollider2D coll;
    public SpriteRenderer spr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coll.size = spr.size;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
