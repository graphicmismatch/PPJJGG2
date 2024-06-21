using UnityEngine;
using UnityEngine.Events;
public class Laser : MonoBehaviour
{
    public Transform endpoint;
    public LineRenderer lr;
    public bool activated;

    public float lineWidth;
    public Color lineColor;
    public Material mat;
    
    public UnityEvent hit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hit.AddListener(PlayerManager.Dead);
        lr.useWorldSpace = false;
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
        lr.SetPosition(1, endpoint.transform.position);
        if (activated) {
            RaycastHit2D[] rh = Physics2D.LinecastAll(transform.position, endpoint.transform.position, 1 << 7);
            if (rh.Length > 0) {
                hit.Invoke();
            }
        }
    }

    public void deactivate() {
        activated = false;
        lr.enabled = false;
    }

    public void toggle(bool s)
    {
        activated = s;
        lr.enabled = s;
    }
}
