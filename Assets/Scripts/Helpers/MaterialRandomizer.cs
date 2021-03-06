﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]

public class MaterialRandomizer : MonoBehaviour {

	public Material[] materials;

	private Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponentInChildren<Renderer>();
		if (materials.Length > 0) {
//			var rand = Random.Range(0,7);
//			rend.material.color = colors[Random.Range(0,7)];
			Material material = materials[Random.Range(0,7)];
			rend.material = material;
		}
	}
}
