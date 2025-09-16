using Gizmo.UI;
using Gizmo.Web.Api.Models.Models.API.Request.CustomPage;
using Gizmo.Web.Components;
using Microsoft.AspNetCore.Components;

namespace Gizmo.Client.UI.Tournament.Module.Pages
{
    [ModuleGuid("c8b74460-0799-4145-8f09-84471a9ade69")]
    [PageUIModule(Title = "Tournaments", Description = "Tournaments page")]
    [ModuleDisplayOrder(int.MaxValue)]
    [ModuleIcon("https://static/logo.svg")]
    [Route("/tournaments")]
    public partial class CustomPageModule : CustomDOMComponentBase
    {
        [Inject] 
        private IGizmoClient GizmoClient { get; set; } = null!;
        
        [CascadingParameter]
        public Action<bool> SetBackgroundVisible { get; set; } = null!;
        
        private CustomPageModel? Page { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            var pages = await GizmoClient.CustomPagesGetAsync();
        
            Page = pages.FirstOrDefault(p => string.Equals("c8b74460-0799-4145-8f09-84471a9ade69", p.ModuleId.ToString().ToLower(), StringComparison.OrdinalIgnoreCase));
        
            if (Page != null)
            {
                var visible = !Page.IsCustomTemplate;
                SetBackgroundVisible?.Invoke(visible);
            }
        }
        
        public override void Dispose()
        {
            SetBackgroundVisible?.Invoke(true);
            base.Dispose();
        }
    }
}
