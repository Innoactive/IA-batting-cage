using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShooter {
    void Shoot(GameObject ball, Transform ballSpawnPosition);
}
