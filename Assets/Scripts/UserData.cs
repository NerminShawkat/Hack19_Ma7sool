using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Governrate
{
    Alexandria
    ,Ismailia 
    ,Aswan 
    ,Asyut 
    ,Luxor 
    ,RedSea 
    ,Beheira 
    ,BeniSuef 
    ,PortSaid
    ,SouthSinai 
    ,Giza 
    ,Dakahlia 
    ,Damietta 
    ,Sohag 
    ,Suez 
    ,Sharqia 
    ,NorthSinai 
    ,Gharbia 
    ,Faiyum 
    ,Cairo 
    ,Qalyubia 
    ,KafrElSheikh 
    ,Matruh 
    ,Monufia 
    ,Minya 
    ,Qena 
    ,NewValley 
}
[System.Serializable]
public class UserData
{
    public string PhoneNumber;
    public string Name;
    public int Governrate;
    public List<string> Requests;
    public List<int> Interists;
    public int Rate;

    public UserData()
    {

    }

    public UserData(string phone, string name, int rate, int governrate, List<string> requests, List<int> interists)
    {
        PhoneNumber = phone;
        Name = name;
        Governrate = governrate;
        Requests = requests;
        Interists = interists;
        Rate = rate;
    }

}
