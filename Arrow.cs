﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

      private void OnTriggerEnter(Collider other)
      {
            Destroy(this.gameObject);
      }

}
