using UnityEngine;

namespace Manager
{
    public class Manager : MonoBehaviour
    {
        private static EventManager events;
        public static EventManager Event { get { return events; } set { events = value; } }

        private static SoundManager sound;
        public static SoundManager Sound { get { return sound; } set { sound = value; } }

        private static ObjectPoolManager pool;
        public static ObjectPoolManager Pool { get { return pool; } set { pool = value; } }


        private void Awake()
        {
            Sound = this.gameObject.AddComponent<SoundManager>();
            Event = this.gameObject.AddComponent<EventManager>();
            Pool = this.gameObject.AddComponent<ObjectPoolManager>();
        }
    }
}