using UnityEngine;

namespace Core.Utils
{
    public class ResourseLoadService
    {
        public static T GetResource<T>(string prefabPath)
                where T : Object
        {
            return Resources.Load<T>(prefabPath);
        }
    }
}