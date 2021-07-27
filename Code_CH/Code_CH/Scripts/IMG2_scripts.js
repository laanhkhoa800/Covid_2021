function ShowImg2(imageUploader2, previewImg2) {
    if (imageUploader2.files && imageUploader2.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImg2).attr('src', e.target.result);
        }
        // doc duong dan cua du lieu
        reader.readAsDataURL(imageUploader2.files[0]);
    }
}