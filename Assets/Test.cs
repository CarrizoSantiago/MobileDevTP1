using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    /*
    const int constante = 5;
    static readonly Dictionary<int, string> dicConst = new Dictionary<int, string>()
    {
        {1, "asd"},
        {2, "asd"}
    };
    public void ClickAqui()
    {
        Debug.LogWarning("Clickeado");
    }

  #region Monobehaviour
    void Start()
    {
        
    }
    void Update()
    {
        Debug.LogWarning(Application.platform);
#if UNITY_ANDROID
    Debug.Log("Mensaje Android");
#elif UNITY_IPHONE
    Debug.Log("Mensaje IPHONE");
//#endif 
    }
    private void OnApplicationQuit()
    {
    }

    */
//#endregion
    public float speed = 3;
    public string player = "";
    // Start is called before the first frame update

    // Update is called once per frame
    private void Update()
    {
       transform.position += 
            speed * Time.deltaTime *
            new Vector3(InputManager.Instance.GetAxis("Horizontal"), 0, InputManager.Instance.GetAxis("Vertical"));
    }
}
