namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A sphere-shaped 3D particle collision shape affecting <see cref="GpuParticles3D" /> nodes.</para>
/// <para>Particle collision shapes work in real-time and can be moved, rotated and scaled during gameplay. Unlike attractors, non-uniform scaling of collision shapes is <i>not</i> supported.</para>
/// <para><b>Note:</b> <see cref="ParticleProcessMaterial.CollisionMode" /> must be <see cref="ParticleProcessMaterial.CollisionModeEnum.Rigid" /> or <see cref="ParticleProcessMaterial.CollisionModeEnum.HideOnContact" /> on the <see cref="GpuParticles3D" />'s process material for collision to work.</para>
/// <para><b>Note:</b> Particle collision only affects <see cref="GpuParticles3D" />, not <see cref="CpuParticles3D" />.</para>
/// </summary>
public class GpuParticlesCollisionSphere3DAdapter : GpuParticlesCollision3DAdapter, IGpuParticlesCollisionSphere3D {
  private readonly GpuParticlesCollisionSphere3D _node;

  public GpuParticlesCollisionSphere3DAdapter(Node node) : base(node) {
    if (node is not GpuParticlesCollisionSphere3D typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a GpuParticlesCollisionSphere3D"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>The collision sphere's radius in 3D units.</para>
    /// </summary>
    public float Radius { get => _node.Radius; set => _node.Radius = value; }

}