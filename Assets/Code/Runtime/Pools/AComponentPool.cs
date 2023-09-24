using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class AComponentPool<T> : MonoBehaviour where T : MonoBehaviour
{
	protected abstract T Prefab { get; }
	protected abstract int MaxActive { get; }
	private ObjectPool<T> pool;
	private GameObject holder;

	private HashSet<T> activeComponents;
	public IReadOnlyCollection<T> ActiveComponents
		=> activeComponents;
	public int ActiveComponentsCount
	=> pool.CountActive;

	public event Action<T> OnRelease;
	public event Action<T> OnGet;

	protected virtual T CreateFunc()
	{
		if (holder == null)
			holder = new GameObject(GetType().Name);

		T newShooter = Instantiate(Prefab, holder.transform);
		return newShooter;
	}
	protected virtual void GetFunc(T component)
		=> component.gameObject.SetActive(true);
	protected virtual void ReleaseFunc(T component)
		=> component.gameObject.SetActive(false);
	protected virtual void DestroyFunc(T component)
		=> Destroy(component.gameObject);

	public T Get()
	{
		T newComponent = pool.Get();
		activeComponents.Add(newComponent);
		OnGet?.Invoke(newComponent);
		return newComponent;
	}
	public void Release(T component)
	{
		pool.Release(component);
		activeComponents.Remove(component);
		OnRelease?.Invoke(component);
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