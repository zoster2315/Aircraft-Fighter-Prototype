using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip("How fast ship moves up, dows, left, right based upon player input")]
    [SerializeField] float moveSpeed = 20f;
    [Tooltip("How far player moves horizontally")]
    [SerializeField] float xRange = 15f;
    [Tooltip("How far player moves vartivcally")]
    [SerializeField] float yRange = 9f;

    [Header("Laser gun array")]
    [Tooltip("Add all player lasers here")]
    [SerializeField] ParticleSystem[] guns;

    [Header("Screen position based tuning")]
    [SerializeField] float postitionPitchFactor = -2f;
    [SerializeField] float positionYawFactor = 2f;

    [Header("Player input based tuning")]
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float controlRollFactor = -30f;


    float yThrow;
    float xThrow;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    private void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float rawXPos = transform.localPosition.x + xThrow * moveSpeed * Time.deltaTime;
        float xPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float rawYPos = transform.localPosition.y + yThrow * moveSpeed * Time.deltaTime;
        float yPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * postitionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
            SetGunsActive(true);
        else
            SetGunsActive(false);
    }

    private void SetGunsActive(bool isActive)
    {
        foreach (ParticleSystem gun in guns)
        {
            var emission = gun.emission;
            emission.enabled = isActive;
        }
    }
}
