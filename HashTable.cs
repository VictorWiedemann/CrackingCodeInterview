using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Channels;

namespace Merge_sort
{
    class HashTableasdf<K,V>
    {
        private const int HashSize = 1024;
        public LinkedListNode<V>[] Table { get; set; } = new LinkedListNode<V>[HashSize];  


        //public V GetValue(K Key)
        public int ComputedKey(K key)
        {
            return Math.Abs(key.GetHashCode() % HashSize );
        }

        public void PutValue(K key, V value)
        {
            int computedKey = ComputedKey(key);
            var newNode = new LinkedListNode<V>(value);
            var lastNode = Table[computedKey];

            while (lastNode.Next != null)
            {
                lastNode = lastNode.Next;
            }

            lastNode = lastNode.Next;
            lastNode = newNode;
        }





    }
}