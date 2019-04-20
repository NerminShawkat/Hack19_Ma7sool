using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellingItem : MonoBehaviour {

    public Text Price;
    public Text Amount;

    public Image Image;
	public void OnItemSelect(int type)
    {
        //ItemPopUp.Instance.
        ItemPopUp.Instance.Price.text = Price.text;
        ItemPopUp.Instance.Amount.text = Amount.text;
        ItemPopUp.Instance.Image.sprite = Image.sprite;
        ItemPopUp.Instance.UserName.text = ArabicSupport.ArabicFixer.Fix(" الأسم : محمود عبد المجيد");
        ItemPopUp.Instance.Loaction.text = ArabicSupport.ArabicFixer.Fix("المحافظة : سوهاج");
        ItemPopUp.Instance.Phone.text = ArabicSupport.ArabicFixer.Fix("التليفون: 01255486325");
        ItemPopUp.Instance.FillData(Random.Range(0, 1));
        ItemPopUp.Instance.gameObject.SetActive(true);

    }
}
