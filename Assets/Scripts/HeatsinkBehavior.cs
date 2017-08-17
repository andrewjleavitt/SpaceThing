using UnityEngine;

public class HeatsinkBehavior : MonoBehaviour {

    public float sinkRate = 0.0f;
    public float sink = 0.0f;

    private float nextSink = 0.0f;

    public float Sink() {
        if (Time.time < nextSink) {
            return -1;
        }

        nextSink = Time.time + sinkRate;
        return sink;
    }
}
