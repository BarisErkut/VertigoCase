# Vertigo Games Game Developer Demo

Hi, I'm Barış Erkut. This is a 2D Wheel of Fortune interface I developed for the Vertigo Games interview process. I designed the project using Unity 2021 LTS. In this README.md file, I have put together a brief report to share my development process over the last week.
## Download and Test
You can download and test the latest version (`.apk`) I compiled for Android devices from the **Releases** section on the right side of this repository. I have also included a short gameplay video and screenshots of the game in different resolutions in my email. 

## Key Features
* **Dynamic Wheel Structure:** I configured Bronze, Silver, and Gold wheel setups that change based on the player's current zone. Each wheel type has its own reward pool.
* **Zone System:** I implemented the risk-free Safe Zone mechanic every 5 levels and a Super Zone with special rewards every 30 levels.
* **Risk and Reward:** I provided the player with the option to collect their earned rewards and leave at any time (Cash Out) or take a risk and continue playing.
* **Death Mechanic:** I implemented a penalty system where all collected rewards are lost if the wheel lands on the bomb slice.

## Architecture and Optimization
I built the codebase in accordance with SOLID principles and Object-Oriented Programming (OOP) standards to ensure it is maintainable.

* **Manager Classes:** I divided the game loop based on responsibilities and controlled it through Manager scripts that I set up.
* **Data-Driven Design:** I made the wheel contents and reward pools editable without touching the code by utilizing a Scriptable Object architecture.
* **UI Optimization:** I disabled the "Raycast Target" and "Maskable" properties on all non-interactive objects to prevent unnecessary draw calls and increase performance.
* **Responsive UI:** I prepared the interface design with strict Anchor/Pivot rules to adapt perfectly to 20:9, 16:9, and 4:3 aspect ratios without any stretching. I set the Canvas Scale Mode to "Expand" as requested in the documentation.
* **Animations:** I managed all UI animations via code using DOTween instead of relying on the root Canvas Animator component.

## Future Improvements (With More Time)
While the core requirements are fully met, If I had more time, I would implement the following features to enhance the game's depth and longevity:

1. **Dynamic Reward Tiering:** In this demo, First zone's standart wheel has the same reward pool as 91st zone's standart wheel. I would improve tiered reward pools that unlock as the player progresses, ensuring that the stakes and prizes become significantly more valuable in higher zones.
2. **Weighted Probability and Difficulty System:** As the game continues, instead of a flat 1/8 chance for all slices, I would implement a weighted probability system where reward rarity determines its drop rate, adding a deeper layer of "risk vs. reward" tension.
3. **Persistent Meta-Progression:** I would add a persistent inventory that tracks player progress across multiple sessions, giving players a sense of long-term achievement even after a reset.
4. **Revive/Continue System:** Currently, the "REVIVE" and the "WATCH AD" buttons are free to use. I would like to implement the google ads API.


