using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int shopID;
    public int itemCost;
    public Image profil;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Purchase()
    {
        bool buying = FindObjectOfType<Player>().exchangeMoney(shopID, itemCost);
        if (buying)
        {
            Bought();
        }
    }

    public void Bought()
    {
        Color newColor = profil.color;
        newColor.a = 0.5f;
        profil.color = newColor;

        Destroy(this.gameObject);
    }
}
