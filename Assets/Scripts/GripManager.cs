using UnityEngine;
using System.Collections;

public class GripManager : MonoBehaviour {

    public Rigidbody Body;

    public Pull left, right;

    void FixedUpdate() {
        var lDevice = SteamVR_Controller.Input((int)left.controller.index);
        var rDevice = SteamVR_Controller.Input((int)right.controller.index);

        bool isGripped = left.canGrip || right.canGrip;

        if (isGripped) {
            if (left.canGrip && lDevice.GetTouch(SteamVR_Controller.ButtonMask.Grip)) {
                Body.useGravity = false;
                Body.isKinematic = true;
                Body.transform.position += (left.prevPos - left.transform.localPosition);
            } else if (left.canGrip && lDevice.GetTouchUp(SteamVR_Controller.ButtonMask.Grip)) {
                Body.useGravity = true;
                Body.isKinematic = false;
                Body.velocity = (left.prevPos - left.transform.localPosition) / Time.deltaTime;
            }

            if (right.canGrip && rDevice.GetTouch(SteamVR_Controller.ButtonMask.Grip)) {
                Body.useGravity = false;
                Body.isKinematic = true;
                Body.transform.position += (right.prevPos - right.transform.localPosition);
            } else if (right.canGrip && rDevice.GetTouchUp(SteamVR_Controller.ButtonMask.Grip)) {
                Body.useGravity = true;
                Body.isKinematic = false;
                Body.velocity = (right.prevPos - right.transform.localPosition) / Time.deltaTime;
            }
        } else {
            Body.useGravity = true;
            Body.isKinematic = false;
        }
        

        left.prevPos = left.controller.transform.localPosition;
        right.prevPos = right.controller.transform.localPosition;
    }
}
