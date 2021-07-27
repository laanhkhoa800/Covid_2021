function ShowImg3(imageUploader3, previewImg3) {
    if (imageUploader3.files && imageUploader3.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImg3).attr('src', e.target.result);
        }
        // doc duong dan cua du lieu
        reader.readAsDataURL(imageUploader3.files[0]);
    }
}