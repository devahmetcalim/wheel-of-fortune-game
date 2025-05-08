using System.Collections.Generic;
using UnityEngine;

namespace Game.Systems.Pooling
{
    public class ObjectPool<T> where T : Component
    {
        private readonly T prefab;
        private readonly Transform parent;
        private readonly Queue<T> pool = new();

        public ObjectPool(T prefab, int initialSize, Transform parent = null)
        {
            this.prefab = prefab;
            this.parent = parent;

            for (int i = 0; i < initialSize; i++)
            {
                var obj = Object.Instantiate(prefab, parent);
                obj.gameObject.SetActive(false);
                pool.Enqueue(obj);
            }
        }

        public T Get()
        {
            if (pool.Count > 0)
            {
                var obj = pool.Dequeue();
                obj.gameObject.SetActive(true);
                return obj;
            }
            else
            {
                var newObj = Object.Instantiate(prefab, parent);
                return newObj;
            }
        }

        public void Return(T obj)
        {
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }

        public void Clear()
        {
            foreach (var obj in pool)
            {
                Object.Destroy(obj.gameObject);
            }
            pool.Clear();
        }
    }
}