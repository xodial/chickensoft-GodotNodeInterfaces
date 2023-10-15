namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A control used for visual representation of a percentage. Shows fill percentage from right to left.</para>
/// </summary>
public class ProgressBarAdapter : RangeAdapter, IProgressBar {
  private readonly ProgressBar _node;

  public ProgressBarAdapter(Node node) : base(node) {
    if (node is not ProgressBar typedNode) {
      throw new System.InvalidCastException(
        $"{node.GetType().Name} is not a ProgressBar"
      );
    }
    _node = typedNode;
  }

    /// <summary>
    /// <para>The fill direction. See <see cref="ProgressBar.FillModeEnum" /> for possible values.</para>
    /// </summary>
    public int FillMode { get => _node.FillMode; set => _node.FillMode = value; }
    /// <summary>
    /// <para>If <c>true</c>, the fill percentage is displayed on the bar.</para>
    /// </summary>
    public bool ShowPercentage { get => _node.ShowPercentage; set => _node.ShowPercentage = value; }

}