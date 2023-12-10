using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject volcanoExplosion, ship, shipClouds, meteorStart, rain, regrowth;

    public void Start()
    {
        //Controls the order of events that happen in the scene
        StartCoroutine(OrderOfEvents());
    }

    public IEnumerator OrderOfEvents()
    {
        //Volcano Explosion
        yield return new WaitForSeconds(5);
        CameraShake.isShaking = true;

        yield return new WaitForSeconds(5);
        volcanoExplosion.SetActive(true);

        yield return new WaitForSeconds(10);
        CameraShake.isShaking = false;

        //Ship Take-off
        shipClouds.SetActive(true);

        yield return new WaitForSeconds(18);
        ship.GetComponent<Rotation>().startTime = Time.time;
        ship.GetComponent<Rotation>().enabled = true;
        ship.GetComponent<ShipMovement>().enabled = true;

        //Meteor activated 
        yield return new WaitForSeconds(10);
        meteorStart.SetActive(true);

        //Rain and clouds activated
        yield return new WaitForSeconds(25);
        rain.SetActive(true);

        //Plants that wil grow over time activated
        yield return new WaitForSeconds(25);
        regrowth.SetActive(true);
    }
}
