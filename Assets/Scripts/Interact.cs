using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour {
    public float range = 2.0f;

    private Camera camera;

	public Text interactText;

	public int[] code = new int[6];
	int curCode = 0;
	
    private void Start() {
        camera = Camera.main;
    }

	private bool isCodeCorrect() {
		return code[0] == 1 && code[1] == 1 && code[2] == 1 && code[3] == 0 && code[4] == 0 && code[5] == 1;
	}

    void Update () {
		RaycastHit hit;

		string message = "";

		if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range)) {
			if (Input.GetKeyDown(KeyCode.E)) {
				if (hit.transform.tag == "Door") {
					hit.transform.GetComponent<Door>().Open(isCodeCorrect() ? true : false);
				}
			}

			if (hit.transform.tag == "MainPizza") {
				GoalPizza pizza = hit.transform.GetComponent<GoalPizza>();

				if (pizza != null && pizza.CurrentState() == 8) {
					message = "Press E to eat pizza and start again.";

					if (Input.GetKeyDown(KeyCode.E)) {
						pizza.EatPizza();
					}
				}
			} else if (hit.transform.tag == "LeftLamp") {
				if (Input.GetKeyDown(KeyCode.E)) {
					code[curCode++] = 1;
					if (curCode == code.Length) curCode = 0;
				}
			} else if (hit.transform.tag == "RightLamp") {
				if (Input.GetKeyDown(KeyCode.E)) {
					code[curCode++] = 0;
					if (curCode == code.Length) curCode = 0;
				}
			}
		}
		interactText.text = message;
	}
}
