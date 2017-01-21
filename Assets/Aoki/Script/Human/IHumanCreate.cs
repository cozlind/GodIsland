using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHumanCreate {

    void Create(HumanStatus status1, HumanStatus status2, Vector3 position);
    void Create(HumanStatus status,Vector3 position);


}
