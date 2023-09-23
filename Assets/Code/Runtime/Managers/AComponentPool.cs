using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Pool;

public abstract class AComponentPool<T> : MonoBehaviour where T : MonoBehaviour
{
	[SerializeField] T prefab;

	private ObjectPool<T> pool;
	private GameObject holder;
	abstract protected int MaxActive { get; }

	private HashSet<T> activeComponents;
	public IReadOnlyCollection<T> ActiveComponents
		=> activeComponents;
	public int ActiveComponentsCount
	=> pool.CountActive;

	virtual protected T CreateFunc()
	{
		if (holder == null)
			holder = new GameObject(this.GetType().Name);

		T newShooter = Instantiate(prefab, holder.transform);
		return newShooter;
	}
	virtual protected void GetFunc(T component)
		=> component.gameObject.SetActive(true);
	virtual protected void ReleaseFunc(T component)
		=> component.gameObject.SetActive(false);
	virtual protected void DestroyFunc(T component)
		=> Destroy(component.gameObject);

	public T Get()
	{
		T newComponent = pool.Get();
		activeComponents.Add(newComponent);
		return newComponent;
	}
	public void Release(T component)
	{

		pool.Release(component);
		activeComponents.Remove(component);
	}
	public void ReleaseAll()
	{
		foreach (var component in activeComponents)
			pool.Release(component);
		activeComponents.Clear();
	}

	private void Awake()
	{
		activeComponents = new HashSet<T>();
		pool = new ObjectPool<T>(CreateFunc, GetFunc, ReleaseFunc, DestroyFunc, false, MaxActive / 2, MaxActive);
	}
}