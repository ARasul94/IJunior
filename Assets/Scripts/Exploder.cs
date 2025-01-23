using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    
    public void Explode()
    {
        List<Rigidbody> rigidbodies = GetExplodableObjects(_explosionRadius);
        
        foreach (Rigidbody rigidbody in rigidbodies)
            rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }
    
    private List<Rigidbody> GetExplodableObjects(float radius)
    {
        IEnumerable<Collider> hits = Physics.OverlapSphere(transform.position, radius).Where(x => x.attachedRigidbody != null);

        List<Rigidbody> explodableObjects = new();

        foreach (Collider hit in hits)
            explodableObjects.Add(hit.attachedRigidbody);

        return explodableObjects;
    }
}