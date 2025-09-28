using System.Collections.Generic;


namespace Engine;


public class Entity
{
    public Entity()
    {
        entities.Add(this);
    }
    public void Dispose()
    {
        entities.Remove(this);
    }
    
    
    protected virtual void Begin      () { }
    protected virtual void Start      () { }
    protected virtual void BeginUpdate() { }
    protected virtual void EarlyUpdate() { }
    protected virtual void Update     () { }
    protected virtual void LateUpdate () { }
    protected virtual void Render     () { }
    protected virtual void EndUpdate  () { }
    protected virtual void Quit       () { }
    protected virtual void End        () { }
    
    
    
    private static readonly List<Entity> entities = new List<Entity>();
 
 
    private static void OnBegin      () { foreach(Entity _entity in entities) _entity.Begin      (); }
    private static void OnStart      () { foreach(Entity _entity in entities) _entity.Start      (); }
    private static void OnBeginUpdate() { foreach(Entity _entity in entities) _entity.BeginUpdate(); }
    private static void OnEarlyUpdate() { foreach(Entity _entity in entities) _entity.EarlyUpdate(); }
    private static void OnUpdate     () { foreach(Entity _entity in entities) _entity.Update     (); }
    private static void OnLateUpdate () { foreach(Entity _entity in entities) _entity.LateUpdate (); }
    private static void OnRender     () { foreach(Entity _entity in entities) _entity.Render     (); }
    private static void OnEndUpdate  () { foreach(Entity _entity in entities) _entity.EndUpdate  (); }
    private static void OnQuit       () { foreach(Entity _entity in entities) _entity.Quit       (); }
    private static void OnEnd        () { foreach(Entity _entity in entities) _entity.End        (); }
}