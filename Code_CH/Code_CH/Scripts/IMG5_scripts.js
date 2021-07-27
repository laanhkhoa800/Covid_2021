function ShowImg5(imageUploader5, previewImg5) {
    if (imageUploader5.files && imageUploader5.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImg5).attr('src', e.target.result);
        }
        // doc duong dan cua du lieu
        reader.readAsDataURL(imageUploader5.files[0]);
    }
}