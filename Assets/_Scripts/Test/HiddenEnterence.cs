using UnityEngine;

namespace TestCode
{
    public class HiddenEnterence : ObjectColor
    {
        protected override void OtherChanges(GemColors color)
        {
            boxCollider.enabled = false;
        }
    }
}
