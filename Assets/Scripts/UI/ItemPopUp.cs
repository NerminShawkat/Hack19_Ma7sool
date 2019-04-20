using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopUp : MonoBehaviour {
    public static ItemPopUp Instance;

    public Text Price;
    public Text Amount;
    public Image Image;

    public Text UserName;
    public Text Loaction;
    public Text Phone;

    public GameObject Connect;
    public GameObject Request;

    void Start () {
        if (Instance == null)
        {
            Instance = this;
            gameObject.SetActive(false);
        }
    }
	
	public void FillData(int type)
    {
        //request
        if (type == 0)
            Request.SetActive(true);
        else
            Connect.SetActive(false);
    }
}
