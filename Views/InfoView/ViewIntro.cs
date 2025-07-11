using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Views.SingleMenu
{
    internal class ViewIntro : ViewInfo
    {
        public ViewIntro()
        {
            _header = [
            "  _     _ _                          ",
            " | |   (_) |__  _ __ __ _ _ __ _   _ ",
            " | |   | | '_ \\| '__/ _` | '__| | | |",
            " | |___| | |_) | | | (_| | |  | |_| |",
            " |_____|_|_.__/|_|  \\__,_|_|   \\__, |",
            "                               |___/ "
        ];
        }
        /// <summary>
        /// Initializes the introductory sequence by rendering and loading the necessary components.
        /// </summary>
        /// <remarks>This method is typically called at the start of an application or process to set up
        /// the introduction. It ensures that the introductory content is displayed and prepared for further
        /// interaction.</remarks>
        public override void InitInfo()
        {
            RenderHeader();
            _renderManager.RenderBorder();
            Loading();
            Thread.Sleep(300);
            Console.Clear();
        }
    }
}
