using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gotolink : MonoBehaviour
{

    public string link;
    public void nav() {
        Application.OpenURL(link);
    }
}
