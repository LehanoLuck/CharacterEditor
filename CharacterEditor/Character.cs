using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditor
{
    public class Character
    {
        private Dictionary<ItemType, string> elements;

        public Character()
        {
            elements = new Dictionary<ItemType, string>();
        }

        public void AddElement(KeyValuePair<ItemType,string> element)
        {
            this.elements.Add(element.Key, element.Value);
        }

        public IEnumerable<string> GetElements()
        {
            return this.elements.Values;
        }
    }
}
