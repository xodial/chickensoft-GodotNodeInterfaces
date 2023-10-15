namespace Chickensoft.GodotNodeInterfaces;

using System;
using System.Collections.Generic;
using Godot;

public static class GodotNodes {
  private static readonly Dictionary<Type, Func<Node, IAdapter>> _adapters = new() {
      [typeof(INode)] = node => new NodeAdapter(node),
      [typeof(IAnimationPlayer)] = node => new AnimationPlayerAdapter(node),
      [typeof(IAnimationTree)] = node => new AnimationTreeAdapter(node),
      [typeof(ICodeEdit)] = node => new CodeEditAdapter(node),
      [typeof(IGraphEdit)] = node => new GraphEditAdapter(node),
      [typeof(IGraphNode)] = node => new GraphNodeAdapter(node),
      [typeof(IMeshInstance3D)] = node => new MeshInstance3DAdapter(node),
      [typeof(INode3D)] = node => new Node3DAdapter(node),
      [typeof(IRichTextLabel)] = node => new RichTextLabelAdapter(node),
      [typeof(ITileMap)] = node => new TileMapAdapter(node),
      [typeof(ITree)] = node => new TreeAdapter(node),
      [typeof(IAcceptDialog)] = node => new AcceptDialogAdapter(node),
      [typeof(IAnimatableBody2D)] = node => new AnimatableBody2DAdapter(node),
      [typeof(IAnimatableBody3D)] = node => new AnimatableBody3DAdapter(node),
      [typeof(IAnimatedSprite2D)] = node => new AnimatedSprite2DAdapter(node),
      [typeof(IAnimatedSprite3D)] = node => new AnimatedSprite3DAdapter(node),
      [typeof(IArea2D)] = node => new Area2DAdapter(node),
      [typeof(IArea3D)] = node => new Area3DAdapter(node),
      [typeof(IAspectRatioContainer)] = node => new AspectRatioContainerAdapter(node),
      [typeof(IAudioListener2D)] = node => new AudioListener2DAdapter(node),
      [typeof(IAudioListener3D)] = node => new AudioListener3DAdapter(node),
      [typeof(IAudioStreamPlayer)] = node => new AudioStreamPlayerAdapter(node),
      [typeof(IAudioStreamPlayer2D)] = node => new AudioStreamPlayer2DAdapter(node),
      [typeof(IAudioStreamPlayer3D)] = node => new AudioStreamPlayer3DAdapter(node),
      [typeof(IBackBufferCopy)] = node => new BackBufferCopyAdapter(node),
      [typeof(IBaseButton)] = node => new BaseButtonAdapter(node),
      [typeof(IBone2D)] = node => new Bone2DAdapter(node),
      [typeof(IBoneAttachment3D)] = node => new BoneAttachment3DAdapter(node),
      [typeof(IBoxContainer)] = node => new BoxContainerAdapter(node),
      [typeof(IButton)] = node => new ButtonAdapter(node),
      [typeof(ICpuParticles2D)] = node => new CpuParticles2DAdapter(node),
      [typeof(ICpuParticles3D)] = node => new CpuParticles3DAdapter(node),
      [typeof(ICsgBox3D)] = node => new CsgBox3DAdapter(node),
      [typeof(ICsgCombiner3D)] = node => new CsgCombiner3DAdapter(node),
      [typeof(ICsgCylinder3D)] = node => new CsgCylinder3DAdapter(node),
      [typeof(ICsgMesh3D)] = node => new CsgMesh3DAdapter(node),
      [typeof(ICsgPolygon3D)] = node => new CsgPolygon3DAdapter(node),
      [typeof(ICsgSphere3D)] = node => new CsgSphere3DAdapter(node),
      [typeof(ICsgTorus3D)] = node => new CsgTorus3DAdapter(node),
      [typeof(ICamera2D)] = node => new Camera2DAdapter(node),
      [typeof(ICamera3D)] = node => new Camera3DAdapter(node),
      [typeof(ICanvasGroup)] = node => new CanvasGroupAdapter(node),
      [typeof(ICanvasLayer)] = node => new CanvasLayerAdapter(node),
      [typeof(ICanvasModulate)] = node => new CanvasModulateAdapter(node),
      [typeof(ICenterContainer)] = node => new CenterContainerAdapter(node),
      [typeof(ICharacterBody2D)] = node => new CharacterBody2DAdapter(node),
      [typeof(ICharacterBody3D)] = node => new CharacterBody3DAdapter(node),
      [typeof(ICheckBox)] = node => new CheckBoxAdapter(node),
      [typeof(ICheckButton)] = node => new CheckButtonAdapter(node),
      [typeof(ICollisionPolygon2D)] = node => new CollisionPolygon2DAdapter(node),
      [typeof(ICollisionPolygon3D)] = node => new CollisionPolygon3DAdapter(node),
      [typeof(ICollisionShape2D)] = node => new CollisionShape2DAdapter(node),
      [typeof(ICollisionShape3D)] = node => new CollisionShape3DAdapter(node),
      [typeof(IColorPicker)] = node => new ColorPickerAdapter(node),
      [typeof(IColorPickerButton)] = node => new ColorPickerButtonAdapter(node),
      [typeof(IColorRect)] = node => new ColorRectAdapter(node),
      [typeof(IConeTwistJoint3D)] = node => new ConeTwistJoint3DAdapter(node),
      [typeof(IConfirmationDialog)] = node => new ConfirmationDialogAdapter(node),
      [typeof(IContainer)] = node => new ContainerAdapter(node),
      [typeof(IControl)] = node => new ControlAdapter(node),
      [typeof(IDampedSpringJoint2D)] = node => new DampedSpringJoint2DAdapter(node),
      [typeof(IDecal)] = node => new DecalAdapter(node),
      [typeof(IDirectionalLight2D)] = node => new DirectionalLight2DAdapter(node),
      [typeof(IDirectionalLight3D)] = node => new DirectionalLight3DAdapter(node),
      [typeof(IFileDialog)] = node => new FileDialogAdapter(node),
      [typeof(IFlowContainer)] = node => new FlowContainerAdapter(node),
      [typeof(IFogVolume)] = node => new FogVolumeAdapter(node),
      [typeof(IGpuParticles2D)] = node => new GpuParticles2DAdapter(node),
      [typeof(IGpuParticles3D)] = node => new GpuParticles3DAdapter(node),
      [typeof(IGpuParticlesAttractorBox3D)] = node => new GpuParticlesAttractorBox3DAdapter(node),
      [typeof(IGpuParticlesAttractorSphere3D)] = node => new GpuParticlesAttractorSphere3DAdapter(node),
      [typeof(IGpuParticlesAttractorVectorField3D)] = node => new GpuParticlesAttractorVectorField3DAdapter(node),
      [typeof(IGpuParticlesCollisionBox3D)] = node => new GpuParticlesCollisionBox3DAdapter(node),
      [typeof(IGpuParticlesCollisionHeightField3D)] = node => new GpuParticlesCollisionHeightField3DAdapter(node),
      [typeof(IGpuParticlesCollisionSdf3D)] = node => new GpuParticlesCollisionSdf3DAdapter(node),
      [typeof(IGpuParticlesCollisionSphere3D)] = node => new GpuParticlesCollisionSphere3DAdapter(node),
      [typeof(IGeneric6DofJoint3D)] = node => new Generic6DofJoint3DAdapter(node),
      [typeof(IGeometryInstance3D)] = node => new GeometryInstance3DAdapter(node),
      [typeof(IGraphElement)] = node => new GraphElementAdapter(node),
      [typeof(IGridContainer)] = node => new GridContainerAdapter(node),
      [typeof(IGridMap)] = node => new GridMapAdapter(node),
      [typeof(IGrooveJoint2D)] = node => new GrooveJoint2DAdapter(node),
      [typeof(IHBoxContainer)] = node => new HBoxContainerAdapter(node),
      [typeof(IHFlowContainer)] = node => new HFlowContainerAdapter(node),
      [typeof(IHScrollBar)] = node => new HScrollBarAdapter(node),
      [typeof(IHSeparator)] = node => new HSeparatorAdapter(node),
      [typeof(IHSlider)] = node => new HSliderAdapter(node),
      [typeof(IHSplitContainer)] = node => new HSplitContainerAdapter(node),
      [typeof(IHttpRequest)] = node => new HttpRequestAdapter(node),
      [typeof(IHingeJoint3D)] = node => new HingeJoint3DAdapter(node),
      [typeof(IImporterMeshInstance3D)] = node => new ImporterMeshInstance3DAdapter(node),
      [typeof(IItemList)] = node => new ItemListAdapter(node),
      [typeof(ILabel)] = node => new LabelAdapter(node),
      [typeof(ILabel3D)] = node => new Label3DAdapter(node),
      [typeof(ILightOccluder2D)] = node => new LightOccluder2DAdapter(node),
      [typeof(ILightmapGI)] = node => new LightmapGIAdapter(node),
      [typeof(ILightmapProbe)] = node => new LightmapProbeAdapter(node),
      [typeof(ILine2D)] = node => new Line2DAdapter(node),
      [typeof(ILineEdit)] = node => new LineEditAdapter(node),
      [typeof(ILinkButton)] = node => new LinkButtonAdapter(node),
      [typeof(IMarginContainer)] = node => new MarginContainerAdapter(node),
      [typeof(IMarker2D)] = node => new Marker2DAdapter(node),
      [typeof(IMarker3D)] = node => new Marker3DAdapter(node),
      [typeof(IMenuBar)] = node => new MenuBarAdapter(node),
      [typeof(IMenuButton)] = node => new MenuButtonAdapter(node),
      [typeof(IMeshInstance2D)] = node => new MeshInstance2DAdapter(node),
      [typeof(IMissingNode)] = node => new MissingNodeAdapter(node),
      [typeof(IMultiMeshInstance2D)] = node => new MultiMeshInstance2DAdapter(node),
      [typeof(IMultiMeshInstance3D)] = node => new MultiMeshInstance3DAdapter(node),
      [typeof(IMultiplayerSpawner)] = node => new MultiplayerSpawnerAdapter(node),
      [typeof(IMultiplayerSynchronizer)] = node => new MultiplayerSynchronizerAdapter(node),
      [typeof(INavigationAgent2D)] = node => new NavigationAgent2DAdapter(node),
      [typeof(INavigationAgent3D)] = node => new NavigationAgent3DAdapter(node),
      [typeof(INavigationLink2D)] = node => new NavigationLink2DAdapter(node),
      [typeof(INavigationLink3D)] = node => new NavigationLink3DAdapter(node),
      [typeof(INavigationObstacle2D)] = node => new NavigationObstacle2DAdapter(node),
      [typeof(INavigationObstacle3D)] = node => new NavigationObstacle3DAdapter(node),
      [typeof(INavigationRegion2D)] = node => new NavigationRegion2DAdapter(node),
      [typeof(INavigationRegion3D)] = node => new NavigationRegion3DAdapter(node),
      [typeof(INinePatchRect)] = node => new NinePatchRectAdapter(node),
      [typeof(INode2D)] = node => new Node2DAdapter(node),
      [typeof(IOccluderInstance3D)] = node => new OccluderInstance3DAdapter(node),
      [typeof(IOmniLight3D)] = node => new OmniLight3DAdapter(node),
      [typeof(IOpenXRHand)] = node => new OpenXRHandAdapter(node),
      [typeof(IOptionButton)] = node => new OptionButtonAdapter(node),
      [typeof(IPanel)] = node => new PanelAdapter(node),
      [typeof(IPanelContainer)] = node => new PanelContainerAdapter(node),
      [typeof(IParallaxBackground)] = node => new ParallaxBackgroundAdapter(node),
      [typeof(IParallaxLayer)] = node => new ParallaxLayerAdapter(node),
      [typeof(IPath2D)] = node => new Path2DAdapter(node),
      [typeof(IPath3D)] = node => new Path3DAdapter(node),
      [typeof(IPathFollow2D)] = node => new PathFollow2DAdapter(node),
      [typeof(IPathFollow3D)] = node => new PathFollow3DAdapter(node),
      [typeof(IPhysicalBone2D)] = node => new PhysicalBone2DAdapter(node),
      [typeof(IPhysicalBone3D)] = node => new PhysicalBone3DAdapter(node),
      [typeof(IPinJoint2D)] = node => new PinJoint2DAdapter(node),
      [typeof(IPinJoint3D)] = node => new PinJoint3DAdapter(node),
      [typeof(IPointLight2D)] = node => new PointLight2DAdapter(node),
      [typeof(IPolygon2D)] = node => new Polygon2DAdapter(node),
      [typeof(IPopup)] = node => new PopupAdapter(node),
      [typeof(IPopupMenu)] = node => new PopupMenuAdapter(node),
      [typeof(IPopupPanel)] = node => new PopupPanelAdapter(node),
      [typeof(IProgressBar)] = node => new ProgressBarAdapter(node),
      [typeof(IRange)] = node => new RangeAdapter(node),
      [typeof(IRayCast2D)] = node => new RayCast2DAdapter(node),
      [typeof(IRayCast3D)] = node => new RayCast3DAdapter(node),
      [typeof(IReferenceRect)] = node => new ReferenceRectAdapter(node),
      [typeof(IReflectionProbe)] = node => new ReflectionProbeAdapter(node),
      [typeof(IRemoteTransform2D)] = node => new RemoteTransform2DAdapter(node),
      [typeof(IRemoteTransform3D)] = node => new RemoteTransform3DAdapter(node),
      [typeof(IResourcePreloader)] = node => new ResourcePreloaderAdapter(node),
      [typeof(IRigidBody2D)] = node => new RigidBody2DAdapter(node),
      [typeof(IRigidBody3D)] = node => new RigidBody3DAdapter(node),
      [typeof(IRootMotionView)] = node => new RootMotionViewAdapter(node),
      [typeof(IScrollContainer)] = node => new ScrollContainerAdapter(node),
      [typeof(IShaderGlobalsOverride)] = node => new ShaderGlobalsOverrideAdapter(node),
      [typeof(IShapeCast2D)] = node => new ShapeCast2DAdapter(node),
      [typeof(IShapeCast3D)] = node => new ShapeCast3DAdapter(node),
      [typeof(ISkeleton2D)] = node => new Skeleton2DAdapter(node),
      [typeof(ISkeleton3D)] = node => new Skeleton3DAdapter(node),
      [typeof(ISkeletonIK3D)] = node => new SkeletonIK3DAdapter(node),
      [typeof(ISliderJoint3D)] = node => new SliderJoint3DAdapter(node),
      [typeof(ISoftBody3D)] = node => new SoftBody3DAdapter(node),
      [typeof(ISpinBox)] = node => new SpinBoxAdapter(node),
      [typeof(ISplitContainer)] = node => new SplitContainerAdapter(node),
      [typeof(ISpotLight3D)] = node => new SpotLight3DAdapter(node),
      [typeof(ISpringArm3D)] = node => new SpringArm3DAdapter(node),
      [typeof(ISprite2D)] = node => new Sprite2DAdapter(node),
      [typeof(ISprite3D)] = node => new Sprite3DAdapter(node),
      [typeof(IStaticBody2D)] = node => new StaticBody2DAdapter(node),
      [typeof(IStaticBody3D)] = node => new StaticBody3DAdapter(node),
      [typeof(ISubViewport)] = node => new SubViewportAdapter(node),
      [typeof(ISubViewportContainer)] = node => new SubViewportContainerAdapter(node),
      [typeof(ITabBar)] = node => new TabBarAdapter(node),
      [typeof(ITabContainer)] = node => new TabContainerAdapter(node),
      [typeof(ITextEdit)] = node => new TextEditAdapter(node),
      [typeof(ITextureButton)] = node => new TextureButtonAdapter(node),
      [typeof(ITextureProgressBar)] = node => new TextureProgressBarAdapter(node),
      [typeof(ITextureRect)] = node => new TextureRectAdapter(node),
      [typeof(ITimer)] = node => new TimerAdapter(node),
      [typeof(ITouchScreenButton)] = node => new TouchScreenButtonAdapter(node),
      [typeof(IVBoxContainer)] = node => new VBoxContainerAdapter(node),
      [typeof(IVFlowContainer)] = node => new VFlowContainerAdapter(node),
      [typeof(IVScrollBar)] = node => new VScrollBarAdapter(node),
      [typeof(IVSeparator)] = node => new VSeparatorAdapter(node),
      [typeof(IVSlider)] = node => new VSliderAdapter(node),
      [typeof(IVSplitContainer)] = node => new VSplitContainerAdapter(node),
      [typeof(IVehicleBody3D)] = node => new VehicleBody3DAdapter(node),
      [typeof(IVehicleWheel3D)] = node => new VehicleWheel3DAdapter(node),
      [typeof(IVideoStreamPlayer)] = node => new VideoStreamPlayerAdapter(node),
      [typeof(IVisibleOnScreenEnabler2D)] = node => new VisibleOnScreenEnabler2DAdapter(node),
      [typeof(IVisibleOnScreenEnabler3D)] = node => new VisibleOnScreenEnabler3DAdapter(node),
      [typeof(IVisibleOnScreenNotifier2D)] = node => new VisibleOnScreenNotifier2DAdapter(node),
      [typeof(IVisibleOnScreenNotifier3D)] = node => new VisibleOnScreenNotifier3DAdapter(node),
      [typeof(IVisualInstance3D)] = node => new VisualInstance3DAdapter(node),
      [typeof(IVoxelGI)] = node => new VoxelGIAdapter(node),
      [typeof(IWindow)] = node => new WindowAdapter(node),
      [typeof(IWorldEnvironment)] = node => new WorldEnvironmentAdapter(node),
      [typeof(IXRAnchor3D)] = node => new XRAnchor3DAdapter(node),
      [typeof(IXRCamera3D)] = node => new XRCamera3DAdapter(node),
      [typeof(IXRController3D)] = node => new XRController3DAdapter(node),
      [typeof(IXROrigin3D)] = node => new XROrigin3DAdapter(node)
  };

  /// <summary>
  /// Creates an adapter for the given Godot node. This will throw if the
  /// incorrect adapter type was specified for the node.
  /// </summary>
  /// <typeparam name="T">Adapter type.</typeparam>
  /// <param name="node">Godot node.</param>
  public static T Adapt<T>(Node node) where T : class, INode => (T)_adapters[typeof(T)](node);
}