using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditor
{
    public enum ItemType
    {
        Background,
        Body,
        Accessory,
        Outwear,
        Beard,
        Glasses,
        HairStyle,
        Hat,
        Mask
    }

    public class CharacterManager
    {
        public static string directoryPath;
        private Random randomizer;
        private Dictionary<ItemType,List<string>> itemDictinary = new Dictionary<ItemType, List<string>>();
        private List<ItemType> notNullTypes = new List<ItemType>();

        public CharacterManager()
        {
            randomizer = new Random();

            AddNotNullTypes();
            LoadItemsByName();
        }

        private void AddNotNullTypes()
        {
            notNullTypes.Add(ItemType.Body);
            notNullTypes.Add(ItemType.Background);
            notNullTypes.Add(ItemType.HairStyle);
        }

        private void LoadItemsByName()
        {
            foreach (ItemType item in Enum.GetValues(typeof(ItemType)))
            {
                var itemList = Directory.GetFiles(directoryPath + $"/{item}").ToList();

                if (!notNullTypes.Contains(item))
                {
                    itemList.Add(null);
                }

                itemDictinary.Add(item, itemList);
            }
        }


        public Character GetRandomCharacter()
        {
            Character character = new Character();

            foreach (var item in itemDictinary)
            {
                var element = GetRandomItemByType(item.Key);
                if (element != null)
                {
                    character.AddElement(new KeyValuePair<ItemType, string>(item.Key, element));
                }
            }

            return character;
        }

        public string GetRandomItemByType(ItemType itemType)
        {
            var items = itemDictinary[itemType];
            var count = items.Count;
            return items[randomizer.Next(count)];
        }

    }
}
