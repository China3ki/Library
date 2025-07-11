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
        protected Form _form = new();
        protected RenderManager _renderManagaer = new();
        protected NotificationManager _notification = new();
        protected FieldType _action;
        abstract public void InitView();
        abstract protected void InitForm();
        abstract protected void HandleValidation();
    }
}
