function ShowImg4(imageUploader4, previewImg4) {
    if (imageUploader4.files && imageUploader4.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImg4).attr('src', e.target.result);
        }
        // doc duong dan cua dus lieu
        reader.readAsDataURL(imageUploader4.files[0]);
    }
}