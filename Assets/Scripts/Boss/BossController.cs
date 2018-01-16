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
    public uint setTAtStart = 1200;
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
    public GameObject midorigoki;
    public GameObject kirogoki;
    public GameObject mizugoki;
    public GameObject muragoki;
    public GameObject ransuyou;
    public GameObject count;
    public GameObject meiten;
    public GameObject bound;
    public GameObject object722;
    public GameObject object761;
    public GameObject hadou;
    public GameObject gottjiki;
    public GameObject kaiten;
    public GameObject kaiten2;

    Player player;
    AudioSource aSource;
    uint t = 0;
    bool bossPlaying = true;
    new Camera camera;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        aSource = GetComponent<AudioSource>();
        aSource.volume = GameManager.Instance.soundManager.MusicVolume;
        camera = FindObjectOfType<Camera>();
    }

    void FixedUpdate()
    {
        if (player.isDead)
        {
            if (bossPlaying)
            {
                bossPlaying = false;

                aSource.Stop();

                /*
                foreach(GameObject go in FindObjectsOfType<GameObject>())
                {
                    if (go.layer == LayerMask.NameToLayer("Dangers"))
                    {
                        Destroy(go);
                    }
                }
                */
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

            t = setTAtStart;
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
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.ImageScaleX = 1.2f;
                gmcObj.ImageScaleY = 1.2f;
            }
        }

        if (t == 41)
        {
            // EMPTY
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

                Destroy(go);
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
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Midori"))
            {
                float a = Random.Range(0.0f, 15.0f);
                float asd = 0.0f;
                
                for (int i = 0; i < 24; i++)
                {
                    GMComponent gmcObj =
                        Instantiate(midorigoki, go.transform.position, Quaternion.identity)
                        .GetComponent<GMComponent>();

                    gmcObj.Speed = 12;
                    gmcObj.Direction = a + asd;
                    asd += 360.0f / 24.0f;
                }
            }
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
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Midorigoki"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.Speed = 3;
                gmcObj.Direction = Random.Range(0.0f,180.0f);
                gmcObj.gravity = -0.1f;
            }
        }

        if (t == 419)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Kiro"))
            {
                float a = 18.0f;
                float asd = 0.0f;

                for (int i = 0; i < 20; i++)
                {
                    GMComponent gmcObj =
                        Instantiate(kirogoki, go.transform.position, Quaternion.identity)
                        .GetComponent<GMComponent>();

                    gmcObj.Speed = 30;
                    gmcObj.Direction = a + asd;
                    asd += 360.0f / 20.0f;
                }
            }
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
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Kirogoki"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.Speed = 23;
                gmcObj.Direction = GMComponent.PointDirection(
                    go.transform.position.x, go.transform.position.y,
                    player.transform.position.x, player.transform.position.y);
            }
        }

        if (t == 459)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Kirogoki"))
            {
                Destroy(go);
            }
            
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Mizu"))
            {
                float a = Random.Range(0.0f, 18.0f);
                float asd = 0.0f;

                for (int i = 0; i < 20; i++)
                {
                    GMComponent gmcObj =
                        Instantiate(mizugoki, go.transform.position, Quaternion.identity)
                        .GetComponent<GMComponent>();

                    gmcObj.Speed = 12;
                    gmcObj.Direction = a + asd;
                    asd += 360.0f / 20.0f;
                }
            }
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
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Mizugoki"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.Speed = 20;
                gmcObj.Direction = Random.Range(-180.0f, 0.0f);
                gmcObj.gravity = 1.0f;
            }
        }

        if (t == 494)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Murasaki"))
            {
                float a = Random.Range(0.0f, 20.0f);
                float asd = 0.0f;

                for (int i = 0; i < 18; i++)
                {
                    GMComponent gmcObj =
                        Instantiate(muragoki, go.transform.position, Quaternion.identity)
                        .GetComponent<GMComponent>();

                    gmcObj.Speed = 15.2f;
                    gmcObj.Direction = a + asd;
                    asd += 360.0f / 18.0f;
                }
            }
        }

        if (t == 495)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Murasaki"))
            {
                Destroy(go);
            }
        }

        if (t == 504)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Muragoki"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.Speed = 8;
                gmcObj.Direction = 270;
            }
        }

        if (t == 527)
        {
            Ransuyou r = Instantiate(ransuyou).GetComponent<Ransuyou>();
            r.StopAlarm("Alarm0");
            r.StartAlarm("Alarm2", 1);
            r.cancelAlarm0 = true;

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Kabe"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();

                gmcObj.ImageAlpha = 1.0f;
                gmcObj.Speed = 1.2f;
                gmcObj.Direction = 0.0f;
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Kabe2"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();

                gmcObj.ImageAlpha = 1.0f;
                gmcObj.Speed = 1.2f;
                gmcObj.Direction = 180.0f;
            }

            Kurai k =
                Instantiate(kurai, new Vector2(GM.offsetX + 400.0f, GM.offsetY - 304.0f), Quaternion.identity)
                .GetComponent<Kurai>();

            k.StartAlarm("Alarm0", 1);
        }

        if (t == 528)
        {
            // EMPTY
        }

        if (t == 640)
        {
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Ransuyou"))
            {
                Destroy(go);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Kurai"))
            {
                Destroy(go);
            }
        }

        if (t == 641)
        {
            camera.transform.Rotate(new Vector3(0.0f, 0.0f, 30.0f));

            Script87(count, 144, 160, 8);

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Muragoki"))
            {
                Destroy(go);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object724"))
            {
                Destroy(go);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Kabe"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.Speed = 30.0f;
                gmcObj.friction = 3f;
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Kabe2"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.Speed = 30.0f;
                gmcObj.friction = 3f;
            }

            Instantiate(meiten, new Vector2(GM.offsetX + 400.0f, GM.offsetY - 304.0f), Quaternion.identity);
        }

        if (t == 642)
        {
            // EMPTY
        }

        if (t == 649)
        {
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Mizugoki"))
            {
                Destroy(go);
            }
        }

        if (t == 650)
        {
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Count"))
            {
                go.GetComponent<GMComponent>().Speed = 0;
            }

            camera.transform.Rotate(new Vector3(0.0f, 0.0f, -60.0f));

            Script86(count, 400,160,8);

            Instantiate(meiten, new Vector2(GM.offsetX + 400.0f, GM.offsetY - 304.0f), Quaternion.identity);
        }

        if (t == 659)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Count"))
            {
                go.GetComponent<GMComponent>().Speed = 0;
            }
        }

        if (t == 660)
        {
            camera.transform.Rotate(new Vector3(0.0f, 0.0f, 30.0f));

            Script85(count, 640, 160, 8);

            Instantiate(meiten, new Vector2(GM.offsetX + 400.0f, GM.offsetY - 304.0f), Quaternion.identity);
        }

        if (t == 669)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Count"))
            {
                go.GetComponent<GMComponent>().Speed = 0;
            }
        }

        if (t == 678)
        {
            Instantiate(kurai, new Vector2(GM.offsetX + 400.0f, GM.offsetY - 304.0f), Quaternion.identity);

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Count"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();

                gmcObj.Direction = GMComponent.PointDirection(
                    go.transform.position.x,
                    go.transform.position.y,
                    player.transform.position.x,
                    player.transform.position.y);
                gmcObj.Speed = 40;
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Kabe"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();

                gmcObj.Speed = 3;
                gmcObj.friction = 0;
                gmcObj.acceleration = 0.3f;
                gmcObj.Direction = 180.0f;

                go.GetComponent<Kabe>().StartAlarm("Alarm1", 1);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Kabe2"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();

                gmcObj.Speed = 3;
                gmcObj.friction = 0;
                gmcObj.acceleration = 0.3f;
                gmcObj.Direction = 0.0f;

                go.GetComponent<Kabe>().StartAlarm("Alarm1", 1);
            }

            Instantiate(meiten, new Vector2(GM.offsetX + 400.0f, GM.offsetY - 304.0f), Quaternion.identity);

            float a = 90;
            float asd = 0.0f;
            
            for (int i = 0; i < 4; i++)
            {
                GMComponent gmcObj =
                    Instantiate(bound, new Vector2(GM.offsetX + 400.0f, GM.offsetY - 150.0f), Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 7;
                gmcObj.Direction = a + asd + 10;
                asd += 360 / 4;
            }
        }

        if (t == 778)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Count"))
            {
                Destroy(go);
            }
        }

        if (t == 798)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Count"))
            {
                Destroy(go);
            }
        }

        if (t == 799)
        {
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Bound"))
            {
                GMComponent gmcObj =
                    Instantiate(bound, go.transform.position, Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 7;
                gmcObj.Direction = Random.Range(0.0f, 360.0f);
            }

            float a = Random.Range(0.0f, 60.0f);
            float asd = 0.0f;

            for (int i =0; i < 6; i++)
            { 
                GMComponent gmcObj =
                    Instantiate(bound, new Vector2(GM.offsetX + 200, GM.offsetY -150.0f), Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 7;
                gmcObj.Direction = a + asd;

                asd += 360 / 6;
            }
        }

        if (t == 804)
        {
            float a = Random.Range(0.0f, 60.0f);
            float asd = 0.0f;

            for (int i = 0; i < 6; i++)
            {
                GMComponent gmcObj =
                    Instantiate(bound, new Vector2(GM.offsetX + 600, GM.offsetY - 150.0f), Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 7;
                gmcObj.Direction = a + asd;

                asd += 360 / 6;
            }
        }

        if (t == 949)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Bound"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.Speed = 0;
                gmcObj.ImageIndex = 4;
                gmcObj.ImageAlpha = 0.3f;
            }
        }

        if (t == 980)
        {
            float a = Random.Range(0.0f, 12.0f);
            float asd = 0.0f;

            for (int i = 0; i < 30; i++)
            {
                GMComponent gmcObj =
                    Instantiate(object722, new Vector2(GM.offsetX + 400, GM.offsetY - 304), Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 11;
                gmcObj.Direction = a + asd;

                gmcObj.gameObject.GetComponent<Object722>().nachi = 1;
                asd += 360 / 30;
            }
        }

        if (t == 1000)
        {
            float a = Random.Range(0.0f, 12.0f);
            float asd = 0.0f;

            for (int i = 0; i < 30; i++)
            {
                GMComponent gmcObj =
                    Instantiate(object722, new Vector2(GM.offsetX + 400, GM.offsetY - 304), Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 11;
                gmcObj.Direction = a + asd;

                gmcObj.gameObject.GetComponent<Object722>().nachi = 2;
                asd += 360 / 30;
            }
        }

        if (t == 1020)
        {
            float a = Random.Range(0.0f, 12.0f);
            float asd = 0.0f;

            for (int i = 0; i < 30; i++)
            {
                GMComponent gmcObj =
                    Instantiate(object722, new Vector2(GM.offsetX + 400, GM.offsetY - 304), Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 11;
                gmcObj.Direction = a + asd;

                gmcObj.gameObject.GetComponent<Object722>().nachi = 1;
                asd += 360 / 30;
            }
        }

        if (t == 1040)
        {
            float a = Random.Range(0.0f, 12.0f);
            float asd = 0.0f;

            for (int i = 0; i < 30; i++)
            {
                GMComponent gmcObj =
                    Instantiate(object722, new Vector2(GM.offsetX + 400, GM.offsetY - 304), Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 11;
                gmcObj.Direction = a + asd;

                gmcObj.gameObject.GetComponent<Object722>().nachi = 2;
                asd += 360 / 30;
            }
        }

        if (t == 1060)
        {
            float a = Random.Range(0.0f, 12.0f);
            float asd = 0.0f;

            for (int i = 0; i < 30; i++)
            {
                GMComponent gmcObj =
                    Instantiate(object722, new Vector2(GM.offsetX + 400, GM.offsetY - 304), Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 11;
                gmcObj.Direction = a + asd;

                gmcObj.gameObject.GetComponent<Object722>().nachi = 1;
                asd += 360 / 30;
            }
        }

        // SKIP 1080

        if (t == 1085)
        {
            float a = 15.0f;
            float asd = 0.0f;

            for (int i = 0; i < 24; i++)
            {
                GMComponent gmcObj =
                    Instantiate(object761, new Vector2(GM.offsetX + 400, GM.offsetY - 304), Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 35;
                gmcObj.Direction = a + asd;

                asd += 360.0f / 24.0f;
            }
        }

        if (t == 1090)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object761"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.Speed = 0.5f;
            }
        }

        if (t == 1109)
        {
            Instantiate(yureruyo);

            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Bound"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.ImageIndex = 0;
                gmcObj.ImageAlpha = 1;
                gmcObj.Direction = GMComponent.PointDirection(
                    go.transform.position.x,
                    go.transform.position.y,
                    GM.offsetX + 400,
                    GM.offsetY - 304);
            }

            float a = 4.5f;
            float asd = 0.0f;

            for (int i = 0; i < 80; i++)
            {
                GMComponent gmcObj =
                    Instantiate(hadou, new Vector2(GM.offsetX + 400, GM.offsetY - 304), Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 30;
                gmcObj.Direction = a + asd;

                asd += 360.0f / 80.0f;
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object761"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.friction = 0;
                gmcObj.Speed = 20;
            }
        }

        if (t == 1110)
        {
            // EMPTY
        }

        if (t == 1114)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Yureruyo"))
            {
                Yureruyo y = go.GetComponent<Yureruyo>();
                y.StopAlarm("Alarm0");

                Destroy(go);
            }

            camera.transform.position = new Vector3(544, 272, camera.transform.position.z);
        }

        if (t == 1130)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Bound"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.Speed = 14;
                gmcObj.Direction = Random.Range(80.0f, 100.0f);
            }
        }

        if (t == 1240)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Bound"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.Speed = 0.5f;
            }
        }

        if (t == 1258)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Bound"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.Speed = 35;
                gmcObj.Direction = Random.Range(80.0f, 100.0f);
                go.GetComponent<Bound>().collide = false;
            }

            Instantiate(meiten, new Vector2(GM.offsetX + 400.0f, GM.offsetY - 304.0f), Quaternion.identity);

            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Kurai"))
            {
                Destroy(go);
            }
        }

        if (t == 1277)
        {
            Ransuyou r = Instantiate(ransuyou).GetComponent<Ransuyou>();

            r.StopAlarm("Alarm0");
            r.cancelAlarm0 = true;
            r.StartAlarm("Alarm4", 1);
            r.StartAlarm("Alarm10", 1);
        }

        if (t == 1312)
        {
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Ransuyou"))
            {
                Ransuyou r = go.GetComponent<Ransuyou>();
                r.StopAlarm("Alarm4");
                r.StopAlarm("Alarm10");
            }
        }

        if (t == 1313)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Hanteinai"))
            {
                go.GetComponent<GMComponent>().Speed = 0;
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Ransuyou"))
            {
                go.GetComponent<Ransuyou>().StartAlarm("Alarm5", 1);
            }
        }

        if (t == 1345)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Ransuyou"))
            {
                go.GetComponent<Ransuyou>().StopAlarm("Alarm5");
            }
        }

        if (t == 1346)
        {
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Hanteinaiyo"))
            {
                go.GetComponent<GMComponent>().Speed = 0;
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Hanteinai"))
            {
                go.GetComponent<GMComponent>().Speed = 16.5f;
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Ransuyou"))
            {
                Ransuyou r = go.GetComponent<Ransuyou>();
                r.StartAlarm("Alarm4", 1);
                r.StartAlarm("Alarm10", 1);
            }
        }

        if (t == 1389)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Ransuyou"))
            {
                Ransuyou r = go.GetComponent<Ransuyou>();
                r.StopAlarm("Alarm4");
                r.StopAlarm("Alarm10");
            }
        }

        if (t == 1390)
        {
            Instantiate(kurai, new Vector2(GM.offsetX + 400.0f, GM.offsetY - 304), Quaternion.identity);

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Hanteinai"))
            {
                go.GetComponent<GMComponent>().Speed = 0.0f;
            }

            Instantiate(yureruyo);

            float a = 10;
            float asd = 0;

            for (int i = 0; i < 36; i++)
            {
                GMComponent gmcObj =
                    Instantiate(gottjiki, new Vector2(GM.offsetX + 600, GM.offsetY - 100), Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 20;
                gmcObj.Direction = a + asd;

                asd += 360 / 36;
            }

            a = 10;

            for (int i = 0; i < 36; i++)
            {
                GMComponent gmcObj =
                    Instantiate(gottjiki, new Vector2(GM.offsetX + 200, GM.offsetY - 100), Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 20;
                gmcObj.Direction = a + asd;

                asd += 360 / 36;
            }
        }

        if (t == 1392)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Yureruyo"))
            {
                Yureruyo y = go.GetComponent<Yureruyo>();
                y.StopAlarm("Alarm0");

                Destroy(go);
            }

            camera.transform.position = new Vector3(544, 272, camera.transform.position.z);
        }

        if (t == 1395)
        {
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Gottjiki"))
            {
                go.GetComponent<GMComponent>().Speed = 0.3f;
            }
        }

        if (t == 1408)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Gottjiki"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.Speed = 40;
                gmcObj.Direction = GMComponent.PointDirection(
                    go.transform.position.x,
                    go.transform.position.y,
                    player.transform.position.x,
                    player.transform.position.y);
            }
        }

        if (t == 1427)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Kurai"))
            {
                Destroy(go);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Hanteinai"))
            {
                go.GetComponent<GMComponent>().Speed = 6;
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Hanteinaiyo"))
            {
                go.GetComponent<GMComponent>().Speed = 6;
            }
            
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Ransuyou"))
            {
                Ransuyou r = go.GetComponent<Ransuyou>();
                r.StartAlarm("Alarm6", 1);
                r.StartAlarm("Alarm7", 1);
            }
        }

        if (t == 1499)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Ransuyou"))
            {
                Ransuyou r = go.GetComponent<Ransuyou>();
                r.StopAlarm("Alarm6");
                r.StopAlarm("Alarm7");
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Hanteinai"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.Speed = 20;
                gmcObj.Direction = Random.Range(0.0f, 360.0f);
                gmcObj.ImageIndex = 6;
                gmcObj.ImageAlpha = 0.2f;
            }
        }

        if (t == 1500)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Hanteinaiyo"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.Speed = -8;
                gmcObj.Direction = GMComponent.PointDirection(
                    go.transform.position.x,
                    go.transform.position.y,
                    player.transform.position.x,
                    player.transform.position.y);
                gmcObj.ImageIndex = 4;
                gmcObj.ImageAlpha = 0.2f;
            }

            GMComponent gmcObj1 =
                Instantiate(kaiten, new Vector2(GM.offsetX, GM.offsetY - 200), Quaternion.identity)
                .GetComponent<GMComponent>();

            gmcObj1.Speed = 30;
            gmcObj1.Direction = 0;


            gmcObj1 =
                Instantiate(kaiten2, new Vector2(GM.offsetX + 800, GM.offsetY - 200), Quaternion.identity)
                .GetComponent<GMComponent>();

            gmcObj1.Speed = 30;
            gmcObj1.Direction = 180;
        }

        if (t == 1578)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Ransuyou"))
            {
                go.GetComponent<Ransuyou>().StartAlarm("Alarm8", 1);
            }

            //instance_create(0, 0, yokoyure)
        }

        if (t == 1610)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Ransuyou"))
            {
                go.GetComponent<Ransuyou>().StopAlarm("Alarm8");
            }

            /*
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Yokoyure"))
            {
               //stop alarm
               //destroy object
               
            }
            */

        //reset camera x pos
        }

        if (t == 1611)
        {
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Object724"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();

                gmcObj.friction = 5;
                gmcObj.Speed = 20;
                gmcObj.Direction = 270;
            }

            //Script88(yazirusi, 112, 112, 10);
            //Script89(yazirusi, 688, 112, 10);
        }

        if (t== 1612)
        {
            //reset camera y pos
        }

        if (t == 1616)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object724"))
            {
                go.GetComponent<GMComponent>().Speed = 20;
            }

            //Script88(yazirusi, 112, 112, 10);
            //Script89(yazirusi, 688, 112, 10);
        }

        if (t == 1617)
        {
            //reset camera y pos
        }

        if (t == 1621)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object724"))
            {
                go.GetComponent<GMComponent>().Speed = 20;
            }
        }

        if (t == 1626)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object724"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();

                gmcObj.friction = 0;
                gmcObj.Speed = 14.5f;
            }

            //reset camera y pos
        }

        if (t == 1652)
        { 
        }
        t++;
    }

    void Script85(GameObject go, float x, float y, float s)
    {
        x += GM.offsetX;
        y = GM.offsetY - y;

        float[] _objX = { 640,640,640,640,640,640,608,674,640,608 };

        float[] _objY = { 160,128,96,192,224,256,256,256,64,96 };

        for (int i = 0; i < 10; i++)
        {
            GMComponent gmcObj =
                Instantiate(go, new Vector2(x, y), Quaternion.identity)
                .GetComponent<GMComponent>();

            gmcObj.Speed = GMComponent.PointDistance(x, y, GM.offsetX + _objX[i], (GM.offsetY - _objY[i])) / s;
            gmcObj.Direction = GMComponent.PointDirection(x, y, GM.offsetX + _objX[i], (GM.offsetY - _objY[i]));
        }
    }

    void Script86(GameObject go, float x, float y, float s)
    {
        x += GM.offsetX;
        y = GM.offsetY - y;

        float[] _objX = { 336,368,400,432,464,464,464,464,432,400,368,336,336,
                336,336,368,400,432,464
        };

        float[] _objY = { 64,64,64,64,64,96,128,160,160,160,160,160,192,224,
            256,256,256,256,256
        };

        for (int i = 0; i < 19; i++)
        {
            GMComponent gmcObj =
                Instantiate(go, new Vector2(x, y), Quaternion.identity)
                .GetComponent<GMComponent>();

            gmcObj.Speed = GMComponent.PointDistance(x, y, GM.offsetX + _objX[i], (GM.offsetY - _objY[i])) / s;
            gmcObj.Direction = GMComponent.PointDirection(x, y, GM.offsetX + _objX[i], (GM.offsetY - _objY[i]));
        }
    }

    void Script87(GameObject go, float x, float y, float s)
    {
        x += GM.offsetX;
        y = GM.offsetY - y;

        float[] _objX = { 176, 176, 144, 112, 208, 208, 176,
            144, 112, 112, 144, 208, 80, 80,80, 208, 208, 208, 208
        };

        float[] _objY = { 160, 64,64, 64,64,256,256,256,256,160,160,160,64,
            160,256,224,192,128,96
        };

        for (int i =0; i < 19; i++)
        {
            GMComponent gmcObj =
                Instantiate(go, new Vector2(x, y), Quaternion.identity)
                .GetComponent<GMComponent>();

            gmcObj.Speed = GMComponent.PointDistance(x, y, GM.offsetX + _objX[i], (GM.offsetY - _objY[i])) / s;
            gmcObj.Direction = GMComponent.PointDirection(x, y, GM.offsetX + _objX[i], (GM.offsetY - _objY[i]));
        }
    }

    void Script88(GameObject go, float x, float y, float s)
    {
        x += GM.offsetX;
        y = GM.offsetY - y;

        float[] _objX = {128,128,96,96,80,96,112,128,144,64,160,96,128,96,128,96,96,128,128,112,80,144};

        float[] _objY = {128,112,96,128,144,160,176,160,144,128,128,64,64,48,48,80,112,80,96,48,128,128};

        for (int i = 0; i < 22; i++)
        {
            GMComponent gmcObj =
                Instantiate(go, new Vector2(x, y), Quaternion.identity)
                .GetComponent<GMComponent>();

            gmcObj.Speed = GMComponent.PointDistance(x, y, GM.offsetX + _objX[i], (GM.offsetY - _objY[i])) / s;
            gmcObj.Direction = GMComponent.PointDirection(x, y, GM.offsetX + _objX[i], (GM.offsetY - _objY[i]));
        }
    }

    void Script89(GameObject go, float x, float y, float s)
    {
        x += GM.offsetX;
        y = GM.offsetY - y;

        float[] _objX = { };

        float[] _objY = { };

        for (int i = 0; i < 19; i++)
        {
            GMComponent gmcObj =
                Instantiate(go, new Vector2(x, y), Quaternion.identity)
                .GetComponent<GMComponent>();

            gmcObj.Speed = GMComponent.PointDistance(x, y, GM.offsetX + _objX[i], (GM.offsetY - _objY[i])) / s;
            gmcObj.Direction = GMComponent.PointDirection(x, y, GM.offsetX + _objX[i], (GM.offsetY - _objY[i]));
        }
    }
}
