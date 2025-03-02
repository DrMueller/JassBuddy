export function startCamera() {
    const videoElement = document.getElementById("videoElement");
    if (!videoElement) {
        throw new Error("Video element not found.");
    }

    navigator.mediaDevices.getUserMedia({ video: true })
        .then(function(stream) {
            const video = document.getElementById("videoElement");
            video.srcObject = stream;

            video.play();
        })
        .catch(function(err) {
            console.error("Error accessing the camera:", err);
        });
}

export function takePicture(dotnetInstance) {
    let video = document.getElementById("videoElement");
    let canvas = document.getElementById("canvasElement");
    let context = canvas.getContext("2d");

    canvas.width = video.videoWidth;
    canvas.height = video.videoHeight;
    context.drawImage(video, 0, 0, canvas.width, canvas.height);
    const imageData = canvas.toDataURL("image/jpeg", 0.7);

    dotnetInstance.invokeMethodAsync('ProcessImageAsync', imageData);
}