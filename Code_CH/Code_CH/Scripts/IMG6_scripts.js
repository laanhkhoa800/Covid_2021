function ShowImg6(imageUploader6, previewImg6) {
    if (imageUploader6.files && imageUploader6.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImg6).attr('src', e.target.result);
        }
        // doc duong dan cua du lieu
        reader.readAsDataURL(imageUploader6.files[0]);
    }
}