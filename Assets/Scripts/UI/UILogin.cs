using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILogin : MonoBehaviour {
    [SerializeField]
    GameObject _registerWindow;
    [SerializeField]
    GameObject _verificationWindow;
    [SerializeField]
    GameObject _userDataWindow;


	public string Name
    {
        get;
        set;
    }

    public string Code
    {
        get;
        set;
    }

    public string PhoneNumber
    {
        get;
        set;
    }

    public int Governrate
    {
        get;
        set;
    }


    List<int> _interists = new List<int>();


    private void Awake()
    {
        if(string.IsNullOrEmpty(PlayerPrefs.GetString("PhoneNumber")))
        {
            _registerWindow.SetActive(true);
        }
        else
        {
            PhoneNumber = PlayerPrefs.GetString("PhoneNumber");
            Register();
        }
    }

    public void Register()
    {
        
        Authentication.Register("+2" + PhoneNumber, success =>
        {
            if(success.Success)
            {
                if(!Authentication.IsLoggedIn)
                {
                    //_registerWindow.SetActive(false);
                    _verificationWindow.SetActive(true);
                }
                else
                {

                    PlayerPrefs.SetString("PhoneNumber", PhoneNumber);
                    SceneManager.LoadScene(1);
                }
            }
        });
    }

    public void Verify()
    {
        Authentication.Verify(Code, success =>
        {
            if(success.Success)
            {
                _verificationWindow.SetActive(false);
                _userDataWindow.SetActive(true);
                PlayerPrefs.SetString("PhoneNumber", PhoneNumber);
            }
        });
    }


    public void OnInteristToggled(int id, bool isAdd)
    {
        if(isAdd)
        {
            _interists.Add(id);
        }
        else
        {
            _interists.Remove(id);
        }
    }

    public void SaveUserData()
    {
        //-1 means not rated
        Authentication.InitializeUse(new UserData(PhoneNumber, Name, -1, Governrate, null, _interists), success =>
        {
            // here open game
            PlayerPrefs.SetString("PhoneNumber", PhoneNumber);
            SceneManager.LoadScene(1);
        });
    }

}
