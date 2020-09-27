using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    static UIManager _instance = null;
    const int POOL_SIZE = 20;
    List<GameObject> pool = null;
    [SerializeField] GameObject popupPrefab = null;
    public static UIManager GetInstance() {
        if (_instance == null)
        {
            _instance = FindObjectOfType<UIManager>();
        }
        return _instance;
    }

    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
    private void Start()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < POOL_SIZE; i++ )
        {
            InstanciteNewPopup();
        }
    }
    GameObject InstanciteNewPopup()
    {
        GameObject popUp = Instantiate<GameObject>(popupPrefab, transform);
        popUp.SetActive(false);
        pool.Add(popUp);
        return popUp;
    }
    public GameObject GetPopUp()
    {
        foreach (var obj in pool)
        {
            if (!obj.activeSelf)
            {
                obj.SetActive(true);
                return obj;
            }

        }
        GameObject popUp = InstanciteNewPopup();
        popUp.SetActive(true);
        return null;
       
    }
    public void ReturnPopup(GameObject popUp)
    {
        popUp.SetActive(false);
    }
}
