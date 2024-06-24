using UnityEngine;
using UnityEngine.Events;
public class Laser : MonoBehaviour
{
    public Transform endpoint;
    public LineRenderer lr;
    public bool activated;
    private Vector3 raypoint;
    public float lineWidth;
    public Color lineColor;
    public Material mat;
    public LayerMask grnd;
    public LayerMask player;
    public UnityEvent hit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        raypoint = endpoint.position;
        hit.AddListener(PlayerManager.Dead);
        lr.useWorldSpace = true;
        lr.startWidth = lineWidth;
        lr.endWidth = lineWidth;
        lr.material = mat;
        lr.startColor = lineColor;
        lr.endColor = lineColor;
        lr.positionCount = 2;
        lr.SetPosition(0, this.transform.position);
        lr.SetPosition(1, endpoint.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, this.transform.position);
        
        if (activated) {
            RaycastHit2D[] rh = Physics2D.LinecastAll(transform.position, endpoint.transform.position,grnd|player);
            raypoint = endpoint.position;
            if (rh.Length>0) {
                
                if (IsInLayerMask(rh[0].transform.gameObject, grnd))
                {
                    raypoint = new Vector3(rh[0].point.x,rh[0].point.y,raypoint.z);
                }
                else
                {
                    hit.Invoke();
                }
            }

            
        }
        lr.SetPosition(1, raypoint);
    }

    public void deactivate() {
        activated = false;
        lr.enabled = false;
    }

    public void invert()
    {
        activated = !activated;
        lr.enabled = !lr.enabled;
    }

    public void toggle(bool s)
    {
        activated = s;
        lr.enabled = s;
    }
    public static bool IsInLayerMask(GameObject obj, LayerMask mask) => (mask.value & (1 << obj.layer)) != 0;
}
