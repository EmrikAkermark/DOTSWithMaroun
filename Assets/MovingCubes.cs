using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public class MovingCubes : JobComponentSystem
{

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        return Entities.WithName("MovingCubes").ForEach(
            (ref Translation transform, in Rotation rotation) =>
            {
                transform.Value += 0.01f * math.forward(rotation.Value) ;
            }).Schedule(inputDeps);
    }
}
