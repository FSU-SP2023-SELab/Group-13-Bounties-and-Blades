using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using BountiesAndBlades.BaseHero;
using BountiesAndBlades.CharacterItems;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<GameObject> Buttons1 = new List<GameObject>();
    public List<GameObject> Buttons2 = new List<GameObject>();
    public List<GameObject> Buttons3 = new List<GameObject>();
    public GameObject EquippedWeapon1;
    public GameObject EquippedWeapon2;
    public GameObject EquippedWeapon3;
    public GameObject EquippedArmor1;
    public GameObject EquippedArmor2;
    public GameObject EquippedArmor3;



    void Awake()
    {
        Instance = this;
    }

    public void setSprites()
    {
        int characterCounter = 0;
        for (int i = 0; i < UnitManager.clones.Count; i++)
        {
            BaseHero cloneScript = UnitManager.clones[i].GetComponent<BaseHero>();
            if (cloneScript.Faction != Faction.Hero)
            {
                continue;
            }

            var inventory = cloneScript.getInventory(); //go onto BaseHero and add a get Inventory method
            int inventorySize = inventory.Count; // this is how mant buttons you need to set
            var equippedWeapon = cloneScript.getEquippedWeapon();
            var equippedArmor = cloneScript.getEquippedArmor();

            if (characterCounter == 0)
            {
                //use Buttons1
                for (int j = 0; j < inventorySize; j++)
                {
                    CharacterItems CurrItem = inventory[j];
                    var button = Buttons1[j];
                    // Get the Image component from the button
                    Image image = button.GetComponent<Image>();
                    // Set the sprite of the image to the new image
                    if (inventory is null) { continue; }
                    image.sprite = CurrItem.sprite;
                }
                Image weaponImage = EquippedWeapon1.GetComponent<Image>();
                Image armorImage = EquippedArmor1.GetComponent<Image>();
                // Set the sprite of the image to the new image
                if (equippedWeapon != null)
                {
                    weaponImage.sprite = equippedWeapon.sprite; //however you get the image off the item in their inventory
                }
                if (equippedArmor != null)
                {
                    armorImage.sprite = equippedArmor.sprite;
                }

            }
            else if (characterCounter == 1)
            {
                //use buttons2
                for (int j = 0; j < inventorySize; j++)
                {
                    CharacterItems CurrItem = inventory[j];
                    var button = Buttons2[j];
                    // Get the Image component from the button
                    Image image = button.GetComponent<Image>();
                    // Set the sprite of the image to the new image
                    if (inventory is null) { continue; }
                    image.sprite = CurrItem.sprite;
                }
                Image weaponImage = EquippedWeapon2.GetComponent<Image>();
                Image armorImage = EquippedArmor2.GetComponent<Image>();
                // Set the sprite of the image to the new image
                if (equippedWeapon != null)
                {
                    weaponImage.sprite = equippedWeapon.sprite; //however you get the image off the item in their inventory
                }
                if (equippedArmor != null)
                {
                    armorImage.sprite = equippedArmor.sprite;
                }
            }
            else
            {
                //use buttons3
                for (int j = 0; j < inventorySize; j++)
                {
                    CharacterItems CurrItem = inventory[j];
                    var button = Buttons3[j];
                    // Get the Image component from the button
                    Image image = button.GetComponent<Image>();
                    // Set the sprite of the image to the new image
                    if (inventory is null) { continue; }
                    image.sprite = CurrItem.sprite;
                }
                Image weaponImage = EquippedWeapon3.GetComponent<Image>();
                Image armorImage = EquippedArmor3.GetComponent<Image>();
                // Set the sprite of the image to the new image
                if (equippedWeapon != null)
                {
                    weaponImage.sprite = equippedWeapon.sprite; //however you get the image off the item in their inventory
                }
                if (equippedArmor != null)
                {
                    armorImage.sprite = equippedArmor.sprite;
                }
            }

            characterCounter++;
        }
    }
}
