using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlacedTurret : MonoBehaviour
{
    public PlacedTurret(string turretId, GameObject turretPrefab, int turretPlacementId)
    {
        this.turretId = turretId;
        this.currentPlacedTurret = turretPrefab;
        this.turretPlacementId = turretPlacementId;
    }

    public string turretId;
    public GameObject currentPlacedTurret;
    public int turretPlacementId;

    public void setTurretId(string turretId)
    {
        this.turretId = turretId;
    }

    public string getTurretId()
    {
        return turretId;
    }

    public void setTurretPrefab(GameObject prefab)
    {
        this.currentPlacedTurret = prefab;
    }

    public GameObject getTurretPrefab()
    {
        return currentPlacedTurret;
    }

    public void setTurretPlacementId(int turretPlacementId)
    {
        this.turretPlacementId = turretPlacementId;
    }

    public int getTurretPlacementId()
    {
        return turretPlacementId;
    }

}