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
    public GameObject smallBox;
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
    public GameObject yokoyure;
    public GameObject yazirusi;
    public GameObject kabeda;
    public GameObject tuibi;
    public GameObject kabetukuru;
    public GameObject object814;
    public GameObject object815;
    public GameObject object816;
    public GameObject object817;
    public GameObject hadouken;
    public GameObject hadouyou;
    public GameObject tenmesuyou;
    public GameObject ransuyou2;
    public GameObject gamenmawaru;
    public GameObject yureru;
    public GameObject hanabidasu;
    public GameObject dasuyo;
    public GameObject kurakunaru;
    public GameObject roopdayo;
    public GameObject gurun;
    public GameObject ransu;
    public GameObject tateyure;
    public GameObject gameClearWarp;

    Player player;
    AudioSource aSource;
    uint t = 0;
    uint setTAtStart = 0;
    bool bossPlaying = true;
    bool bossFinished = false;
    new Camera camera;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        aSource = GetComponent<AudioSource>();
        aSource.volume = GameManager.Instance.soundManager.MusicVolume;
        camera = FindObjectOfType<Camera>();
    }
    
    void ResetCameraPos()
    {
        camera.transform.position = new Vector3(544, 272, camera.transform.position.z);
        camera.transform.rotation = Quaternion.identity;
    }

    void FixedUpdate()
    {
        if (bossFinished)
        {
            return;
        }

        if (player.isDead)
        {
            if (bossPlaying)
            {
                bossPlaying = false;

                aSource.Stop();
                
                ResetCameraPos();

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
            Hanabidasu.a = 0;
            Hanabidasu.s = 8;

            aSource.Play();

            if (useSmallerHitbox)
            {
                BoxCollider2D playerCollider = player.gameObject.transform.GetChild(1).GetComponent<BoxCollider2D>();
                playerCollider.offset = new Vector2(0.0f, -8.0f);
                playerCollider.size = new Vector2(4.0f, 4.0f);
            }

            Instantiate(smallBox, player.transform);

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
            
            ResetCameraPos();
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

            ResetCameraPos();
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

            ResetCameraPos();
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

            Instantiate(yokoyure);
        }

        if (t == 1610)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Ransuyou"))
            {
                go.GetComponent<Ransuyou>().StopAlarm("Alarm8");
            }
            
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Yokoyure"))
            {
                go.GetComponent<Yokoyure>().StopAlarm("Alarm0");
                Destroy(go);
            }

            ResetCameraPos();
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

            Script88(yazirusi, 112, 112, 10);
            Script89(yazirusi, 688, 112, 10);
        }

        if (t == 1612)
        {
            // EMPTY
        }

        if (t == 1616)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object724"))
            {
                go.GetComponent<GMComponent>().Speed = 20;
            }

            Script88(yazirusi, 112, 112, 10);
            Script89(yazirusi, 688, 112, 10);
        }

        if (t == 1617)
        {
            // EMPTY
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
        }

        if (t == 1652)
        {
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Ransuyou"))
            {
                go.GetComponent<Ransuyou>().StartAlarm("Alarm9", 1);
            }

            Script90(yazirusi, 688, 304, 5);

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Yazirusi"))
            {
                go.GetComponent<GMComponent>().ImageAlpha = 0.001f;

                Yazirusi y = go.GetComponent<Yazirusi>();
                y.preventAlarm0 = true;
                y.StopAlarm("Alarm0");
            }
        }

        if (t == 1656)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Yazirusi"))
            {
                go.GetComponent<GMComponent>().Speed = 0.0f;
            }

            GMComponent gmcObj = 
                Instantiate(kabeda, new Vector2(GM.offsetX + 800, GM.offsetY), Quaternion.identity)
                .GetComponent<GMComponent>();

            gmcObj.Direction = 270;
            gmcObj.Speed = 30;
        }

        if (t == 1687)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Ransuyou"))
            {
                go.GetComponent<Ransuyou>().StopAlarm("Alarm9");
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Yazirusi"))
            {
                Yazirusi y = go.GetComponent<Yazirusi>();
                y.preventAlarm0 = false;
                y.StartAlarm("Alarm0",1);

                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.ImageAlpha = 1.5f;
                gmcObj.Direction = 180;
                gmcObj.Speed = 30;
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Hanabi"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.Speed = 3;
                gmcObj.Direction = 181;
                gmcObj.acceleration = 0.3f;
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Kabedayou"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.Speed = 20;
                gmcObj.Direction = 180;
                gmcObj.acceleration = -1;
                gmcObj.ImageAlpha = 1;
            }

            float a = 1;
            float asd = 0;

            for (int i =0; i < 360; i++)
            {
                GMComponent gmcObj = Instantiate(hadouken, new Vector2(
                    GM.offsetX + 800, GM.offsetY -304
                    ), Quaternion.identity).GetComponent<GMComponent>();

                gmcObj.Speed = 60;
                gmcObj.Direction = a+asd;

                asd += 360 / 360;
            }

            camera.transform.position += Vector3.right * -10;
        }

        if (t == 1688)
        {
            // EMPTY
        }

        if (t == 1690)
        {
            ResetCameraPos();
        }

        if (t == 1725)
        {
            Instantiate(tuibi, new Vector2(
                GM.offsetX + 0, GM.offsetY - 0
                ), Quaternion.identity);

            Instantiate(tuibi, new Vector2(
                GM.offsetX + 800, GM.offsetY - 0
                ), Quaternion.identity);
        }

        if (t == 1797)
        {
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Tuibi"))
            {
                go.GetComponent<Tuibi>().StopAlarm("Alarm0");
                Destroy(go);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object724"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.Direction = GMComponent.PointDirection(
                    go.transform.position.x,
                    go.transform.position.y,
                    player.transform.position.x,
                    player.transform.position.y);
                gmcObj.Speed = -30;
            }

            GMComponent gmcObj1 = Instantiate(kabetukuru, new Vector2(
                GM.offsetX + 540, GM.offsetY + 17
                ), Quaternion.identity).GetComponent<GMComponent>();

            gmcObj1.Speed = 40;
            gmcObj1.Direction = 270;


            gmcObj1 = Instantiate(kabetukuru, new Vector2(
                 GM.offsetX + 0, GM.offsetY - 164
                 ), Quaternion.identity).GetComponent<GMComponent>();

            gmcObj1.Speed = 40;
            gmcObj1.Direction = 0;
        }

        if (t == 1800)
        {
            float a = 10;
            float asd = 0;

            for (int i = 0; i < 36;i++)
            {
                GMComponent gmcObj = Instantiate(object814, new Vector2(
                    GM.offsetX + 0, GM.offsetY + 0
                    ), Quaternion.identity).GetComponent<GMComponent>();

                gmcObj.Speed = 30;
                gmcObj.friction = 3;
                gmcObj.Direction = a+asd;

                asd += 360 / 36;
            }

            for (int i = 0; i < 36; i++)
            {
                GMComponent gmcObj = Instantiate(object815, new Vector2(
                    GM.offsetX + 800, GM.offsetY -608
                    ), Quaternion.identity).GetComponent<GMComponent>();

                gmcObj.Speed = 30;
                gmcObj.friction = 3;
                gmcObj.Direction = a + asd;

                asd += 360 / 36;
            }

            Instantiate(tenmetsuda, new Vector2(GM.offsetX + 400.0f, GM.offsetY - 304), Quaternion.identity);
        }

        if (t == 1808)
        {
            GMComponent gmcObj = Instantiate(kabetukuru, new Vector2(
                GM.offsetX + 260, GM.offsetY + 17
                ), Quaternion.identity).GetComponent<GMComponent>();

            gmcObj.Speed = 40;
            gmcObj.Direction = 270;


            gmcObj = Instantiate(kabetukuru, new Vector2(
                 GM.offsetX + 0, GM.offsetY - 443
                 ), Quaternion.identity).GetComponent<GMComponent>();

            gmcObj.Speed = 40;
            gmcObj.Direction = 0;
        }
        
        if (t == 1810)
        {
            float a = 10;
            float asd = 0;

            for (int i = 0; i < 36; i++)
            {
                GMComponent gmcObj = Instantiate(object816, new Vector2(
                    GM.offsetX + 0, GM.offsetY -608
                    ), Quaternion.identity).GetComponent<GMComponent>();

                gmcObj.Speed = 30;
                gmcObj.friction = 3;
                gmcObj.Direction = a + asd;

                asd += 360 / 36;
            }

            for (int i = 0; i < 36; i++)
            {
                GMComponent gmcObj = Instantiate(object817, new Vector2(
                    GM.offsetX + 800, GM.offsetY
                    ), Quaternion.identity).GetComponent<GMComponent>();

                gmcObj.Speed = 30;
                gmcObj.friction = 3;
                gmcObj.Direction = a + asd;

                asd += 360 / 36;
            }
        }

        if (t == 1815)
        {
            Instantiate(hadouyou, new Vector2(
                GM.offsetX + 400, GM.offsetY - 304), Quaternion.identity);
            Instantiate(yureruyo);
            Instantiate(tenmesuyou);
        }

        if (t == 1822)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object814"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.friction = 0;
                gmcObj.Speed = 1;
            }
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object815"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.friction = 0;
                gmcObj.Speed = 1;
            }
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object816"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.friction = 0;
                gmcObj.Speed = 1;
            }
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object817"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();
                gmcObj.friction = 0;
                gmcObj.Speed = 1;
            }
        }

        if (t == 1835)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Hadouyou"))
            {
                go.GetComponent<Hadouyou>().StopAlarm("Alarm1");

                Destroy(go);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Yureruyo"))
            {
                go.GetComponent<Yureruyo>().StopAlarm("Alarm0");

                Destroy(go);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Tenmesuyou"))
            {
                go.GetComponent<Tenmesuyou>().StopAlarm("Alarm1");

                Destroy(go);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object814"))
            {
                go.GetComponent<GMComponent>().Speed = 25;
            }
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object815"))
            {
                go.GetComponent<GMComponent>().Speed = 25;
            }
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object816"))
            {
                go.GetComponent<GMComponent>().Speed = 25;
            }
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object817"))
            {
                go.GetComponent<GMComponent>().Speed = 25;
            }

            ResetCameraPos();
        }

        if (t == 1845)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Kabeninaru"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();

                gmcObj.Direction = GMComponent.PointDirection(
                    go.transform.position.x,
                    go.transform.position.y,
                    player.transform.position.x,
                    player.transform.position.y);
                gmcObj.Speed = -25;
            }
        }

        if (t == 1853)
        {
            Instantiate(ransuyou2);
        }

        if (t == 1855)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Kabeninaru"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();

                gmcObj.Direction = GMComponent.PointDirection(
                    go.transform.position.x,
                    go.transform.position.y,
                    GM.offsetX + 400,
                    GM.offsetY - 304);
                gmcObj.Speed = 45;
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object814"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();

                gmcObj.Direction = GMComponent.PointDirection(
                    go.transform.position.x,
                    go.transform.position.y,
                    GM.offsetX + 400,
                    GM.offsetY - 304);
                gmcObj.Speed = 60;
                gmcObj.ImageAlpha = 0.9f;
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object815"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();

                gmcObj.Direction = GMComponent.PointDirection(
                    go.transform.position.x,
                    go.transform.position.y,
                    GM.offsetX + 400,
                    GM.offsetY - 304);
                gmcObj.Speed = 60;
                gmcObj.ImageAlpha = 0.9f;
            }
            
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object816"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();

                gmcObj.Direction = GMComponent.PointDirection(
                    go.transform.position.x,
                    go.transform.position.y,
                    GM.offsetX + 400,
                    GM.offsetY - 304);
                gmcObj.Speed = 60;
                gmcObj.ImageAlpha = 0.9f;
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object817"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();

                gmcObj.Direction = GMComponent.PointDirection(
                    go.transform.position.x,
                    go.transform.position.y,
                    GM.offsetX + 400,
                    GM.offsetY - 304);
                gmcObj.Speed = 60;
                gmcObj.ImageAlpha = 0.9f;
            }

            Instantiate(gamenmawaru);
        }

        if (t == 1865)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Gamenmawaru"))
            {
                go.GetComponent<Gamenmawaru>().StopAlarm("Alarm0");
                Destroy(go);
            }

            ResetCameraPos();
        }

        if (t == 1873)
        {
            GameObject go = Instantiate(yureru);

            Yureru y = go.GetComponent<Yureru>();
            y.preventAlarm0 = true;
            y.StopAlarm("Alarm0");
            y.StartAlarm("Alarm1",1);
        }

        if (t == 1949)
        {
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Ransuyou2"))
            {
                go.GetComponent<Ransuyou2>().StopAlarm("Alarm0");
            }
        }

        if (t == 1950)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Kabeninaru"))
            {
                Destroy(go);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object814"))
            {
                Destroy(go);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object815"))
            {
                Destroy(go);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object816"))
            {
                Destroy(go);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object817"))
            {
                Destroy(go);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object832"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();

                gmcObj.Direction = 45;
                gmcObj.Speed = 30;
                gmcObj.ImageAlpha = 0.2f;
                gmcObj.ImageIndex = 4;
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Yureru"))
            {
                go.GetComponent<Yureru>().StopAlarm("Alarm1");
            }

            ResetCameraPos();
        }

        if (t == 1960)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object832"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();

                gmcObj.Direction = 230;
                gmcObj.Speed = 12.5f;
                gmcObj.ImageAlpha = 1;
                gmcObj.ImageIndex = 0;
            }
        }

        if (t == 2005)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Ransuyou2"))
            {
                go.GetComponent<Ransuyou2>().StartAlarm("Alarm1", 1);
            }
        }

        if (t == 2025)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Yureru"))
            {
                go.GetComponent<Yureru>().StartAlarm("Alarm2",1);
            }
        }

        if (t == 2099)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Ransuyou2"))
            {
                go.GetComponent<Ransuyou2>().StopAlarm("Alarm1");
            }
        }

        if (t == 2100)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object833"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();

                gmcObj.Direction = 135;
                gmcObj.Speed = 30;
                gmcObj.ImageAlpha = 0.2f;
                gmcObj.ImageIndex = 4;
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Yureru"))
            {
                go.GetComponent<Yureru>().StopAlarm("Alarm2");
            }

            ResetCameraPos();
        }

        if (t == 2110)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object833"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();

                gmcObj.Direction = 310;
                gmcObj.Speed = 12.5f;
                gmcObj.ImageAlpha = 1;
                gmcObj.ImageIndex = 0;
            }
        }
        
        if (t == 2135)
        {
            Instantiate(hanabidasu, new Vector2(
                GM.offsetX + 400, GM.offsetY - 16), Quaternion.identity);

            Instantiate(dasuyo, new Vector2(
                GM.offsetX + 400, GM.offsetY - 16), Quaternion.identity);
        }

        if (t == 2145)
        {
            Instantiate(hanabidasu, new Vector2(
                GM.offsetX + 336, GM.offsetY - 80), Quaternion.identity);

            Instantiate(dasuyo, new Vector2(
                GM.offsetX + 336, GM.offsetY - 80), Quaternion.identity);
        }

        if (t == 2155)
        {
            Instantiate(hanabidasu, new Vector2(
                GM.offsetX + 400, GM.offsetY - 144), Quaternion.identity);

            Instantiate(dasuyo, new Vector2(
                GM.offsetX + 400, GM.offsetY - 144), Quaternion.identity);
        }

        if (t == 2165)
        {
            Instantiate(hanabidasu, new Vector2(
                GM.offsetX + 464, GM.offsetY - 80), Quaternion.identity);

            Instantiate(dasuyo, new Vector2(
                GM.offsetX + 464, GM.offsetY - 80), Quaternion.identity);
        }

        if (t == 2175)
        {
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Dasuyo"))
            {
                Destroy(go);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Hanabidasu"))
            {
                Hanabidasu h = go.GetComponent<Hanabidasu>();
                h.StartAlarm("Alarm1", 1);
                h.StartAlarm("Alarm2", 1);
            }
        }

        if (t == 2325)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Hanabidasu"))
            {
                Hanabidasu h = go.GetComponent<Hanabidasu>();
                h.StopAlarm("Alarm2");
                h.StartAlarm("Alarm3",1);
                h.StartAlarm("Alarm4",1);
            }
        }

        if (t == 2475)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Hanabidasu"))
            {
                Hanabidasu h = go.GetComponent<Hanabidasu>();
                h.StopAlarm("Alarm3");
                h.StopAlarm("Alarm4");

                Destroy(go);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Hanabi"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();

                gmcObj.Speed = -6;
                gmcObj.Direction = GMComponent.PointDirection(
                    go.transform.position.x, go.transform.position.y,
                    player.transform.position.x, player.transform.position.y);
            }

            Instantiate(kurakunaru);

            float a = Random.Range(0.0f, 18.0f);
            float asd = 0;

            for (int i =0; i < 20; i++)
            {
                GMComponent gmcObj = Instantiate(object722, new Vector2(GM.offsetX + 400, GM.offsetY - 80), Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 10;
                gmcObj.Direction = a + asd;

                gmcObj.gameObject.GetComponent<Object722>().nachi = 1;

                asd += 360.0f / 20.0f;
            }

            a = Random.Range(0.0f, 18.0f);

            for (int i = 0; i < 20; i++)
            {
                GMComponent gmcObj = Instantiate(object722, new Vector2(GM.offsetX + 400, GM.offsetY - 80), Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 10;
                gmcObj.Direction = a + asd;

                gmcObj.gameObject.GetComponent<Object722>().nachi = 2;

                asd += 360.0f / 20.0f;
            }
        }

        if (t == 2530)
        {
            float a = Random.Range(0.0f, 12.0f);
            float asd = 0;

            for (int i = 0; i < 30; i++)
            {
                GMComponent gmcObj = Instantiate(object722, new Vector2(GM.offsetX + 400, GM.offsetY - 80), Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 10;
                gmcObj.Direction = a + asd;

                gmcObj.gameObject.GetComponent<Object722>().nachi = 1;

                asd += 360.0f / 30.0f;
            }
        }

        if (t == 2550)
        {
            float a = Random.Range(0.0f, 12.0f);
            float asd = 0;

            for (int i = 0; i < 30; i++)
            {
                GMComponent gmcObj = Instantiate(object722, new Vector2(GM.offsetX + 400, GM.offsetY - 80), Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 10;
                gmcObj.Direction = a + asd;

                gmcObj.gameObject.GetComponent<Object722>().nachi = 2;

                asd += 360.0f / 30.0f;
            }
        }

        if (t == 2625)
        {
            float a = Random.Range(0.0f, 12.0f);
            float asd = 0;

            for (int i = 0; i < 30; i++)
            {
                GMComponent gmcObj = Instantiate(object722, new Vector2(GM.offsetX + 400, GM.offsetY - 80), Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 10;
                gmcObj.Direction = a + asd;

                gmcObj.gameObject.GetComponent<Object722>().nachi = 1;

                asd += 360.0f / 30.0f;
            }
        }

        if (t == 2655)
        {
            float a = Random.Range(0.0f, 12.0f);
            float asd = 0;

            for (int i = 0; i < 30; i++)
            {
                GMComponent gmcObj = Instantiate(object722, new Vector2(GM.offsetX + 400, GM.offsetY - 80), Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 10;
                gmcObj.Direction = a + asd;

                gmcObj.gameObject.GetComponent<Object722>().nachi = 2;

                asd += 360.0f / 30.0f;
            }
        }

        if (t == 2698)
        {

            GMComponent gmcObj = Instantiate(roopdayo, new Vector2(GM.offsetX + 400, GM.offsetY - 50), Quaternion.identity)
                .GetComponent<GMComponent>();
            gmcObj.Speed = 10;
            gmcObj.Direction = 180;


            gmcObj = Instantiate(roopdayo, new Vector2(GM.offsetX + 400, GM.offsetY - 50), Quaternion.identity)
                .GetComponent<GMComponent>();
            gmcObj.Speed = 10;
            gmcObj.Direction = 0;

            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Roopdayo"))
            {
                go.GetComponent<Roopdayo>().StartAlarm("Alarm1" , 1);
            }
        }

        if (t == 2737)
        {
            float a = Random.Range(0.0f, 12.0f);
            float asd = 0;

            for (int i = 0; i < 30; i++)
            {
                GMComponent gmcObj = Instantiate(hanabi, new Vector2(GM.offsetX + 400, GM.offsetY - 80), Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 10;
                gmcObj.Direction = a + asd;

                asd += 360.0f / 30.0f;
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Roopdayo"))
            {
                go.GetComponent<Roopdayo>().StopAlarm("Alarm1");
                Destroy(go);
            }
        }

        if (t == 2770)
        {
            float a = Random.Range(0.0f, 12.0f);
            float asd = 0;

            for (int i = 0; i < 30; i++)
            {
                GMComponent gmcObj = Instantiate(hadou, new Vector2(GM.offsetX + 400, GM.offsetY - 80), Quaternion.identity)
                    .GetComponent<GMComponent>();

                gmcObj.Speed = 14;
                gmcObj.Direction = a + asd;

                asd += 360.0f / 30.0f;
            }

            Instantiate(gurun, new Vector2(GM.offsetX + 400, GM.offsetY - 80), Quaternion.identity)
                .GetComponent<Gurun>().StartAlarm("Alarm2", 1);
        }

        if (t == 2999)
        {
            Jikihazusi j = Instantiate(jikihazusi).GetComponent<Jikihazusi>();
            j.preventAlarm0 = true;
            j.StopAlarm("Alarm0");
            j.StartAlarm("Alarm2", 1);
            
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object871"))
            {
                GMComponent gmcObj = go.GetComponent<GMComponent>();

                gmcObj.Direction = GMComponent.PointDirection(
                    go.transform.position.x, go.transform.position.y,
                    player.transform.position.x, player.transform.position.y);
                gmcObj.Speed = -20;
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Hanabi"))
            {
                go.GetComponent<GMComponent>().Speed = 0.5f;
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Gurun"))
            {
                Gurun g = go.GetComponent<Gurun>();
                g.StopAlarm("Alarm2");
                g.StopAlarm("Alarm1");
            }
        }

        if (t == 3035)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Jikihazusi"))
            {
                go.GetComponent<Jikihazusi>().StopAlarm("Alarm2");
                Destroy(go);
            }
        }

        if (t == 3070)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Gurun"))
            {
                go.GetComponent<Gurun>().StartAlarm("Alarm3",1);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Hanabi"))
            {
                go.GetComponent<GMComponent>().Speed = 12.0f;
            }
        }

        if (t == 3371)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Gurun"))
            {
                go.GetComponent<Gurun>().StopAlarm("Alarm3");
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Object915"))
            {
                go.GetComponent<GMComponent>().Speed = 0.5f;
            }
        }

        if (t == 3426)
        {
            GMComponent gmcObj = Instantiate(ransu, new Vector2(player.transform.position.x, GM.offsetY), Quaternion.identity)
                .GetComponent<GMComponent>();
            gmcObj.Direction = 270;
            gmcObj.Speed = 17;
        }

        if (t == 3446)
        {
            GMComponent gmcObj = Instantiate(ransu, new Vector2(player.transform.position.x, GM.offsetY), Quaternion.identity)
                .GetComponent<GMComponent>();
            gmcObj.Direction = 270;
            gmcObj.Speed = 17;
        }

        if (t == 3524)
        {
            GMComponent gmcObj = Instantiate(ransu, new Vector2(player.transform.position.x, GM.offsetY), Quaternion.identity)
                .GetComponent<GMComponent>();
            gmcObj.Direction = 270;
            gmcObj.Speed = 17;
        }

        if (t == 3545)
        {
            GMComponent gmcObj = Instantiate(ransu, new Vector2(player.transform.position.x, GM.offsetY), Quaternion.identity)
                .GetComponent<GMComponent>();
            gmcObj.Direction = 270;
            gmcObj.Speed = 17;
        }

        if (t == 3575)
        {
            GMComponent gmcObj = Instantiate(ransu, new Vector2(player.transform.position.x, GM.offsetY), Quaternion.identity)
                .GetComponent<GMComponent>();
            gmcObj.Direction = 270;
            gmcObj.Speed = 17;
        }

        if (t == 3600)
        {
            GMComponent gmcObj = Instantiate(ransu, new Vector2(player.transform.position.x, GM.offsetY), Quaternion.identity)
                .GetComponent<GMComponent>();
            gmcObj.Direction = 270;
            gmcObj.Speed = 17;
        }

        if (t == 3632)
        {
            GMComponent gmcObj = Instantiate(ransu, new Vector2(player.transform.position.x, GM.offsetY), Quaternion.identity)
                .GetComponent<GMComponent>();
            gmcObj.Direction = 270;
            gmcObj.Speed = 17;
        }

        if (t == 3670)
        {
            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Object915"))
            {
                go.GetComponent<GMComponent>().Speed = 0;
                go.GetComponent<Object915>().StartAlarm("Alarm0", 1);
            }

            Instantiate(tateyure);

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Kurakunaru"))
            {
                go.GetComponent<Kurakunaru>().StartAlarm("Alarm1",1);
            }
            
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Kurai"))
            {
                Destroy(go);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Ransuyou"))
            {
                Destroy(go);
            }
        }

        if (t == 3800)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Ransuyou2"))
            {
                Destroy(go);
            }
        }

        if (t == 3850)
        {
            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Tateyure"))
            {
                go.GetComponent<Tateyure>().StopAlarm("Alarm1");
                Destroy(go);
            }

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("Kurakunaru"))
            {
                go.GetComponent<Kurakunaru>().StopAlarm("Alarm1");
                Destroy(go);
            }

            Instantiate(tenmetsuda);

            aSource.Stop();

            GameManager.Instance.PlaySound("BossDeath");

            Instantiate(gameClearWarp);

            ResetCameraPos();

            bossFinished = true;
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

        float[] _objX = { 736,720,704,704,704,704,704,704,688,672,672,672,672,672,672,656,640,656,672,688,704,720 };

        float[] _objY = { 128,128,128,112,96,80,64,48,48,48,64,80,96,112,128,128,128,144,160,176,160,144 };

        for (int i = 0; i < 22; i++)
        {
            GMComponent gmcObj =
                Instantiate(go, new Vector2(x, y), Quaternion.identity)
                .GetComponent<GMComponent>();

            gmcObj.Speed = GMComponent.PointDistance(x, y, GM.offsetX + _objX[i], (GM.offsetY - _objY[i])) / s;
            gmcObj.Direction = GMComponent.PointDirection(x, y, GM.offsetX + _objX[i], (GM.offsetY - _objY[i]));
        }
    }

    void Script90(GameObject go, float x, float y, float s)
    {
        x += GM.offsetX;
        y = GM.offsetY - y;

        float[] _objX = new float[44];

        float[] _objY = new float[44];

        _objX[0] = 752;
        _objY[0] = 112;

        _objX[1] = 752;
        _objY[1] = 128;

        _objX[2] = 752;
        _objY[2] = 144;

        _objX[3] = 736;
        _objY[3] = 112;

        _objX[4] = 720;
        _objY[4] = 112;

        _objX[5] = 704;
        _objY[5] = 112;

        _objX[6] = 688;
        _objY[6] = 112;

        _objX[7] = 672;
        _objY[7] = 112;

        _objX[8] = 672;
        _objY[8] = 96;

        _objX[9] = 672;
        _objY[9] = 80;

        _objX[10] = 656;
        _objY[10] = 96;

        _objX[11] = 640;
        _objY[11] = 112;

        _objX[12] = 624;
        _objY[12] = 128;

        _objX[13] = 640;
        _objY[13] = 144;

        _objX[14] = 656;
        _objY[14] = 160;

        _objX[15] = 672;
        _objY[15] = 176;

        _objX[16] = 672;
        _objY[16] = 160;

        _objX[17] = 672;
        _objY[17] = 144;

        _objX[18] = 688;
        _objY[18] = 144;

        _objX[19] = 704;
        _objY[19] = 144;

        _objX[20] = 736;
        _objY[20] = 144;

        _objX[21] = 720;
        _objY[21] = 144;

        _objX[22] = 752;
        _objY[22] = 464;

        _objX[23] = 752;
        _objY[23] = 480;

        _objX[24] = 752;
        _objY[24] = 496;

        _objX[25] = 736;
        _objY[25] = 496;

        _objX[26] = 720;
        _objY[26] = 496;

        _objX[27] = 704;
        _objY[27] = 496;

        _objX[28] = 688;
        _objY[28] = 496;

        _objX[29] = 672;
        _objY[29] = 496;

        _objX[30] = 672;
        _objY[30] = 464;

        _objX[31] = 688;
        _objY[31] = 464;

        _objX[32] = 704;
        _objY[32] = 464;

        _objX[33] = 720;
        _objY[33] = 464;

        _objX[34] = 736;
        _objY[34] = 464;

        _objX[35] = 672;
        _objY[35] = 448;

        _objX[36] = 672;
        _objY[36] = 512;

        _objX[37] = 656;
        _objY[37] = 512;

        _objX[38] = 640;
        _objY[38] = 496;

        _objX[39] = 624;
        _objY[39] = 480;

        _objX[40] = 672;
        _objY[40] = 528;

        _objX[41] = 672;
        _objY[41] = 432;

        _objX[42] = 656;
        _objY[42] = 448;

        _objX[43] = 640;
        _objY[43] = 464;

        for (int i = 0; i < 44; i++)
        {
            GMComponent gmcObj =
                Instantiate(go, new Vector2(x, y), Quaternion.identity)
                .GetComponent<GMComponent>();

            gmcObj.Speed = GMComponent.PointDistance(x, y, GM.offsetX + _objX[i], (GM.offsetY - _objY[i])) / s;
            gmcObj.Direction = GMComponent.PointDirection(x, y, GM.offsetX + _objX[i], (GM.offsetY - _objY[i]));
        }
    }
}
