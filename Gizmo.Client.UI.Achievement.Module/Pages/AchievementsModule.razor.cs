using System.Reflection;
using System.Text.Json;
using Gizmo.UI;
using Gizmo.Web.Components;
using Microsoft.AspNetCore.Components;

namespace Gizmo.Client.UI.Achievement.Module.Pages
{
    [ModuleGuid("AF614B09-12B6-4F6B-81C5-B61957404CFB")]
    [PageUIModule(Title = "Achievements", Description = "Achievements page")]
    [ModuleDisplayOrder(int.MaxValue)]
    [Route("/achievements")]
    [ModuleIcon("data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMzAiIGhlaWdodD0iMzAiIHZpZXdCb3g9IjAgMCAzMCAzMCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPHBhdGggZD0iTTE1IDEzLjU4MzNDMTUuNzc5MiAxMy41ODMzIDE2LjQ0NjIgMTMuMzA1OSAxNy4wMDEgMTIuNzUxQzE3LjU1NTkgMTIuMTk2MiAxNy44MzMzIDExLjUyOTIgMTcuODMzMyAxMC43NUMxNy44MzMzIDkuOTcwODMgMTcuNTU1OSA5LjMwMzgyIDE3LjAwMSA4Ljc0ODk2QzE2LjQ0NjIgOC4xOTQxIDE1Ljc3OTIgNy45MTY2NyAxNSA3LjkxNjY3QzE0LjIyMDggNy45MTY2NyAxMy41NTM4IDguMTk0MSAxMi45OTkgOC43NDg5NkMxMi40NDQxIDkuMzAzODIgMTIuMTY2NyA5Ljk3MDgzIDEyLjE2NjcgMTAuNzVDMTIuMTY2NyAxMS41MjkyIDEyLjQ0NDEgMTIuMTk2MiAxMi45OTkgMTIuNzUxQzEzLjU1MzggMTMuMzA1OSAxNC4yMjA4IDEzLjU4MzMgMTUgMTMuNTgzM1pNNy45MTY2NyAyNy43NVYyNC45MTY3SDEzLjU4MzNWMjAuNTI1QzEyLjQyNjQgMjAuMjY1MyAxMS4zOTM0IDE5Ljc3NTMgMTAuNDg0NCAxOS4wNTUyQzkuNTc1MzUgMTguMzM1MSA4LjkwODMzIDE3LjQzMTkgOC40ODMzMyAxNi4zNDU4QzYuNzEyNSAxNi4xMzMzIDUuMjMwOSAxNS4zNjAxIDQuMDM4NTQgMTQuMDI2QzIuODQ2MTggMTIuNjkyIDIuMjUgMTEuMTI3OCAyLjI1IDkuMzMzMzNWNy45MTY2N0MyLjI1IDcuMTM3NSAyLjUyNzQzIDYuNDcwNDkgMy4wODIyOSA1LjkxNTYyQzMuNjM3MTUgNS4zNjA3NiA0LjMwNDE3IDUuMDgzMzMgNS4wODMzMyA1LjA4MzMzSDcuOTE2NjdWMi4yNUgyMi4wODMzVjUuMDgzMzNIMjQuOTE2N0MyNS42OTU4IDUuMDgzMzMgMjYuMzYyOCA1LjM2MDc2IDI2LjkxNzcgNS45MTU2MkMyNy40NzI2IDYuNDcwNDkgMjcuNzUgNy4xMzc1IDI3Ljc1IDcuOTE2NjdWOS4zMzMzM0MyNy43NSAxMS4xMjc4IDI3LjE1MzggMTIuNjkyIDI1Ljk2MTUgMTQuMDI2QzI0Ljc2OTEgMTUuMzYwMSAyMy4yODc1IDE2LjEzMzMgMjEuNTE2NyAxNi4zNDU4QzIxLjA5MTcgMTcuNDMxOSAyMC40MjQ3IDE4LjMzNTEgMTkuNTE1NiAxOS4wNTUyQzE4LjYwNjYgMTkuNzc1MyAxNy41NzM2IDIwLjI2NTMgMTYuNDE2NyAyMC41MjVWMjQuOTE2N0gyMi4wODMzVjI3Ljc1SDcuOTE2NjdaTTcuOTE2NjcgMTMuM1Y3LjkxNjY3SDUuMDgzMzNWOS4zMzMzM0M1LjA4MzMzIDEwLjIzMDYgNS4zNDMwNiAxMS4wMzkyIDUuODYyNSAxMS43NTk0QzYuMzgxOTQgMTIuNDc5NSA3LjA2NjY3IDEyLjk5MzEgNy45MTY2NyAxMy4zWk0yMi4wODMzIDEzLjNDMjIuOTMzMyAxMi45OTMxIDIzLjYxODEgMTIuNDc5NSAyNC4xMzc1IDExLjc1OTRDMjQuNjU2OSAxMS4wMzkyIDI0LjkxNjcgMTAuMjMwNiAyNC45MTY3IDkuMzMzMzNWNy45MTY2N0gyMi4wODMzVjEzLjNaIiBmaWxsPSIjRkFGQUZBIi8+Cjwvc3ZnPgo=")]
    public partial class AchievementsModule : CustomDOMComponentBase
    {
        private string Content { get; set; } = string.Empty;

        protected override async Task OnParametersSetAsync()
        {
            var json = await File.ReadAllTextAsync("customPagesConfig.json");
            using var doc = JsonDocument.Parse(json);
            var root = doc.RootElement;
            var content = root.GetProperty("Gizmo.Client.UI.Achievement.Module.dll").GetString();
            Content = content ?? throw new Exception("Achievement content is null");
            
            await base.OnInitializedAsync();
        }
    }
}