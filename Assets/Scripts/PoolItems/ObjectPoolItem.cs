using System;
using UnityEngine;

namespace PoolItems
{
    public abstract class ObjectPoolItem : MonoBehaviour
    {
        public abstract void Release();
    }
}