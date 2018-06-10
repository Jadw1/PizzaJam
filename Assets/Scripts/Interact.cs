using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour {
    public float range = 2.0f;

    private Camera camera;

	public Text interactText;

	public int[] code = new int[6];
	
    private void Start() {
        camera = Camera.main;
    }

	private bool isCodeCorrect() {
		return code[0] == 1 && code[1] == 0 && code[2] == 0 && code[3] == 1 && code[4] == 1 && code[5] == 1;
	}

	private void resetCode() {
		for (int i = 0; i < code.Length; i++) {
			code[i] = 0;
		}
	}

	private void inputCode(int c) {
		code[5] = code[4];
		code[4] = code[3];
		code[3] = code[2];
		code[2] = code[1];
		code[1] = code[0];
		code[0] = c;
	}

    void Update () {
		RaycastHit hit;

		string message = "";

        if (Input.GetKeyDown(KeyCode.R)) {
            GameObject.FindGameObjectWithTag("MainPizza").GetComponent<GoalPizza>().ResetLevel();
            RoomTower tower = GameObject.FindGameObjectWithTag("RoomStack").GetComponent<RoomTower>();
            tower.DeactivateDoorsInRooms();
            tower.TeleportToStart(transform);
        }

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range)) {
			if (Input.GetKeyDown(KeyCode.E)) {
				if (hit.transform.tag == "Door") {
					if (isCodeCorrect()) {
						hit.transform.GetComponent<Door>().Open(true);
						resetCode();
					} else {
						hit.transform.GetComponent<Door>().Open(false);
					}
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
					inputCode(1);
				}
			} else if (hit.transform.tag == "RightLamp") {
				if (Input.GetKeyDown(KeyCode.E)) {
					inputCode(0);
				}
			}
		}
		interactText.text = message;
	}
}
