using XNode;

public abstract class BaseNode : Node 
{
	// default implementation of xnode method -- can ignore
	public override object GetValue(NodePort port) 
	{
		return null;
	}

	public abstract void ParseNode(EnemyController controller, BehaviourGraph graph);
	
	public virtual void StartActions(EnemyController controller)
	{

    }
	public virtual void UpdateActions(EnemyController controller)
	{

    }
	public virtual void FixedUpdateActions(EnemyController controller)
	{

    }
	public virtual void UpdateTransitions(EnemyController controller)
	{

    }
}