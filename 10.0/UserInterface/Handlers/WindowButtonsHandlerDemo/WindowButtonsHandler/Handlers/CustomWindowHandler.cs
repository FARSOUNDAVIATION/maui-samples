﻿using Microsoft.Maui.Handlers;
using WindowButtonsHandler.Controls;

namespace WindowButtonsHandler.Handlers
{
    /// <summary>
    /// Custom window handler that extends the default WindowHandler
    /// to provide additional functionality for controlling window button visibility.
    /// This handler maps custom properties (IsMinimizable, IsMaximizable) to platform-specific
    /// implementations that can hide/show the native window buttons.
    /// </summary>
    public partial class CustomWindowHandler : WindowHandler
    {
        /// <summary>
        /// Custom property mapper that extends the base WindowHandler mapper
        /// with mappings for our custom window button properties.
        /// This mapper defines how changes to our custom properties trigger
        /// platform-specific updates.
        /// </summary>
        public static IPropertyMapper<ICustomWindow, CustomWindowHandler> CustomMapper =
            new PropertyMapper<ICustomWindow, CustomWindowHandler>(WindowHandler.Mapper)
            {
                // Map the IsMinimizable property to the MapIsMinimizable method
                [nameof(ICustomWindow.IsMinimizable)] = MapIsMinimizable,

                // Map the IsMaximizable property to the MapIsMaximizable method
                [nameof(ICustomWindow.IsMaximizable)] = MapIsMaximizable,
            };

        /// <summary>
        /// Initializes a new instance of the CustomWindowHandler class.
        /// Uses the custom mapper to handle property changes.
        /// </summary>
        public CustomWindowHandler() : base(CustomMapper)
        {
        }

        /// <summary>
        /// Platform-specific implementation for handling IsMinimizable property changes.
        /// This method is implemented in platform-specific partial class files.
        /// </summary>
        /// <param name="handler">The handler instance managing the window</param>
        /// <param name="window">The custom window instance with the changed property</param>
        public static partial void MapIsMinimizable(CustomWindowHandler handler, ICustomWindow window);

        /// <summary>
        /// Platform-specific implementation for handling IsMaximizable property changes.
        /// This method is implemented in platform-specific partial class files.
        /// </summary>
        /// <param name="handler">The handler instance managing the window</param>
        /// <param name="window">The custom window instance with the changed property</param>
        public static partial void MapIsMaximizable(CustomWindowHandler handler, ICustomWindow window);
    }
}