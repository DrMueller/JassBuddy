using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Mmu.JassBuddy2.Infrastructure.JavaScript.Services;

namespace Mmu.JassBuddy2.Shared.Cameras
{
    public sealed partial class Camera : IAsyncDisposable
    {
        private IJSObjectReference? _module;

        [Parameter]
        public EventCallback<Picture> OnPictureTaken { get; set; }

        private DotNetObjectReference<Camera>? Instance { get; set; }

        [Inject]
        private IJavaScriptLocator JsLocator { get; set; } = default!;

        [Inject]
        private IJSRuntime JsRuntime { get; set; } = default!;

        public async ValueTask DisposeAsync()
        {
            if (_module != null)
            {
                await _module.DisposeAsync();
                _module = null;
            }

            Instance?.Dispose();
        }

        [JSInvokable]
        public async Task ProcessImageAsync(string imageString)
        {
            var imageData = Convert.FromBase64String(imageString.Split(',')[1]);
            await OnPictureTaken.InvokeAsync(new Picture(imageData));
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var jsFilePath = await JsLocator.LocateJsFilePathAsync(this);
                _module ??= await JsRuntime.InvokeAsync<IJSObjectReference>("import", jsFilePath);

                Instance ??= DotNetObjectReference.Create(this);
            }
        }

        private async Task StartCameraAsync()
        {
            await _module!.InvokeVoidAsync("startCamera");
        }

        private async Task TakePictureAsync()
        {
            await _module!.InvokeAsync<string?>("takePicture", Instance);
        }
    }
}