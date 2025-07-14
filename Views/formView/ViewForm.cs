using FormController;
using Library.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Views.formView
{
    abstract internal class ViewForm
    {
        protected string _sqlConnectionString = "server=localhost;uid=root;database=library";
        protected Form _form = new();
        protected RenderManager _renderManager = new();
        protected NotificationManager _notificationManager = new();
        protected FieldType _action;
        /// <summary>
        /// Initializes the view, preparing it for display or interaction.
        /// </summary>
        /// <remarks>This method must be implemented by derived classes to set up the view's state or
        /// components. It is typically called during the initialization phase of the application or when the view is
        /// being loaded.</remarks>
        abstract public void InitView();
        /// <summary>
        /// Handles the processing of a form in a derived class.
        /// </summary>
        /// <remarks>This method must be implemented in a derived class to define the specific behavior
        /// for handling a form. It is invoked as part of the form processing workflow.</remarks>
        abstract protected void HandleForm();
        /// <summary>
        /// Initializes the form and sets up its components.
        /// </summary>
        /// <remarks>This method is intended to be overridden in a derived class to provide specific
        /// initialization logic for the form. It is called during the form's lifecycle to ensure that all necessary
        /// components and settings are configured before the form is displayed.</remarks>
        abstract protected void InitForm();
        /// <summary>
        /// Performs validation logic and determines whether the operation is valid.
        /// </summary>
        /// <returns><see langword="true"/> if the validation succeeds; otherwise, <see langword="false"/>.</returns>
        abstract protected bool HandleValidation();
    }
}
