namespace BountiesAndBlades.InventorySystem
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using BountiesAndBlades.BaseHero;
    using BountiesAndBlades.CharacterItems;
    using BountiesAndBlades.CharacterClass;



    public class InventorySystem : MonoBehaviour
    {
        public List<CharacterItems> items = new List<CharacterItems>();

        public virtual void RemoveItem(CharacterItems item)
        {
            items.Remove(item);
        }

        public virtual void EquipItem(CharacterItems item)
        {

        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
