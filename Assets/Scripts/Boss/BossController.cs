///////////////////////////////////////////////////////////////////////
//
//      BossController.cs
//      CompSci 40S, 2017-2018, Yaroslav Mikhaylik - HaselLoyance
//
///////////////////////////////////////////////////////////////////////

using UnityEngine;

/* There are reasons why the stuff is the way it is. Please don't ask me how and why and when.
 * It just happens and it works most of the time, so I'm just fine with that and you should be too.
 * 
 * 
 * 
 * 
 */

public class BossController : MonoBehaviour
{
    public bool useSmallerHitbox = false;
    public GameObject kurai;
    public GameObject hanabi;
    public GameObject kaitenDekai;
    public GameObject hanabi2;
    public GameObject hanabi22;
    public GameObject yureruyo;
    public GameObject shower;
    public GameObject tenmetsuda;
    public GameObject karahuru;
    public GameObject jikihazusi;

    Player player;
    AudioSource aSource;
    uint t = 0;
    bool bossPlaying = true;
    GameObject[] kabes;
    GameObject[] kabe2s;
    GameObject[] kabeDasus;
    GameObject[] kabeDasu2s;
    new Camera camera;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        aSource = GetComponent<AudioSource>();
        aSource.volume = GameManager.Instance.soundManager.MusicVolume;
        camera = FindObjectOfType<Camera>();

