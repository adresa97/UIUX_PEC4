using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

public class HandlerXRTransformers : XRSingleGrabFreeTransformer
{
    [SerializeField]
    private Transform minSelector;

    [SerializeField]
    private Transform maxSelector;

    private Vector3 interPlanePosition;
    private Quaternion minSelectorDirection, maxSelectorDirection;
    private float minRotation, maxRotation;

    public override void OnLink(XRGrabInteractable grabInteractable)
    {
        base.OnLink(grabInteractable);

        Transform interTransform = grabInteractable.gameObject.transform;
        interPlanePosition = new Vector3(interTransform.position.x, 0, interTransform.position.z);

        Vector3 minSelectorPosition = new Vector3(minSelector.position.x, 0, minSelector.position.z);
        minSelectorDirection = Quaternion.LookRotation(Vector3.Normalize(interPlanePosition - minSelectorPosition));
        minRotation = -minSelectorDirection.eulerAngles.y;
        if (minRotation < -180) minRotation += 360;

        Vector3 maxSelectorPosition = new Vector3(maxSelector.position.x, 0, maxSelector.position.z);
        maxSelectorDirection = Quaternion.LookRotation(Vector3.Normalize(interPlanePosition - maxSelectorPosition));
        maxRotation = -maxSelectorDirection.eulerAngles.y;
        if (maxRotation < -180) maxRotation += 360;
    }

    public override void Process(XRGrabInteractable grabInteractable, XRInteractionUpdateOrder.UpdatePhase updatePhase, ref Pose targetPose, ref Vector3 localScale)
    {
        Transform handTransform = grabInteractable.GetOldestInteractorSelecting().transform;
        Vector3 handPlanePosition = new Vector3(handTransform.position.x, 0, handTransform.position.z);
        Quaternion toHandRotation = Quaternion.LookRotation(Vector3.Normalize(interPlanePosition - handPlanePosition));

        float yRotation = -toHandRotation.eulerAngles.y;
        if (yRotation < -180) yRotation += 360;

        if (yRotation > maxRotation)
        {
            targetPose.rotation = maxSelectorDirection;
        }
        else if (yRotation < minRotation)
        {
            targetPose.rotation = minSelectorDirection;
        }
        else
        {
            targetPose.rotation = toHandRotation;
        }
    }
}
