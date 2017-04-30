using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteInfo {
	public string Name;
	public string TLE1;
	public string TLE2;
	public string Details;
}

public class Startup : MonoBehaviour {
	public GameObject SatellitePrefab;

	public List<SatelliteInfo> Satellites = new List<SatelliteInfo>() {
		new SatelliteInfo() {
			Name = "ISS",
			TLE1 = "1 25544U 98067A   17117.89041289 -.00158687  00000-0 -24621-2 0  9992",
			TLE2 = "2 25544  51.6432 289.0003 0006055 101.4704 344.3366 15.53834686 53936"
		},
		new SatelliteInfo() {
			Name = "LANDSAT 7",
			TLE1 = "1 25682U 99020A   17118.75230309  .00000051  00000-0  21321-4 0  9999",
			TLE2 = "2 25682  98.2153 190.5896 0001186  97.9604 262.1694 14.57106736959397"
		},
		new SatelliteInfo() {
			Name = "AQUA",
			TLE1 = " 27424U 02022A   17118.92920056  .00000140  00000-0  41123-4 0  9996",
			TLE2 = "2 27424  98.2013  60.9656 0000079  26.8795  23.5764 14.57120412797051"
		}
	};

	public double Long = -0.332794;
	public double Lat = 53.739141;
	public DateTime Time = new DateTime(2017, 5, 9, 3, 40, 0);

	private List<SatelliteLogic> satellites = new List<SatelliteLogic>();

	// Use this for initialization
	void Start () {
		/*
		foreach (var satellite in Satellites) {
			var gameObject = GameObject.Instantiate (SatellitePrefab);

			var logic = gameObject.GetComponent<SatelliteLogic> ();
			logic.SatelliteName = satellite.Name;
			logic.Time = Time;
			logic.Long = Long;
			logic.Lat = Lat;
			logic.TLE1 = satellite.TLE1;
			logic.TLE2 = satellite.TLE2;

			satellites.Add (logic);
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		foreach (var s in satellites) {
			s.Time = DateTime.Now;

		}
	}
}
