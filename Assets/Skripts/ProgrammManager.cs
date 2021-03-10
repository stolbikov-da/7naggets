using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ProgrammManager : MonoBehaviour
{
    [Header("Put your planeMarker here")]
    [SerializeField] private GameObject PlaneMarkerPrefab;

    private ARRaycastManager ARRaycastManagerScript;

    private Vector2 TouchPosition;

    public GameObject ObjectToSpawn;

    void Start()
    {
        ARRaycastManagerScript = FindObjectOfType<ARRaycastManager>();

        PlaneMarkerPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //ShowMarker();
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            Touch touch = Input.GetTouch(0);
            TouchPosition = touch.position;

            ARRaycastManagerScript.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

            Instantiate(ObjectToSpawn, hits[0].pose.position, ObjectToSpawn.transform.rotation);
        }
    }

    void ShowMarker()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        ARRaycastManagerScript.Raycast(TouchPosition, hits, TrackableType.Planes);



        if (hits.Count > 0)
        {
            PlaneMarkerPrefab.transform.position = hits[0].pose.position;
            PlaneMarkerPrefab.SetActive(true);
        }
    }
}
