using UnityEngine;

public class Cube : MonoBehaviour
{
    public void SetUpRigidbodyAtContact()
    {
        float xForce = 0;
        float yForce = 0;
        float zForce = 3000;

        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(new Vector3(xForce, yForce, zForce));
        rigidbody.isKinematic = false;
        rigidbody.constraints &= ~RigidbodyConstraints.FreezePositionY;
    }
}