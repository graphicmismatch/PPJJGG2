using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerManager : MonoBehaviour
{


    public PlayerMovement playerA;
    public PlayerMovement playerB;
    public Transform playerAinit;
    public Transform playerBinit;

    public float playerAcamZ;
    public float playerBcamZ;

    public bool onPlayerA;
    bool inputlatch;
    public float followSharpness;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputlatch = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (onPlayerA)
        {
            transform.position += (new Vector3(playerA.transform.position.x, 0, playerAcamZ) - transform.position) * followSharpness;
        }
        else {
            transform.position += (new Vector3(playerB.transform.position.x, 0, playerBcamZ) - transform.position) * followSharpness;
        }
    }
    public static void Dead() { 
    
    }

    public void switchPlayer(InputAction.CallbackContext ctx) {
        if (ctx.ReadValueAsButton() && inputlatch)
        {
            onPlayerA = !onPlayerA;

            playerA.isActive = onPlayerA;
            playerB.isActive = !onPlayerA;

            if (onPlayerA)
            {
                this.transform.position = new Vector3(playerA.transform.position.x, 0, playerAcamZ);
            }
            else
            {
                this.transform.position = new Vector3(playerB.transform.position.x, 0, playerBcamZ);
            }
            inputlatch = false;
        }
        else if (!ctx.ReadValueAsButton()) {
            inputlatch = true;
        }
    }
}
