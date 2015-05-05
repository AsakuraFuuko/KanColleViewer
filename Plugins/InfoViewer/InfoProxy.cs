using Grabacr07.KanColleWrapper;
using Livet;
using System;
using System.Reactive.Linq;

namespace InfoViewer
{
    public class InfoProxy : NotificationObject
    {
        private string _Url;

        public string Url
        {
            get { return this._Url; }
            set
            {
                if (this._Url != value)
                {
                    this._Url = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        public InfoProxy()
        {
            KanColleClient.Current.Proxy.api_port
                .Subscribe(x => this.Url = x.oRequest.headers["Referer"]);
        }
    }
}