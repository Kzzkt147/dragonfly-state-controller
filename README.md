# Dragonfly State Controller

A node-based state controller for setting up enemy behaviours in unity. Create new state nodes and add your own actions and conditions to them in a node editor. The state controller will move between connected nodes depending on conditions that you have set on each node.

You can create your own actions and conditions(decisions) to add to these nodes - more info below.

![NodeGraph](https://user-images.githubusercontent.com/79820324/178208790-dbe29a2e-e013-4a1b-8272-77a78c0b4a3d.PNG)


## Download
<details><summary>Download & Installation</summary>

[Download](https://github.com/Kzzkt147/enemy-state-controller/releases)

### Installation
Download the unity package and import it into your unity project. <br>
![Package](img/Import.PNG)
</details>
<br>

# How to Use

## Setting up nodes

1. Create a new behaviour graph in your project folder **(Create>BehaviourGraph)**. <br>
![MakeGraph](https://user-images.githubusercontent.com/79820324/178208717-b8a56636-a856-4753-879e-60ac64857beb.gif)


2. Inside the graph, right click to add state nodes. Connect a start node to the state node that the enemy will begin on. <br>
![CreateNode](https://user-images.githubusercontent.com/79820324/178208811-f9e5f8d4-0e20-4626-9656-29d04aea205a.gif)


3. Assign an action to the state node and add as many decisions as needed. Actions will dictate what the state controller does when the state is active, and decisions are conditionals - when they are met, it will switch the connected state.<br>
![SetupNode](https://user-images.githubusercontent.com/79820324/178208829-368220c5-4460-4375-a6ad-2f72572edb4e.gif)


4. Add a StateTicker component to your enemy, and assign the graph we created to the EnemyController.<br>
![SetupController](https://user-images.githubusercontent.com/79820324/178208846-6474e0cf-0a7f-4b70-b307-aff6b0d9c392.gif)


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
![CreateAsset](https://user-images.githubusercontent.com/79820324/178208864-e30e8431-d7db-4f8f-8721-424109bac2fc.gif)


### Decisions
Create a new script and inherit your class from the abstract 'Decision' class, making sure to implement the abstract methods from 'Decision'. Because this is a scriptable object, add a 'CreateAssetMenu' attribute and create an instance of the class as an object. When returning true, the state controller will change the current state to the state that is connected to this decision.
```cs
[CreateAssetMenu(menuName = "Enemy/Decisions/ExampleDecision", fileName = "ExampleDecision")]
public class ExampleDecision : Decision {
    public override bool HandleDecision(StateController controller) {
        // this should contain conditional code that will return true or false. 
        return false;
    }
}
```

### Extra Notes
Each action and decision is a scriptable object - meaning that if two enemies share the same action as behaviour, they are sharing the same instance of that script. To make sure there are no conflicts in their behaviour, do not create any new variables in these scripts and should instead be taking everything from the state controller.
<br>
<br>
**See example scene for more info on setting things up.**

# Sources

### Xnode

[Xnode](https://github.com/Siccity/xNode)

### License
[MIT License](LICENSE.txt)

### Pluggable AI Template
[Unity Pluggable AI Series](https://www.youtube.com/watch?v=cHUXh5biQMg&list=PLX2vGYjWbI0ROSj_B0_eir_VkHrEkd4pi) Formed the basis of the core idea.

# Features Checklist
### TODO
- [X] Scriptable Object Actions and Decisions
- [X] State Controller to use behaviours
- [X] Node graph to view and create behaviours
- [X] Seperate node parser and state controller
- [ ] More thorough testing
