using UnityEngine;

public class RainParticles : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    private void FixedUpdate()
    {
        transform.position = playerTransform.position;
    }
}
