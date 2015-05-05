using Livet;
using System;

namespace InfoViewer
{
    public class InfoViewModel : ViewModel
    {
        private InfoProxy _InfoProxy;

        public InfoProxy InfoProxy
        {
            get
            { return _InfoProxy; }
            set
            {
                if (_InfoProxy == value)
                    return;
                _InfoProxy = value;
                if (_InfoProxy != null)
                {
                    _InfoProxy.PropertyChanged += (sender, e) =>
                    {
                        if (e.PropertyName == "Url")
                        {
                            RaisePropertyChanged(() => LoginUrl);
                            RaisePropertyChanged(() => Token);
                            RaisePropertyChanged(() => StartTime);
                        }
                    };
                }
                RaisePropertyChanged();
            }
        }

        public string LoginUrl
        {
            get
            {
                try
                {
                    Uri uri = new Uri(InfoProxy.Url.Replace("/[[DYNAMIC]]/1", ""));
                    return uri.OriginalString;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public string Token
        {
            get
            {
                try
                {
                    Uri uri = new Uri(InfoProxy.Url.Replace("/[[DYNAMIC]]/1", ""));
                    return Helper.GetQueryString(uri.Query)["api_token"];
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public string StartTime
        {
            get
            {
                try
                {
                    Uri uri = new Uri(InfoProxy.Url.Replace("/[[DYNAMIC]]/1", ""));
                    return Helper.GetQueryString(uri.Query)["api_starttime"];
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}