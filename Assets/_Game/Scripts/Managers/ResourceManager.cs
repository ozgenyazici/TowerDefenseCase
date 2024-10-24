using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class ResourceManager
    {
        public T Load<T>(string path) where T : Object
        {
          
            return Resources.Load<T>(path);
        }

        public GameObject Instantiate(string path, Transform parent = null)
        {
            GameObject original = Load<GameObject>($"Prefabs/{path}");
            if (original == null)
            {
                Debug.Log($"Faild to load prefab : {path}");
                return null;
            }


            if (original.GetComponent<Poolable>() != null)
                return Managers.Pool.Pop(original, parent).gameObject;


            GameObject go = Object.Instantiate(original, parent);
            go.name = original.name;

            return go;
        }
        public GameObject Instantiate(string path, Vector3 position, Transform parent = null)
        {
            GameObject original = Load<GameObject>($"Prefabs/{path}");
            if (original == null)
            {
                Debug.Log($"Faild to load prefab : {path}");
                return null;
            }


            if (original.GetComponent<Poolable>() != null)
                return Managers.Pool.Pop(original, parent).gameObject;


            GameObject go = Object.Instantiate(original, position, Quaternion.identity, parent);
            go.name = original.name;

            return go;
        }

        public void Destroy(GameObject obj, float time = 0)
        {
            if (obj == null)
            {
                return;
            }


            Poolable poolable = obj.GetComponent<Poolable>();
            if (poolable != null)
            {
                Managers.Pool.Push(poolable, time);
                return;
            }

            Object.Destroy(obj, time);
        }

    }
}
