using Mmu.JassBuddy2.Components;

namespace Mmu.JassBuddy2.Shell.Initialization
{
    public static class AppInitialization
    {
        public static void Initialize(WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAntiforgery();
            app.UseAuthorization();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();
            app.MapControllers();
        }
    }
}