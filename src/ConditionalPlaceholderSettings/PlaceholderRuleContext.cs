using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Pipelines.GetPlaceholderRenderings;
using Sitecore.Rules;

namespace ConditionalPlaceholderSettings
{
    public class PlaceholderRuleContext : RuleContext
    {
        public List<Item> AllowedRenderings { get; set; }

        public List<Item> BlockedRenderings { get; set; }

        public Database ContentDatabase { get; set; }

        public DeviceItem Device { get; set; }

        public string FullPlaceholderKey { get; set; }

        public bool HasInitialRenderings { get; set; }

        public bool IsEditable { get; set; }

        public string PlaceholderKey { get; set; }

        public PlaceholderRuleContext(GetPlaceholderRenderingsArgs args)
        {
            AllowedRenderings = new List<Item>();
            BlockedRenderings = new List<Item>();
            IsEditable = true;

            ContentDatabase = args.ContentDatabase;
            FullPlaceholderKey = args.PlaceholderKey;

            PlaceholderKey = FullPlaceholderKey.Split('/').Last();
            HasInitialRenderings = args.PlaceholderRenderings != null && args.PlaceholderRenderings.Count > 0;

            GetDevice(args);
            GetItem(args);
        }

        private void GetDevice(GetPlaceholderRenderingsArgs args)
        {
            Device = Context.Device;
            if (Device == null || Device.Database.Name != ContentDatabase.Name)
            {
                var id = HttpContext.Current.Request.QueryString["dev"];
                Device = args.ContentDatabase.GetItem(id);
            }
        }

        private void GetItem(GetPlaceholderRenderingsArgs args)
        {
            Item = Context.Item;
            if (Item == null)
            {
                var id = HttpContext.Current.Request.QueryString["id"];
                Item = args.ContentDatabase.GetItem(id);
            }
        }
    }
}