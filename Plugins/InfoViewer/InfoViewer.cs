using Grabacr07.KanColleViewer.Composition;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoViewer
{
    [Export(typeof(IToolPlugin))]
    [ExportMetadata("Title", "InfoViewer")]
    [ExportMetadata("Description", "Token等显示")]
    [ExportMetadata("Version", "1.0.0")]
    [ExportMetadata("Author", "@AsakuraFuuko")]
    public class EventMapHpViewer : IToolPlugin
    {
        private readonly InfoViewModel _vm = new InfoViewModel
        {
            InfoProxy = new InfoProxy()
        };

        public object GetToolView()
        {
            return new InfoView { DataContext = _vm };
        }

        public string ToolName
        {
            get { return "Info"; }
        }

        public object GetSettingsView()
        {
            return null;
        }
    }
}