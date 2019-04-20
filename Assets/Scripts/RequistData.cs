using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RequistData  {

    public string SenderId;
    public string RecieverId;
    public int price;
    public int Ammount;
    public int ItemId;
    public int Status; //0 started - 1 declined - 2 accepted
    public int Type; //0 sell - 1 buy

    public RequistData()
    {

    }
}
