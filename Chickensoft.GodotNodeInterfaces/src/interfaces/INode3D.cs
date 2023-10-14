namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
using Godot.Collections;

// Apply interface to a Godot node implementation to make sure the
// generated interface is correct.
internal partial class Node3DNode : Node3D, INode3D { }

/// <summary>
/// <para>Most basic 3D game object, with a <see cref="Transform3D" /> and visibility settings. All other 3D game objects inherit from <see cref="Node3D" />. Use <see cref="Node3D" /> as a parent node to move, scale, rotate and show/hide children in a 3D project.</para>
/// <para>Affine operations (rotate, scale, translate) happen in parent's local coordinate system, unless the <see cref="Node3D" /> object is set as top-level. Affine operations in this coordinate system correspond to direct affine operations on the <see cref="Node3D" />'s transform. The word local below refers to this coordinate system. The coordinate system that is attached to the <see cref="Node3D" /> object itself is referred to as object-local coordinate system.</para>
/// <para><b>Note:</b> Unless otherwise specified, all methods that have angle parameters must have angles specified as <i>radians</i>. To convert degrees to radians, use <c>@GlobalScope.deg_to_rad</c>.</para>
/// <para><b>Note:</b> Be aware that "Spatial" nodes are now called "Node3D" starting with Godot 4. Any Godot 3.x references to "Spatial" nodes refer to "Node3D" in Godot 4.</para>
/// </summary>
public interface INode3D : INode {
    /// <summary>
    /// <para>Attach an editor gizmo to this <see cref="Node3D" />.</para>
    /// <para><b>Note:</b> The gizmo object would typically be an instance of <c>EditorNode3DGizmo</c>, but the argument type is kept generic to avoid creating a dependency on editor classes in <see cref="Node3D" />.</para>
    /// </summary>
    void AddGizmo(Node3DGizmo gizmo);
    /// <summary>
    /// <para>Direct access to the 3x3 basis of the <see cref="Node3D.Transform" /> property.</para>
    /// </summary>
    Basis Basis { get; set; }
    /// <summary>
    /// <para>Clear all gizmos attached to this <see cref="Node3D" />.</para>
    /// </summary>
    void ClearGizmos();
    /// <summary>
    /// <para>Clears subgizmo selection for this node in the editor. Useful when subgizmo IDs become invalid after a property change.</para>
    /// </summary>
    void ClearSubgizmoSelection();
    /// <summary>
    /// <para>Forces the transform to update. Transform changes in physics are not instant for performance reasons. Transforms are accumulated and then set. Use this if you need an up-to-date transform when doing physics operations.</para>
    /// </summary>
    void ForceUpdateTransform();
    /// <summary>
    /// <para>Returns all the gizmos attached to this <see cref="Node3D" />.</para>
    /// </summary>
    Godot.Collections.Array<Node3DGizmo> GetGizmos();
    /// <summary>
    /// <para>Returns the parent <see cref="Node3D" />, or an empty <see cref="GodotObject" /> if no parent exists or parent is not of type <see cref="Node3D" />.</para>
    /// </summary>
    Node3D GetParentNode3D();
    /// <summary>
    /// <para>Returns the current <see cref="World3D" /> resource this <see cref="Node3D" /> node is registered to.</para>
    /// </summary>
    World3D GetWorld3D();
    /// <summary>
    /// <para>Global basis of this node. This is equivalent to <c>global_transform.basis</c>.</para>
    /// </summary>
    Basis GlobalBasis { get; set; }
    /// <summary>
    /// <para>Global position of this node. This is equivalent to <c>global_transform.origin</c>.</para>
    /// </summary>
    Vector3 GlobalPosition { get; set; }
    /// <summary>
    /// <para>Rotates the global (world) transformation around axis, a unit <see cref="Vector3" />, by specified angle in radians. The rotation axis is in global coordinate system.</para>
    /// </summary>
    void GlobalRotate(Vector3 axis, float angle);
    /// <summary>
    /// <para>Rotation part of the global transformation in radians, specified in terms of YXZ-Euler angles in the format (X angle, Y angle, Z angle).</para>
    /// <para><b>Note:</b> In the mathematical sense, rotation is a matrix and not a vector. The three Euler angles, which are the three independent parameters of the Euler-angle parametrization of the rotation matrix, are stored in a <see cref="Vector3" /> data structure not because the rotation is a vector, but only because <see cref="Vector3" /> exists as a convenient data-structure to store 3 floating-point numbers. Therefore, applying affine operations on the rotation "vector" is not meaningful.</para>
    /// </summary>
    Vector3 GlobalRotation { get; set; }
    /// <summary>
    /// <para>Helper property to access <see cref="Node3D.GlobalRotation" /> in degrees instead of radians.</para>
    /// </summary>
    Vector3 GlobalRotationDegrees { get; set; }
    /// <summary>
    /// <para>Scales the global (world) transformation by the given <see cref="Vector3" /> scale factors.</para>
    /// </summary>
    void GlobalScale(Vector3 scale);
    /// <summary>
    /// <para>World3D space (global) <see cref="Transform3D" /> of this node.</para>
    /// </summary>
    Transform3D GlobalTransform { get; set; }
    /// <summary>
    /// <para>Moves the global (world) transformation by <see cref="Vector3" /> offset. The offset is in global coordinate system.</para>
    /// </summary>
    void GlobalTranslate(Vector3 offset);
    /// <summary>
    /// <para>Disables rendering of this node. Changes <see cref="Node3D.Visible" /> to <c>false</c>.</para>
    /// </summary>
    void Hide();
    /// <summary>
    /// <para>Returns whether node notifies about its local transformation changes. <see cref="Node3D" /> will not propagate this by default.</para>
    /// </summary>
    bool IsLocalTransformNotificationEnabled();
    /// <summary>
    /// <para>Returns whether this node uses a scale of <c>(1, 1, 1)</c> or its local transformation scale.</para>
    /// </summary>
    bool IsScaleDisabled();
    /// <summary>
    /// <para>Returns whether the node notifies about its global and local transformation changes. <see cref="Node3D" /> will not propagate this by default.</para>
    /// </summary>
    bool IsTransformNotificationEnabled();
    /// <summary>
    /// <para>Returns <c>true</c> if the node is present in the <see cref="SceneTree" />, its <see cref="Node3D.Visible" /> property is <c>true</c> and all its ancestors are also visible. If any ancestor is hidden, this node will not be visible in the scene tree.</para>
    /// </summary>
    bool IsVisibleInTree();
    /// <inheritdoc cref="M:Godot.Node3D.LookAt(Godot.Vector3,System.Nullable{Godot.Vector3},System.Boolean)" />
    void LookAt(Vector3 target, Nullable<Vector3> up);
    /// <summary>
    /// <para>Rotates the node so that the local forward axis (-Z, <c>Vector3.FORWARD</c>) points toward the <paramref name="target" /> position.</para>
    /// <para>The local up axis (+Y) points as close to the <paramref name="up" /> vector as possible while staying perpendicular to the local forward axis. The resulting transform is orthogonal, and the scale is preserved. Non-uniform scaling may not work correctly.</para>
    /// <para>The <paramref name="target" /> position cannot be the same as the node's position, the <paramref name="up" /> vector cannot be zero, and the direction from the node's position to the <paramref name="target" /> vector cannot be parallel to the <paramref name="up" /> vector.</para>
    /// <para>Operations take place in global space, which means that the node must be in the scene tree.</para>
    /// <para>If <paramref name="useModelFront" /> is <c>true</c>, the +Z axis (asset front) is treated as forward (implies +X is left) and points toward the <paramref name="target" /> position. By default, the -Z axis (camera forward) is treated as forward (implies +X is right).</para>
    /// </summary>
    /// <param name="up">If the parameter is null, then the default value is <c>new Vector3(0, 1, 0)</c>.</param>
    void LookAt(Vector3 target, Nullable<Vector3> up, bool useModelFront);
    /// <inheritdoc cref="M:Godot.Node3D.LookAtFromPosition(Godot.Vector3,Godot.Vector3,System.Nullable{Godot.Vector3},System.Boolean)" />
    void LookAtFromPosition(Vector3 position, Vector3 target, Nullable<Vector3> up);
    /// <summary>
    /// <para>Moves the node to the specified <paramref name="position" />, and then rotates the node to point toward the <paramref name="target" /> as per <see cref="Node3D.LookAt(Godot.Vector3,System.Nullable{Godot.Vector3},System.Boolean)" />. Operations take place in global space.</para>
    /// </summary>
    /// <param name="up">If the parameter is null, then the default value is <c>new Vector3(0, 1, 0)</c>.</param>
    void LookAtFromPosition(Vector3 position, Vector3 target, Nullable<Vector3> up, bool useModelFront);
    /// <summary>
    /// <para>Resets this node's transformations (like scale, skew and taper) preserving its rotation and translation by performing Gram-Schmidt orthonormalization on this node's <see cref="Transform3D" />.</para>
    /// </summary>
    void Orthonormalize();
    /// <summary>
    /// <para>Local position or translation of this node relative to the parent. This is equivalent to <c>transform.origin</c>.</para>
    /// </summary>
    Vector3 Position { get; set; }
    /// <summary>
    /// <para>Access to the node rotation as a <see cref="Quaternion" />. This property is ideal for tweening complex rotations.</para>
    /// </summary>
    Quaternion Quaternion { get; set; }
    /// <summary>
    /// <para>Rotates the local transformation around axis, a unit <see cref="Vector3" />, by specified angle in radians.</para>
    /// </summary>
    void Rotate(Vector3 axis, float angle);
    /// <summary>
    /// <para>Rotates the local transformation around axis, a unit <see cref="Vector3" />, by specified angle in radians. The rotation axis is in object-local coordinate system.</para>
    /// </summary>
    void RotateObjectLocal(Vector3 axis, float angle);
    /// <summary>
    /// <para>Rotates the local transformation around the X axis by angle in radians.</para>
    /// </summary>
    void RotateX(float angle);
    /// <summary>
    /// <para>Rotates the local transformation around the Y axis by angle in radians.</para>
    /// </summary>
    void RotateY(float angle);
    /// <summary>
    /// <para>Rotates the local transformation around the Z axis by angle in radians.</para>
    /// </summary>
    void RotateZ(float angle);
    /// <summary>
    /// <para>Rotation part of the local transformation in radians, specified in terms of Euler angles. The angles construct a rotation in the order specified by the <see cref="Node3D.RotationOrder" /> property.</para>
    /// <para><b>Note:</b> In the mathematical sense, rotation is a matrix and not a vector. The three Euler angles, which are the three independent parameters of the Euler-angle parametrization of the rotation matrix, are stored in a <see cref="Vector3" /> data structure not because the rotation is a vector, but only because <see cref="Vector3" /> exists as a convenient data-structure to store 3 floating-point numbers. Therefore, applying affine operations on the rotation "vector" is not meaningful.</para>
    /// <para><b>Note:</b> This property is edited in the inspector in degrees. If you want to use degrees in a script, use <see cref="Node3D.RotationDegrees" />.</para>
    /// </summary>
    Vector3 Rotation { get; set; }
    /// <summary>
    /// <para>Helper property to access <see cref="Node3D.Rotation" /> in degrees instead of radians.</para>
    /// </summary>
    Vector3 RotationDegrees { get; set; }
    /// <summary>
    /// <para>Specify how rotation (and scale) will be presented in the editor.</para>
    /// </summary>
    Node3D.RotationEditModeEnum RotationEditMode { get; set; }
    /// <summary>
    /// <para>Specify the axis rotation order of the <see cref="Node3D.Rotation" /> property. The final orientation is constructed by rotating the Euler angles in the order specified by this property.</para>
    /// </summary>
    EulerOrder RotationOrder { get; set; }
    /// <summary>
    /// <para>Scale part of the local transformation.</para>
    /// <para><b>Note:</b> Mixed negative scales in 3D are not decomposable from the transformation matrix. Due to the way scale is represented with transformation matrices in Godot, the scale values will either be all positive or all negative.</para>
    /// <para><b>Note:</b> Not all nodes are visually scaled by the <see cref="Node3D.Scale" /> property. For example, <see cref="Light3D" />s are not visually affected by <see cref="Node3D.Scale" />.</para>
    /// </summary>
    Vector3 Scale { get; set; }
    /// <summary>
    /// <para>Scales the local transformation by given 3D scale factors in object-local coordinate system.</para>
    /// </summary>
    void ScaleObjectLocal(Vector3 scale);
    /// <summary>
    /// <para>Sets whether the node uses a scale of <c>(1, 1, 1)</c> or its local transformation scale. Changes to the local transformation scale are preserved.</para>
    /// </summary>
    void SetDisableScale(bool disable);
    /// <summary>
    /// <para>Reset all transformations for this node (sets its <see cref="Transform3D" /> to the identity matrix).</para>
    /// </summary>
    void SetIdentity();
    /// <summary>
    /// <para>Sets whether the node ignores notification that its transformation (global or local) changed.</para>
    /// </summary>
    void SetIgnoreTransformNotification(bool enabled);
    /// <summary>
    /// <para>Sets whether the node notifies about its local transformation changes. <see cref="Node3D" /> will not propagate this by default.</para>
    /// </summary>
    void SetNotifyLocalTransform(bool enable);
    /// <summary>
    /// <para>Sets whether the node notifies about its global and local transformation changes. <see cref="Node3D" /> will not propagate this by default, unless it is in the editor context and it has a valid gizmo.</para>
    /// </summary>
    void SetNotifyTransform(bool enable);
    /// <summary>
    /// <para>Set subgizmo selection for this node in the editor.</para>
    /// <para><b>Note:</b> The gizmo object would typically be an instance of <c>EditorNode3DGizmo</c>, but the argument type is kept generic to avoid creating a dependency on editor classes in <see cref="Node3D" />.</para>
    /// </summary>
    void SetSubgizmoSelection(Node3DGizmo gizmo, int id, Transform3D transform);
    /// <summary>
    /// <para>Enables rendering of this node. Changes <see cref="Node3D.Visible" /> to <c>true</c>.</para>
    /// </summary>
    void Show();
    /// <summary>
    /// <para>Transforms <paramref name="localPoint" /> from this node's local space to world space.</para>
    /// </summary>
    Vector3 ToGlobal(Vector3 localPoint);
    /// <summary>
    /// <para>Transforms <paramref name="globalPoint" /> from world space to this node's local space.</para>
    /// </summary>
    Vector3 ToLocal(Vector3 globalPoint);
    /// <summary>
    /// <para>If <c>true</c>, the node will not inherit its transformations from its parent. Node transformations are only in global space.</para>
    /// </summary>
    bool TopLevel { get; set; }
    /// <summary>
    /// <para>Local space <see cref="Transform3D" /> of this node, with respect to the parent node.</para>
    /// </summary>
    Transform3D Transform { get; set; }
    /// <summary>
    /// <para>Changes the node's position by the given offset <see cref="Vector3" />.</para>
    /// <para>Note that the translation <paramref name="offset" /> is affected by the node's scale, so if scaled by e.g. <c>(10, 1, 1)</c>, a translation by an offset of <c>(2, 0, 0)</c> would actually add 20 (<c>2 * 10</c>) to the X coordinate.</para>
    /// </summary>
    void Translate(Vector3 offset);
    /// <summary>
    /// <para>Changes the node's position by the given offset <see cref="Vector3" /> in local space.</para>
    /// </summary>
    void TranslateObjectLocal(Vector3 offset);
    /// <summary>
    /// <para>Updates all the <see cref="Node3D" /> gizmos attached to this node.</para>
    /// </summary>
    void UpdateGizmos();
    /// <summary>
    /// <para>Defines the visibility range parent for this node and its subtree. The visibility parent must be a GeometryInstance3D. Any visual instance will only be visible if the visibility parent (and all of its visibility ancestors) is hidden by being closer to the camera than its own <see cref="GeometryInstance3D.VisibilityRangeBegin" />. Nodes hidden via the <see cref="Node3D.Visible" /> property are essentially removed from the visibility dependency tree, so dependent instances will not take the hidden node or its ancestors into account.</para>
    /// </summary>
    NodePath VisibilityParent { get; set; }
    /// <summary>
    /// <para>If <c>true</c>, this node is drawn. The node is only visible if all of its ancestors are visible as well (in other words, <see cref="Node3D.IsVisibleInTree" /> must return <c>true</c>).</para>
    /// </summary>
    bool Visible { get; set; }

}