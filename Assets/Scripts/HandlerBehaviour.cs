using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;

public class HandlerBehaviour : MonoBehaviour
{
    private float yRotation;

    [SerializeField]
    private float rotationLimit;

    private Rigidbody rb;

    void Start()
    {
        yRotation = -transform.localEulerAngles.y;

        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    public void OnSelectionEnter()
    {
        rb.isKinematic = false;
        StartCoroutine(WhileDrag());
    }

    public void OnSelectionExit()
    {
        rb.isKinematic = true;
        StopCoroutine(WhileDrag());
    }

    private float GetVolumeValueFromRotation()
    {
        float upperLimit = rotationLimit * 2;
        float normalizedRotation = (yRotation + rotationLimit) / upperLimit;
        if (normalizedRotation < 0) normalizedRotation = 0;
        else if (normalizedRotation > 1) normalizedRotation = 1;

        return normalizedRotation;
    }

    IEnumerator WhileDrag()
    {
        while (true)
        {
            yRotation = -transform.localEulerAngles.y;
            if (yRotation < -180) yRotation += 360;

            yield return new WaitForFixedUpdate();
        }
    }
}
