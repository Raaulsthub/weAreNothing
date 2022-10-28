using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPC_movement : MonoBehaviour
{
    public GameObject dialoguePanel;
    public GameObject button;
    public Text dialogueText;
    public string[] dialogue;
    private int index;
    public float wordSpedd;
    public bool playerClose;
    public float speed;
    public float tempoAndando;
    public float tempoParado;
    private Animator animation;
    private Rigidbody2D rigidBody;
    private bool running;
    private bool lado;
    private float countParado;
    private float countAndando;
    public bool grounded;
    public bool conversando;
    void Start()
    {
        animation = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        running = false;
        conversando = false;
        lado = true;
        countAndando = tempoAndando;
        countParado = tempoParado;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerClose){
            conversando = true;
            if(dialoguePanel.activeInHierarchy){
                zeroText();
            }
            else{
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
        if(dialogueText.text == dialogue[index]){
            button.SetActive(true);
        }
        if(grounded && !conversando){
            if(countAndando>0){
                running = true;
                if(lado){
                    rigidBody.velocity = new Vector2(-speed,0);
                }
                else{
                    rigidBody.velocity = new Vector2(speed,0);
                }
                countAndando -= Time.deltaTime;
            }
            else{
                if(countParado>0){
                    countParado -= Time.deltaTime;
                    running = false;
                }
                else{
                    countAndando = tempoAndando;
                    countParado = tempoParado;
                    lado = !lado;
                }
            }
            
            if(running){
                animation.SetBool("running", true);
                if(lado){
                    animation.SetInteger("lado", 1);
                }
                else{
                    animation.SetInteger("lado", 0);
                }
            }
            else{
                animation.SetBool("running", false);
            }
        }
        
    }

    public void zeroText(){
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        conversando = false;
    }

    IEnumerator Typing(){
        foreach(char letter in dialogue[index].ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpedd);
        }
    }

    public void nextLine(){
        button.SetActive(false);
        if(index < dialogue.Length - 1){
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else{
            zeroText();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        if(collision.gameObject.tag == "Player"){
            playerClose = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
        if(collision.gameObject.tag == "Player"){
            playerClose = false;
            zeroText();
        }
        
    }

}
