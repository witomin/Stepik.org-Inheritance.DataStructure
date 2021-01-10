using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.DataStructure
{
    public class Category : IComparable
    {
        public string Name { get; private set; }
        public MessageType MessageType { get; private set; }
        public MessageTopic MessageTopic { get; private set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Category Cat = obj as Category;
            if (Cat == null) throw new ArgumentException("Object is not a Category");


            if (string.Compare(Name, Cat.Name) != 0) return string.Compare(Name, Cat.Name);
            if (MessageType < Cat.MessageType) return -1;
            else if (MessageType > Cat.MessageType) return 1;
            if (MessageTopic < Cat.MessageTopic) return -1;
            else if (MessageTopic > Cat.MessageTopic) return 1;
            return 0;
        }

        public override bool Equals(object obj)
        {
            return obj is Category category &&
                   Name == category.Name &&
                   MessageType == category.MessageType &&
                   MessageTopic == category.MessageTopic;
        }

        public override int GetHashCode()
        {
            int hashCode = 369389661;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + MessageType.GetHashCode();
            hashCode = hashCode * -1521134295 + MessageTopic.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "A.Incoming.Subscribe";
        }

        public Category(string Name, MessageType MessageType, MessageTopic MessageTopic)
        {
            this.Name = Name;
            this.MessageType = MessageType;
            this.MessageTopic = MessageTopic;
        }

        public static bool operator <=(Category x, Category y)
        {
            if (x.CompareTo(y) == -1 || x.CompareTo(y) == 0) return true;
            else return false;
        }
        public static bool operator >=(Category x, Category y)
        {
            if (x.CompareTo(y) == 1 || x.CompareTo(y) == 0) return true;
            else return false;
        }
        public static bool operator <(Category x, Category y)
        {
            if (x.CompareTo(y) == -1) return true;
            else return false;
        }
        public static bool operator >(Category x, Category y)
        {
            if (x.CompareTo(y) == 1) return true;
            else return false;
        }
    }

    
}
