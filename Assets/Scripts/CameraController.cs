using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 cameraPositionOffset;
    [SerializeField] private Vector3 cameraRotationOffset;
    [SerializeField] private float smoothSpeed;

    private void Start() {
        transform.eulerAngles = cameraRotationOffset;
    }

    private void LateUpdate() {
        FollowPlayer();
    }

    //Kamera, Player'ı yumuşatılmış şekilde takip eder.
    private void FollowPlayer() {


        Vector3 desiredPosition = _player.position + cameraPositionOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }
}
