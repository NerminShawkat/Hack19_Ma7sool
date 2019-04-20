using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntreristToggle : MonoBehaviour {
    [SerializeField]
    InteristToggleEvent _onInteristToggle;
    [SerializeField]
    int _id;

    public void ToggleInterist(bool enable)
    {
        _onInteristToggle.Invoke(_id, enable);
    }

}
[System.Serializable]
public class InteristToggleEvent : UnityEvent<int,bool>
{ }
