﻿using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {

	public static int wave;
	public static int objective01;
	public static int objective02;
	public static bool bossWave;

	public static void setWave(bool value){
		bossWave = value;
	}

	public static bool getWave(){
		return bossWave;
	}
}
