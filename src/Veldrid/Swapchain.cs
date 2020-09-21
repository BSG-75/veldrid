﻿using System;
using System.ComponentModel;

namespace Veldrid
{
    /// <summary>
    /// A device resource providing the ability to present rendered images to a visible surface.
    /// See <see cref="SwapchainDescription"/>.
    /// </summary>
    public abstract class Swapchain : DeviceResource, IDisposable
    {
        /// <summary>
        /// Gets a <see cref="Framebuffer"/> representing the render targets of this instance.
        /// This property cannot be used with
        /// <see cref="CommandBuffer.BeginRenderPass(in RenderPassDescription)"/>.
        /// Instead, use one of the Framebuffers from <see cref="Framebuffers"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public abstract Framebuffer Framebuffer { get; }

        public abstract Framebuffer[] Framebuffers { get; }

        public abstract uint LastAcquiredImage { get; }

        public uint BufferCount => (uint)Framebuffers.Length;
        public uint Width => Framebuffers[0].Width;
        public uint Height => Framebuffers[0].Height;

        /// <summary>
        /// Resizes the renderable Textures managed by this instance to the given dimensions.
        /// </summary>
        /// <param name="width">The new width of the Swapchain.</param>
        /// <param name="height">The new height of the Swapchain.</param>
        public abstract void Resize(uint width, uint height);

        /// <summary>
        /// Gets or sets whether presentation of this Swapchain will be synchronized to the window system's vertical refresh
        /// rate.
        /// </summary>
        public abstract bool SyncToVerticalBlank { get; set; }
        /// <summary>
        /// A string identifying this instance. Can be used to differentiate between objects in graphics debuggers and other
        /// tools.
        /// </summary>
        public abstract string Name { get; set; }
        /// <summary>
        /// A bool indicating whether this instance has been disposed.
        /// </summary>
        public abstract bool IsDisposed { get; }
        /// <summary>
        /// Frees unmanaged device resources controlled by this instance.
        /// </summary>
        public abstract void Dispose();
    }
}
