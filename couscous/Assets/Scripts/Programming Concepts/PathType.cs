using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PATH_TYPES { WALK, WALL, PHASE, HOLE };

public class PathType : MonoBehaviour {

    public PATH_TYPES object_type;

    PATH_TYPES getType()
    {
        return object_type;
    }

    void setType(PATH_TYPES type)
    {
        this.object_type = type;
    }
}
