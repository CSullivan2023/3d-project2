using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class cameracontrolls : MonoBehaviour
{
    public CharacterMovement player;
    private float sensitvity = 500f;
    private float clampAngle = 85f;

    private float verticalRotation;
    private float horizontalRotation;
    // Start is called before the first frame update
    private void Start()
    {
        this.verticalRotation = this.transform.localEulerAngles.x;
        this.horizontalRotation = this.transform.eulerAngles.y;
    }

    // Update is called once per frame
    private void Update()
    {
        look();
        Debug.DrawRay(this.transform.position, this.transform.forward * 2);
    }

    private void look()
    {
        float mouseVertical = -Input.GetAxis("Mouse Y");
        float mouseHorizontal = Input.GetAxis("Mouse X");

        this.verticalRotation += mouseVertical * sensitvity * Time.deltaTime;
        this.horizontalRotation += mouseHorizontal * sensitvity * Time.deltaTime;

        this.verticalRotation = Mathf.Clamp(this.verticalRotation, -this.clampAngle, this.clampAngle);

        this.transform.localRotation = Quaternion.Euler(this.verticalRotation, 0f, 0f);
        this.player.transform.rotation = Quaternion.Euler(0f, this.horizontalRotation, 0f);
    }
}
