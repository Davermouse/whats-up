using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using HoloToolkit.Unity.InputModule;

using Zeptomoby.OrbitTools;

public class SatelliteLogic : MonoBehaviour, IFocusable {
	public const double RadsPerDegree = Math.PI / 180.0;
	public const double DegreesPerRad = (double)180 / Math.PI;

	public GameObject labelPrefab;

	public DateTime Time = DateTime.Now;
	public string SatelliteName;
	public string TLE1;
	public string TLE2;

	public string ModelName = "Models/Landsat7";

	public double Long;
	public double Lat;
	public double Altitude;

	public Text mainLabel;

	private GameObject model;

	private Tle _tle;
	private Satellite _satellite;
	private Site _site;
	private GameObject _detailsCanvas;
	private bool isFocused;

	// Use this for initialization
	void Start () {
		this._tle = new Tle ("sat", TLE1, TLE2);
		this._satellite = new Satellite (_tle);
		this._site = new Site(Lat, Long, Altitude);
		this._detailsCanvas = this.transform.Find ("detailsCanvas").gameObject;
			
		mainLabel.text = SatelliteName;
	}
	
	// Update is called once per frame
	void Update () {
		if (_satellite == null)
			return;
		
		var time = _satellite.PositionEci(DateTime.Now);
		var look = _site.GetLookAngle(time);

		var azimuth = (float)(DegreesPerRad * look.AzimuthRad);
		var elevation = (float)(DegreesPerRad * look.ElevationRad);

	//	Debug.Log(string.Format("A:{0}, E:{1}", look.AzimuthDeg, look.ElevationDeg));
			
		var rot = Quaternion.Euler (
			new Vector3 (0, azimuth, elevation));

		this.gameObject.transform.rotation = rot;
        this.gameObject.transform.position = Camera.main.transform.position;
	}

	public void OnFocusEnter() {
		this.isFocused = true;
	}

	public void OnFocusExit() {
		this.isFocused = false;
	}
}
