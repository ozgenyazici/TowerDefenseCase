using UnityEngine;
namespace TowerDefense
{
    public interface IMoveable
    {
        public int wayPointIndex { get; set; }
        public Transform target { get; set; }
    }
}