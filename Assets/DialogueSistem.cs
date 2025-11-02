using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueSistem : MonoBehaviour
{
    public static DialogueSistem Instance;

    [Header("UI Elements")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private TMP_Text speakerName;

    [Header("Audio")]
    [SerializeField] private AudioSource voiceSource; // Fuente de audio para las voces

    private Queue<string> sentences;
    private string currentSpeaker;

    private Dictionary<int, Dialogue> dialogues = new Dictionary<int, Dialogue>();
    private Dialogue activeDialogue;
    private int currentIndex = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        sentences = new Queue<string>();
        dialoguePanel.SetActive(false);

        RegisterDialogues();
    }

    void RegisterDialogues()
    {
        //NPC1
        AudioClip npc1_1 = Resources.Load<AudioClip>("Audio/Dialogue/NPC1/NPC1_Line1");
        AudioClip npc1_2 = Resources.Load<AudioClip>("Audio/Dialogue/NPC1/NPC1_Line2");
        AudioClip npc1_3 = Resources.Load<AudioClip>("Audio/Dialogue/NPC1/NPC1_Line3");
        AudioClip npc1_4 = Resources.Load<AudioClip>("Audio/Dialogue/NPC1/NPC1_Line4");
        AudioClip npc1_5 = Resources.Load<AudioClip>("Audio/Dialogue/NPC1/NPC1_Line5");
        AudioClip npc1_6 = Resources.Load<AudioClip>("Audio/Dialogue/NPC1/NPC1_Line6");

        //Rowan
        AudioClip rowan_1 = Resources.Load<AudioClip>("Audio/Dialogue/Rowan/RL1");
        AudioClip rowan_2 = Resources.Load<AudioClip>("Audio/Dialogue/Rowan/RL2");
        AudioClip rowan_3 = Resources.Load<AudioClip>("Audio/Dialogue/Rowan/RL3");
        AudioClip rowan_4 = Resources.Load<AudioClip>("Audio/Dialogue/Rowan/RL4");
        AudioClip rowan_5 = Resources.Load<AudioClip>("Audio/Dialogue/Rowan/RL5");
        AudioClip rowan_6 = Resources.Load<AudioClip>("Audio/Dialogue/Rowan/RL6");
        AudioClip rowan_7 = Resources.Load<AudioClip>("Audio/Dialogue/Rowan/RL7");
        AudioClip rowan_8 = Resources.Load<AudioClip>("Audio/Dialogue/Rowan/RL8");
        AudioClip rowan_9 = Resources.Load<AudioClip>("Audio/Dialogue/Rowan/RL9");
        AudioClip rowan_10 = Resources.Load<AudioClip>("Audio/Dialogue/Rowan/RL10");
        AudioClip rowan_11 = Resources.Load<AudioClip>("Audio/Dialogue/Rowan/RL11");
        AudioClip rowan_12 = Resources.Load<AudioClip>("Audio/Dialogue/Rowan/RL12");
        AudioClip rowan_13 = Resources.Load<AudioClip>("Audio/Dialogue/Rowan/RL13");
        AudioClip rowan_14 = Resources.Load<AudioClip>("Audio/Dialogue/Rowan/RL14");

        //NPC2
        AudioClip npc2_1 = Resources.Load<AudioClip>("Audio/Dialogue/NPC2/NPC2_Line1");
        AudioClip npc2_2 = Resources.Load<AudioClip>("Audio/Dialogue/NPC2/NPC2_Line2");
        AudioClip npc2_3 = Resources.Load<AudioClip>("Audio/Dialogue/NPC2/NPC2_Line3");
        AudioClip npc2_4 = Resources.Load<AudioClip>("Audio/Dialogue/NPC2/NPC2_Line4");
        AudioClip npc2_5 = Resources.Load<AudioClip>("Audio/Dialogue/NPC2/NPC2_Line5");
        AudioClip npc2_6 = Resources.Load<AudioClip>("Audio/Dialogue/NPC2/NPC2_Line6");
        AudioClip npc2_7 = Resources.Load<AudioClip>("Audio/Dialogue/NPC2/NPC2_Line7");
        AudioClip npc2_8 = Resources.Load<AudioClip>("Audio/Dialogue/NPC2/NPC2_Line8");
        AudioClip npc2_9 = Resources.Load<AudioClip>("Audio/Dialogue/NPC2/NPC2_Line9");
        AudioClip npc2_10 = Resources.Load<AudioClip>("Audio/Dialogue/NPC2/NPC2_Line10");


        dialogues.Add(1, new Dialogue(
            new string[]
            {
                "Hola, eres nueva por aquí... Nunca te había visto.",
                "Hola, mi nombre es Rowan. Estoy buscando a mi hermano ¿Lo has visto?",
                "No he visto otro humano por aquí, pero NPC2 podría ayudarte. Es muy bueno recordando rostros.",
                "¿En serio?, ¿Dónde puedo encontrarlo?",
                "Debes seguir el camino y lo hallarás en el círculo de las runas.",
                "¡Gracias!",
                "¡Ten cuidado!, el bosque esconde muchos peligros, no bajes la guardia."
            },
            new string[]
            {
                "NPC 1",
                "Rowan",
                "NPC 1",
                "Rowan",
                "NPC 1",
                "Rowan",
                "NPC 1"
            },
            new AudioClip[] {
                
            }
        ));

        dialogues.Add(2, new Dialogue(
            new string[]
            {
                "Gracias por salvarme pequeña pero no podré quedarme a charlar contigo.",
                "Estos maleantes se llevaron mis runas y ahora no podré salir del bosque.",
                "Qué pena... Yo podría ayudarte a recuperarlas pero también necesito tu ayuda.",
                "¡Qué valiente! Haciendo tratos con un desconocido. Muy bien niña deberás revelar los secretos de este bosque para encontrarlas.",
                "Las flores azules se inclinan hacia lo que guardan. Sigue su mirada y lo encontrarás.",
            },
            new string[]
            {
                "NPC 2",
                "NPC 2",
                "Rowan",
                "NPC 2",
                "NPC 2",
            },
            new AudioClip[] { }
        ));

        dialogues.Add(3, new Dialogue(
            new string[]
            {
                "¡Lo conseguiste!. Estoy impresionado para alguien de tu tamaño.",
                "Bien pero eso no es todo.",
                "“Entre tres guardianes de madera caídos hallarás el fruto que no crece en rama alguna, cuidado con las termitas.”",
            },
            new string[]
            {
                "NPC2",
                "NPC2",
                "NPC2"
            },
            new AudioClip[] { }
        ));

        dialogues.Add(4, new Dialogue(
            new string[]
            {
                "¡Bravo!. Estamos cada vez más cerca.",
                "“No siempre lo nuevo abre caminos; a veces, el regreso trae la salida. Vuelve sobre tus huellas y hallarás lo que antes estaba sellado.”",
            },
            new string[]
            {
                "NPC2",
                "NPC2",
            },
            new AudioClip[] { }
        ));

        dialogues.Add(5, new Dialogue(
            new string[]
            {
                "¡Lo lograste!. Derrotaste a la gran calabaza. Ahora... ¿en qué necesitas ayuda?",
                "Nunca vi un ser tan diminuto peleando así.",
                "No fue fácil... pero ¿qué abre esta llave?",
                "Necesito encontrar a mi hermano.",
                "Lo que persigues está al otro lado. Tu hermano aguarda… aunque ya no sea el mismo que recuerdas.",
            },
            new string[]
            {
                "NPC2",
                "NPC2",
                "Rowan",
                "Rowan",
                "NPC2",
            },
            new AudioClip[] { }
        ));

        dialogues.Add(6, new Dialogue(
            new string[]
            {
                "¡Eh, tú! No había visto a nadie por aquí en días…",
                "No quiero problemas, solo busco a alguien que pueda ayudarme.",
                "¿Qué necesitas, pequeña?",
                "Necesito encontrar a mi hermano. Entró en el bosque y… lo perdí de vista. ¿Lo has visto por aquí?",
                "No, no he visto a ningún muchacho. Pero quizás NPC2 pueda ayudarte. Vive en el árbol más grande del bosque, el que sobresale entre todos los demás.",
                "¿NPC2? ¿Crees que él sepa algo?",
                "Si alguien ha visto a tu hermano, es ella. Pero escúchame bien, niña… ten cuidado en el camino.",
                "¿Por qué?",
                "Hay cosas moviéndose entre los árboles. No son amistosas. Si los escuchas, no corras: agáchate, quédate quieta y deja que pasen.",
                "Entendido… seré sigilosa. Gracias por advertirme.",
                "No me las des todavía. Encuentra a tu hermano… y no dejes que el bosque te encuentre primero.",
            },
            new string[]
            {
                "NPC1",
                "Rowan",
                "NPC1",
                "Rowan",
                "NPC1",
                "Rowan",
                "NPC1",
                "Rowan",
                "NPC1",
                "Rowan",
                "NPC1",
            },
            new AudioClip[] {
                npc1_1,
                rowan_1,
                npc1_2, 
                rowan_2,
                npc1_3,
                rowan_3,
                npc1_4,
                rowan_4,
                npc1_5,
                rowan_5,
                npc1_6,
            
            }
        ));

        dialogues.Add(7, new Dialogue(
            new string[]
            {
                "No muchos se atreven a llegar hasta aquí. ¿Quién eres, niña?",
                "Soy Rowan. NPC1 me dijo que viniera a verte. Estoy buscando a mi hermano… entró al bosque y no he vuelto a verlo.",
                "Ah, sí… NPC1. Siempre ha enviado problemas hacia mí.",
                "¿Lo has visto? Desde aquí puedes ver todo, ¿verdad?",
                "He visto sombras moviéndose entre los árboles. No sé si eran tu hermano o algo más…",
                "¿Sabes cómo puedo salir de este lugar? Cada camino me lleva de nuevo al mismo punto.",
                "Hay una salida… justo aquí. Pero está bloqueada por la oscuridad.",
                "¿Oscuridad?",
                "La sombra cubre todo lo que fue luz. Para alejarla, debes hacer que las antorchas de la cueva vuelvan a encenderse. Cuando la luz renazca, el paso se abrirá.",
                "¿Y dónde está esa cueva?",
                "Algunos árboles tienen marcas de la oscuridad. Pero ve con cuidado, a la oscuridad no le gusta que la despierten.",
                "¿Despertarla?",
                "La oscuridad es un ser, se encargó de apagar todo. Para vencerla debes alumbrar la cueva.",
                "Entiendo... entonces tendré que encenderlas y enfrentar a la oscuridad para salir de aquí.",
                "Sí. Y tal vez, con la luz, también encuentres lo que buscas.",
                "Recuerda, pequeña: no temas a la oscuridad… pero no la desafíes demasiado tiempo.",
            },
            new string[]
            {
                "NPC2",
                "Rowan",
                "NPC2",
                "Rowan",
                "NPC2",
                "Rowan",
                "NPC2",
                "Rowan",
                "NPC2",
                "Rowan",
                "NPC2",
                "Rowan",
                "NPC2",
                "Rowan",
                "NPC2",
                "NPC2",
            },
            new AudioClip[] {
                npc2_1,
                rowan_6,
                npc2_2,
                rowan_7,
                npc2_3,
                rowan_8,
                npc2_4,
                rowan_9,
                npc2_5,
                rowan_10,
                npc2_6,
                rowan_11,
                npc2_7,
                rowan_12,
                npc2_8,
                
            
            }
        ));

        dialogues.Add(8, new Dialogue(
            new string[]
            {
                "Gracias Rowan!! Por devolver la luz a este lugar, pasó tanto tiempo que olvidé cómo se sentía la luz.",
                "No fue fácil, pero fue posible gracias a tus consejos.",
                "Rowan, he visto un niño pasar esta puerta, detrás de ella hay un gran laberinto, y es en donde muchos fallan.",
                "Faltan 2 minutos para que el sol se vuelva a poner, si logras encontrar a tu hermano antes de ese tiempo, lograrán salir ambos de este mundo traicionero.",
                "¿Solo tengo dos minutos?",
                "Sí, date prisa, el tiempo vuela Rowan, te deseo mucha suerte.",
            },
            new string[]
            {
                "NPC2",
                "Rowan",
                "NPC2",
                "NPC2",
                "Rowan",
                "NPC2",
            },
            new AudioClip[] {
                npc2_9,
                rowan_13,
                npc2_10,
            }
        ));
    }

    public void StartDialogue(int dialogueID)
    {
        if (!dialogues.ContainsKey(dialogueID))
        {
            Debug.LogWarning("No existe el diálogo con ID " + dialogueID);
            return;
        }

        dialoguePanel.SetActive(true);
        sentences.Clear();

        activeDialogue = dialogues[dialogueID];
        currentIndex = 0;

        for (int i = 0; i < activeDialogue.sentences.Length; i++)
        {
            sentences.Enqueue(activeDialogue.speakers[i] + "|" + activeDialogue.sentences[i]);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (voiceSource != null && voiceSource.isPlaying)
            voiceSource.Stop();

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string rawSentence = sentences.Dequeue();
        string[] parts = rawSentence.Split('|');
        currentSpeaker = parts[0];
        string sentence = parts[1];

        speakerName.text = currentSpeaker;
        dialogueText.text = sentence;

        if (activeDialogue.voiceClips != null && currentIndex < activeDialogue.voiceClips.Length)
        {
            AudioClip clip = activeDialogue.voiceClips[currentIndex];
            if (clip != null && voiceSource != null)
                voiceSource.PlayOneShot(clip);
        }

        currentIndex++;
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        if (voiceSource != null && voiceSource.isPlaying)
            voiceSource.Stop();

        Debug.Log("Fin del diálogo.");
    }
}

[System.Serializable]
public class Dialogue
{
    public string[] sentences;
    public string[] speakers;
    public AudioClip[] voiceClips;

    public Dialogue(string[] s, string[] sp, AudioClip[] vc = null)
    {
        sentences = s;
        speakers = sp;
        voiceClips = vc;
    }
}
