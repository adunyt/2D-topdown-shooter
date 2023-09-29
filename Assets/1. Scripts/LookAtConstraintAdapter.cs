using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(LookAtConstraint))]
public class LookAtConstraintAdapter : MonoBehaviour
{
    private LookAtConstraint lookAtConstraint;

    private void Awake()
    {
        lookAtConstraint = GetComponent<LookAtConstraint>();
    }

    public void AddSource(GameObject gameObject)
    {
        ClearSources();
        var source = new ConstraintSource
        {
            weight = 1,
            sourceTransform = gameObject.transform
        };
        lookAtConstraint.AddSource(source);
    }

    public void ClearSources()
    {
        for (int i = 0; i < lookAtConstraint.sourceCount; i++)
        {
            lookAtConstraint.RemoveSource(i);
        }
    }
}