        kabes = GameObject.FindGameObjectsWithTag("Kabe");
        kabe2s = GameObject.FindGameObjectsWithTag("Kabe2");
        kabeDasus = GameObject.FindGameObjectsWithTag("KabeDasu");
        kabeDasu2s = GameObject.FindGameObjectsWithTag("KabeDasu2");
    }

    void FixedUpdate()
    {
        if (player.isDead)
        {
            if (bossPlaying)
            {
                bossPlaying = false;
                aSource.Stop();
            }

            return;
        }

        if (t == 0)
        {
            aSource.Play();

            if (useSmallerHitbox)
            {
                BoxCollider2D playerCollider = player.gameObject.transform.GetChild(1).GetComponent<BoxCollider2D>();
                playerCollider.offset = new Vector2(0.5f, -8.5f);
                playerCollider.size = new Vector2(6.0f, 6.0f);
            }
            
            Instantiate(kurai, new Vector2(GM.offsetX + 400.0f, GM.offsetY - 304), Quaternion.identity);

            float a = 15.0f;
            float asd = 0.0f;

            for (int i = 0; i < 24; i++)
            {
                GMComponent gmcObj = 
                    Instantiate(hanabi, new Vector2(GM.offsetX + 400.0f, GM.offsetY - 304), Quaternion.identity)
                    .GetComponent<GMComponent>();
                
                gmcObj.Speed = 17;
                gmcObj.Direction = a + asd + 7.5f;

                asd += 360.0f / 24.0f;
            }

            a = 15.0f;

            for (int i = 0; i < 24; i++)
            {
                GMComponent gmcObj =
                    Instantiate(hanabi, new Vector2(GM.offsetX + 400.0f, GM.offsetY - 304), Quaternion.identity)
                    .GetComponent<GMComponent>();
                
                gmcObj.Speed = 19;
                gmcObj.Direction = a + asd + 7.5f;

                asd += 360.0f / 24.0f;
            }
            
            a = 15.0f;

            for (int i = 0; i < 24; i++)
            {
                GMComponent gmcObj =
                    Instantiate(hanabi, new Vector2(GM.offsetX + 400.0f, GM.offsetY - 304), Quaternion.identity)
                    .GetComponent<GMComponent>();
                
                gmcObj.Speed = 21;
                gmcObj.Direction = a + asd + 7.5f;

                asd += 360.0f / 24.0f;
            }

            a = 15.0f;

            for (int i = 0; i < 24; i++)
            {
                GMComponent gmcObj =
                    Instantiate(hanabi, new Vector2(GM.offsetX + 400.0f, GM.offsetY - 304), Quaternion.identity)
                    .GetComponent<GMComponent>();
                
                gmcObj.Speed = 23;
                gmcObj.Direction = a + asd + 7.5f;

                asd += 360.0f / 24.0f;
            }

            a = 15.0f;

            for (int i = 0; i < 24; i++)
            {
                GMComponent gmcObj =
                    Instantiate(hanabi, new Vector2(GM.offsetX + 400.0f, GM.offsetY - 304), Quaternion.identity)
                    .GetComponent<GMComponent>();
                                
                gmcObj.Speed = 25;
                gmcObj.Direction = a + asd + 7.5f;

                asd += 360.0f / 24.0f;
            }
        }

        if (t == 10)
        {
            float a = 90.0f;
            float asd = 0.0f;

            for (int i = 0; i < 4; i++)
            {
                GMComponent gmcObj =
                    Instantiate(kaitenDekai, new Vector2(GM.offsetX + 400.0f, GM.offsetY - 304), Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 30;
                gmcObj.Direction = a + asd + 45;
                gmcObj.friction = 3.3f;

                asd += 360.0f / 4.0f;
            }
            
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Hanabi"))
            {
                go.GetComponent<GMComponent>().Speed = 0;
            }
        }

        if (t == 20)
        {
            float a = 180.0f;
            float asd = 0.0f;

            for (int i = 0; i < 2; i++)
            {
                GMComponent gmcObj =
                    Instantiate(hanabi2, new Vector2(GM.offsetX + 400.0f, GM.offsetY - 304), Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 30;
                gmcObj.Direction = a + asd;
                asd += 360.0f / 2.0f;
            }

            a = 180.0f;
            
            for (int i = 0; i < 2; i++)
            {
                GMComponent gmcObj =
                    Instantiate(hanabi22, new Vector2(GM.offsetX + 400.0f, GM.offsetY - 304), Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 30;
                gmcObj.Direction = a + asd + 90.0f;
                
                asd += 360.0f / 2.0f;
            }
        }
        
        if (t == 40)
        {
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("KaitenDekai"))
            {
                KaitenDekai kd = go.GetComponent<KaitenDekai>();
                kd.StartAlarm("Alarm0", 1);
            }
            
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Hanabi3"))
            {
                Hanabi3 h3 = go.GetComponent<Hanabi3>();
                h3.StartAlarm("Alarm0", 1);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Hanabi33"))
            {
                Hanabi33 h33 = go.GetComponent<Hanabi33>();
                h33.StartAlarm("Alarm0", 1);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Hanabi"))
            {
                Hanabi h = go.GetComponent<Hanabi>();
                h.StartAlarm("Alarm0", 1);

                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.ImageScaleX = 1.2f;
                gmcObj.ImageScaleY = 1.2f;
            }
        }

        if (t == 41)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Hanabi"))
            {
                Hanabi h = go.GetComponent<Hanabi>();
                h.StopAlarm("Alarm0");
            }
        }

        if (t == 60)
        {
            Instantiate(yureruyo);
            Instantiate(shower);

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("KaitenDekai"))
            {
                KaitenDekai kd = go.GetComponent<KaitenDekai>();
                kd.StartAlarm("Alarm2", 1);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Hanabi2"))
            {
                Destroy(go);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Hanabi22"))
            {
                Destroy(go);
            }
        }

        if (t == 80)
        {
            Instantiate(karahuru);
            Instantiate(tenmetsuda, new Vector2(GM.offsetX + 400.0f, GM.offsetY - 304), Quaternion.identity);

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Hanabi"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.friction = 0;
                gmcObj.Speed = -25;
                gmcObj.Direction += 20;

                Hanabi h = go.GetComponent<Hanabi>();
                h.StopAlarm("Alarm0");
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Hanabi3"))
            {
                Hanabi3 h3 = go.GetComponent<Hanabi3>();
                h3.StopAlarm("Alarm0");
                h3.t = 0;
                Destroy(go);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Hanabi33"))
            {
                Hanabi33 h33 = go.GetComponent<Hanabi33>();
                h33.StopAlarm("Alarm0");
                h33.t = 0;
                Destroy(go);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Yureruyo"))
            {
                Yureruyo y = go.GetComponent<Yureruyo>();
                y.StopAlarm("Alarm0");

                Destroy(go);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Kurai"))
            {
                Destroy(go);
            }
            
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("KaitenDekai"))
            {
                KaitenDekai kd = go.GetComponent<KaitenDekai>();
                kd.StopAlarm("Alarm0");
                kd.t = 0;
                kd.StartAlarm("Alarm3", 1);
            }
            
            camera.transform.position = new Vector3(544, 272, camera.transform.position.z);
        }

        if (t == 81)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("KaitenDekai"))
            {
                KaitenDekai kd = go.GetComponent<KaitenDekai>();
                kd.StopAlarm("Alarm3");
                Destroy(go);
            }
        }

        // Skip 121
        // Skip 131
        // Skip 141

        if (t == 219)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Karahuru"))
            {
                Destroy(go);
            }
        }

        if (t == 220)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Shower"))
            {
                Shower s = go.GetComponent<Shower>();
                s.StopAlarm("Alarm0");
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Ransu"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.Speed = 3.5f;
                gmcObj.gravity = -0.2f;

                Ransu r = go.GetComponent<Ransu>();
                r.StartAlarm("Alarm2", 1);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Murasaki"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.Speed = 0;
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Mizu"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.Speed = 0;
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Midori"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.Speed = 0;
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Kiro"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.Speed = 0;
            }
        }

        if (t == 221)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Ransu"))
            {
                Ransu r = go.GetComponent<Ransu>();
                r.StopAlarm("Alarm2");
            }
        }

        if (t == 304)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Shower"))
            {
                Shower s = go.GetComponent<Shower>();
                s.StopAlarm("Alarm1");
            }
            
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object724"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.Speed = 0.3f;
                gmcObj.ImageIndex = 6;
                gmcObj.gravity = 0.0f;
            }

            Instantiate(jikihazusi);
        }

        if (t == 341)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Jikihazusi"))
            {
                go.GetComponent<Jikihazusi>().StopAlarm("Alarm0");
                Destroy(go);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object724"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.Speed = 0.3f;
                gmcObj.ImageIndex = 6;

                Object724 o724 = go.GetComponent<Object724>();
                o724.StartAlarm("Alarm0", 1);
            }
        }

        if (t == 379)
        {
            /*
                with(midori){
                a = random(15);
                repeat(24){ 
                  idx = instance_create(x,y,midorigoki);
                    idx.speed = 12;
                  idx.direction = a + asd;
                  asd += 360/24;
                }}
                midori.alarm[1]=1
            */
        }

        if (t == 380)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Midori"))
            {
                Destroy(go);
            }
        }

        if (t == 391)
        {
            /*
            with(midorigoki){
            direction=random_range(0,180)
            gravity=0.1
            speed=3}
            */
        }

        if (t == 419)
        {
            /*
            with(kiro){
                a = 18;
                repeat(20){
                    idx = instance_create(x, y, kirogoki);
                    idx.speed = 30;
                    idx.direction = a + asd;
                    asd += 360 / 20;
                }
            }
            kiro.alarm[1] = 1
            */
        }

        if (t == 420)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Kiro"))
            {
                Destroy(go);
            }
        }

        if (t == 424)
        {
            /*
            with(kirogoki){
                direction = point_direction(x, y, player.x, player.y)
            speed = 23}
            */
        }

        if (t == 459)
        {
            /*
            with(kirogoki){ instance_destroy()};

            with(mizu){
                a = random(18);
                repeat(20){
                    idx = instance_create(x, y, gokimizu);
                    idx.speed = 12;

                    idx.direction = a + asd;
                    asd += 360 / 20;
                }
            }
            mizu.alarm[1] = 1
                */
        }

        if (t == 460)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Mizu"))
            {
                Destroy(go);
            }
        }

        if (t == 469)
        {
            /*
            with(gokimizu){
direction=random_range(0,-180)
speed=20
gravity=1
gravity_direction=90}
            */
        }

        if (t == 494)
        {
            /*
            with(murasaki){
                a = random(20);
                repeat(18){
                    idx = instance_create(x, y, muragoki);
                    idx.speed = 15.2;
                    idx.direction = a + asd;
                    asd += 360 / 18;
                }
            }
            murasaki.alarm[1] = 1
                */
        }

        if (t == 495)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Murasaki"))
            {
                Destroy(go);
            }
        }

        t++;
    }
}
