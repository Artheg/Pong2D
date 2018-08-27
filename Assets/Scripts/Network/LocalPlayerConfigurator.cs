using UnityEngine.Networking;

public class LocalPlayerConfigurator : NetworkBehaviour {

    public BaseTransformController controller;

    void Start()
    {
        if (controller != null)
            controller.AllowControls(hasAuthority);
    }
}
