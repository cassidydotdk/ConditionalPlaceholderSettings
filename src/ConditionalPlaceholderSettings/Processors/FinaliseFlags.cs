using Sitecore.Pipelines.GetPlaceholderRenderings;

namespace ConditionalPlaceholderSettings.Processors
{
    public class FinaliseFlags : ProcessorBase
    {
        public override void Process(GetPlaceholderRenderingsArgs args, PlaceholderRuleContext ruleContext)
        {
            if (!ruleContext.IsEditable)
            {
                return;
            }

            // All originally present renderings have been removed, so make placeholder un-editable.
            if (ruleContext.HasInitialRenderings && args.PlaceholderRenderings.Count == 0)
            {
                args.HasPlaceholderSettings = false;
                args.PlaceholderRenderings = null;
            }

            // No renderings / placeholder settings were present, but rules have added some, so make placeholder editable.
            if (!ruleContext.HasInitialRenderings && args.PlaceholderRenderings != null && args.PlaceholderRenderings.Count > 0)
            {
                args.HasPlaceholderSettings = true;
                args.Options.ShowTree = false;
            }
        }
    }
}