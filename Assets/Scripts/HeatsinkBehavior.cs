using UnityEngine;

public class HeatsinkBehavior  {

    public float sink = 1.0f;

    private float nextSink = 0.0f;
    private float rate = 0.0f;

    public HeatsinkBehavior(float rate) {
        this.rate = rate;
    }

    public float Sink() {
        if (Time.time < nextSink) {
            return -1;
        }

        nextSink = Time.time + rate;
        return sink;
    }
}
