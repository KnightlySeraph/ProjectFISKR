using System.Collections;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {
    public Light sun;
    public float secondsInFullDayNight = 120f; // 2 min default?
    [Range(0, 24)] //24 hour cycle to make it simpler to think on
    public float currentTime = 0;
    float lightIntensity, intensityMultiplier = 1;
    const int sunYOffsetToMakeShadowsMoreDynamic = -30;
    const float sunriseStartTime = 6f,
        sunsetStartTime = 17.5f;

    void Start() {
        lightIntensity = sun.intensity;
    }

    void Update() {
        UpdateSun();
        //Update our time of day based off delta time multiplied by our 24 hour cycle...and our seconds will be the 
        //real thing that determines how long this will be
        currentTime += ((Time.deltaTime * 24f) / secondsInFullDayNight);

        if (currentTime >= 24) { //Reset time to 0 when we hit our upper limit
            currentTime = 0;
        }
    }

    void UpdateSun() { //Rotate our (sun) based off the time of day X                      Y                      Z
        //For our day night, the X we multiply the current time by 15f (360degrees/our 24 hour time=15f)-90degrees (Will make it rise/set off the direct horizon, but close enough to to seem realistic)
        sun.transform.localRotation = Quaternion.Euler((currentTime * 15f) - 90, sunYOffsetToMakeShadowsMoreDynamic, 0);

        intensityMultiplier = 1;
        if (currentTime <= sunriseStartTime) { //Before 5:30, sunrise
            intensityMultiplier = Mathf.Clamp01(currentTime - sunriseStartTime);
        } else if (currentTime >= sunsetStartTime) { //After 18:00, sunset
            intensityMultiplier = Mathf.Clamp01(1 - (currentTime - sunsetStartTime));
        }

        sun.intensity = lightIntensity * intensityMultiplier;
    }
}