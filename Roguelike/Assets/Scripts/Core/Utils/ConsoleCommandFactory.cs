using IngameDebugConsole;
using JetBrains.Annotations;
using UnityEngine;

namespace Core.Utils
{
    public class ConsoleCommandFactory : MonoBehaviour
    {
        [ConsoleMethod("sayGay", "Print message")]
        [UsedImplicitly]
        public static void SayGay()
        {
            Debug.LogWarning("You are GAY!!!");
        }
    }
}