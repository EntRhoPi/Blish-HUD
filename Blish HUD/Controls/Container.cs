﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Blish_HUD.Controls {

    // TODO: Ensure that container objects, when disposed, first dispose of their children

    /// <summary>
    /// A control that is capable of having child controls that are drawn when the container is drawn.
    /// Classes that inherit should be packaged controls that that manage their own controls internally.
    /// For a Container with accessible children for non-packaged controls, use <see cref="AccessibleContainer"/>.
    /// </summary>
    public abstract class Container:Control, IEnumerable<Control> {

        public event EventHandler<ChildChangedEventArgs> ChildAdded;
        public event EventHandler<ChildChangedEventArgs> ChildRemoved;

        public event EventHandler<RegionChangedEventArgs> ContentResized;

        protected List<Control> _children;
        [Newtonsoft.Json.JsonIgnore]
        public IReadOnlyCollection<Control> Children => _children.AsReadOnly();

        protected Container() {
            _children = new List<Control>();
        }

        protected virtual void OnChildAdded(ChildChangedEventArgs e) {
            this.ChildAdded?.Invoke(this, e);
        }

        protected virtual void OnChildRemoved(ChildChangedEventArgs e) {
            this.ChildRemoved?.Invoke(this, e);
        }

        protected virtual void OnContentResized(RegionChangedEventArgs e) {
            this.ContentResized?.Invoke(this, e);
        }

        protected override void OnResized(ResizedEventArgs e) {
            base.OnResized(e);

            /* ContentRegion defaults to match our control size until one is manually set,
               so we do squeeze in OnPropertyChanged for it if the control hasn't had a
               ContentRegion specified and then resizes */
            if (!_contentRegion.HasValue)
                OnPropertyChanged(nameof(this.ContentRegion));
        }

        public void AddChild(Control child) {
            if (_children.Contains(child)) return;

            var resultingChildren = _children.ToList();
            resultingChildren.Add(child);

            var evRes = new ChildChangedEventArgs(this, child, true, resultingChildren);
            OnChildAdded(evRes);

            if (evRes.Cancel) return;

            _children.Add(child);
            Invalidate();
        }

        public void RemoveChild(Control child) {
            if (!_children.Contains(child)) return;

            var resultingChildren = _children.ToList();
            resultingChildren.Remove(child);

            var evRes = new ChildChangedEventArgs(this, child, false, resultingChildren);
            OnChildRemoved(evRes);

            if (evRes.Cancel) return;

            _children.Remove(child);
            Invalidate();
        }

        private Rectangle? _contentRegion;
        public Rectangle ContentRegion {
            get => _contentRegion ?? new Rectangle(Point.Zero, this.Size);
            protected set {
                var previousRegion = this.ContentRegion;

                if (SetProperty(ref _contentRegion, value, true)) {
                    OnContentResized(new RegionChangedEventArgs(previousRegion, this.ContentRegion));
                }
            }
        }
        
        private int _verticalScrollOffset;
        public int VerticalScrollOffset {
            get => _verticalScrollOffset;
            set => SetProperty(ref _verticalScrollOffset, value);
        }

        private int _horizontalScrollOffset;
        public int HorizontalScrollOffset {
            get => _horizontalScrollOffset;
            set => SetProperty(ref _horizontalScrollOffset, value);
        }

        public List<Control> GetDescendants() {
            var allDescendants = _children.ToList();

            foreach (var child in _children) {
                if (!(child is Container container)) continue;

                allDescendants.AddRange(container.GetDescendants());
            }

            return allDescendants;
        }

        public override Control TriggerMouseInput(MouseEventType mouseEventType, MouseState ms) {
            List<Control> zSortedChildren = _children.OrderByDescending(i => i.ZIndex).ToList();

            if (mouseEventType == MouseEventType.MouseMoved) base.TriggerMouseInput(mouseEventType, ms);

            Control childResult = null;

            foreach (var childControl in zSortedChildren) {
                if (childControl.AbsoluteBounds.Contains(ms.Position) && childControl.Visible) {
                    childResult = childControl.TriggerMouseInput(mouseEventType, ms);

                    if (childResult != null) {
                        break;
                    }
                }
            }

            if (mouseEventType == MouseEventType.MouseMoved) {
                var overResult = base.TriggerMouseInput(mouseEventType, ms);

                return childResult ?? overResult;
            }

            return childResult ?? base.TriggerMouseInput(mouseEventType, ms);
        }

        public override void DoUpdate(GameTime gameTime) {
            foreach (var childControl in _children.ToList()) {
                if (childControl.Visible)
                    childControl.Update(gameTime);
            }
        }

        protected sealed override void Paint(SpriteBatch spriteBatch, Rectangle bounds) {
            var controlScissor = Graphics.GraphicsDevice.ScissorRectangle.ScaleBy(1 / Graphics.GetScaleRatio(Graphics.UIScale));

            // Draw container background
            PaintBeforeChildren(spriteBatch, bounds);

            spriteBatch.End();

            PaintChildren(spriteBatch, bounds, controlScissor);

            // Restore scissor
            Graphics.GraphicsDevice.ScissorRectangle = controlScissor.ScaleBy(Graphics.GetScaleRatio(Graphics.UIScale));

            spriteBatch.Begin(this.SpriteBatchParameters);

            PaintAfterChildren(spriteBatch, bounds);
        }

        public virtual void PaintBeforeChildren(SpriteBatch spriteBatch, Rectangle bounds) { /* NOOP */ }

        public void PaintChildren(SpriteBatch spriteBatch, Rectangle bounds, Rectangle scissor) {
            var contentScissor = Rectangle.Intersect(scissor, ContentRegion.ToBounds(this.AbsoluteBounds));

            List<Control> zSortedChildren = _children.OrderBy(i => i.ZIndex).ToList();

            // Render each visible child
            foreach (var childControl in zSortedChildren) {
                if (childControl.Visible) {
                    var childBounds = new Rectangle(Point.Zero, childControl.Size);

                    if (childControl.AbsoluteBounds.Intersects(contentScissor))
                        childControl.Draw(spriteBatch, childBounds, contentScissor);
                }
            }
        }

        public virtual void PaintAfterChildren(SpriteBatch spriteBatch, Rectangle bounds) { /* NOOP */ }

        #region IEnumerable Implementation

        public IEnumerator<Control> GetEnumerator() {
            return this.Children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }

        #endregion

    }
}