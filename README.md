# Enemy State Controller

A node-based state controller for setting up enemy behaviours in unity. Create your own custom actons and conditional state transitions.

![Node Graph](images/NodeGraph.png)

## Download
<details><summary>Download & Installation</summary>

[Download](https://github.com/Kzzkt147/enemy-state-controller/releases)

### Installation
Download the unity package and import it into your unity project.
![Package](images/Import.PNG)
</details>
<br>

# How to Use

## Setting up nodes

1. Create a new behaviour graph in your project folder **(Create>BehaviourGraph)**.
![Make Graph](images/MakeGraph.gif)

2. Inside the graph, right click to add state nodes. Connect a start node to the state node that the enemy will begin on.
![Create Node](images/CreateNode.gif)

3. Assign an action to the state node and add as many decisions as needed. Actions will dictate what the state controller does when the state is active, and decisions are conditionals - when they are met, it will switch the connected state.
![Setup Node](images/SetupNode.gif)

4. Assign the graph we just created to the state controller on the enemy.
![Setup Controller](images/SetupController.gif)

## Creating Actions and Decisions

### Actions
Create a new script and inherit your class from the abstract 'Action' class, making sure to implement the abstract methods from 'Action'. Because this is a scriptable object, add a 'CreateAssetMenu' attribute and create an instance of the class as an object.
```cs
[CreateAssetMenu(menuName = "Enemy/Actions/ExampleAction", fileName = "ExampleAction")]
public class ExampleAction : Action {

    public override void StartActions(StateController controller) {
        // this code will run when we enter the state.
    }

    public override void UpdateActions(StateController controller) {
        // this code will update every frame that the state is running.
    }

    public override void FixedUpdateActions(StateController controller) {
        // this code will update every physics update that the state is running.
    }
}
```
![Create Asset](images/CreateAsset.gif)

### Decisions
Create a new script and inherit your class from the abstract 'Decision' class, making sure to implement the abstract methods from 'Decision'. Because this is a scriptable object, add a 'CreateAssetMenu' attribute and create an instance of the class as an object.
```cs
[CreateAssetMenu(menuName = "Enemy/Decisions/ExampleDecision", fileName = "ExampleDecision")]
public class ExampleDecision : Decision {
    public override bool HandleDecision(StateController controller) {
        // this should contain conditional code that will return true or false. 
        return false;
    }
}
```