﻿using System;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour {

    [SerializeField] private LayerMask ignoredLayers;
    [SerializeField] private float laserWidth;
    [SerializeField] private int dps;

    private LineRenderer laserLine;
    private float lastHit;

    private void Start() {
        ignoredLayers = ~ignoredLayers;

        laserLine = GetComponent<LineRenderer>();
        laserLine.startWidth = laserWidth;
        laserLine.endWidth = laserWidth;
    }

    private void Update() {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -transform.right, out hit, Mathf.Infinity, ignoredLayers)) {
            Entity entityScript = hit.transform.root.GetComponent<Entity>();
            if (entityScript != null && Time.time > lastHit + 1f) {
                entityScript.TakeDamage(dps, -1);
                lastHit = Time.time;
            }
            DrawLaser(hit.point, true);
        } else {
            DrawLaser(-transform.right * 100f, false);
        }
    }

    private void DrawLaser(Vector3 laserEnd, bool showSpark) {
        laserLine.SetPosition(0, transform.position);
        laserLine.SetPosition(1, laserEnd);
    }

}