# Popper

## Description
**Popper** is a balloon-shooting VR game designed for Meta VR devices like the Oculus Quest. This repository contains only the C# script files and does not include any Unity project files. Despite its simplicity, Popper is a fully playable game available for sale in the official Oculus Rift Store.

In Popper, players use dart guns, crossbows, and other creative methods to pop balloons across 16 dynamic levels, including environments like Playground, Western, and Moon. The game features a high-score system, engaging sound effects, and music, providing a fun and immersive experience in virtual reality.

While the code quality reflects the experimental nature of an early Unity/C# project, the game successfully passed all Oculus Quality Assurance validations, marking a significant milestone in its development.

## Features
- **Balloon Popping Mechanics**: Shoot balloons with various weapons like dart guns and crossbows.
- **Dynamic Game Objects**: Objects interact dynamically with the environment, providing a rich gameplay experience.
- **16 Levels**: Includes environments such as Playground, Western, and Moon.
- **High-Score System**: Keep track of scores and aim for the highest points.
- **Sound Effects and Music**: Immersive audio enhances the VR experience.

## Installation
To use the C# scripts in your own Unity project, follow these steps:

1. **Clone the Repository:**
   ```bash
    git clone https://github.com/your-username/Popper.git
    
    cd Popper
    
2. **Integrate into Unity:**

    - Open your Unity project.
    - Copy the C# scripts from this repository into your project's Assets/Scripts directory.

3. **Configure the Scene:**

    - Set up your scene with the necessary game objects, such as balloons, weapons, and environmental elements.
    - Assign the scripts to the appropriate game objects in the Unity Editor.

4. **Build and Deploy:**

    - Build the project for the Oculus Quest or another Meta VR device.
    - Deploy and test the game in your VR environment.


## Example Function: MoveBalloon ##
Here's an example of one of the functions used in the game to move the balloons between waypoints:

    private void MoveBallon()
    {
        var lastWayPointIndex = wayPoints.Length - 1; // keep track of the last waypoint
        Vector3 lastWayPoint = wayPoints[lastWayPointIndex].transform.position + new Vector3(0, 2, 0);  // make lastWayPoint the position plus 2m above ground
        Vector3 nextWayPoint = wayPoints[nextWayPointIndex].transform.position + new Vector3(0, 2, 0);
        Vector3 direction = nextWayPoint - transform.position; // direction applied to the balloon

        if (Vector3.Distance(transform.position, lastWayPoint) > 0.1f)
        {
            speed = Waves.GetComponent<Waves>().balloonSpeed;
            // Keep moving towards the next waypoint
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        }

        if (Vector3.Distance(transform.position, nextWayPoint) < 0.5f && nextWayPointIndex < lastWayPointIndex)
        {
            nextWayPointIndex++;
        }

        if (nextWayPointIndex == lastWayPointIndex && Vector3.Distance(transform.position, lastWayPoint) < 0.5f)
        {
            dieSound.GetComponent<DieSound>().PlayDie();
            GameVariables.bummers++;
            Destroy(this.gameObject);
        }
    }


This function manages the movement of balloons along predetermined waypoints and handles their destruction upon reaching the final waypoint.

## License ##
This project is licensed under the MIT License. See the LICENSE file for more information.

